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
            gameRoundPanel = new GroupBox();
            gameCount5 = new RadioButton();
            gameCount3 = new RadioButton();
            gameCount1 = new RadioButton();
            algorithmPanel = new GroupBox();
            computerAster = new RadioButton();
            computerDFS = new RadioButton();
            computerBFS = new RadioButton();
            textBox1 = new TextBox();
            makeRoomBtn = new Button();
            cancelMakeRoomBtn = new Button();
            mapPanel = new GroupBox();
            size70 = new RadioButton();
            size50 = new RadioButton();
            size30 = new RadioButton();
            shadowPictureBox1 = new PictureBox();
            shadowPictureBox2 = new PictureBox();
            shadowPictureBox5 = new PictureBox();
            shadowPictureBox4 = new PictureBox();
            shadowPictureBox3 = new PictureBox();
            gameRoundPanel.SuspendLayout();
            algorithmPanel.SuspendLayout();
            mapPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)shadowPictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)shadowPictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)shadowPictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)shadowPictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)shadowPictureBox3).BeginInit();
            SuspendLayout();
            // 
            // makeRoom_label
            // 
            makeRoom_label.AutoSize = true;
            makeRoom_label.BackColor = Color.Gray;
            makeRoom_label.Font = new Font("맑은 고딕", 24F, FontStyle.Bold, GraphicsUnit.Point, 129);
            makeRoom_label.ForeColor = Color.LightGray;
            makeRoom_label.Location = new Point(29, 27);
            makeRoom_label.Name = "makeRoom_label";
            makeRoom_label.Size = new Size(197, 54);
            makeRoom_label.TabIndex = 4;
            makeRoom_label.Text = "게임 설정";
            makeRoom_label.Paint += makeRoom_label_Paint;
            // 
            // roominfo_ip_label
            // 
            roominfo_ip_label.AutoSize = true;
            roominfo_ip_label.BackColor = Color.DarkGray;
            roominfo_ip_label.Location = new Point(559, 270);
            roominfo_ip_label.Name = "roominfo_ip_label";
            roominfo_ip_label.Size = new Size(66, 20);
            roominfo_ip_label.TabIndex = 5;
            roominfo_ip_label.Text = "HOST IP";
            // 
            // gameRoundPanel
            // 
            gameRoundPanel.BackColor = Color.Gray;
            gameRoundPanel.Controls.Add(gameCount5);
            gameRoundPanel.Controls.Add(gameCount3);
            gameRoundPanel.Controls.Add(gameCount1);
            gameRoundPanel.Location = new Point(29, 113);
            gameRoundPanel.Margin = new Padding(0);
            gameRoundPanel.Name = "gameRoundPanel";
            gameRoundPanel.Padding = new Padding(3, 2, 3, 2);
            gameRoundPanel.Size = new Size(480, 110);
            gameRoundPanel.TabIndex = 6;
            gameRoundPanel.TabStop = false;
            gameRoundPanel.Text = "게임 수";
            // 
            // gameCount5
            // 
            gameCount5.AutoSize = true;
            gameCount5.Location = new Point(350, 50);
            gameCount5.Name = "gameCount5";
            gameCount5.Size = new Size(38, 24);
            gameCount5.TabIndex = 2;
            gameCount5.Text = "5";
            gameCount5.UseVisualStyleBackColor = true;
            // 
            // gameCount3
            // 
            gameCount3.AutoSize = true;
            gameCount3.Location = new Point(210, 50);
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
            gameCount1.Location = new Point(70, 50);
            gameCount1.Margin = new Padding(3, 2, 3, 2);
            gameCount1.Name = "gameCount1";
            gameCount1.Size = new Size(38, 24);
            gameCount1.TabIndex = 0;
            gameCount1.TabStop = true;
            gameCount1.Text = "1";
            gameCount1.UseVisualStyleBackColor = true;
            // 
            // algorithmPanel
            // 
            algorithmPanel.BackColor = Color.Gray;
            algorithmPanel.Controls.Add(computerAster);
            algorithmPanel.Controls.Add(computerDFS);
            algorithmPanel.Controls.Add(computerBFS);
            algorithmPanel.Location = new Point(29, 243);
            algorithmPanel.Name = "algorithmPanel";
            algorithmPanel.Padding = new Padding(3, 2, 3, 2);
            algorithmPanel.Size = new Size(480, 110);
            algorithmPanel.TabIndex = 7;
            algorithmPanel.TabStop = false;
            algorithmPanel.Text = "알고리즘";
            // 
            // computerAster
            // 
            computerAster.AutoSize = true;
            computerAster.Location = new Point(350, 50);
            computerAster.Name = "computerAster";
            computerAster.Size = new Size(64, 24);
            computerAster.TabIndex = 2;
            computerAster.Text = "Astar";
            computerAster.UseVisualStyleBackColor = true;
            computerAster.CheckedChanged += computerAster_CheckedChanged;
            // 
            // computerDFS
            // 
            computerDFS.AutoSize = true;
            computerDFS.Location = new Point(210, 50);
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
            computerBFS.Location = new Point(70, 50);
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
            textBox1.Location = new Point(558, 293);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(135, 27);
            textBox1.TabIndex = 8;
            // 
            // makeRoomBtn
            // 
            makeRoomBtn.Location = new Point(557, 337);
            makeRoomBtn.Margin = new Padding(3, 2, 3, 2);
            makeRoomBtn.Name = "makeRoomBtn";
            makeRoomBtn.Size = new Size(180, 60);
            makeRoomBtn.TabIndex = 9;
            makeRoomBtn.Text = "만들기";
            makeRoomBtn.UseVisualStyleBackColor = true;
            makeRoomBtn.Click += makeRoomBtn_Click;
            // 
            // cancelMakeRoomBtn
            // 
            cancelMakeRoomBtn.Location = new Point(557, 417);
            cancelMakeRoomBtn.Margin = new Padding(3, 2, 3, 2);
            cancelMakeRoomBtn.Name = "cancelMakeRoomBtn";
            cancelMakeRoomBtn.Size = new Size(180, 60);
            cancelMakeRoomBtn.TabIndex = 10;
            cancelMakeRoomBtn.Text = "취소";
            cancelMakeRoomBtn.UseVisualStyleBackColor = true;
            cancelMakeRoomBtn.Click += cancelMakeRoomBtn_Click;
            // 
            // mapPanel
            // 
            mapPanel.BackColor = Color.Gray;
            mapPanel.Controls.Add(size70);
            mapPanel.Controls.Add(size50);
            mapPanel.Controls.Add(size30);
            mapPanel.Location = new Point(29, 373);
            mapPanel.Name = "mapPanel";
            mapPanel.Size = new Size(480, 110);
            mapPanel.TabIndex = 3;
            mapPanel.TabStop = false;
            mapPanel.Text = "맵 크기";
            // 
            // size70
            // 
            size70.AutoSize = true;
            size70.Location = new Point(350, 50);
            size70.Name = "size70";
            size70.Size = new Size(94, 24);
            size70.TabIndex = 5;
            size70.Text = "100 * 100";
            size70.UseVisualStyleBackColor = true;
            // 
            // size50
            // 
            size50.AutoSize = true;
            size50.Location = new Point(210, 50);
            size50.Name = "size50";
            size50.Size = new Size(78, 24);
            size50.TabIndex = 4;
            size50.Text = "70 * 70";
            size50.UseVisualStyleBackColor = true;
            size50.CheckedChanged += size50_CheckedChanged;
            // 
            // size30
            // 
            size30.AutoSize = true;
            size30.Checked = true;
            size30.Location = new Point(70, 50);
            size30.Name = "size30";
            size30.Size = new Size(78, 24);
            size30.TabIndex = 3;
            size30.TabStop = true;
            size30.Text = "40 * 40";
            size30.UseVisualStyleBackColor = true;
            size30.CheckedChanged += radioButton1_CheckedChanged;
            // 
            // shadowPictureBox1
            // 
            shadowPictureBox1.BackColor = Color.FromArgb(64, 64, 64);
            shadowPictureBox1.Location = new Point(564, 344);
            shadowPictureBox1.Name = "shadowPictureBox1";
            shadowPictureBox1.Size = new Size(180, 60);
            shadowPictureBox1.TabIndex = 11;
            shadowPictureBox1.TabStop = false;
            // 
            // shadowPictureBox2
            // 
            shadowPictureBox2.BackColor = Color.FromArgb(64, 64, 64);
            shadowPictureBox2.Location = new Point(564, 424);
            shadowPictureBox2.Name = "shadowPictureBox2";
            shadowPictureBox2.Size = new Size(180, 60);
            shadowPictureBox2.TabIndex = 12;
            shadowPictureBox2.TabStop = false;
            // 
            // shadowPictureBox5
            // 
            shadowPictureBox5.BackColor = Color.FromArgb(64, 64, 64);
            shadowPictureBox5.Location = new Point(557, 26);
            shadowPictureBox5.Name = "shadowPictureBox5";
            shadowPictureBox5.Size = new Size(180, 60);
            shadowPictureBox5.TabIndex = 13;
            shadowPictureBox5.TabStop = false;
            // 
            // shadowPictureBox4
            // 
            shadowPictureBox4.BackColor = Color.FromArgb(64, 64, 64);
            shadowPictureBox4.Location = new Point(559, 92);
            shadowPictureBox4.Name = "shadowPictureBox4";
            shadowPictureBox4.Size = new Size(180, 60);
            shadowPictureBox4.TabIndex = 14;
            shadowPictureBox4.TabStop = false;
            // 
            // shadowPictureBox3
            // 
            shadowPictureBox3.BackColor = Color.FromArgb(64, 64, 64);
            shadowPictureBox3.Location = new Point(567, 162);
            shadowPictureBox3.Name = "shadowPictureBox3";
            shadowPictureBox3.Size = new Size(180, 60);
            shadowPictureBox3.TabIndex = 15;
            shadowPictureBox3.TabStop = false;
            // 
            // SettingScene
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DimGray;
            ClientSize = new Size(816, 509);
            Controls.Add(shadowPictureBox3);
            Controls.Add(shadowPictureBox4);
            Controls.Add(shadowPictureBox5);
            Controls.Add(mapPanel);
            Controls.Add(cancelMakeRoomBtn);
            Controls.Add(makeRoomBtn);
            Controls.Add(textBox1);
            Controls.Add(algorithmPanel);
            Controls.Add(gameRoundPanel);
            Controls.Add(roominfo_ip_label);
            Controls.Add(makeRoom_label);
            Controls.Add(shadowPictureBox1);
            Controls.Add(shadowPictureBox2);
            Name = "SettingScene";
            Text = "MULTIMAZE";
            Load += SettingScene_Load;
            gameRoundPanel.ResumeLayout(false);
            gameRoundPanel.PerformLayout();
            algorithmPanel.ResumeLayout(false);
            algorithmPanel.PerformLayout();
            mapPanel.ResumeLayout(false);
            mapPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)shadowPictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)shadowPictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)shadowPictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)shadowPictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)shadowPictureBox3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label makeRoom_label;
        private Label roominfo_ip_label;
        private GroupBox gameRoundPanel;
        private RadioButton gameCount5;
        private RadioButton gameCount3;
        private RadioButton gameCount1;
        private GroupBox algorithmPanel;
        private RadioButton computerAster;
        private RadioButton computerDFS;
        private RadioButton computerBFS;
        private TextBox textBox1;
        private Button makeRoomBtn;
        private Button cancelMakeRoomBtn;
        private GroupBox mapPanel;
        private RadioButton size70;
        private RadioButton size50;
        private RadioButton size30;
        private PictureBox shadowPictureBox1;
        private PictureBox shadowPictureBox2;
        private PictureBox shadowPictureBox5;
        private PictureBox shadowPictureBox4;
        private PictureBox shadowPictureBox3;
    }
}