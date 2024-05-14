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
            BackToMain = new Button();
            Ready = new Button();
            Start = new Button();
            NextTime = new Label();
            Countdown = new Label();
            timerCountdown = new System.Windows.Forms.Timer(components);
            button1 = new Button();
            drawTimer = new System.Windows.Forms.Timer(components);
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
            Winner.Location = new Point(117, 428);
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
            WinnerName.Location = new Point(168, 428);
            WinnerName.Margin = new Padding(4, 0, 4, 0);
            WinnerName.Name = "WinnerName";
            WinnerName.Size = new Size(0, 20);
            WinnerName.TabIndex = 9;
            // 
            // Time
            // 
            Time.AutoSize = true;
            Time.Location = new Point(117, 461);
            Time.Margin = new Padding(4, 0, 4, 0);
            Time.Name = "Time";
            Time.Size = new Size(82, 20);
            Time.TabIndex = 10;
            Time.Text = "소요시간 : ";
            // 
            // TimeValue
            // 
            TimeValue.AutoSize = true;
            TimeValue.Location = new Point(203, 461);
            TimeValue.Margin = new Padding(4, 0, 4, 0);
            TimeValue.Name = "TimeValue";
            TimeValue.Size = new Size(0, 20);
            TimeValue.TabIndex = 11;
            // 
            // BackToMain
            // 
            BackToMain.Location = new Point(687, 503);
            BackToMain.Margin = new Padding(4);
            BackToMain.Name = "BackToMain";
            BackToMain.Size = new Size(96, 31);
            BackToMain.TabIndex = 12;
            BackToMain.Text = "나가기";
            BackToMain.UseVisualStyleBackColor = true;
            // 
            // Ready
            // 
            Ready.Location = new Point(687, 461);
            Ready.Margin = new Padding(4);
            Ready.Name = "Ready";
            Ready.Size = new Size(96, 31);
            Ready.TabIndex = 13;
            Ready.Text = "준비";
            Ready.UseVisualStyleBackColor = true;
            // 
            // Start
            // 
            Start.Location = new Point(687, 423);
            Start.Margin = new Padding(4);
            Start.Name = "Start";
            Start.Size = new Size(96, 31);
            Start.TabIndex = 14;
            Start.Text = "시작";
            Start.UseVisualStyleBackColor = true;
            Start.Click += Start_Click;
            // 
            // NextTime
            // 
            NextTime.AutoSize = true;
            NextTime.Location = new Point(689, 388);
            NextTime.Margin = new Padding(4, 0, 4, 0);
            NextTime.Name = "NextTime";
            NextTime.Size = new Size(57, 20);
            NextTime.TabIndex = 15;
            NextTime.Text = "카운트:";
            // 
            // Countdown
            // 
            Countdown.AutoSize = true;
            Countdown.Location = new Point(756, 388);
            Countdown.Margin = new Padding(4, 0, 4, 0);
            Countdown.Name = "Countdown";
            Countdown.Size = new Size(17, 20);
            Countdown.TabIndex = 16;
            Countdown.Text = "5";
            // 
            // timerCountdown
            // 
            timerCountdown.Tick += timerCountdown_Tick;
            // 
            // button1
            // 
            button1.Location = new Point(662, 15);
            button1.Name = "button1";
            button1.Size = new Size(163, 29);
            button1.TabIndex = 5;
            button1.Text = "6번 화면 이동";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // drawTimer
            // 
            drawTimer.Interval = 10;
            drawTimer.Tick += drawTimer_Tick;
            // 
            // RoundOverScene
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(913, 569);
            Controls.Add(Countdown);
            Controls.Add(NextTime);
            Controls.Add(Start);
            Controls.Add(Ready);
            Controls.Add(BackToMain);
            Controls.Add(TimeValue);
            Controls.Add(Time);
            Controls.Add(WinnerName);
            Controls.Add(Winner);
            Controls.Add(label1);
            Controls.Add(button1);
            Name = "RoundOverScene";
            Text = "RoundOver";
            Load += RoundOverScene_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
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
        private System.Windows.Forms.Timer drawTimer;
    }
}