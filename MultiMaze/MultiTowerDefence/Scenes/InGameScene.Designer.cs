﻿namespace MazeClient.Scenes
{
    partial class InGameScene
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            panel1 = new Panel();
            jumpLabel = new Label();
            jumpBar = new ProgressBar();
            pictureBox1 = new PictureBox();
            panel2 = new Panel();
            ScoreBoard = new DataGridView();
            NameColumn = new DataGridViewTextBoxColumn();
            ShapeColumn = new DataGridViewImageColumn();
            Round1Label = new DataGridViewTextBoxColumn();
            Round2Label = new DataGridViewTextBoxColumn();
            Round3Label = new DataGridViewTextBoxColumn();
            Round4Label = new DataGridViewTextBoxColumn();
            Round5Label = new DataGridViewTextBoxColumn();
            timer1 = new System.Windows.Forms.Timer(components);
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ScoreBoard).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(jumpLabel);
            panel1.Controls.Add(jumpBar);
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(10, 9);
            panel1.Margin = new Padding(0);
            panel1.Name = "panel1";
            panel1.Size = new Size(900, 600);
            panel1.TabIndex = 1;
            panel1.Paint += panel1_Paint;
            // 
            // jumpLabel
            // 
            jumpLabel.AutoSize = true;
            jumpLabel.BackColor = Color.White;
            jumpLabel.Location = new Point(657, 555);
            jumpLabel.Name = "jumpLabel";
            jumpLabel.Size = new Size(39, 20);
            jumpLabel.TabIndex = 4;
            jumpLabel.Text = "점프";
            // 
            // jumpBar
            // 
            jumpBar.BackColor = SystemColors.ControlDark;
            jumpBar.Location = new Point(750, 550);
            jumpBar.Maximum = 200;
            jumpBar.Name = "jumpBar";
            jumpBar.Size = new Size(130, 30);
            jumpBar.TabIndex = 3;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(-1, 0);
            pictureBox1.Margin = new Padding(0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(758, 337);
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(ScoreBoard);
            panel2.Location = new Point(10, 610);
            panel2.Name = "panel2";
            panel2.Size = new Size(900, 400);
            panel2.TabIndex = 2;
            // 
            // ScoreBoard
            // 
            ScoreBoard.AllowUserToAddRows = false;
            ScoreBoard.AllowUserToDeleteRows = false;
            ScoreBoard.AllowUserToResizeColumns = false;
            ScoreBoard.AllowUserToResizeRows = false;
            ScoreBoard.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            ScoreBoard.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ScoreBoard.Columns.AddRange(new DataGridViewColumn[] { NameColumn, ShapeColumn, Round1Label, Round2Label, Round3Label, Round4Label, Round5Label });
            ScoreBoard.Location = new Point(0, 0);
            ScoreBoard.Margin = new Padding(0);
            ScoreBoard.MultiSelect = false;
            ScoreBoard.Name = "ScoreBoard";
            ScoreBoard.RowHeadersVisible = false;
            ScoreBoard.RowHeadersWidth = 51;
            ScoreBoard.ShowCellToolTips = false;
            ScoreBoard.ShowRowErrors = false;
            ScoreBoard.Size = new Size(894, 283);
            ScoreBoard.TabIndex = 12;
            ScoreBoard.SelectionChanged += ScoreBoard_SelectionChanged;
            // 
            // NameColumn
            // 
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            NameColumn.DefaultCellStyle = dataGridViewCellStyle1;
            NameColumn.HeaderText = "Name";
            NameColumn.MinimumWidth = 6;
            NameColumn.Name = "NameColumn";
            NameColumn.ReadOnly = true;
            NameColumn.Resizable = DataGridViewTriState.False;
            NameColumn.Width = 125;
            // 
            // ShapeColumn
            // 
            ShapeColumn.HeaderText = "Shape";
            ShapeColumn.MinimumWidth = 6;
            ShapeColumn.Name = "ShapeColumn";
            ShapeColumn.ReadOnly = true;
            ShapeColumn.Resizable = DataGridViewTriState.False;
            ShapeColumn.Width = 125;
            // 
            // Round1Label
            // 
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Round1Label.DefaultCellStyle = dataGridViewCellStyle2;
            Round1Label.HeaderText = "Round1";
            Round1Label.MinimumWidth = 6;
            Round1Label.Name = "Round1Label";
            Round1Label.ReadOnly = true;
            Round1Label.Resizable = DataGridViewTriState.False;
            Round1Label.Width = 125;
            // 
            // Round2Label
            // 
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Round2Label.DefaultCellStyle = dataGridViewCellStyle3;
            Round2Label.HeaderText = "Round2";
            Round2Label.MinimumWidth = 6;
            Round2Label.Name = "Round2Label";
            Round2Label.ReadOnly = true;
            Round2Label.Resizable = DataGridViewTriState.False;
            Round2Label.Width = 125;
            // 
            // Round3Label
            // 
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Round3Label.DefaultCellStyle = dataGridViewCellStyle4;
            Round3Label.HeaderText = "Round3";
            Round3Label.MinimumWidth = 6;
            Round3Label.Name = "Round3Label";
            Round3Label.ReadOnly = true;
            Round3Label.Resizable = DataGridViewTriState.False;
            Round3Label.Width = 125;
            // 
            // Round4Label
            // 
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Round4Label.DefaultCellStyle = dataGridViewCellStyle5;
            Round4Label.HeaderText = "Round4";
            Round4Label.MinimumWidth = 6;
            Round4Label.Name = "Round4Label";
            Round4Label.ReadOnly = true;
            Round4Label.Resizable = DataGridViewTriState.False;
            Round4Label.Width = 125;
            // 
            // Round5Label
            // 
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Round5Label.DefaultCellStyle = dataGridViewCellStyle6;
            Round5Label.HeaderText = "Round5";
            Round5Label.MinimumWidth = 6;
            Round5Label.Name = "Round5Label";
            Round5Label.ReadOnly = true;
            Round5Label.Resizable = DataGridViewTriState.False;
            Round5Label.Width = 125;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 50;
            timer1.Tick += timer1_Tick;
            // 
            // InGameScene
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 900);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "InGameScene";
            Text = "MULTIMAZE";
            FormClosing += InGameScene_FormClosing;
            FormClosed += InGameScene_FormClosed;
            Load += InGameScene_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ScoreBoard).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel1;
        private PictureBox pictureBox1;
        private Panel panel2;
        private System.Windows.Forms.Timer timer1;
        private DataGridView ScoreBoard;
        private DataGridViewTextBoxColumn NameColumn;
        private DataGridViewImageColumn ShapeColumn;
        private DataGridViewTextBoxColumn Round1Label;
        private DataGridViewTextBoxColumn Round2Label;
        private DataGridViewTextBoxColumn Round3Label;
        private DataGridViewTextBoxColumn Round4Label;
        private DataGridViewTextBoxColumn Round5Label;
        private ProgressBar jumpBar;
        private Label jumpLabel;
    }
}