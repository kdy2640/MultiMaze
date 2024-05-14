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
            main_label = new Label();
            btn_enter = new Button();
            btm_makeroom = new Button();
            button3 = new Button();
            SuspendLayout();
            // 
            // button2
            // 
            button2.Dock = DockStyle.Bottom;
            button2.Location = new Point(0, 437);
            button2.Name = "button2";
            button2.Size = new Size(984, 118);
            button2.TabIndex = 1;
            button2.Text = "나가기";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // main_label
            // 
            main_label.AutoSize = true;
            main_label.Location = new Point(449, 55);
            main_label.Name = "main_label";
            main_label.Size = new Size(74, 20);
            main_label.TabIndex = 2;
            main_label.Text = "메인 화면";
            main_label.Click += label1_Click;
            // 
            // btn_enter
            // 
            btn_enter.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btn_enter.Location = new Point(200, 228);
            btn_enter.Margin = new Padding(3, 2, 3, 2);
            btn_enter.Name = "btn_enter";
            btn_enter.Size = new Size(140, 105);
            btn_enter.TabIndex = 3;
            btn_enter.Text = "방 입장";
            btn_enter.UseVisualStyleBackColor = true;
            btn_enter.Click += button3_Click;
            // 
            // btm_makeroom
            // 
            btm_makeroom.Location = new Point(634, 228);
            btm_makeroom.Margin = new Padding(3, 2, 3, 2);
            btm_makeroom.Name = "btm_makeroom";
            btm_makeroom.Size = new Size(140, 105);
            btm_makeroom.TabIndex = 4;
            btm_makeroom.Text = "방 만들기";
            btm_makeroom.UseVisualStyleBackColor = true;
            btm_makeroom.Click += btm_makeroom_Click;
            // 
            // button3
            // 
            button3.Location = new Point(129, 58);
            button3.Margin = new Padding(3, 2, 3, 2);
            button3.Name = "button3";
            button3.Size = new Size(145, 27);
            button3.TabIndex = 5;
            button3.Text = "로딩창 테스트 ";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click_1;
            // 
            // MainScene
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 555);
            Controls.Add(button3);
            Controls.Add(btm_makeroom);
            Controls.Add(btn_enter);
            Controls.Add(main_label);
            Controls.Add(button2);
            Name = "MainScene";
            Text = "MainScene";
            Load += MainScene_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button button2;
        private Label main_label;
        private Button btn_enter;
        private Button btm_makeroom;
        private Button button3;
    }
}