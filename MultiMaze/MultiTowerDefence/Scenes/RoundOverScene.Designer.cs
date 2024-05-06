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
            pictureBox1 = new PictureBox();
            Winner = new Label();
            WinnerName = new Label();
            Time = new Label();
            TimeValue = new Label();
            BackToMain = new Button();
            Ready = new Button();
            Start = new Button();
            NextTime = new Label();
            Countdown = new Label();
            timerCountdown = new System.Windows.Forms.Timer(components);
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(177, 54);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(0, 15);
            label1.TabIndex = 6;
            label1.Click += label1_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(92, 38);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(435, 194);
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
            // 
            // Winner
            // 
            Winner.AutoSize = true;
            Winner.Location = new Point(92, 247);
            Winner.Name = "Winner";
            Winner.Size = new Size(34, 15);
            Winner.TabIndex = 8;
            Winner.Text = "승자:";
            Winner.Click += label2_Click;
            // 
            // WinnerName
            // 
            WinnerName.AutoSize = true;
            WinnerName.Location = new Point(132, 247);
            WinnerName.Name = "WinnerName";
            WinnerName.Size = new Size(0, 15);
            WinnerName.TabIndex = 9;
            // 
            // Time
            // 
            Time.AutoSize = true;
            Time.Location = new Point(92, 272);
            Time.Name = "Time";
            Time.Size = new Size(58, 15);
            Time.TabIndex = 10;
            Time.Text = "소요시간:";
            // 
            // TimeValue
            // 
            TimeValue.AutoSize = true;
            TimeValue.Location = new Point(159, 272);
            TimeValue.Name = "TimeValue";
            TimeValue.Size = new Size(0, 15);
            TimeValue.TabIndex = 11;
            // 
            // BackToMain
            // 
            BackToMain.Location = new Point(535, 303);
            BackToMain.Name = "BackToMain";
            BackToMain.Size = new Size(75, 23);
            BackToMain.TabIndex = 12;
            BackToMain.Text = "나가기";
            BackToMain.UseVisualStyleBackColor = true;
            // 
            // Ready
            // 
            Ready.Location = new Point(535, 272);
            Ready.Name = "Ready";
            Ready.Size = new Size(75, 23);
            Ready.TabIndex = 13;
            Ready.Text = "준비";
            Ready.UseVisualStyleBackColor = true;
            // 
            // Start
            // 
            Start.Location = new Point(535, 243);
            Start.Name = "Start";
            Start.Size = new Size(75, 23);
            Start.TabIndex = 14;
            Start.Text = "시작";
            Start.UseVisualStyleBackColor = true;
            // 
            // NextTime
            // 
            NextTime.AutoSize = true;
            NextTime.Location = new Point(537, 217);
            NextTime.Name = "NextTime";
            NextTime.Size = new Size(46, 15);
            NextTime.TabIndex = 15;
            NextTime.Text = "카운트:";
            // 
            // Countdown
            // 
            Countdown.AutoSize = true;
            Countdown.Location = new Point(589, 217);
            Countdown.Name = "Countdown";
            Countdown.Size = new Size(14, 15);
            Countdown.TabIndex = 16;
            Countdown.Text = "5";
            // 
            // button1
            // 
            button1.Location = new Point(484, 11);
            button1.Margin = new Padding(2);
            button1.Name = "button1";
            button1.Size = new Size(127, 22);
            button1.TabIndex = 5;
            button1.Text = "6번 화면 이동";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // RoundOverScene
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(622, 338);
            Controls.Add(Countdown);
            Controls.Add(NextTime);
            Controls.Add(Start);
            Controls.Add(Ready);
            Controls.Add(BackToMain);
            Controls.Add(TimeValue);
            Controls.Add(Time);
            Controls.Add(WinnerName);
            Controls.Add(Winner);
            Controls.Add(pictureBox1);
            Controls.Add(label1);
            Controls.Add(button1);
            Margin = new Padding(2, 2, 2, 2);
            Name = "RoundOverScene";
            Text = "RoundOver";
            Load += RoundOverScene_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private PictureBox pictureBox1;
        private Label Winner;
        private Label WinnerName;
        private Label Time;
        private Label TimeValue;
        private Button BackToMain;
        private Button Ready;
        private Button Start;
        private Label NextTime;
        private Label Countdown;
        private System.Windows.Forms.Timer timerCountdown;
        private Button button1;
    }
}