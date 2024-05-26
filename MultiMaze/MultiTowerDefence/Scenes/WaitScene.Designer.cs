namespace MazeClient
{
    partial class WaitScene
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            BtnStart = new Button();
            BtnReady = new Button();
            BtnLeave = new Button();
            PicPlayer2 = new PictureBox();
            Player1 = new Label();
            Player2 = new Label();
            Player4 = new Label();
            PicPlayer1 = new PictureBox();
            Player3 = new Label();
            PicPlayer4 = new PictureBox();
            PicPlayer3 = new PictureBox();
            RtbChat = new RichTextBox();
            BtnSend = new Button();
            BtnColor = new Button();
            cld = new ColorDialog();
            inputTb = new TextBox();
            hostLabel = new Label();
            playerPanel = new Panel();
            wait_label = new Label();
            shadowPictureBox1 = new PictureBox();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox3 = new PictureBox();
            pictureBox4 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)PicPlayer2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PicPlayer1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PicPlayer4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PicPlayer3).BeginInit();
            playerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)shadowPictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            SuspendLayout();
            // 
            // BtnStart
            // 
            BtnStart.Font = new Font("맑은 고딕", 16.2F, FontStyle.Bold);
            BtnStart.Location = new Point(35, 460);
            BtnStart.Margin = new Padding(4);
            BtnStart.Name = "BtnStart";
            BtnStart.Size = new Size(210, 120);
            BtnStart.TabIndex = 3;
            BtnStart.Text = "게임 시작";
            BtnStart.UseVisualStyleBackColor = true;
            BtnStart.Click += BtnStart_Click;
            // 
            // BtnReady
            // 
            BtnReady.Font = new Font("맑은 고딕", 16.2F, FontStyle.Bold);
            BtnReady.Location = new Point(260, 460);
            BtnReady.Margin = new Padding(4);
            BtnReady.Name = "BtnReady";
            BtnReady.Size = new Size(210, 120);
            BtnReady.TabIndex = 3;
            BtnReady.Text = "준비";
            BtnReady.UseVisualStyleBackColor = true;
            BtnReady.Click += BtnReady_Click;
            // 
            // BtnLeave
            // 
            BtnLeave.Font = new Font("맑은 고딕", 12F, FontStyle.Bold);
            BtnLeave.Location = new Point(655, 460);
            BtnLeave.Margin = new Padding(4);
            BtnLeave.Name = "BtnLeave";
            BtnLeave.Size = new Size(120, 120);
            BtnLeave.TabIndex = 3;
            BtnLeave.Text = "나가기";
            BtnLeave.UseVisualStyleBackColor = true;
            BtnLeave.Click += BtnLeave_Click;
            // 
            // PicPlayer2
            // 
            PicPlayer2.BackColor = Color.LightGray;
            PicPlayer2.Location = new Point(200, 25);
            PicPlayer2.Margin = new Padding(4);
            PicPlayer2.Name = "PicPlayer2";
            PicPlayer2.Size = new Size(110, 110);
            PicPlayer2.TabIndex = 4;
            PicPlayer2.TabStop = false;
            PicPlayer2.Paint += PicPlayer_Paint;
            // 
            // Player1
            // 
            Player1.AutoSize = true;
            Player1.Font = new Font("맑은 고딕", 9F, FontStyle.Bold);
            Player1.Location = new Point(37, 141);
            Player1.Margin = new Padding(4, 0, 4, 0);
            Player1.Name = "Player1";
            Player1.Size = new Size(61, 20);
            Player1.TabIndex = 6;
            Player1.Text = "Player1";
            Player1.Paint += Player_Paint;
            // 
            // Player2
            // 
            Player2.AutoSize = true;
            Player2.Font = new Font("맑은 고딕", 9F, FontStyle.Bold);
            Player2.Location = new Point(200, 141);
            Player2.Margin = new Padding(4, 0, 4, 0);
            Player2.Name = "Player2";
            Player2.Size = new Size(61, 20);
            Player2.TabIndex = 6;
            Player2.Text = "Player2";
            Player2.Paint += Player_Paint;
            // 
            // Player4
            // 
            Player4.AutoSize = true;
            Player4.Font = new Font("맑은 고딕", 9F, FontStyle.Bold);
            Player4.Location = new Point(200, 301);
            Player4.Margin = new Padding(4, 0, 4, 0);
            Player4.Name = "Player4";
            Player4.Size = new Size(61, 20);
            Player4.TabIndex = 6;
            Player4.Text = "Player4";
            Player4.Paint += Player_Paint;
            // 
            // PicPlayer1
            // 
            PicPlayer1.BackColor = Color.LightGray;
            PicPlayer1.Location = new Point(37, 25);
            PicPlayer1.Margin = new Padding(4);
            PicPlayer1.Name = "PicPlayer1";
            PicPlayer1.Size = new Size(110, 110);
            PicPlayer1.TabIndex = 4;
            PicPlayer1.TabStop = false;
            PicPlayer1.Paint += PicPlayer_Paint;
            // 
            // Player3
            // 
            Player3.AutoSize = true;
            Player3.Font = new Font("맑은 고딕", 9F, FontStyle.Bold);
            Player3.Location = new Point(37, 301);
            Player3.Margin = new Padding(4, 0, 4, 0);
            Player3.Name = "Player3";
            Player3.Size = new Size(61, 20);
            Player3.TabIndex = 6;
            Player3.Text = "Player3";
            Player3.Paint += Player_Paint;
            // 
            // PicPlayer4
            // 
            PicPlayer4.BackColor = Color.Gainsboro;
            PicPlayer4.Location = new Point(200, 185);
            PicPlayer4.Margin = new Padding(4);
            PicPlayer4.Name = "PicPlayer4";
            PicPlayer4.Size = new Size(110, 110);
            PicPlayer4.TabIndex = 4;
            PicPlayer4.TabStop = false;
            PicPlayer4.Paint += PicPlayer_Paint;
            // 
            // PicPlayer3
            // 
            PicPlayer3.BackColor = Color.LightGray;
            PicPlayer3.Location = new Point(37, 185);
            PicPlayer3.Margin = new Padding(4);
            PicPlayer3.Name = "PicPlayer3";
            PicPlayer3.Size = new Size(110, 110);
            PicPlayer3.TabIndex = 4;
            PicPlayer3.TabStop = false;
            PicPlayer3.Paint += PicPlayer_Paint;
            // 
            // RtbChat
            // 
            RtbChat.BackColor = Color.FromArgb(224, 224, 224);
            RtbChat.Location = new Point(422, 79);
            RtbChat.Margin = new Padding(4);
            RtbChat.Name = "RtbChat";
            RtbChat.Size = new Size(353, 325);
            RtbChat.TabIndex = 7;
            RtbChat.Text = "";
            // 
            // BtnSend
            // 
            BtnSend.Font = new Font("맑은 고딕", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 129);
            BtnSend.Location = new Point(691, 416);
            BtnSend.Margin = new Padding(4);
            BtnSend.Name = "BtnSend";
            BtnSend.Size = new Size(84, 30);
            BtnSend.TabIndex = 8;
            BtnSend.Text = "전송";
            BtnSend.UseVisualStyleBackColor = true;
            BtnSend.Click += BtnSend_Click;
            // 
            // BtnColor
            // 
            BtnColor.Font = new Font("맑은 고딕", 12F, FontStyle.Bold);
            BtnColor.Location = new Point(517, 459);
            BtnColor.Name = "BtnColor";
            BtnColor.Size = new Size(120, 120);
            BtnColor.TabIndex = 9;
            BtnColor.Text = "색 변경";
            BtnColor.UseVisualStyleBackColor = true;
            BtnColor.Click += BtnColor_Click;
            // 
            // inputTb
            // 
            inputTb.BackColor = Color.FromArgb(224, 224, 224);
            inputTb.Location = new Point(422, 418);
            inputTb.Name = "inputTb";
            inputTb.Size = new Size(262, 27);
            inputTb.TabIndex = 9;
            inputTb.KeyDown += inputTb_KeyDown;
            // 
            // hostLabel
            // 
            hostLabel.AutoSize = true;
            hostLabel.BackColor = Color.LightGray;
            hostLabel.Location = new Point(34, 429);
            hostLabel.Name = "hostLabel";
            hostLabel.Size = new Size(86, 20);
            hostLabel.TabIndex = 10;
            hostLabel.Text = "Host의 IP : ";
            // 
            // playerPanel
            // 
            playerPanel.BackColor = Color.DarkGray;
            playerPanel.Controls.Add(PicPlayer4);
            playerPanel.Controls.Add(PicPlayer2);
            playerPanel.Controls.Add(PicPlayer3);
            playerPanel.Controls.Add(PicPlayer1);
            playerPanel.Controls.Add(Player1);
            playerPanel.Controls.Add(Player3);
            playerPanel.Controls.Add(Player2);
            playerPanel.Controls.Add(Player4);
            playerPanel.Location = new Point(34, 79);
            playerPanel.Name = "playerPanel";
            playerPanel.Size = new Size(354, 335);
            playerPanel.TabIndex = 11;
            // 
            // wait_label
            // 
            wait_label.AutoSize = true;
            wait_label.BackColor = Color.Gray;
            wait_label.Font = new Font("맑은 고딕", 24F, FontStyle.Bold, GraphicsUnit.Point, 129);
            wait_label.ForeColor = Color.LightGray;
            wait_label.Location = new Point(34, 15);
            wait_label.Name = "wait_label";
            wait_label.Size = new Size(197, 54);
            wait_label.TabIndex = 12;
            wait_label.Text = "게임 대기";
            wait_label.Paint += wait_label_Paint;
            // 
            // shadowPictureBox1
            // 
            shadowPictureBox1.BackColor = Color.FromArgb(64, 64, 64);
            shadowPictureBox1.Location = new Point(558, 9);
            shadowPictureBox1.Name = "shadowPictureBox1";
            shadowPictureBox1.Size = new Size(180, 60);
            shadowPictureBox1.TabIndex = 14;
            shadowPictureBox1.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.FromArgb(64, 64, 64);
            pictureBox1.Location = new Point(42, 467);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(210, 120);
            pictureBox1.TabIndex = 15;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.FromArgb(64, 64, 64);
            pictureBox2.Location = new Point(267, 467);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(210, 120);
            pictureBox2.TabIndex = 16;
            pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = Color.FromArgb(64, 64, 64);
            pictureBox3.Location = new Point(524, 466);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(120, 120);
            pictureBox3.TabIndex = 17;
            pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            pictureBox4.BackColor = Color.FromArgb(64, 64, 64);
            pictureBox4.Location = new Point(662, 467);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(120, 120);
            pictureBox4.TabIndex = 18;
            pictureBox4.TabStop = false;
            // 
            // WaitScene
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DimGray;
            ClientSize = new Size(788, 591);
            Controls.Add(shadowPictureBox1);
            Controls.Add(wait_label);
            Controls.Add(hostLabel);
            Controls.Add(BtnColor);
            Controls.Add(inputTb);
            Controls.Add(BtnSend);
            Controls.Add(RtbChat);
            Controls.Add(BtnLeave);
            Controls.Add(BtnReady);
            Controls.Add(BtnStart);
            Controls.Add(playerPanel);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox4);
            Name = "WaitScene";
            Text = "WaitScene";
            Load += WaitScene_Load;
            ((System.ComponentModel.ISupportInitialize)PicPlayer2).EndInit();
            ((System.ComponentModel.ISupportInitialize)PicPlayer1).EndInit();
            ((System.ComponentModel.ISupportInitialize)PicPlayer4).EndInit();
            ((System.ComponentModel.ISupportInitialize)PicPlayer3).EndInit();
            playerPanel.ResumeLayout(false);
            playerPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)shadowPictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button BtnStart;
        private Button BtnReady;
        private Button BtnLeave;
        private PictureBox PicPlayer2;
        private Label Player1;
        private Label Player2;
        private Label Player4;
        private PictureBox PicPlayer1;
        private Label Player3;
        private PictureBox PicPlayer4;
        private PictureBox PicPlayer3;
        private RichTextBox RtbChat;
        private Button BtnSend;
        private Button BtnColor;
        private ColorDialog cld;
        private TextBox inputTb;
        private Label hostLabel;
        private Panel playerPanel;
        private Label wait_label;
        private PictureBox shadowPictureBox1;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private PictureBox pictureBox4;
    }
}
