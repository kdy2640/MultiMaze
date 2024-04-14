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
            hostLabel.Location = new Point(63, 77);
            hostLabel.Name = "hostLabel";
            hostLabel.Size = new Size(60, 25);
            hostLabel.TabIndex = 0;
            hostLabel.Text = "Host :";
            // 
            // portLabel
            // 
            portLabel.AutoSize = true;
            portLabel.Location = new Point(63, 147);
            portLabel.Name = "portLabel";
            portLabel.Size = new Size(55, 25);
            portLabel.TabIndex = 1;
            portLabel.Text = "Port :";
            // 
            // hostTxtbox
            // 
            hostTxtbox.Location = new Point(160, 77);
            hostTxtbox.Name = "hostTxtbox";
            hostTxtbox.Size = new Size(150, 31);
            hostTxtbox.TabIndex = 2;
            // 
            // enterRoomBtn
            // 
            enterRoomBtn.Location = new Point(77, 227);
            enterRoomBtn.Name = "enterRoomBtn";
            enterRoomBtn.Size = new Size(112, 34);
            enterRoomBtn.TabIndex = 4;
            enterRoomBtn.Text = "확인";
            enterRoomBtn.UseVisualStyleBackColor = true;
            enterRoomBtn.Click += enterRoomBtn_Click;
            // 
            // CancelBtn
            // 
            CancelBtn.Location = new Point(253, 227);
            CancelBtn.Name = "CancelBtn";
            CancelBtn.Size = new Size(112, 34);
            CancelBtn.TabIndex = 5;
            CancelBtn.Text = "취소";
            CancelBtn.UseVisualStyleBackColor = true;
            CancelBtn.Click += CancelBtn_Click;
            // 
            // portTxtbox
            // 
            portTxtbox.Location = new Point(160, 147);
            portTxtbox.Mask = "99999";
            portTxtbox.Name = "portTxtbox";
            portTxtbox.Size = new Size(150, 31);
            portTxtbox.TabIndex = 6;
            // 
            // GetRoomInfoScene
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(447, 308);
            Controls.Add(portTxtbox);
            Controls.Add(CancelBtn);
            Controls.Add(enterRoomBtn);
            Controls.Add(hostTxtbox);
            Controls.Add(portLabel);
            Controls.Add(hostLabel);
            Name = "GetRoomInfoScene";
            Text = "Form1";
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