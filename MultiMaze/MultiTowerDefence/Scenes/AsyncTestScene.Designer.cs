namespace MazeClient.Scenes
{
    partial class AsyncTestScene
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
            button = new Button();
            label1 = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // button
            // 
            button.Location = new Point(41, 87);
            button.Margin = new Padding(2, 2, 2, 2);
            button.Name = "button";
            button.Size = new Size(192, 77);
            button.TabIndex = 0;
            button.Text = "비동기 테스트";
            button.UseVisualStyleBackColor = true;
            button.Click += button_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(244, 205);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 1;
            label1.Text = "label1";
            // 
            // button1
            // 
            button1.Location = new Point(312, 87);
            button1.Margin = new Padding(2);
            button1.Name = "button1";
            button1.Size = new Size(192, 77);
            button1.TabIndex = 2;
            button1.Text = "카운트다운 테스트";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // AsyncTestScene
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(560, 270);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(button);
            Margin = new Padding(2, 2, 2, 2);
            Name = "AsyncTestScene";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button;
        private Label label1;
        private Button button1;
    }
}