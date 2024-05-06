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
            button1 = new Button();
            label1 = new Label();
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
            ((System.ComponentModel.ISupportInitialize)PicPlayer2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PicPlayer1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PicPlayer4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PicPlayer3).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(563, 43);
            button1.Margin = new Padding(2);
            button1.Name = "button1";
            button1.Size = new Size(124, 22);
            button1.TabIndex = 0;
            button1.Text = "4번 화면 이동";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(328, 9);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(54, 15);
            label1.TabIndex = 2;
            label1.Text = "3번 화면";
            // 
            // BtnStart
            // 
            BtnStart.Location = new Point(0, 342);
            BtnStart.Name = "BtnStart";
            BtnStart.Size = new Size(359, 127);
            BtnStart.TabIndex = 3;
            BtnStart.Text = "Start";
            BtnStart.UseVisualStyleBackColor = true;
            BtnStart.Click += BtnStart_Click;
            // 
            // BtnReady
            // 
            BtnReady.Location = new Point(356, 342);
            BtnReady.Name = "BtnReady";
            BtnReady.Size = new Size(359, 69);
            BtnReady.TabIndex = 3;
            BtnReady.Text = "준비";
            BtnReady.UseVisualStyleBackColor = true;
            BtnReady.Click += BtnReady_Click;
            // 
            // BtnLeave
            // 
            BtnLeave.Location = new Point(356, 405);
            BtnLeave.Name = "BtnLeave";
            BtnLeave.Size = new Size(359, 64);
            BtnLeave.TabIndex = 3;
            BtnLeave.Text = "나가기";
            BtnLeave.UseVisualStyleBackColor = true;
            BtnLeave.Click += BtnLeave_Click;
            // 
            // PicPlayer2
            // 
            PicPlayer2.Location = new Point(297, 56);
            PicPlayer2.Name = "PicPlayer2";
            PicPlayer2.Size = new Size(100, 86);
            PicPlayer2.TabIndex = 4;
            PicPlayer2.TabStop = false;
            // 
            // Player1
            // 
            Player1.AutoSize = true;
            Player1.Location = new Point(159, 145);
            Player1.Name = "Player1";
            Player1.Size = new Size(46, 15);
            Player1.TabIndex = 6;
            Player1.Text = "Player1";
            // 
            // Player2
            // 
            Player2.AutoSize = true;
            Player2.Location = new Point(328, 145);
            Player2.Name = "Player2";
            Player2.Size = new Size(46, 15);
            Player2.TabIndex = 6;
            Player2.Text = "Player2";
            // 
            // Player4
            // 
            Player4.AutoSize = true;
            Player4.Location = new Point(328, 262);
            Player4.Name = "Player4";
            Player4.Size = new Size(46, 15);
            Player4.TabIndex = 6;
            Player4.Text = "Player4";
            // 
            // PicPlayer1
            // 
            PicPlayer1.Location = new Point(127, 56);
            PicPlayer1.Name = "PicPlayer1";
            PicPlayer1.Size = new Size(100, 86);
            PicPlayer1.TabIndex = 4;
            PicPlayer1.TabStop = false;
            // 
            // Player3
            // 
            Player3.AutoSize = true;
            Player3.Location = new Point(159, 262);
            Player3.Name = "Player3";
            Player3.Size = new Size(46, 15);
            Player3.TabIndex = 6;
            Player3.Text = "Player3";
            // 
            // PicPlayer4
            // 
            PicPlayer4.Location = new Point(297, 175);
            PicPlayer4.Name = "PicPlayer4";
            PicPlayer4.Size = new Size(100, 84);
            PicPlayer4.TabIndex = 4;
            PicPlayer4.TabStop = false;
            // 
            // PicPlayer3
            // 
            PicPlayer3.Location = new Point(127, 175);
            PicPlayer3.Name = "PicPlayer3";
            PicPlayer3.Size = new Size(100, 84);
            PicPlayer3.TabIndex = 4;
            PicPlayer3.TabStop = false;
            // 
            // RtbChat
            // 
            RtbChat.Location = new Point(447, 70);
            RtbChat.Name = "RtbChat";
            RtbChat.Size = new Size(228, 245);
            RtbChat.TabIndex = 7;
            RtbChat.Text = "";
            // 
            // BtnSend
            // 
            BtnSend.Location = new Point(600, 313);
            BtnSend.Name = "BtnSend";
            BtnSend.Size = new Size(75, 23);
            BtnSend.TabIndex = 8;
            BtnSend.Text = "전송";
            BtnSend.UseVisualStyleBackColor = true;
            BtnSend.Click += BtnSend_Click;
            // 
            // WaitScene
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(739, 470);
            Controls.Add(BtnSend);
            Controls.Add(RtbChat);
            Controls.Add(Player3);
            Controls.Add(Player4);
            Controls.Add(Player2);
            Controls.Add(Player1);
            Controls.Add(PicPlayer1);
            Controls.Add(PicPlayer3);
            Controls.Add(PicPlayer4);
            Controls.Add(PicPlayer2);
            Controls.Add(BtnLeave);
            Controls.Add(BtnReady);
            Controls.Add(BtnStart);
            Controls.Add(label1);
            Controls.Add(button1);
            Margin = new Padding(2);
            Name = "WaitScene";
            ((System.ComponentModel.ISupportInitialize)PicPlayer2).EndInit();
            ((System.ComponentModel.ISupportInitialize)PicPlayer1).EndInit();
            ((System.ComponentModel.ISupportInitialize)PicPlayer4).EndInit();
            ((System.ComponentModel.ISupportInitialize)PicPlayer3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label label1;
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
    }
}
