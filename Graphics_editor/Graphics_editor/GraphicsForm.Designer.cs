﻿namespace GraphicsEditor
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mainPictureBox = new System.Windows.Forms.PictureBox();
            this.drawGroupBox = new System.Windows.Forms.GroupBox();
            this.polygonButton = new System.Windows.Forms.Button();
            this.ellipseButton = new System.Windows.Forms.Button();
            this.triangleButton = new System.Windows.Forms.Button();
            this.lineButton = new System.Windows.Forms.Button();
            this.circleButton = new System.Windows.Forms.Button();
            this.polylineButton = new System.Windows.Forms.Button();
            this.selectMouseButton = new System.Windows.Forms.Button();
            this.colorGroupBox = new System.Windows.Forms.GroupBox();
            this.brushColorpanel = new System.Windows.Forms.Panel();
            this.canvasColorpanel = new System.Windows.Forms.Panel();
            this.penColorpanel = new System.Windows.Forms.Panel();
            this.selectBrushColorButton = new System.Windows.Forms.Button();
            this.selectCanvasColorButton = new System.Windows.Forms.Button();
            this.selectPenColorButton = new System.Windows.Forms.Button();
            this.clearCanvasButton = new System.Windows.Forms.Button();
            this.penStyleGroupBox = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.penStrokeWidthNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.widthLabel = new System.Windows.Forms.Label();
            this.thicknessNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.SelectionGroupBox = new System.Windows.Forms.GroupBox();
            this.lassoSelectionButton = new System.Windows.Forms.Button();
            this.discardButton = new System.Windows.Forms.Button();
            this.selectedObjectGroupBox = new System.Windows.Forms.GroupBox();
            this.designSelectedGroupBox = new System.Windows.Forms.GroupBox();
            this.selectedBrushPanel = new System.Windows.Forms.Panel();
            this.selectedObjectBrushLabel = new System.Windows.Forms.Label();
            this.selectedColorPanel = new System.Windows.Forms.Panel();
            this.colorSelectedLabel = new System.Windows.Forms.Label();
            this.selectedStrokeLabel = new System.Windows.Forms.Label();
            this.selectedStrokeNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.selectedWidthLabel = new System.Windows.Forms.Label();
            this.selectedWidthNnumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.locationGroupBox = new System.Windows.Forms.GroupBox();
            this.StartPLabel = new System.Windows.Forms.Label();
            this.EndPLabel = new System.Windows.Forms.Label();
            this.typeLabel = new System.Windows.Forms.Label();
            this.objectLabel = new System.Windows.Forms.Label();
            this.canvasGroupBox = new System.Windows.Forms.GroupBox();
            this.leftGroupBox = new System.Windows.Forms.GroupBox();
            this.rightGroupBox = new System.Windows.Forms.GroupBox();
            this.selectObjectSPXMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.selectObjectSPYMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.selectObjectEPXMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.selectObjectEPYMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.sSPXLabel = new System.Windows.Forms.Label();
            this.sSPYLabel = new System.Windows.Forms.Label();
            this.sEPXLabel = new System.Windows.Forms.Label();
            this.sEPYLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.mainPictureBox)).BeginInit();
            this.drawGroupBox.SuspendLayout();
            this.colorGroupBox.SuspendLayout();
            this.penStyleGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.penStrokeWidthNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.thicknessNumericUpDown)).BeginInit();
            this.SelectionGroupBox.SuspendLayout();
            this.selectedObjectGroupBox.SuspendLayout();
            this.designSelectedGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.selectedStrokeNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectedWidthNnumericUpDown)).BeginInit();
            this.locationGroupBox.SuspendLayout();
            this.canvasGroupBox.SuspendLayout();
            this.leftGroupBox.SuspendLayout();
            this.rightGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPictureBox
            // 
            this.mainPictureBox.BackColor = System.Drawing.SystemColors.Window;
            this.mainPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("mainPictureBox.Image")));
            this.mainPictureBox.Location = new System.Drawing.Point(151, 12);
            this.mainPictureBox.Name = "mainPictureBox";
            this.mainPictureBox.Size = new System.Drawing.Size(715, 534);
            this.mainPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.mainPictureBox.TabIndex = 0;
            this.mainPictureBox.TabStop = false;
            this.mainPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mainPictureBox_MouseDown);
            this.mainPictureBox.MouseLeave += new System.EventHandler(this.mainPictureBox_MouseLeave);
            this.mainPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mainPictureBox_MouseMove);
            this.mainPictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mainPictureBox_MouseUp);
            // 
            // drawGroupBox
            // 
            this.drawGroupBox.Controls.Add(this.polygonButton);
            this.drawGroupBox.Controls.Add(this.ellipseButton);
            this.drawGroupBox.Controls.Add(this.triangleButton);
            this.drawGroupBox.Controls.Add(this.lineButton);
            this.drawGroupBox.Controls.Add(this.circleButton);
            this.drawGroupBox.Controls.Add(this.polylineButton);
            this.drawGroupBox.Location = new System.Drawing.Point(6, 12);
            this.drawGroupBox.Name = "drawGroupBox";
            this.drawGroupBox.Size = new System.Drawing.Size(133, 196);
            this.drawGroupBox.TabIndex = 1;
            this.drawGroupBox.TabStop = false;
            this.drawGroupBox.Text = "Draw";
            // 
            // polygonButton
            // 
            this.polygonButton.Location = new System.Drawing.Point(13, 164);
            this.polygonButton.Name = "polygonButton";
            this.polygonButton.Size = new System.Drawing.Size(75, 23);
            this.polygonButton.TabIndex = 7;
            this.polygonButton.Text = "Polygon";
            this.polygonButton.UseVisualStyleBackColor = true;
            this.polygonButton.Click += new System.EventHandler(this.polygonButton_Click);
            // 
            // ellipseButton
            // 
            this.ellipseButton.Location = new System.Drawing.Point(13, 135);
            this.ellipseButton.Name = "ellipseButton";
            this.ellipseButton.Size = new System.Drawing.Size(75, 23);
            this.ellipseButton.TabIndex = 4;
            this.ellipseButton.Text = "Ellipse";
            this.ellipseButton.UseVisualStyleBackColor = true;
            this.ellipseButton.Click += new System.EventHandler(this.ellipseButton_Click);
            // 
            // triangleButton
            // 
            this.triangleButton.Location = new System.Drawing.Point(13, 77);
            this.triangleButton.Name = "triangleButton";
            this.triangleButton.Size = new System.Drawing.Size(75, 23);
            this.triangleButton.TabIndex = 5;
            this.triangleButton.Text = "Triangle";
            this.triangleButton.UseVisualStyleBackColor = true;
            this.triangleButton.Click += new System.EventHandler(this.triangleButton_Click);
            // 
            // lineButton
            // 
            this.lineButton.Location = new System.Drawing.Point(13, 19);
            this.lineButton.Name = "lineButton";
            this.lineButton.Size = new System.Drawing.Size(75, 23);
            this.lineButton.TabIndex = 2;
            this.lineButton.Text = "Line";
            this.lineButton.UseVisualStyleBackColor = true;
            this.lineButton.Click += new System.EventHandler(this.lineButton_Click);
            // 
            // circleButton
            // 
            this.circleButton.Location = new System.Drawing.Point(13, 106);
            this.circleButton.Name = "circleButton";
            this.circleButton.Size = new System.Drawing.Size(75, 23);
            this.circleButton.TabIndex = 4;
            this.circleButton.Text = "Circle";
            this.circleButton.UseVisualStyleBackColor = true;
            this.circleButton.Click += new System.EventHandler(this.circleButton_Click);
            // 
            // polylineButton
            // 
            this.polylineButton.Location = new System.Drawing.Point(13, 48);
            this.polylineButton.Name = "polylineButton";
            this.polylineButton.Size = new System.Drawing.Size(75, 23);
            this.polylineButton.TabIndex = 3;
            this.polylineButton.Text = "Polyline";
            this.polylineButton.UseVisualStyleBackColor = true;
            this.polylineButton.Click += new System.EventHandler(this.polylineButton_Click);
            // 
            // selectMouseButton
            // 
            this.selectMouseButton.Location = new System.Drawing.Point(13, 19);
            this.selectMouseButton.Name = "selectMouseButton";
            this.selectMouseButton.Size = new System.Drawing.Size(75, 23);
            this.selectMouseButton.TabIndex = 6;
            this.selectMouseButton.Text = "Select";
            this.selectMouseButton.UseVisualStyleBackColor = true;
            this.selectMouseButton.Click += new System.EventHandler(this.selectMouseButton_Click);
            // 
            // colorGroupBox
            // 
            this.colorGroupBox.Controls.Add(this.brushColorpanel);
            this.colorGroupBox.Controls.Add(this.canvasColorpanel);
            this.colorGroupBox.Controls.Add(this.penColorpanel);
            this.colorGroupBox.Controls.Add(this.selectBrushColorButton);
            this.colorGroupBox.Controls.Add(this.selectCanvasColorButton);
            this.colorGroupBox.Controls.Add(this.selectPenColorButton);
            this.colorGroupBox.Location = new System.Drawing.Point(6, 300);
            this.colorGroupBox.Name = "colorGroupBox";
            this.colorGroupBox.Size = new System.Drawing.Size(133, 106);
            this.colorGroupBox.TabIndex = 2;
            this.colorGroupBox.TabStop = false;
            this.colorGroupBox.Text = "Color";
            // 
            // brushColorpanel
            // 
            this.brushColorpanel.BackColor = System.Drawing.Color.White;
            this.brushColorpanel.Location = new System.Drawing.Point(94, 77);
            this.brushColorpanel.Name = "brushColorpanel";
            this.brushColorpanel.Size = new System.Drawing.Size(23, 23);
            this.brushColorpanel.TabIndex = 9;
            // 
            // canvasColorpanel
            // 
            this.canvasColorpanel.BackColor = System.Drawing.Color.White;
            this.canvasColorpanel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.canvasColorpanel.Location = new System.Drawing.Point(94, 48);
            this.canvasColorpanel.Name = "canvasColorpanel";
            this.canvasColorpanel.Size = new System.Drawing.Size(23, 23);
            this.canvasColorpanel.TabIndex = 8;
            // 
            // penColorpanel
            // 
            this.penColorpanel.BackColor = System.Drawing.Color.Black;
            this.penColorpanel.Location = new System.Drawing.Point(94, 19);
            this.penColorpanel.Name = "penColorpanel";
            this.penColorpanel.Size = new System.Drawing.Size(23, 23);
            this.penColorpanel.TabIndex = 7;
            // 
            // selectBrushColorButton
            // 
            this.selectBrushColorButton.Location = new System.Drawing.Point(13, 77);
            this.selectBrushColorButton.Name = "selectBrushColorButton";
            this.selectBrushColorButton.Size = new System.Drawing.Size(75, 23);
            this.selectBrushColorButton.TabIndex = 6;
            this.selectBrushColorButton.Text = "Brush";
            this.selectBrushColorButton.UseVisualStyleBackColor = true;
            this.selectBrushColorButton.Click += new System.EventHandler(this.selectBrushColorButton_Click);
            // 
            // selectCanvasColorButton
            // 
            this.selectCanvasColorButton.Location = new System.Drawing.Point(13, 48);
            this.selectCanvasColorButton.Name = "selectCanvasColorButton";
            this.selectCanvasColorButton.Size = new System.Drawing.Size(75, 23);
            this.selectCanvasColorButton.TabIndex = 3;
            this.selectCanvasColorButton.Text = "Canvas";
            this.selectCanvasColorButton.UseVisualStyleBackColor = true;
            this.selectCanvasColorButton.Click += new System.EventHandler(this.selectCanvasColorButton_Click);
            // 
            // selectPenColorButton
            // 
            this.selectPenColorButton.Location = new System.Drawing.Point(13, 19);
            this.selectPenColorButton.Name = "selectPenColorButton";
            this.selectPenColorButton.Size = new System.Drawing.Size(75, 23);
            this.selectPenColorButton.TabIndex = 3;
            this.selectPenColorButton.Text = "Pen";
            this.selectPenColorButton.UseVisualStyleBackColor = true;
            this.selectPenColorButton.Click += new System.EventHandler(this.selectColorButton_Click);
            // 
            // clearCanvasButton
            // 
            this.clearCanvasButton.Location = new System.Drawing.Point(13, 19);
            this.clearCanvasButton.Name = "clearCanvasButton";
            this.clearCanvasButton.Size = new System.Drawing.Size(75, 23);
            this.clearCanvasButton.TabIndex = 3;
            this.clearCanvasButton.Text = "Clear";
            this.clearCanvasButton.UseVisualStyleBackColor = true;
            this.clearCanvasButton.Click += new System.EventHandler(this.clearCanvasButton_Click);
            // 
            // penStyleGroupBox
            // 
            this.penStyleGroupBox.Controls.Add(this.label1);
            this.penStyleGroupBox.Controls.Add(this.penStrokeWidthNumericUpDown);
            this.penStyleGroupBox.Controls.Add(this.widthLabel);
            this.penStyleGroupBox.Controls.Add(this.thicknessNumericUpDown);
            this.penStyleGroupBox.Location = new System.Drawing.Point(6, 214);
            this.penStyleGroupBox.Name = "penStyleGroupBox";
            this.penStyleGroupBox.Size = new System.Drawing.Size(133, 80);
            this.penStyleGroupBox.TabIndex = 5;
            this.penStyleGroupBox.TabStop = false;
            this.penStyleGroupBox.Text = "Pen style";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Stroke";
            // 
            // penStrokeWidthNumericUpDown
            // 
            this.penStrokeWidthNumericUpDown.Location = new System.Drawing.Point(55, 45);
            this.penStrokeWidthNumericUpDown.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.penStrokeWidthNumericUpDown.Name = "penStrokeWidthNumericUpDown";
            this.penStrokeWidthNumericUpDown.Size = new System.Drawing.Size(33, 20);
            this.penStrokeWidthNumericUpDown.TabIndex = 7;
            this.penStrokeWidthNumericUpDown.ValueChanged += new System.EventHandler(this.penStrokeWidthNumericUpDown_ValueChanged);
            // 
            // widthLabel
            // 
            this.widthLabel.AutoSize = true;
            this.widthLabel.Location = new System.Drawing.Point(10, 21);
            this.widthLabel.Name = "widthLabel";
            this.widthLabel.Size = new System.Drawing.Size(35, 13);
            this.widthLabel.TabIndex = 7;
            this.widthLabel.Text = "Width";
            // 
            // thicknessNumericUpDown
            // 
            this.thicknessNumericUpDown.Location = new System.Drawing.Point(55, 19);
            this.thicknessNumericUpDown.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.thicknessNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.thicknessNumericUpDown.Name = "thicknessNumericUpDown";
            this.thicknessNumericUpDown.Size = new System.Drawing.Size(33, 20);
            this.thicknessNumericUpDown.TabIndex = 6;
            this.thicknessNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.thicknessNumericUpDown.ValueChanged += new System.EventHandler(this.thicknessNumericUpDown_ValueChanged);
            // 
            // SelectionGroupBox
            // 
            this.SelectionGroupBox.Controls.Add(this.lassoSelectionButton);
            this.SelectionGroupBox.Controls.Add(this.discardButton);
            this.SelectionGroupBox.Controls.Add(this.selectMouseButton);
            this.SelectionGroupBox.Location = new System.Drawing.Point(6, 268);
            this.SelectionGroupBox.Name = "SelectionGroupBox";
            this.SelectionGroupBox.Size = new System.Drawing.Size(167, 110);
            this.SelectionGroupBox.TabIndex = 6;
            this.SelectionGroupBox.TabStop = false;
            this.SelectionGroupBox.Text = "Selection";
            // 
            // lassoSelectionButton
            // 
            this.lassoSelectionButton.Location = new System.Drawing.Point(13, 48);
            this.lassoSelectionButton.Name = "lassoSelectionButton";
            this.lassoSelectionButton.Size = new System.Drawing.Size(75, 23);
            this.lassoSelectionButton.TabIndex = 7;
            this.lassoSelectionButton.Text = "Lasso";
            this.lassoSelectionButton.UseVisualStyleBackColor = true;
            this.lassoSelectionButton.Click += new System.EventHandler(this.lassoSelectionButton_Click);
            // 
            // discardButton
            // 
            this.discardButton.Location = new System.Drawing.Point(13, 76);
            this.discardButton.Name = "discardButton";
            this.discardButton.Size = new System.Drawing.Size(75, 23);
            this.discardButton.TabIndex = 7;
            this.discardButton.Text = "Discard all";
            this.discardButton.UseVisualStyleBackColor = true;
            this.discardButton.Click += new System.EventHandler(this.discardButton_Click);
            // 
            // selectedObjectGroupBox
            // 
            this.selectedObjectGroupBox.Controls.Add(this.designSelectedGroupBox);
            this.selectedObjectGroupBox.Controls.Add(this.SelectionGroupBox);
            this.selectedObjectGroupBox.Controls.Add(this.locationGroupBox);
            this.selectedObjectGroupBox.Controls.Add(this.typeLabel);
            this.selectedObjectGroupBox.Controls.Add(this.objectLabel);
            this.selectedObjectGroupBox.Location = new System.Drawing.Point(6, 12);
            this.selectedObjectGroupBox.Name = "selectedObjectGroupBox";
            this.selectedObjectGroupBox.Size = new System.Drawing.Size(179, 388);
            this.selectedObjectGroupBox.TabIndex = 7;
            this.selectedObjectGroupBox.TabStop = false;
            this.selectedObjectGroupBox.Text = "Selected object";
            // 
            // designSelectedGroupBox
            // 
            this.designSelectedGroupBox.Controls.Add(this.selectedBrushPanel);
            this.designSelectedGroupBox.Controls.Add(this.selectedObjectBrushLabel);
            this.designSelectedGroupBox.Controls.Add(this.selectedColorPanel);
            this.designSelectedGroupBox.Controls.Add(this.colorSelectedLabel);
            this.designSelectedGroupBox.Controls.Add(this.selectedStrokeLabel);
            this.designSelectedGroupBox.Controls.Add(this.selectedStrokeNumericUpDown);
            this.designSelectedGroupBox.Controls.Add(this.selectedWidthLabel);
            this.designSelectedGroupBox.Controls.Add(this.selectedWidthNnumericUpDown);
            this.designSelectedGroupBox.Location = new System.Drawing.Point(8, 128);
            this.designSelectedGroupBox.Name = "designSelectedGroupBox";
            this.designSelectedGroupBox.Size = new System.Drawing.Size(165, 134);
            this.designSelectedGroupBox.TabIndex = 7;
            this.designSelectedGroupBox.TabStop = false;
            this.designSelectedGroupBox.Text = "Design";
            // 
            // selectedBrushPanel
            // 
            this.selectedBrushPanel.BackColor = System.Drawing.Color.White;
            this.selectedBrushPanel.ForeColor = System.Drawing.Color.White;
            this.selectedBrushPanel.Location = new System.Drawing.Point(55, 95);
            this.selectedBrushPanel.Name = "selectedBrushPanel";
            this.selectedBrushPanel.Size = new System.Drawing.Size(23, 23);
            this.selectedBrushPanel.TabIndex = 11;
            // 
            // selectedObjectBrushLabel
            // 
            this.selectedObjectBrushLabel.AutoSize = true;
            this.selectedObjectBrushLabel.Location = new System.Drawing.Point(10, 100);
            this.selectedObjectBrushLabel.Name = "selectedObjectBrushLabel";
            this.selectedObjectBrushLabel.Size = new System.Drawing.Size(34, 13);
            this.selectedObjectBrushLabel.TabIndex = 10;
            this.selectedObjectBrushLabel.Text = "Brush";
            // 
            // selectedColorPanel
            // 
            this.selectedColorPanel.BackColor = System.Drawing.Color.White;
            this.selectedColorPanel.ForeColor = System.Drawing.SystemColors.Control;
            this.selectedColorPanel.Location = new System.Drawing.Point(55, 71);
            this.selectedColorPanel.Name = "selectedColorPanel";
            this.selectedColorPanel.Size = new System.Drawing.Size(23, 23);
            this.selectedColorPanel.TabIndex = 9;
            // 
            // colorSelectedLabel
            // 
            this.colorSelectedLabel.AutoSize = true;
            this.colorSelectedLabel.Location = new System.Drawing.Point(10, 74);
            this.colorSelectedLabel.Name = "colorSelectedLabel";
            this.colorSelectedLabel.Size = new System.Drawing.Size(31, 13);
            this.colorSelectedLabel.TabIndex = 8;
            this.colorSelectedLabel.Text = "Color";
            // 
            // selectedStrokeLabel
            // 
            this.selectedStrokeLabel.AutoSize = true;
            this.selectedStrokeLabel.Location = new System.Drawing.Point(10, 47);
            this.selectedStrokeLabel.Name = "selectedStrokeLabel";
            this.selectedStrokeLabel.Size = new System.Drawing.Size(38, 13);
            this.selectedStrokeLabel.TabIndex = 6;
            this.selectedStrokeLabel.Text = "Stroke";
            // 
            // selectedStrokeNumericUpDown
            // 
            this.selectedStrokeNumericUpDown.Location = new System.Drawing.Point(55, 45);
            this.selectedStrokeNumericUpDown.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.selectedStrokeNumericUpDown.Name = "selectedStrokeNumericUpDown";
            this.selectedStrokeNumericUpDown.Size = new System.Drawing.Size(33, 20);
            this.selectedStrokeNumericUpDown.TabIndex = 7;
            // 
            // selectedWidthLabel
            // 
            this.selectedWidthLabel.AutoSize = true;
            this.selectedWidthLabel.Location = new System.Drawing.Point(10, 21);
            this.selectedWidthLabel.Name = "selectedWidthLabel";
            this.selectedWidthLabel.Size = new System.Drawing.Size(35, 13);
            this.selectedWidthLabel.TabIndex = 7;
            this.selectedWidthLabel.Text = "Width";
            // 
            // selectedWidthNnumericUpDown
            // 
            this.selectedWidthNnumericUpDown.Location = new System.Drawing.Point(55, 19);
            this.selectedWidthNnumericUpDown.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.selectedWidthNnumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.selectedWidthNnumericUpDown.Name = "selectedWidthNnumericUpDown";
            this.selectedWidthNnumericUpDown.Size = new System.Drawing.Size(33, 20);
            this.selectedWidthNnumericUpDown.TabIndex = 6;
            this.selectedWidthNnumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // locationGroupBox
            // 
            this.locationGroupBox.Controls.Add(this.sEPYLabel);
            this.locationGroupBox.Controls.Add(this.sEPXLabel);
            this.locationGroupBox.Controls.Add(this.sSPYLabel);
            this.locationGroupBox.Controls.Add(this.sSPXLabel);
            this.locationGroupBox.Controls.Add(this.selectObjectEPYMaskedTextBox);
            this.locationGroupBox.Controls.Add(this.selectObjectSPYMaskedTextBox);
            this.locationGroupBox.Controls.Add(this.selectObjectEPXMaskedTextBox);
            this.locationGroupBox.Controls.Add(this.selectObjectSPXMaskedTextBox);
            this.locationGroupBox.Controls.Add(this.StartPLabel);
            this.locationGroupBox.Controls.Add(this.EndPLabel);
            this.locationGroupBox.Location = new System.Drawing.Point(6, 48);
            this.locationGroupBox.Name = "locationGroupBox";
            this.locationGroupBox.Size = new System.Drawing.Size(167, 74);
            this.locationGroupBox.TabIndex = 6;
            this.locationGroupBox.TabStop = false;
            this.locationGroupBox.Text = "Location";
            // 
            // StartPLabel
            // 
            this.StartPLabel.AutoSize = true;
            this.StartPLabel.Location = new System.Drawing.Point(6, 23);
            this.StartPLabel.Name = "StartPLabel";
            this.StartPLabel.Size = new System.Drawing.Size(58, 13);
            this.StartPLabel.TabIndex = 2;
            this.StartPLabel.Text = "Start point:";
            // 
            // EndPLabel
            // 
            this.EndPLabel.AutoSize = true;
            this.EndPLabel.Location = new System.Drawing.Point(6, 47);
            this.EndPLabel.Name = "EndPLabel";
            this.EndPLabel.Size = new System.Drawing.Size(55, 13);
            this.EndPLabel.TabIndex = 3;
            this.EndPLabel.Text = "End point:";
            // 
            // typeLabel
            // 
            this.typeLabel.AutoSize = true;
            this.typeLabel.Location = new System.Drawing.Point(76, 19);
            this.typeLabel.Name = "typeLabel";
            this.typeLabel.Size = new System.Drawing.Size(0, 13);
            this.typeLabel.TabIndex = 1;
            // 
            // objectLabel
            // 
            this.objectLabel.AutoSize = true;
            this.objectLabel.Location = new System.Drawing.Point(12, 19);
            this.objectLabel.Name = "objectLabel";
            this.objectLabel.Size = new System.Drawing.Size(64, 13);
            this.objectLabel.TabIndex = 0;
            this.objectLabel.Text = "Object type:";
            // 
            // canvasGroupBox
            // 
            this.canvasGroupBox.Controls.Add(this.clearCanvasButton);
            this.canvasGroupBox.Location = new System.Drawing.Point(12, 500);
            this.canvasGroupBox.Name = "canvasGroupBox";
            this.canvasGroupBox.Size = new System.Drawing.Size(127, 46);
            this.canvasGroupBox.TabIndex = 8;
            this.canvasGroupBox.TabStop = false;
            this.canvasGroupBox.Text = "Canvas";
            // 
            // leftGroupBox
            // 
            this.leftGroupBox.Controls.Add(this.drawGroupBox);
            this.leftGroupBox.Controls.Add(this.canvasGroupBox);
            this.leftGroupBox.Controls.Add(this.penStyleGroupBox);
            this.leftGroupBox.Controls.Add(this.colorGroupBox);
            this.leftGroupBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.leftGroupBox.Location = new System.Drawing.Point(0, 0);
            this.leftGroupBox.Name = "leftGroupBox";
            this.leftGroupBox.Size = new System.Drawing.Size(145, 561);
            this.leftGroupBox.TabIndex = 9;
            this.leftGroupBox.TabStop = false;
            // 
            // rightGroupBox
            // 
            this.rightGroupBox.Controls.Add(this.selectedObjectGroupBox);
            this.rightGroupBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.rightGroupBox.Location = new System.Drawing.Point(861, 0);
            this.rightGroupBox.Name = "rightGroupBox";
            this.rightGroupBox.Size = new System.Drawing.Size(191, 561);
            this.rightGroupBox.TabIndex = 10;
            this.rightGroupBox.TabStop = false;
            // 
            // selectObjectSPXMaskedTextBox
            // 
            this.selectObjectSPXMaskedTextBox.Location = new System.Drawing.Point(76, 19);
            this.selectObjectSPXMaskedTextBox.Mask = "00000";
            this.selectObjectSPXMaskedTextBox.Name = "selectObjectSPXMaskedTextBox";
            this.selectObjectSPXMaskedTextBox.PromptChar = ' ';
            this.selectObjectSPXMaskedTextBox.Size = new System.Drawing.Size(31, 20);
            this.selectObjectSPXMaskedTextBox.TabIndex = 4;
            this.selectObjectSPXMaskedTextBox.ValidatingType = typeof(int);
            // 
            // selectObjectSPYMaskedTextBox
            // 
            this.selectObjectSPYMaskedTextBox.Location = new System.Drawing.Point(126, 19);
            this.selectObjectSPYMaskedTextBox.Mask = "00000";
            this.selectObjectSPYMaskedTextBox.Name = "selectObjectSPYMaskedTextBox";
            this.selectObjectSPYMaskedTextBox.PromptChar = ' ';
            this.selectObjectSPYMaskedTextBox.Size = new System.Drawing.Size(31, 20);
            this.selectObjectSPYMaskedTextBox.TabIndex = 5;
            this.selectObjectSPYMaskedTextBox.ValidatingType = typeof(int);
            // 
            // selectObjectEPXMaskedTextBox
            // 
            this.selectObjectEPXMaskedTextBox.Location = new System.Drawing.Point(126, 44);
            this.selectObjectEPXMaskedTextBox.Mask = "00000";
            this.selectObjectEPXMaskedTextBox.Name = "selectObjectEPXMaskedTextBox";
            this.selectObjectEPXMaskedTextBox.PromptChar = ' ';
            this.selectObjectEPXMaskedTextBox.Size = new System.Drawing.Size(31, 20);
            this.selectObjectEPXMaskedTextBox.TabIndex = 6;
            this.selectObjectEPXMaskedTextBox.ValidatingType = typeof(int);
            // 
            // selectObjectEPYMaskedTextBox
            // 
            this.selectObjectEPYMaskedTextBox.Location = new System.Drawing.Point(76, 44);
            this.selectObjectEPYMaskedTextBox.Mask = "00000";
            this.selectObjectEPYMaskedTextBox.Name = "selectObjectEPYMaskedTextBox";
            this.selectObjectEPYMaskedTextBox.PromptChar = ' ';
            this.selectObjectEPYMaskedTextBox.Size = new System.Drawing.Size(31, 20);
            this.selectObjectEPYMaskedTextBox.TabIndex = 7;
            this.selectObjectEPYMaskedTextBox.ValidatingType = typeof(int);
            // 
            // sSPXLabel
            // 
            this.sSPXLabel.AutoSize = true;
            this.sSPXLabel.Location = new System.Drawing.Point(59, 23);
            this.sSPXLabel.Name = "sSPXLabel";
            this.sSPXLabel.Size = new System.Drawing.Size(17, 13);
            this.sSPXLabel.TabIndex = 8;
            this.sSPXLabel.Text = "X:";
            // 
            // sSPYLabel
            // 
            this.sSPYLabel.AutoSize = true;
            this.sSPYLabel.Location = new System.Drawing.Point(109, 23);
            this.sSPYLabel.Name = "sSPYLabel";
            this.sSPYLabel.Size = new System.Drawing.Size(17, 13);
            this.sSPYLabel.TabIndex = 9;
            this.sSPYLabel.Text = "Y:";
            // 
            // sEPXLabel
            // 
            this.sEPXLabel.AutoSize = true;
            this.sEPXLabel.Location = new System.Drawing.Point(59, 47);
            this.sEPXLabel.Name = "sEPXLabel";
            this.sEPXLabel.Size = new System.Drawing.Size(17, 13);
            this.sEPXLabel.TabIndex = 10;
            this.sEPXLabel.Text = "X:";
            // 
            // sEPYLabel
            // 
            this.sEPYLabel.AutoSize = true;
            this.sEPYLabel.Location = new System.Drawing.Point(109, 47);
            this.sEPYLabel.Name = "sEPYLabel";
            this.sEPYLabel.Size = new System.Drawing.Size(17, 13);
            this.sEPYLabel.TabIndex = 11;
            this.sEPYLabel.Text = "Y:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1052, 561);
            this.Controls.Add(this.rightGroupBox);
            this.Controls.Add(this.leftGroupBox);
            this.Controls.Add(this.mainPictureBox);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(700, 400);
            this.Name = "MainForm";
            this.Text = "Graphics editor [v0.2]";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MainForm_KeyPress);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.mainPictureBox)).EndInit();
            this.drawGroupBox.ResumeLayout(false);
            this.colorGroupBox.ResumeLayout(false);
            this.penStyleGroupBox.ResumeLayout(false);
            this.penStyleGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.penStrokeWidthNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.thicknessNumericUpDown)).EndInit();
            this.SelectionGroupBox.ResumeLayout(false);
            this.selectedObjectGroupBox.ResumeLayout(false);
            this.selectedObjectGroupBox.PerformLayout();
            this.designSelectedGroupBox.ResumeLayout(false);
            this.designSelectedGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.selectedStrokeNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectedWidthNnumericUpDown)).EndInit();
            this.locationGroupBox.ResumeLayout(false);
            this.locationGroupBox.PerformLayout();
            this.canvasGroupBox.ResumeLayout(false);
            this.leftGroupBox.ResumeLayout(false);
            this.rightGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox mainPictureBox;
        private System.Windows.Forms.GroupBox drawGroupBox;
        private System.Windows.Forms.Button lineButton;
        private System.Windows.Forms.Button polylineButton;
        private System.Windows.Forms.Button circleButton;
        private System.Windows.Forms.Button triangleButton;
        private System.Windows.Forms.GroupBox colorGroupBox;
        private System.Windows.Forms.Button selectPenColorButton;
        private System.Windows.Forms.Button selectCanvasColorButton;
        private System.Windows.Forms.Button clearCanvasButton;
        private System.Windows.Forms.Button ellipseButton;
        private System.Windows.Forms.GroupBox penStyleGroupBox;
        private System.Windows.Forms.NumericUpDown thicknessNumericUpDown;
        private System.Windows.Forms.Label widthLabel;
        private System.Windows.Forms.NumericUpDown penStrokeWidthNumericUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button selectBrushColorButton;
        private System.Windows.Forms.Button selectMouseButton;
        private System.Windows.Forms.GroupBox SelectionGroupBox;
        private System.Windows.Forms.Button discardButton;
        private System.Windows.Forms.Button lassoSelectionButton;
        private System.Windows.Forms.Button polygonButton;
        private System.Windows.Forms.Panel brushColorpanel;
        private System.Windows.Forms.Panel canvasColorpanel;
        private System.Windows.Forms.Panel penColorpanel;
        private System.Windows.Forms.GroupBox selectedObjectGroupBox;
        private System.Windows.Forms.Label objectLabel;
        private System.Windows.Forms.Label typeLabel;
        private System.Windows.Forms.Label EndPLabel;
        private System.Windows.Forms.Label StartPLabel;
        private System.Windows.Forms.GroupBox canvasGroupBox;
        private System.Windows.Forms.GroupBox leftGroupBox;
        private System.Windows.Forms.GroupBox rightGroupBox;
        private System.Windows.Forms.GroupBox locationGroupBox;
        private System.Windows.Forms.GroupBox designSelectedGroupBox;
        private System.Windows.Forms.Panel selectedColorPanel;
        private System.Windows.Forms.Label colorSelectedLabel;
        private System.Windows.Forms.Label selectedStrokeLabel;
        private System.Windows.Forms.NumericUpDown selectedStrokeNumericUpDown;
        private System.Windows.Forms.Label selectedWidthLabel;
        private System.Windows.Forms.NumericUpDown selectedWidthNnumericUpDown;
        private System.Windows.Forms.Panel selectedBrushPanel;
        private System.Windows.Forms.Label selectedObjectBrushLabel;
        private System.Windows.Forms.Label sEPYLabel;
        private System.Windows.Forms.Label sEPXLabel;
        private System.Windows.Forms.Label sSPYLabel;
        private System.Windows.Forms.Label sSPXLabel;
        private System.Windows.Forms.MaskedTextBox selectObjectEPYMaskedTextBox;
        private System.Windows.Forms.MaskedTextBox selectObjectSPYMaskedTextBox;
        private System.Windows.Forms.MaskedTextBox selectObjectEPXMaskedTextBox;
        private System.Windows.Forms.MaskedTextBox selectObjectSPXMaskedTextBox;
    }
}

