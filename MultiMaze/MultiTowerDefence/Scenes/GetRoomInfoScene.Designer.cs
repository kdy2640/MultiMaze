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
            SuspendLayout();
            // 
            // hostLabel
            // 
            hostLabel.AutoSize = true;
            hostLabel.Location = new Point(57, 62);
            hostLabel.Name = "hostLabel";
            hostLabel.Size = new Size(48, 20);
            hostLabel.TabIndex = 0;
            hostLabel.Text = "Host :";
            // 
            // portLabel
            // 
            portLabel.AutoSize = true;
            portLabel.Location = new Point(57, 118);
            portLabel.Name = "portLabel";
            portLabel.Size = new Size(45, 20);
            portLabel.TabIndex = 1;
            portLabel.Text = "Port :";
            // 
            // hostTxtbox
            // 
            hostTxtbox.Location = new Point(144, 62);
            hostTxtbox.Margin = new Padding(3, 2, 3, 2);
            hostTxtbox.Name = "hostTxtbox";
            hostTxtbox.Size = new Size(135, 27);
            hostTxtbox.TabIndex = 2;
            // 
            // enterRoomBtn
            // 
            enterRoomBtn.Location = new Point(69, 182);
            enterRoomBtn.Margin = new Padding(3, 2, 3, 2);
            enterRoomBtn.Name = "enterRoomBtn";
            enterRoomBtn.Size = new Size(101, 27);
            enterRoomBtn.TabIndex = 4;
            enterRoomBtn.Text = "확인";
            enterRoomBtn.UseVisualStyleBackColor = true;
            enterRoomBtn.Click += enterRoomBtn_Click;
            // 
            // CancelBtn
            // 
            CancelBtn.Location = new Point(228, 182);
            CancelBtn.Margin = new Padding(3, 2, 3, 2);
            CancelBtn.Name = "CancelBtn";
            CancelBtn.Size = new Size(101, 27);
            CancelBtn.TabIndex = 5;
            CancelBtn.Text = "취소";
            CancelBtn.UseVisualStyleBackColor = true;
            CancelBtn.Click += CancelBtn_Click;
            // 
            // portTxtbox
            // 
            portTxtbox.Location = new Point(144, 118);
            portTxtbox.Margin = new Padding(3, 2, 3, 2);
            portTxtbox.Mask = "99999";
            portTxtbox.Name = "portTxtbox";
            portTxtbox.Size = new Size(135, 27);
            portTxtbox.TabIndex = 6;
            // 
            // GetRoomInfoScene
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(402, 246);
            Controls.Add(portTxtbox);
            Controls.Add(CancelBtn);
            Controls.Add(enterRoomBtn);
            Controls.Add(hostTxtbox);
            Controls.Add(portLabel);
            Controls.Add(hostLabel);
            Margin = new Padding(3, 2, 3, 2);
            Name = "GetRoomInfoScene";
            Text = "서버정보입력";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label hostLabel;
        private Label portLabel;
        private TextBox hostTxtbox;
        private Button enterRoomBtn;
        private Button CancelBtn;
        private MaskedTextBox portTxtbox;
    }
}