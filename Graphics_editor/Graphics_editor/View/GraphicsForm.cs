﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using GraphicsEditor.Enums;
using GraphicsEditor.Interfaces;
using GraphicsEditor.View;
using SDK;
using SDK.Interfaces;
using StructureMap;

namespace GraphicsEditor
{
    public partial class MainForm : Form
    {
        /// <summary>
        ///     Буффер обмена
        /// </summary>
        private IDraftClipboard _buffer;

        /// <summary>
        ///     Менеджер рисования
        /// </summary>
        private IDrawManager _drawManager;

        /// <summary>
        ///     Панель выделенных объектов
        /// </summary>
        private readonly SelectionPanel _highlightPanel;

        /// <summary>
        ///     Ядро рисования
        /// </summary>
        private Graphics _paintCore;

        public MainForm(IContainer container)
        {
            InitializeComponent();

            foreach (Control control in Controls)
                typeof(Control).InvokeMember("DoubleBuffered",
                    BindingFlags.SetProperty |
                    BindingFlags.Instance |
                    BindingFlags.NonPublic,
                    null, control, new object[] { true });

            var btm = new Bitmap(mainPictureBox.Width, mainPictureBox.Height);
            mainPictureBox.Image = btm;
            _paintCore = Graphics.FromImage(btm);

            var draftFactory = container.With(container)
                .GetInstance<IDraftFactory>();
            var buffer = container
                .With(draftFactory)
                .With(new List<IDrawable>())
                .GetInstance<IDraftClipboard>();
            var penSettings = container
                .With(Color.Black)
                .With((float)1)
                .GetInstance<IPenSettings>();
            var paintingParameters = container.With(penSettings)
                .GetInstance<IPaintingParameters>();
            var drawerFacade = container.With(container)
                .GetInstance<IDrawerFacade>();
            var undoRedoStack = container.GetInstance<IUndoRedoStack>();
            var strategyDeterminer = container.With(container)
                .GetInstance<IStrategyDeterminer>();
            var painterState = container.With(strategyDeterminer)
                .GetInstance<IPainterState>();
            var draftStorage = container.GetInstance<IDraftStorage>();
            var commandFactory = container.GetInstance<ICommandFactory>();
            var selector = container.GetInstance<ISelector>();
            var serealizer = container.GetInstance<IDraftSerealizer>();
            var storageManager = container
                .With(draftStorage)
                .With(commandFactory)
                .With(undoRedoStack)
                .GetInstance<IStorageManager>();
            var draftPainter = container.With(_paintCore).With(paintingParameters).With(storageManager)
                .With(draftFactory).With(drawerFacade).GetInstance<IDraftPainter>();
            var drawManager = container
                .With(_paintCore)
                .With(draftPainter)
                .With(storageManager)
                .With(painterState)
                .With(selector)
                .With(undoRedoStack)
                .With(serealizer)
                .GetInstance<IDrawManager>();

            Setup(buffer, drawManager);

            _highlightPanel = new SelectionPanel(draftFactory)
            {
                StorageManager = _drawManager.DraftStorageManager
            };

            Controls.Add(_highlightPanel);
            rightGroupBox.Controls.Add(_highlightPanel);
            _highlightPanel.Location = new Point(3, 2);
            _highlightPanel.ModelChanged += _drawManager.DraftPainter.RefreshCanvas;
            _highlightPanel.ModelChanged += mainPictureBox.Invalidate;
            var figureToolBox = new FigureToolBox(_drawManager.DraftPainter.State);
            leftGroupBox.Controls.Add(figureToolBox);
            figureToolBox.Location = new Point(6, 12);
        }

        /// <summary>
        ///     Внедрение зависимостей через метод.
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="drawManager"></param>
        public void Setup(IDraftClipboard buffer, IDrawManager drawManager)
        {
            _buffer = buffer;
            _drawManager = drawManager;
        }

        private void mainPictureBox_MouseMove_1(object sender,
            MouseEventArgs e)
        {
            _drawManager.MouseProcess(e, MouseAction.Move);
            mainPictureBox.Invalidate();
        }

        private void mainPictureBox_MouseUp_1(object sender, MouseEventArgs e)
        {
            _drawManager.MouseProcess(e, MouseAction.Up);
            RefreshView();
            mainPictureBox.Invalidate();
        }

        private void mainPictureBox_MouseDown_1(object sender, MouseEventArgs e)
        {
            _drawManager.MouseProcess(e, MouseAction.Down);
            RefreshView();
            mainPictureBox.Invalidate();
        }

        private void clearCanvasButton_Click(object sender, EventArgs e)
        {
            canvasColorpanel.BackColor = Color.White;
            _drawManager.DraftPainter.ClearCanvas();
            RefreshView();
            mainPictureBox.Invalidate();
        }

        private void thicknessNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            RefreshPen();
        }

        private void penStrokeWidthNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            RefreshPen();
        }

        private void RefreshPen()
        {
            _drawManager.DraftPainter.Parameters.GPen =
                new PenSettings(_drawManager.DraftPainter.Parameters.GPen.Color,
                    (float)thicknessNumericUpDown.Value)
                {
                    DashPattern = _drawManager.DraftPainter.Parameters.GPen.DashPattern
                };

            if (penStrokeWidthNumericUpDown.Value > 0)
                _drawManager.DraftPainter.Parameters.DashPattern = new[]
                {
                    (float)penStrokeWidthNumericUpDown.Value,
                    (float)penStrokeWidthNumericUpDown.Value
                };
            else
                _drawManager.DraftPainter.Parameters.DashPattern = null;
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (mainPictureBox.Width < 1 && mainPictureBox.Height < 1)
                return;

            var btm = new Bitmap(mainPictureBox.Width, mainPictureBox.Height);
            mainPictureBox.Image = btm;
            _paintCore = Graphics.FromImage(btm);
            _drawManager.DraftPainter.Painter = _paintCore;
            _drawManager.DraftPainter.RefreshCanvas();
            mainPictureBox.Invalidate();
        }

        private void selectMouseButton_Click(object sender, EventArgs e)
        {
            _drawManager.State.DrawAction = DrawAction.Highlight;
        }

        /// <summary>
        ///     Обновить настройки пера
        /// </summary>
        private void RefreshView()
        {
            _highlightPanel.Drafts =
                _drawManager.DraftStorageManager.HighlightDraftStorage;
            CommandStackView.Items.Clear();
            foreach (var command in _drawManager.CommandStack.UndoStack.ToArray().Reverse())
                CommandStackView.Items.Add(
                    command.ToString().Split('.').Last());

            if (CommandStackView.Items.Count > 0)
            {
                CommandStackView.Items[CommandStackView.Items.Count - 1] =
                    "-->" + CommandStackView.Items[CommandStackView.Items.Count - 1];
                CommandStackView.TopIndex = CommandStackView.Items.Count - 1;
            }

            foreach (var command in _drawManager.CommandStack.RedoStack.ToArray())
                CommandStackView.Items.Add(
                    command.ToString().Split('.').Last());
            mainPictureBox.Invalidate();
        }

        private void MainForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            _drawManager.KeyProcess(e, _buffer);
            _drawManager.DraftPainter.RefreshCanvas();
            RefreshView();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveProject();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenProject();
        }

        private void penColorPanel_Click(object sender, EventArgs e)
        {
            var colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                _drawManager.DraftPainter.Parameters.GPen = new PenSettings(
                    colorDialog.Color,
                    _drawManager.DraftPainter.Parameters.GPen.Width)
                {
                    DashPattern = _drawManager.DraftPainter.Parameters.GPen.DashPattern
                };
                penColorpanel.BackColor = colorDialog.Color;
            }

            RefreshPen();
        }

        private void canvasColorPanel_Click(object sender, EventArgs e)
        {
            var colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                _drawManager.EditCanvasColor(colorDialog.Color);
                canvasColorpanel.BackColor = colorDialog.Color;
            }

            mainPictureBox.Invalidate();
            RefreshView();
        }

        private void brushColorPanel_Click(object sender, EventArgs e)
        {
            var colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            _drawManager.DraftPainter.Parameters.BrushColor = colorDialog.Color;
            brushColorpanel.BackColor = colorDialog.Color;
        }

        private void exportToBmpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var saveDialog = new SaveFileDialog();
            _drawManager.DraftStorageManager.DiscardAll();
            _drawManager.DraftPainter.RefreshCanvas();
            mainPictureBox.Invalidate();

            if (saveDialog.ShowDialog() == DialogResult.OK) mainPictureBox.Image.Save(saveDialog.FileName + ".bmp");
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _drawManager.Copy(_buffer);
            RefreshView();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _drawManager.Cut(_buffer);
            RefreshView();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _drawManager.Remove();
            RefreshView();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _drawManager.Paste(_buffer);
            RefreshView();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _drawManager.Undo();
            RefreshView();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _drawManager.Redo();
            RefreshView();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            var result = CreateCloseProjectDialog(
                "Save project?");

            switch (result)
            {
                case DialogResult.Yes:
                    SaveProject();
                    break;
                case DialogResult.Cancel:
                    e.Cancel = true;
                    break;
            }
        }

        private void newProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = CreateCloseProjectDialog(
                "You want to create a new project. Save current project ?");

            switch (result)
            {
                case DialogResult.Yes:
                    SaveProject();
                    _drawManager.CreateNewProject();
                    break;
                case DialogResult.No:
                    _drawManager.CreateNewProject();
                    break;
            }

            mainPictureBox.Invalidate();
        }

        /// <summary>
        ///     Сохранение проекта
        /// </summary>
        private void SaveProject()
        {
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "GraphicsEditor Project|*.proj";
            if (saveFileDialog.ShowDialog() != DialogResult.Cancel)
                using (var stream = saveFileDialog.OpenFile())
                {
                    _drawManager.Serialize(stream);
                }
        }

        /// <summary>
        ///     Открытие проекта
        /// </summary>
        private void OpenProject()
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "GraphicsEditor Project|*.proj";
            if (openFileDialog.ShowDialog() != DialogResult.Cancel)
                using (var stream = openFileDialog.OpenFile())
                {
                    _drawManager.Deserialize(stream);
                }

            mainPictureBox.Invalidate();
        }

        /// <summary>
        ///     Создать диалог закрытия проекта
        /// </summary>
        /// <param name="message">Сообщение</param>
        /// <returns>Результат диалога</returns>
        private DialogResult CreateCloseProjectDialog(string message)
        {
            var result = MessageBox.Show(
                message,
                Text,
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1);
            return result;
        }
    }
}