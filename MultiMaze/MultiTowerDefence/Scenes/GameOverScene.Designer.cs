namespace MazeClient
{
    partial class GameOverScene
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
            BackToMain = new Button();
            pictureBox3 = new PictureBox();
            roundLabel = new Label();
            panel1 = new Panel();
            First = new Label();
            Second = new Label();
            Third = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // BackToMain
            // 
            BackToMain.Location = new Point(408, 395);
            BackToMain.Margin = new Padding(2);
            BackToMain.Name = "BackToMain";
            BackToMain.Size = new Size(124, 68);
            BackToMain.TabIndex = 19;
            BackToMain.Text = "나가기";
            BackToMain.UseVisualStyleBackColor = true;
            BackToMain.Click += BackToMain_Click;
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = Color.FromArgb(64, 64, 64);
            pictureBox3.Location = new Point(414, 400);
            pictureBox3.Margin = new Padding(2);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(124, 68);
            pictureBox3.TabIndex = 21;
            pictureBox3.TabStop = false;
            // 
            // roundLabel
            // 
            roundLabel.AutoSize = true;
            roundLabel.BackColor = Color.Gray;
            roundLabel.Font = new Font("맑은 고딕", 24F, FontStyle.Bold, GraphicsUnit.Point, 129);
            roundLabel.ForeColor = Color.LightGray;
            roundLabel.Location = new Point(23, 14);
            roundLabel.Margin = new Padding(2, 0, 2, 0);
            roundLabel.Name = "roundLabel";
            roundLabel.Size = new Size(191, 45);
            roundLabel.TabIndex = 22;
            roundLabel.Text = "라운드 종료";
            // 
            // panel1
            // 
            panel1.BackColor = Color.Gray;
            panel1.Controls.Add(Third);
            panel1.Controls.Add(First);
            panel1.Controls.Add(Second);
            panel1.Location = new Point(23, 363);
            panel1.Margin = new Padding(2);
            panel1.Name = "panel1";
            panel1.Size = new Size(355, 105);
            panel1.TabIndex = 23;
            // 
            // First
            // 
            First.AutoSize = true;
            First.BackColor = Color.LightGray;
            First.Location = new Point(12, 16);
            First.Name = "First";
            First.Size = new Size(37, 15);
            First.TabIndex = 8;
            First.Text = "1등 : ";
            // 
            // Second
            // 
            Second.AutoSize = true;
            Second.BackColor = Color.LightGray;
            Second.Location = new Point(12, 46);
            Second.Name = "Second";
            Second.Size = new Size(37, 15);
            Second.TabIndex = 10;
            Second.Text = "2등 : ";
            // 
            // Third
            // 
            Third.AutoSize = true;
            Third.BackColor = Color.LightGray;
            Third.Location = new Point(12, 76);
            Third.Name = "Third";
            Third.Size = new Size(37, 15);
            Third.TabIndex = 11;
            Third.Text = "3등 : ";
            // 
            // GameOverScene
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DimGray;
            ClientSize = new Size(590, 472);
            Controls.Add(panel1);
            Controls.Add(roundLabel);
            Controls.Add(BackToMain);
            Controls.Add(pictureBox3);
            Margin = new Padding(2);
            Name = "GameOverScene";
            Text = "GameOver";
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button BackToMain;
        private PictureBox pictureBox3;
        private Label roundLabel;
        private Panel panel1;
        private Label Third;
        private Label First;
        private Label Second;
    }
}