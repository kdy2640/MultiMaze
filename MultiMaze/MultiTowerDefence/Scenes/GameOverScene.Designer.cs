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
            components = new System.ComponentModel.Container();
            BackToMain = new Button();
            pictureBox3 = new PictureBox();
            roundLabel = new Label();
            panel1 = new Panel();
            Third = new Label();
            First = new Label();
            Second = new Label();
            fastTimeLabel = new Label();
            fastPlayerLabel = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            shadowPictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)shadowPictureBox1).BeginInit();
            SuspendLayout();
            // 
            // BackToMain
            // 
            BackToMain.Font = new Font("맑은 고딕", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 129);
            BackToMain.Location = new Point(525, 527);
            BackToMain.Name = "BackToMain";
            BackToMain.Size = new Size(159, 91);
            BackToMain.TabIndex = 19;
            BackToMain.Text = "나가기";
            BackToMain.UseVisualStyleBackColor = true;
            BackToMain.Click += BackToMain_Click;
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = Color.FromArgb(64, 64, 64);
            pictureBox3.Location = new Point(532, 533);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(159, 91);
            pictureBox3.TabIndex = 21;
            pictureBox3.TabStop = false;
            // 
            // roundLabel
            // 
            roundLabel.AutoSize = true;
            roundLabel.BackColor = Color.Gray;
            roundLabel.Font = new Font("맑은 고딕", 24F, FontStyle.Bold, GraphicsUnit.Point, 129);
            roundLabel.ForeColor = Color.LightGray;
            roundLabel.Location = new Point(30, 19);
            roundLabel.Name = "roundLabel";
            roundLabel.Size = new Size(197, 54);
            roundLabel.TabIndex = 22;
            roundLabel.Text = "게임 종료";
            roundLabel.Paint += roundLabel_Paint;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Gray;
            panel1.Controls.Add(Third);
            panel1.Controls.Add(First);
            panel1.Controls.Add(Second);
            panel1.Location = new Point(30, 527);
            panel1.Name = "panel1";
            panel1.Size = new Size(456, 97);
            panel1.TabIndex = 23;
            // 
            // Third
            // 
            Third.AutoSize = true;
            Third.BackColor = Color.LightGray;
            Third.Location = new Point(15, 69);
            Third.Margin = new Padding(4, 0, 4, 0);
            Third.Name = "Third";
            Third.Size = new Size(45, 20);
            Third.TabIndex = 11;
            Third.Text = "3등 : ";
            // 
            // First
            // 
            First.AutoSize = true;
            First.BackColor = Color.LightGray;
            First.Location = new Point(15, 8);
            First.Margin = new Padding(4, 0, 4, 0);
            First.Name = "First";
            First.Size = new Size(45, 20);
            First.TabIndex = 8;
            First.Text = "1등 : ";
            // 
            // Second
            // 
            Second.AutoSize = true;
            Second.BackColor = Color.LightGray;
            Second.Location = new Point(15, 39);
            Second.Margin = new Padding(4, 0, 4, 0);
            Second.Name = "Second";
            Second.Size = new Size(45, 20);
            Second.TabIndex = 10;
            Second.Text = "2등 : ";
            // 
            // fastTimeLabel
            // 
            fastTimeLabel.AutoSize = true;
            fastTimeLabel.BackColor = Color.LightGray;
            fastTimeLabel.Location = new Point(245, 53);
            fastTimeLabel.Margin = new Padding(4, 0, 4, 0);
            fastTimeLabel.Name = "fastTimeLabel";
            fastTimeLabel.Size = new Size(122, 20);
            fastTimeLabel.TabIndex = 12;
            fastTimeLabel.Text = "최단 탈출 시간 : ";
            // 
            // fastPlayerLabel
            // 
            fastPlayerLabel.AutoSize = true;
            fastPlayerLabel.BackColor = Color.LightGray;
            fastPlayerLabel.Location = new Point(245, 19);
            fastPlayerLabel.Margin = new Padding(4, 0, 4, 0);
            fastPlayerLabel.Name = "fastPlayerLabel";
            fastPlayerLabel.Size = new Size(152, 20);
            fastPlayerLabel.TabIndex = 24;
            fastPlayerLabel.Text = "최단 탈출 플레이어 : ";
            // 
            // timer1
            // 
            timer1.Interval = 10;
            timer1.Tick += timer1_Tick;
            // 
            // shadowPictureBox1
            // 
            shadowPictureBox1.BackColor = Color.FromArgb(64, 64, 64);
            shadowPictureBox1.Location = new Point(487, 421);
            shadowPictureBox1.Name = "shadowPictureBox1";
            shadowPictureBox1.Size = new Size(160, 90);
            shadowPictureBox1.TabIndex = 25;
            shadowPictureBox1.TabStop = false;
            // 
            // GameOverScene
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DimGray;
            ClientSize = new Size(759, 629);
            Controls.Add(shadowPictureBox1);
            Controls.Add(fastPlayerLabel);
            Controls.Add(fastTimeLabel);
            Controls.Add(panel1);
            Controls.Add(roundLabel);
            Controls.Add(BackToMain);
            Controls.Add(pictureBox3);
            Name = "GameOverScene";
            Text = "GameOver";
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)shadowPictureBox1).EndInit();
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
        private Label fastTimeLabel;
        private Label fastPlayerLabel;
        private System.Windows.Forms.Timer timer1;
        private PictureBox shadowPictureBox1;
    }
}