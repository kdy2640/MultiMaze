namespace MazeClient.Scenes
{
    partial class GetRoomInfoScene
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
            hostLabel = new Label();
            portLabel = new Label();
            hostTxtbox = new TextBox();
            enterRoomBtn = new Button();
            CancelBtn = new Button();
            portTxtbox = new MaskedTextBox();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // hostLabel
            // 
            hostLabel.AutoSize = true;
            hostLabel.BackColor = Color.Silver;
            hostLabel.Location = new Point(17, 24);
            hostLabel.Name = "hostLabel";
            hostLabel.Size = new Size(71, 20);
            hostLabel.TabIndex = 0;
            hostLabel.Text = "Host Ip : ";
            // 
            // portLabel
            // 
            portLabel.AutoSize = true;
            portLabel.BackColor = Color.Silver;
            portLabel.Location = new Point(17, 80);
            portLabel.Name = "portLabel";
            portLabel.Size = new Size(45, 20);
            portLabel.TabIndex = 1;
            portLabel.Text = "Port :";
            // 
            // hostTxtbox
            // 
            hostTxtbox.Location = new Point(104, 24);
            hostTxtbox.Margin = new Padding(3, 2, 3, 2);
            hostTxtbox.Name = "hostTxtbox";
            hostTxtbox.Size = new Size(187, 27);
            hostTxtbox.TabIndex = 2;
            // 
            // enterRoomBtn
            // 
            enterRoomBtn.Font = new Font("맑은 고딕", 10.2F, FontStyle.Bold);
            enterRoomBtn.Location = new Point(58, 173);
            enterRoomBtn.Margin = new Padding(0);
            enterRoomBtn.Name = "enterRoomBtn";
            enterRoomBtn.Size = new Size(100, 40);
            enterRoomBtn.TabIndex = 4;
            enterRoomBtn.Text = "확인";
            enterRoomBtn.UseVisualStyleBackColor = true;
            enterRoomBtn.Click += enterRoomBtn_Click;
            // 
            // CancelBtn
            // 
            CancelBtn.Font = new Font("맑은 고딕", 10.2F, FontStyle.Bold);
            CancelBtn.Location = new Point(218, 173);
            CancelBtn.Margin = new Padding(0);
            CancelBtn.Name = "CancelBtn";
            CancelBtn.Size = new Size(100, 40);
            CancelBtn.TabIndex = 5;
            CancelBtn.Text = "취소";
            CancelBtn.UseVisualStyleBackColor = true;
            CancelBtn.Click += CancelBtn_Click;
            // 
            // portTxtbox
            // 
            portTxtbox.Location = new Point(104, 80);
            portTxtbox.Margin = new Padding(3, 2, 3, 2);
            portTxtbox.Mask = "99999";
            portTxtbox.Name = "portTxtbox";
            portTxtbox.Size = new Size(187, 27);
            portTxtbox.TabIndex = 6;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.FromArgb(64, 64, 64);
            pictureBox1.Location = new Point(65, 180);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(100, 40);
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.FromArgb(64, 64, 64);
            pictureBox2.Location = new Point(225, 180);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(100, 40);
            pictureBox2.TabIndex = 8;
            pictureBox2.TabStop = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Gray;
            panel1.Controls.Add(portTxtbox);
            panel1.Controls.Add(hostTxtbox);
            panel1.Controls.Add(hostLabel);
            panel1.Controls.Add(portLabel);
            panel1.Location = new Point(25, 32);
            panel1.Name = "panel1";
            panel1.Size = new Size(336, 126);
            panel1.TabIndex = 9;
            // 
            // GetRoomInfoScene
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DimGray;
            ClientSize = new Size(383, 246);
            Controls.Add(CancelBtn);
            Controls.Add(enterRoomBtn);
            Controls.Add(pictureBox1);
            Controls.Add(pictureBox2);
            Controls.Add(panel1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "GetRoomInfoScene";
            Text = "서버정보입력";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label hostLabel;
        private Label portLabel;
        private TextBox hostTxtbox;
        private Button enterRoomBtn;
        private Button CancelBtn;
        private MaskedTextBox portTxtbox;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Panel panel1;
    }
}