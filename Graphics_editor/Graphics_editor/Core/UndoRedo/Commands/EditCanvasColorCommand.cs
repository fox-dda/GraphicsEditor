using System;
using System.Drawing;
using GraphicsEditor.Interfaces;

namespace GraphicsEditor.Core.UndoRedo.Commands
{
    /// <summary>
    ///     Команда изменения цвета канваса
    /// </summary>
    [Serializable]
    public class EditCanvasColorCommand : ICommand
    {
        /// <summary>
        ///     Бекап цвета
        /// </summary>
        private Color _backUpCanvasColor;

        /// <summary>
        ///     Новый цвет
        /// </summary>
        private Color _newColor;

        /// <summary>
        ///     Конструктор команды
        /// </summary>
        /// <param name="editedPaintingParameters">Параметры изменяемого канваса</param>
        /// <param name="newColor">Новый цвет канваса</param>
        public EditCanvasColorCommand(IPaintingParameters editedPaintingParameters, Color newColor)
        {
            TargetPaintingParameters = editedPaintingParameters;
            _backUpCanvasColor = editedPaintingParameters.CanvasColor;
            _newColor = newColor;
        }

        /// <summary>
        ///     Параметры изменяемого канваса
        /// </summary>
        public IPaintingParameters TargetPaintingParameters { get; set; }

        /// <summary>
        ///     Выполнить команду
        /// </summary>
        public void Do()
        {
            TargetPaintingParameters.CanvasColor = _newColor;
        }

        /// <summary>
        ///     Откатить команду
        /// </summary>
        public void Undo()
        {
            TargetPaintingParameters.CanvasColor = _backUpCanvasColor;
        }
    }
}