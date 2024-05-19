namespace MazeClient
{
    partial class SettingScene
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
            makeRoom_label = new Label();
            roominfo_ip_label = new Label();
            gameRound = new GroupBox();
            gameCount5 = new RadioButton();
            gameCount3 = new RadioButton();
            gameCount1 = new RadioButton();
            groupBox1 = new GroupBox();
            computerRandom = new RadioButton();
            computerDFS = new RadioButton();
            computerBFS = new RadioButton();
            textBox1 = new TextBox();
            makeRoomBtn = new Button();
            cancelMakeRoomBtn = new Button();
            gameRound.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // makeRoom_label
            // 
            makeRoom_label.AutoSize = true;
            makeRoom_label.Location = new Point(331, 22);
            makeRoom_label.Name = "makeRoom_label";
            makeRoom_label.Size = new Size(89, 20);
            makeRoom_label.TabIndex = 4;
            makeRoom_label.Text = "게임 만들기";
            // 
            // roominfo_ip_label
            // 
            roominfo_ip_label.AutoSize = true;
            roominfo_ip_label.Location = new Point(173, 99);
            roominfo_ip_label.Name = "roominfo_ip_label";
            roominfo_ip_label.Size = new Size(66, 20);
            roominfo_ip_label.TabIndex = 5;
            roominfo_ip_label.Text = "HOST IP";
            // 
            // gameRound
            // 
            gameRound.Controls.Add(gameCount5);
            gameRound.Controls.Add(gameCount3);
            gameRound.Controls.Add(gameCount1);
            gameRound.Location = new Point(114, 143);
            gameRound.Margin = new Padding(3, 2, 3, 2);
            gameRound.Name = "gameRound";
            gameRound.Padding = new Padding(3, 2, 3, 2);
            gameRound.Size = new Size(479, 98);
            gameRound.TabIndex = 6;
            gameRound.TabStop = false;
            gameRound.Text = "게임 수";
            // 
            // gameCount5
            // 
            gameCount5.AutoSize = true;
            gameCount5.Location = new Point(368, 42);
            gameCount5.Margin = new Padding(3, 2, 3, 2);
            gameCount5.Name = "gameCount5";
            gameCount5.Size = new Size(38, 24);
            gameCount5.TabIndex = 2;
            gameCount5.Text = "5";
            gameCount5.UseVisualStyleBackColor = true;
            // 
            // gameCount3
            // 
            gameCount3.AutoSize = true;
            gameCount3.Location = new Point(217, 42);
            gameCount3.Margin = new Padding(3, 2, 3, 2);
            gameCount3.Name = "gameCount3";
            gameCount3.Size = new Size(38, 24);
            gameCount3.TabIndex = 1;
            gameCount3.Text = "3";
            gameCount3.UseVisualStyleBackColor = true;
            // 
            // gameCount1
            // 
            gameCount1.AutoSize = true;
            gameCount1.Checked = true;
            gameCount1.Location = new Point(70, 42);
            gameCount1.Margin = new Padding(3, 2, 3, 2);
            gameCount1.Name = "gameCount1";
            gameCount1.Size = new Size(38, 24);
            gameCount1.TabIndex = 0;
            gameCount1.TabStop = true;
            gameCount1.Text = "1";
            gameCount1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(computerRandom);
            groupBox1.Controls.Add(computerDFS);
            groupBox1.Controls.Add(computerBFS);
            groupBox1.Location = new Point(114, 269);
            groupBox1.Margin = new Padding(3, 2, 3, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 2, 3, 2);
            groupBox1.Size = new Size(479, 112);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            groupBox1.Text = "groupBox1";
            // 
            // computerRandom
            // 
            computerRandom.AutoSize = true;
            computerRandom.Location = new Point(340, 55);
            computerRandom.Margin = new Padding(3, 2, 3, 2);
            computerRandom.Name = "computerRandom";
            computerRandom.Size = new Size(87, 24);
            computerRandom.TabIndex = 2;
            computerRandom.Text = "Random";
            computerRandom.UseVisualStyleBackColor = true;
            // 
            // computerDFS
            // 
            computerDFS.AutoSize = true;
            computerDFS.Location = new Point(217, 55);
            computerDFS.Margin = new Padding(3, 2, 3, 2);
            computerDFS.Name = "computerDFS";
            computerDFS.Size = new Size(56, 24);
            computerDFS.TabIndex = 1;
            computerDFS.Text = "DFS";
            computerDFS.UseVisualStyleBackColor = true;
            // 
            // computerBFS
            // 
            computerBFS.AutoSize = true;
            computerBFS.Checked = true;
            computerBFS.Location = new Point(70, 55);
            computerBFS.Margin = new Padding(3, 2, 3, 2);
            computerBFS.Name = "computerBFS";
            computerBFS.Size = new Size(54, 24);
            computerBFS.TabIndex = 0;
            computerBFS.TabStop = true;
            computerBFS.Text = "BFS";
            computerBFS.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(331, 99);
            textBox1.Margin = new Padding(3, 2, 3, 2);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(135, 27);
            textBox1.TabIndex = 8;
            // 
            // makeRoomBtn
            // 
            makeRoomBtn.Location = new Point(643, 214);
            makeRoomBtn.Margin = new Padding(3, 2, 3, 2);
            makeRoomBtn.Name = "makeRoomBtn";
            makeRoomBtn.Size = new Size(101, 27);
            makeRoomBtn.TabIndex = 9;
            makeRoomBtn.Text = "만들기";
            makeRoomBtn.UseVisualStyleBackColor = true;
            makeRoomBtn.Click += makeRoomBtn_Click;
            // 
            // cancelMakeRoomBtn
            // 
            cancelMakeRoomBtn.Location = new Point(643, 278);
            cancelMakeRoomBtn.Margin = new Padding(3, 2, 3, 2);
            cancelMakeRoomBtn.Name = "cancelMakeRoomBtn";
            cancelMakeRoomBtn.Size = new Size(101, 27);
            cancelMakeRoomBtn.TabIndex = 10;
            cancelMakeRoomBtn.Text = "취소";
            cancelMakeRoomBtn.UseVisualStyleBackColor = true;
            cancelMakeRoomBtn.Click += cancelMakeRoomBtn_Click;
            // 
            // SettingScene
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(cancelMakeRoomBtn);
            Controls.Add(makeRoomBtn);
            Controls.Add(textBox1);
            Controls.Add(groupBox1);
            Controls.Add(gameRound);
            Controls.Add(roominfo_ip_label);
            Controls.Add(makeRoom_label);
            Name = "SettingScene";
            Text = "Form1";
            gameRound.ResumeLayout(false);
            gameRound.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label makeRoom_label;
        private Label roominfo_ip_label;
        private GroupBox gameRound;
        private RadioButton gameCount5;
        private RadioButton gameCount3;
        private RadioButton gameCount1;
        private GroupBox groupBox1;
        private RadioButton computerRandom;
        private RadioButton computerDFS;
        private RadioButton computerBFS;
        private TextBox textBox1;
        private Button makeRoomBtn;
        private Button cancelMakeRoomBtn;
    }
}