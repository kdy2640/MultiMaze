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

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            PicPlayer1 = new PictureBox();
            BtnStart = new Button();
            BtnReady = new Button();
            BtnLeave = new Button();
            lblPlayer1 = new Label();
            lblPlayer2 = new Label();
            PicPlayer2 = new PictureBox();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)PicPlayer1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PicPlayer2).BeginInit();
            SuspendLayout();
            // 
            // PicPlayer1
            // 
            PicPlayer1.Location = new Point(202, 196);
            PicPlayer1.Margin = new Padding(3, 4, 3, 4);
            PicPlayer1.Name = "PicPlayer1";
            PicPlayer1.Size = new Size(29, 32);
            PicPlayer1.TabIndex = 0;
            PicPlayer1.TabStop = false;
            // 
            // BtnStart
            // 
            BtnStart.Location = new Point(-2, 412);
            BtnStart.Margin = new Padding(3, 4, 3, 4);
            BtnStart.Name = "BtnStart";
            BtnStart.Size = new Size(413, 152);
            BtnStart.TabIndex = 1;
            BtnStart.Text = "Start";
            BtnStart.UseVisualStyleBackColor = true;
            BtnStart.Click += BtnStart_Click;
            // 
            // BtnReady
            // 
            BtnReady.Location = new Point(409, 412);
            BtnReady.Margin = new Padding(3, 4, 3, 4);
            BtnReady.Name = "BtnReady";
            BtnReady.Size = new Size(389, 79);
            BtnReady.TabIndex = 1;
            BtnReady.Text = "Ready";
            BtnReady.UseVisualStyleBackColor = true;
            BtnReady.Click += BtnReady_Click;
            // 
            // BtnLeave
            // 
            BtnLeave.Location = new Point(409, 486);
            BtnLeave.Margin = new Padding(3, 4, 3, 4);
            BtnLeave.Name = "BtnLeave";
            BtnLeave.Size = new Size(389, 79);
            BtnLeave.TabIndex = 1;
            BtnLeave.Text = "나가기";
            BtnLeave.UseVisualStyleBackColor = true;
            BtnLeave.Click += BtnLeave_Click;
            // 
            // lblPlayer1
            // 
            lblPlayer1.AutoSize = true;
            lblPlayer1.Location = new Point(200, 310);
            lblPlayer1.Name = "lblPlayer1";
            lblPlayer1.Size = new Size(50, 15);
            lblPlayer1.TabIndex = 2;
            lblPlayer1.Text = "Player 1";
            // 
            // lblPlayer2
            // 
            lblPlayer2.AutoSize = true;
            lblPlayer2.Location = new Point(556, 310);
            lblPlayer2.Name = "lblPlayer2";
            lblPlayer2.Size = new Size(46, 15);
            lblPlayer2.TabIndex = 2;
            lblPlayer2.Text = "Player2";
            // 
            // PicPlayer2
            // 
            PicPlayer2.Location = new Point(558, 196);
            PicPlayer2.Margin = new Padding(3, 4, 3, 4);
            PicPlayer2.Name = "PicPlayer2";
            PicPlayer2.Size = new Size(29, 32);
            PicPlayer2.TabIndex = 0;
            PicPlayer2.TabStop = false;
            // 
            // button1
            // 
            button1.Location = new Point(669, 252);
            button1.Name = "button1";
            button1.Size = new Size(108, 23);
            button1.TabIndex = 3;
            button1.Text = "4번화면 이동";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // WaitScene
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 562);
            Controls.Add(button1);
            Controls.Add(lblPlayer2);
            Controls.Add(lblPlayer1);
            Controls.Add(BtnLeave);
            Controls.Add(BtnReady);
            Controls.Add(BtnStart);
            Controls.Add(PicPlayer2);
            Controls.Add(PicPlayer1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "WaitScene";
            Text = "WaitScene";
            //Load += WaitScene_Load;
            ((System.ComponentModel.ISupportInitialize)PicPlayer1).EndInit();
            ((System.ComponentModel.ISupportInitialize)PicPlayer2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.PictureBox PicPlayer1;
        private System.Windows.Forms.Button BtnStart;
        private System.Windows.Forms.Button BtnReady;
        private System.Windows.Forms.Button BtnLeave;
        private System.Windows.Forms.Label lblPlayer1;
        private System.Windows.Forms.Label lblPlayer2;
        private System.Windows.Forms.PictureBox PicPlayer2;
        private Button button1;
    }
}

