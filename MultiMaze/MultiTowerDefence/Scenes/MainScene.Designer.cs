namespace MazeClient
{
    partial class MainScene
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
            button2 = new Button();
            btn_enter = new Button();
            btm_makeroom = new Button();
            button3 = new Button();
            MultiMazeLabel = new Label();
            pictureBox1 = new PictureBox();
            buttonShadowPictureBox1 = new PictureBox();
            buttonShadowPictureBox2 = new PictureBox();
            buttonShadowPictureBox3 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)buttonShadowPictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)buttonShadowPictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)buttonShadowPictureBox3).BeginInit();
            SuspendLayout();
            // 
            // button2
            // 
            button2.Font = new Font("맑은 고딕", 13.8F, FontStyle.Bold);
            button2.Location = new Point(390, 460);
            button2.Margin = new Padding(0);
            button2.Name = "button2";
            button2.Size = new Size(220, 60);
            button2.TabIndex = 1;
            button2.Text = "나가기";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // btn_enter
            // 
            btn_enter.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btn_enter.Font = new Font("맑은 고딕", 13.8F, FontStyle.Bold);
            btn_enter.Location = new Point(390, 300);
            btn_enter.Margin = new Padding(0);
            btn_enter.Name = "btn_enter";
            btn_enter.Size = new Size(220, 60);
            btn_enter.TabIndex = 3;
            btn_enter.Text = "방 입장";
            btn_enter.UseVisualStyleBackColor = true;
            btn_enter.Click += button3_Click;
            // 
            // btm_makeroom
            // 
            btm_makeroom.Font = new Font("맑은 고딕", 13.8F, FontStyle.Bold);
            btm_makeroom.Location = new Point(390, 380);
            btm_makeroom.Margin = new Padding(0);
            btm_makeroom.Name = "btm_makeroom";
            btm_makeroom.Size = new Size(220, 60);
            btm_makeroom.TabIndex = 4;
            btm_makeroom.Text = "방 만들기";
            btm_makeroom.UseVisualStyleBackColor = true;
            btm_makeroom.Click += btm_makeroom_Click;
            // 
            // button3
            // 
            button3.Location = new Point(909, 541);
            button3.Margin = new Padding(3, 2, 3, 2);
            button3.Name = "button3";
            button3.Size = new Size(145, 27);
            button3.TabIndex = 5;
            button3.Text = "로딩창 테스트 ";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click_1;
            // 
            // MultiMazeLabel
            // 
            MultiMazeLabel.AutoSize = true;
            MultiMazeLabel.BackColor = Color.Gray;
            MultiMazeLabel.Font = new Font("맑은 고딕", 90F, FontStyle.Bold, GraphicsUnit.Point, 129);
            MultiMazeLabel.ForeColor = Color.LightGray;
            MultiMazeLabel.Location = new Point(91, 67);
            MultiMazeLabel.Name = "MultiMazeLabel";
            MultiMazeLabel.Size = new Size(841, 199);
            MultiMazeLabel.TabIndex = 6;
            MultiMazeLabel.Text = "MultiMaze";
            MultiMazeLabel.Paint += MultiMazeLabel_Paint;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Gray;
            pictureBox1.Location = new Point(0, 60);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(990, 208);
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
            // 
            // buttonShadowPictureBox1
            // 
            buttonShadowPictureBox1.BackColor = Color.FromArgb(64, 64, 64);
            buttonShadowPictureBox1.Location = new Point(397, 307);
            buttonShadowPictureBox1.Name = "buttonShadowPictureBox1";
            buttonShadowPictureBox1.Size = new Size(220, 60);
            buttonShadowPictureBox1.TabIndex = 8;
            buttonShadowPictureBox1.TabStop = false;
            // 
            // buttonShadowPictureBox2
            // 
            buttonShadowPictureBox2.BackColor = Color.FromArgb(64, 64, 64);
            buttonShadowPictureBox2.Location = new Point(397, 387);
            buttonShadowPictureBox2.Name = "buttonShadowPictureBox2";
            buttonShadowPictureBox2.Size = new Size(220, 60);
            buttonShadowPictureBox2.TabIndex = 9;
            buttonShadowPictureBox2.TabStop = false;
            // 
            // buttonShadowPictureBox3
            // 
            buttonShadowPictureBox3.BackColor = Color.FromArgb(64, 64, 64);
            buttonShadowPictureBox3.Location = new Point(397, 467);
            buttonShadowPictureBox3.Name = "buttonShadowPictureBox3";
            buttonShadowPictureBox3.Size = new Size(220, 60);
            buttonShadowPictureBox3.TabIndex = 10;
            buttonShadowPictureBox3.TabStop = false;
            // 
            // MainScene
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DimGray;
            ClientSize = new Size(984, 555);
            Controls.Add(MultiMazeLabel);
            Controls.Add(button3);
            Controls.Add(btm_makeroom);
            Controls.Add(btn_enter);
            Controls.Add(button2);
            Controls.Add(buttonShadowPictureBox1);
            Controls.Add(buttonShadowPictureBox2);
            Controls.Add(buttonShadowPictureBox3);
            Controls.Add(pictureBox1);
            ForeColor = SystemColors.ControlText;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "MainScene";
            Text = "Multimaze";
            Load += MainScene_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)buttonShadowPictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)buttonShadowPictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)buttonShadowPictureBox3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button button2;
        private Button btn_enter;
        private Button btm_makeroom;
        private Button button3;
        private Label MultiMazeLabel;
        private PictureBox pictureBox1;
        private PictureBox buttonShadowPictureBox1;
        private PictureBox buttonShadowPictureBox2;
        private PictureBox buttonShadowPictureBox3;
    }
}