namespace MazeClient
{
    partial class GameOverScene
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
            label1 = new Label();
            BackToMain = new Button();
            First = new Label();
            Second = new Label();
            Third = new Label();
            FirstName = new Label();
            SecondName = new Label();
            ThirdName = new Label();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(312, 61);
            label1.Name = "label1";
            label1.Size = new Size(0, 20);
            label1.TabIndex = 8;
            // 
            // BackToMain
            // 
            BackToMain.Location = new Point(688, 404);
            BackToMain.Margin = new Padding(4, 4, 4, 4);
            BackToMain.Name = "BackToMain";
            BackToMain.Size = new Size(96, 31);
            BackToMain.TabIndex = 9;
            BackToMain.Text = "나가기";
            BackToMain.UseVisualStyleBackColor = true;
            // 
            // First
            // 
            First.AutoSize = true;
            First.Location = new Point(118, 20);
            First.Margin = new Padding(4, 0, 4, 0);
            First.Name = "First";
            First.Size = new Size(35, 20);
            First.TabIndex = 10;
            First.Text = "1등:";
            // 
            // Second
            // 
            Second.AutoSize = true;
            Second.Location = new Point(118, 61);
            Second.Margin = new Padding(4, 0, 4, 0);
            Second.Name = "Second";
            Second.Size = new Size(35, 20);
            Second.TabIndex = 11;
            Second.Text = "2등:";
            // 
            // Third
            // 
            Third.AutoSize = true;
            Third.Location = new Point(118, 100);
            Third.Margin = new Padding(4, 0, 4, 0);
            Third.Name = "Third";
            Third.Size = new Size(35, 20);
            Third.TabIndex = 12;
            Third.Text = "3등:";
            // 
            // FirstName
            // 
            FirstName.AutoSize = true;
            FirstName.Location = new Point(163, 20);
            FirstName.Margin = new Padding(4, 0, 4, 0);
            FirstName.Name = "FirstName";
            FirstName.Size = new Size(0, 20);
            FirstName.TabIndex = 13;
            // 
            // SecondName
            // 
            SecondName.AutoSize = true;
            SecondName.Location = new Point(163, 61);
            SecondName.Margin = new Padding(4, 0, 4, 0);
            SecondName.Name = "SecondName";
            SecondName.Size = new Size(0, 20);
            SecondName.TabIndex = 14;
            // 
            // ThirdName
            // 
            ThirdName.AutoSize = true;
            ThirdName.Location = new Point(163, 100);
            ThirdName.Margin = new Padding(4, 0, 4, 0);
            ThirdName.Name = "ThirdName";
            ThirdName.Size = new Size(0, 20);
            ThirdName.TabIndex = 15;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(118, 124);
            pictureBox1.Margin = new Padding(4, 4, 4, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(559, 259);
            pictureBox1.TabIndex = 16;
            pictureBox1.TabStop = false;
            // 
            // GameOverScene
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 451);
            Controls.Add(pictureBox1);
            Controls.Add(ThirdName);
            Controls.Add(SecondName);
            Controls.Add(FirstName);
            Controls.Add(Third);
            Controls.Add(Second);
            Controls.Add(First);
            Controls.Add(BackToMain);
            Controls.Add(label1);
            Name = "GameOverScene";
            Text = "GameOver";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button BackToMain;
        private Label First;
        private Label Second;
        private Label Third;
        private Label FirstName;
        private Label SecondName;
        private Label ThirdName;
        private PictureBox pictureBox1;
    }
}