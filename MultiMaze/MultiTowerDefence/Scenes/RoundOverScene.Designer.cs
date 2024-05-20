namespace MazeClient
{
    partial class RoundOverScene
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
            label1 = new Label();
            Winner = new Label();
            WinnerName = new Label();
            Time = new Label();
            TimeValue = new Label();
            timerCountdown = new System.Windows.Forms.Timer(components);
            drawTimer = new System.Windows.Forms.Timer(components);
            roundLabel = new Label();
            nextRoundButton = new Button();
            panel1 = new Panel();
            pictureBox3 = new PictureBox();
            shadowPictureBox1 = new PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)shadowPictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(228, 72);
            label1.Name = "label1";
            label1.Size = new Size(0, 20);
            label1.TabIndex = 6;
            label1.Click += label1_Click;
            // 
            // Winner
            // 
            Winner.AutoSize = true;
            Winner.BackColor = Color.LightGray;
            Winner.Location = new Point(16, 21);
            Winner.Margin = new Padding(4, 0, 4, 0);
            Winner.Name = "Winner";
            Winner.Size = new Size(52, 20);
            Winner.TabIndex = 8;
            Winner.Text = "승자 : ";
            Winner.Click += label2_Click;
            // 
            // WinnerName
            // 
            WinnerName.AutoSize = true;
            WinnerName.Location = new Point(169, 494);
            WinnerName.Margin = new Padding(4, 0, 4, 0);
            WinnerName.Name = "WinnerName";
            WinnerName.Size = new Size(0, 20);
            WinnerName.TabIndex = 9;
            // 
            // Time
            // 
            Time.AutoSize = true;
            Time.BackColor = Color.LightGray;
            Time.Location = new Point(16, 61);
            Time.Margin = new Padding(4, 0, 4, 0);
            Time.Name = "Time";
            Time.Size = new Size(82, 20);
            Time.TabIndex = 10;
            Time.Text = "소요시간 : ";
            // 
            // TimeValue
            // 
            TimeValue.AutoSize = true;
            TimeValue.Location = new Point(204, 527);
            TimeValue.Margin = new Padding(4, 0, 4, 0);
            TimeValue.Name = "TimeValue";
            TimeValue.Size = new Size(0, 20);
            TimeValue.TabIndex = 11;
            // 
            // timerCountdown
            // 
            timerCountdown.Tick += timerCountdown_Tick;
            // 
            // drawTimer
            // 
            drawTimer.Interval = 10;
            drawTimer.Tick += drawTimer_Tick;
            // 
            // roundLabel
            // 
            roundLabel.AutoSize = true;
            roundLabel.BackColor = Color.Gray;
            roundLabel.Font = new Font("맑은 고딕", 24F, FontStyle.Bold, GraphicsUnit.Point, 129);
            roundLabel.ForeColor = Color.LightGray;
            roundLabel.Location = new Point(30, 18);
            roundLabel.Name = "roundLabel";
            roundLabel.Size = new Size(237, 54);
            roundLabel.TabIndex = 17;
            roundLabel.Text = "라운드 종료";
            roundLabel.Paint += roundLabel_Paint;
            // 
            // nextRoundButton
            // 
            nextRoundButton.Location = new Point(525, 527);
            nextRoundButton.Name = "nextRoundButton";
            nextRoundButton.Size = new Size(160, 90);
            nextRoundButton.TabIndex = 18;
            nextRoundButton.Text = "다음 라운드로 이동";
            nextRoundButton.UseVisualStyleBackColor = true;
            nextRoundButton.Click += nextRoundButton_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Gray;
            panel1.Controls.Add(Winner);
            panel1.Controls.Add(Time);
            panel1.Location = new Point(31, 527);
            panel1.Name = "panel1";
            panel1.Size = new Size(456, 92);
            panel1.TabIndex = 19;
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = Color.FromArgb(64, 64, 64);
            pictureBox3.Location = new Point(532, 534);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(160, 90);
            pictureBox3.TabIndex = 20;
            pictureBox3.TabStop = false;
            // 
            // shadowPictureBox1
            // 
            shadowPictureBox1.BackColor = Color.FromArgb(64, 64, 64);
            shadowPictureBox1.Location = new Point(532, 424);
            shadowPictureBox1.Name = "shadowPictureBox1";
            shadowPictureBox1.Size = new Size(160, 90);
            shadowPictureBox1.TabIndex = 21;
            shadowPictureBox1.TabStop = false;
            // 
            // RoundOverScene
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DimGray;
            ClientSize = new Size(758, 629);
            Controls.Add(shadowPictureBox1);
            Controls.Add(nextRoundButton);
            Controls.Add(roundLabel);
            Controls.Add(TimeValue);
            Controls.Add(WinnerName);
            Controls.Add(label1);
            Controls.Add(panel1);
            Controls.Add(pictureBox3);
            Name = "RoundOverScene";
            Text = "RoundOver";
            Load += RoundOverScene_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)shadowPictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label Winner;
        private Label WinnerName;
        private Label Time;
        private Label TimeValue;
        private System.Windows.Forms.Timer timerCountdown;
        private System.Windows.Forms.Timer drawTimer;
        private Label roundLabel;
        private Button nextRoundButton;
        private Panel panel1;
        private PictureBox pictureBox3;
        private PictureBox shadowPictureBox1;
    }
}