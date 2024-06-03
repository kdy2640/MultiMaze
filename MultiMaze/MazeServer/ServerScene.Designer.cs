namespace MazeServer
{
    partial class ServerScene
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            shutDownServerBtn = new Button();
            logTextBox = new RichTextBox();
            SuspendLayout();
            // 
            // shutDownServerBtn
            // 
            shutDownServerBtn.Location = new Point(270, 276);
            shutDownServerBtn.Name = "shutDownServerBtn";
            shutDownServerBtn.Size = new Size(94, 29);
            shutDownServerBtn.TabIndex = 0;
            shutDownServerBtn.Text = "서버 종료";
            shutDownServerBtn.UseVisualStyleBackColor = true;
            shutDownServerBtn.Click += button1_Click;
            // 
            // logTextBox
            // 
            logTextBox.Location = new Point(12, 21);
            logTextBox.Name = "logTextBox";
            logTextBox.Size = new Size(352, 237);
            logTextBox.TabIndex = 1;
            logTextBox.Text = "";
            // 
            // ServerScene
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(389, 322);
            Controls.Add(logTextBox);
            Controls.Add(shutDownServerBtn);
            Name = "ServerScene";
            Text = "서버로그";
            Load += ServerTempScene_Load;
            ResumeLayout(false);
        }

        #endregion

        public Button shutDownServerBtn;
        private RichTextBox logTextBox;
    }
}
