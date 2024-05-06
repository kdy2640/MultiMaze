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
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(243, 46);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(0, 15);
            label1.TabIndex = 8;
            // 
            // BackToMain
            // 
            BackToMain.Location = new Point(535, 303);
            BackToMain.Name = "BackToMain";
            BackToMain.Size = new Size(75, 23);
            BackToMain.TabIndex = 9;
            BackToMain.Text = "나가기";
            BackToMain.UseVisualStyleBackColor = true;
            // 
            // First
            // 
            First.AutoSize = true;
            First.Location = new Point(92, 15);
            First.Name = "First";
            First.Size = new Size(29, 15);
            First.TabIndex = 10;
            First.Text = "1등:";
            // 
            // Second
            // 
            Second.AutoSize = true;
            Second.Location = new Point(92, 46);
            Second.Name = "Second";
            Second.Size = new Size(29, 15);
            Second.TabIndex = 11;
            Second.Text = "2등:";
            // 
            // Third
            // 
            Third.AutoSize = true;
            Third.Location = new Point(92, 75);
            Third.Name = "Third";
            Third.Size = new Size(29, 15);
            Third.TabIndex = 12;
            Third.Text = "3등:";
            // 
            // FirstName
            // 
            FirstName.AutoSize = true;
            FirstName.Location = new Point(127, 15);
            FirstName.Name = "FirstName";
            FirstName.Size = new Size(0, 15);
            FirstName.TabIndex = 13;
            // 
            // SecondName
            // 
            SecondName.AutoSize = true;
            SecondName.Location = new Point(127, 46);
            SecondName.Name = "SecondName";
            SecondName.Size = new Size(0, 15);
            SecondName.TabIndex = 14;
            // 
            // ThirdName
            // 
            ThirdName.AutoSize = true;
            ThirdName.Location = new Point(127, 75);
            ThirdName.Name = "ThirdName";
            ThirdName.Size = new Size(0, 15);
            ThirdName.TabIndex = 15;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(92, 93);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(435, 194);
            pictureBox1.TabIndex = 16;
            pictureBox1.TabStop = false;
            // 
            // button1
            // 
            button1.Location = new Point(484, 11);
            button1.Margin = new Padding(2);
            button1.Name = "button1";
            button1.Size = new Size(127, 22);
            button1.TabIndex = 7;
            button1.Text = "1번 화면 이동";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // GameOverScene
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(622, 338);
            Controls.Add(pictureBox1);
            Controls.Add(ThirdName);
            Controls.Add(SecondName);
            Controls.Add(FirstName);
            Controls.Add(Third);
            Controls.Add(Second);
            Controls.Add(First);
            Controls.Add(BackToMain);
            Controls.Add(label1);
            Controls.Add(button1);
            Margin = new Padding(2);
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
        private Button button1;
    }
}