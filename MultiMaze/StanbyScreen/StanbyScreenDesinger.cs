namespace Room
{
    partial class MainForm
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
            this.btnStart = new System.Windows.Forms.Button();
            this.btnReady = new System.Windows.Forms.Button();
            this.btnLeave = new System.Windows.Forms.Button();
            this.picPlayer1 = new System.Windows.Forms.PictureBox();
            this.picPlayer2 = new System.Windows.Forms.PictureBox();
            this.txtplayer1 = new System.Windows.Forms.TextBox();
            this.txtplayer2 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.picPlayer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPlayer2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnStart.Font = new System.Drawing.Font("굴림", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnStart.Location = new System.Drawing.Point(-5, 317);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(438, 177);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = false;
            // 
            // btnReady
            // 
            this.btnReady.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnReady.Font = new System.Drawing.Font("굴림", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnReady.Location = new System.Drawing.Point(429, 317);
            this.btnReady.Name = "btnReady";
            this.btnReady.Size = new System.Drawing.Size(394, 90);
            this.btnReady.TabIndex = 1;
            this.btnReady.Text = "Ready";
            this.btnReady.UseVisualStyleBackColor = false;
            // 
            // btnLeave
            // 
            this.btnLeave.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnLeave.Font = new System.Drawing.Font("굴림", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnLeave.Location = new System.Drawing.Point(429, 404);
            this.btnLeave.Name = "btnLeave";
            this.btnLeave.Size = new System.Drawing.Size(394, 90);
            this.btnLeave.TabIndex = 1;
            this.btnLeave.Text = "나가기";
            this.btnLeave.UseVisualStyleBackColor = false;
            // 
            // picPlayer1
            // 
            this.picPlayer1.Location = new System.Drawing.Point(141, 48);
            this.picPlayer1.Name = "picPlayer1";
            this.picPlayer1.Size = new System.Drawing.Size(177, 177);
            this.picPlayer1.TabIndex = 2;
            this.picPlayer1.TabStop = false;
            // 
            // picPlayer2
            // 
            this.picPlayer2.Location = new System.Drawing.Point(515, 48);
            this.picPlayer2.Name = "picPlayer2";
            this.picPlayer2.Size = new System.Drawing.Size(177, 177);
            this.picPlayer2.TabIndex = 2;
            this.picPlayer2.TabStop = false;
            // 
            // txtplayer1
            // 
            this.txtplayer1.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtplayer1.Location = new System.Drawing.Point(141, 222);
            this.txtplayer1.Name = "txtplayer1";
            this.txtplayer1.Size = new System.Drawing.Size(177, 35);
            this.txtplayer1.TabIndex = 3;
            this.txtplayer1.Text = "Player 1";
            this.txtplayer1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtplayer2
            // 
            this.txtplayer2.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtplayer2.Location = new System.Drawing.Point(515, 222);
            this.txtplayer2.Name = "txtplayer2";
            this.txtplayer2.Size = new System.Drawing.Size(177, 35);
            this.txtplayer2.TabIndex = 3;
            this.txtplayer2.Text = "Player 2";
            this.txtplayer2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(825, 496);
            this.Controls.Add(this.txtplayer2);
            this.Controls.Add(this.txtplayer1);
            this.Controls.Add(this.picPlayer2);
            this.Controls.Add(this.picPlayer1);
            this.Controls.Add(this.btnLeave);
            this.Controls.Add(this.btnReady);
            this.Controls.Add(this.btnStart);
            this.Name = "MainForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.picPlayer1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPlayer2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnReady;
        private System.Windows.Forms.Button btnLeave;
        private System.Windows.Forms.PictureBox picPlayer1;
        private System.Windows.Forms.PictureBox picPlayer2;
        private System.Windows.Forms.TextBox txtplayer1;
        private System.Windows.Forms.TextBox txtplayer2;
    }
}

