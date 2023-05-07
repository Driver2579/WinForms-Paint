﻿namespace Paint
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            label1 = new Label();
            NumericLineWitdth = new NumericUpDown();
            PicColor = new Button();
            ColorPicker = new PictureBox();
            panel3 = new Panel();
            BtnLine = new Button();
            BtnColor = new Button();
            BtnRect = new Button();
            BtnFill = new Button();
            BtnEllipse = new Button();
            BtnPencil = new Button();
            BtnEraser = new Button();
            panel2 = new Panel();
            Pic = new PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)NumericLineWitdth).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ColorPicker).BeginInit();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Pic).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(64, 64, 64);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(NumericLineWitdth);
            panel1.Controls.Add(PicColor);
            panel1.Controls.Add(ColorPicker);
            panel1.Controls.Add(panel3);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1094, 110);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.White;
            label1.Location = new Point(1030, 65);
            label1.Name = "label1";
            label1.Size = new Size(52, 15);
            label1.TabIndex = 11;
            label1.Text = "Ширина";
            // 
            // NumericLineWitdth
            // 
            NumericLineWitdth.Location = new Point(1030, 35);
            NumericLineWitdth.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            NumericLineWitdth.Name = "NumericLineWitdth";
            NumericLineWitdth.Size = new Size(52, 23);
            NumericLineWitdth.TabIndex = 10;
            NumericLineWitdth.Value = new decimal(new int[] { 1, 0, 0, 0 });
            NumericLineWitdth.ValueChanged += NumericLineWitdth_ValueChanged;
            // 
            // PicColor
            // 
            PicColor.BackColor = Color.Black;
            PicColor.FlatAppearance.MouseDownBackColor = Color.Black;
            PicColor.FlatAppearance.MouseOverBackColor = Color.Black;
            PicColor.FlatStyle = FlatStyle.Flat;
            PicColor.Location = new Point(345, 30);
            PicColor.Name = "PicColor";
            PicColor.Size = new Size(50, 50);
            PicColor.TabIndex = 0;
            PicColor.UseVisualStyleBackColor = false;
            // 
            // ColorPicker
            // 
            ColorPicker.Image = Properties.Resources.ColorPalette;
            ColorPicker.Location = new Point(0, 0);
            ColorPicker.Name = "ColorPicker";
            ColorPicker.Size = new Size(336, 110);
            ColorPicker.SizeMode = PictureBoxSizeMode.StretchImage;
            ColorPicker.TabIndex = 9;
            ColorPicker.TabStop = false;
            // 
            // panel3
            // 
            panel3.BackColor = Color.Black;
            panel3.Controls.Add(BtnLine);
            panel3.Controls.Add(BtnColor);
            panel3.Controls.Add(BtnRect);
            panel3.Controls.Add(BtnFill);
            panel3.Controls.Add(BtnEllipse);
            panel3.Controls.Add(BtnPencil);
            panel3.Controls.Add(BtnEraser);
            panel3.Location = new Point(405, 15);
            panel3.Name = "panel3";
            panel3.Size = new Size(615, 80);
            panel3.TabIndex = 8;
            // 
            // BtnLine
            // 
            BtnLine.BackColor = Color.FromArgb(64, 64, 64);
            BtnLine.FlatAppearance.MouseDownBackColor = Color.Silver;
            BtnLine.FlatAppearance.MouseOverBackColor = Color.Gray;
            BtnLine.FlatStyle = FlatStyle.Flat;
            BtnLine.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            BtnLine.ForeColor = Color.White;
            BtnLine.Image = Properties.Resources.Line;
            BtnLine.ImageAlign = ContentAlignment.TopCenter;
            BtnLine.Location = new Point(531, 10);
            BtnLine.Name = "BtnLine";
            BtnLine.Size = new Size(75, 60);
            BtnLine.TabIndex = 7;
            BtnLine.Text = "Линия";
            BtnLine.TextAlign = ContentAlignment.BottomCenter;
            BtnLine.UseVisualStyleBackColor = false;
            // 
            // BtnColor
            // 
            BtnColor.BackColor = Color.FromArgb(64, 64, 64);
            BtnColor.FlatAppearance.MouseDownBackColor = Color.Silver;
            BtnColor.FlatAppearance.MouseOverBackColor = Color.Gray;
            BtnColor.FlatStyle = FlatStyle.Flat;
            BtnColor.ForeColor = Color.White;
            BtnColor.Image = Properties.Resources.Color;
            BtnColor.Location = new Point(10, 10);
            BtnColor.Name = "BtnColor";
            BtnColor.Size = new Size(75, 60);
            BtnColor.TabIndex = 1;
            BtnColor.Text = "Цвет";
            BtnColor.TextAlign = ContentAlignment.BottomCenter;
            BtnColor.UseVisualStyleBackColor = false;
            // 
            // BtnRect
            // 
            BtnRect.BackColor = Color.FromArgb(64, 64, 64);
            BtnRect.FlatAppearance.MouseDownBackColor = Color.Silver;
            BtnRect.FlatAppearance.MouseOverBackColor = Color.Gray;
            BtnRect.FlatStyle = FlatStyle.Flat;
            BtnRect.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            BtnRect.ForeColor = Color.White;
            BtnRect.Image = Properties.Resources.Rectangle;
            BtnRect.ImageAlign = ContentAlignment.TopCenter;
            BtnRect.Location = new Point(415, 10);
            BtnRect.Name = "BtnRect";
            BtnRect.Size = new Size(110, 60);
            BtnRect.TabIndex = 6;
            BtnRect.Text = "Прямоугольник";
            BtnRect.TextAlign = ContentAlignment.BottomCenter;
            BtnRect.UseVisualStyleBackColor = false;
            // 
            // BtnFill
            // 
            BtnFill.BackColor = Color.FromArgb(64, 64, 64);
            BtnFill.FlatAppearance.MouseDownBackColor = Color.Silver;
            BtnFill.FlatAppearance.MouseOverBackColor = Color.Gray;
            BtnFill.FlatStyle = FlatStyle.Flat;
            BtnFill.ForeColor = Color.White;
            BtnFill.Image = Properties.Resources.Bucket;
            BtnFill.ImageAlign = ContentAlignment.MiddleLeft;
            BtnFill.Location = new Point(91, 10);
            BtnFill.Name = "BtnFill";
            BtnFill.Size = new Size(75, 60);
            BtnFill.TabIndex = 2;
            BtnFill.Text = "Заливка";
            BtnFill.TextAlign = ContentAlignment.BottomCenter;
            BtnFill.UseVisualStyleBackColor = false;
            // 
            // BtnEllipse
            // 
            BtnEllipse.BackColor = Color.FromArgb(64, 64, 64);
            BtnEllipse.FlatAppearance.MouseDownBackColor = Color.Silver;
            BtnEllipse.FlatAppearance.MouseOverBackColor = Color.Gray;
            BtnEllipse.FlatStyle = FlatStyle.Flat;
            BtnEllipse.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            BtnEllipse.ForeColor = Color.White;
            BtnEllipse.Image = Properties.Resources.Circle;
            BtnEllipse.ImageAlign = ContentAlignment.TopCenter;
            BtnEllipse.Location = new Point(334, 10);
            BtnEllipse.Name = "BtnEllipse";
            BtnEllipse.Size = new Size(75, 60);
            BtnEllipse.TabIndex = 5;
            BtnEllipse.Text = "Эллипс";
            BtnEllipse.TextAlign = ContentAlignment.BottomCenter;
            BtnEllipse.UseVisualStyleBackColor = false;
            // 
            // BtnPencil
            // 
            BtnPencil.BackColor = Color.FromArgb(64, 64, 64);
            BtnPencil.FlatAppearance.MouseDownBackColor = Color.Silver;
            BtnPencil.FlatAppearance.MouseOverBackColor = Color.Gray;
            BtnPencil.FlatStyle = FlatStyle.Flat;
            BtnPencil.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            BtnPencil.ForeColor = Color.White;
            BtnPencil.Image = Properties.Resources.Pencil;
            BtnPencil.ImageAlign = ContentAlignment.TopLeft;
            BtnPencil.Location = new Point(172, 10);
            BtnPencil.Name = "BtnPencil";
            BtnPencil.Size = new Size(75, 60);
            BtnPencil.TabIndex = 3;
            BtnPencil.Text = "Карандаш";
            BtnPencil.TextAlign = ContentAlignment.BottomCenter;
            BtnPencil.UseVisualStyleBackColor = false;
            BtnPencil.Click += BtnPencil_Click;
            // 
            // BtnEraser
            // 
            BtnEraser.BackColor = Color.FromArgb(64, 64, 64);
            BtnEraser.FlatAppearance.MouseDownBackColor = Color.Silver;
            BtnEraser.FlatAppearance.MouseOverBackColor = Color.Gray;
            BtnEraser.FlatStyle = FlatStyle.Flat;
            BtnEraser.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            BtnEraser.ForeColor = Color.White;
            BtnEraser.Image = Properties.Resources.Eraser;
            BtnEraser.ImageAlign = ContentAlignment.BottomLeft;
            BtnEraser.Location = new Point(253, 10);
            BtnEraser.Name = "BtnEraser";
            BtnEraser.Size = new Size(75, 60);
            BtnEraser.TabIndex = 4;
            BtnEraser.Text = "Ластик";
            BtnEraser.TextAlign = ContentAlignment.BottomCenter;
            BtnEraser.UseVisualStyleBackColor = false;
            BtnEraser.Click += BtnEraser_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(64, 64, 64);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 565);
            panel2.Name = "panel2";
            panel2.Size = new Size(1094, 50);
            panel2.TabIndex = 1;
            // 
            // Pic
            // 
            Pic.BackColor = Color.White;
            Pic.Dock = DockStyle.Fill;
            Pic.Location = new Point(0, 0);
            Pic.Name = "Pic";
            Pic.Size = new Size(1094, 615);
            Pic.TabIndex = 2;
            Pic.TabStop = false;
            Pic.MouseDown += Pic_MouseDown;
            Pic.MouseMove += Pic_MouseMove;
            Pic.MouseUp += Pic_MouseUp;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1094, 615);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(Pic);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)NumericLineWitdth).EndInit();
            ((System.ComponentModel.ISupportInitialize)ColorPicker).EndInit();
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)Pic).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private PictureBox Pic;
        private Button PicColor;
        private Button BtnColor;
        private Button BtnEraser;
        private Button BtnPencil;
        private Button BtnFill;
        private Button BtnRect;
        private Button BtnEllipse;
        private Button BtnLine;
        private Panel panel3;
        private PictureBox ColorPicker;
        private NumericUpDown NumericLineWitdth;
        private Label label1;
    }
}