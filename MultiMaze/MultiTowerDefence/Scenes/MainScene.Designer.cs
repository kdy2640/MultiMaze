﻿namespace MazeClient
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
            button1 = new Button();
            button2 = new Button();
            main_label = new Label();
            btn_enter = new Button();
            btm_makeroom = new Button();
            button3 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(873, 82);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(149, 36);
            button1.TabIndex = 0;
            button1.Text = "2번화면 이동";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Dock = DockStyle.Bottom;
            button2.Location = new Point(0, 546);
            button2.Margin = new Padding(3, 4, 3, 4);
            button2.Name = "button2";
            button2.Size = new Size(1093, 148);
            button2.TabIndex = 1;
            button2.Text = "나가기";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // main_label
            // 
            main_label.AutoSize = true;
            main_label.Location = new Point(499, 69);
            main_label.Name = "main_label";
            main_label.Size = new Size(90, 25);
            main_label.TabIndex = 2;
            main_label.Text = "메인 화면";
            main_label.Click += label1_Click;
            // 
            // btn_enter
            // 
            btn_enter.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btn_enter.Location = new Point(222, 285);
            btn_enter.Margin = new Padding(3, 2, 3, 2);
            btn_enter.Name = "btn_enter";
            btn_enter.Size = new Size(156, 131);
            btn_enter.TabIndex = 3;
            btn_enter.Text = "방 입장";
            btn_enter.UseVisualStyleBackColor = true;
            btn_enter.Click += button3_Click;
            // 
            // btm_makeroom
            // 
            btm_makeroom.Location = new Point(704, 285);
            btm_makeroom.Margin = new Padding(3, 2, 3, 2);
            btm_makeroom.Name = "btm_makeroom";
            btm_makeroom.Size = new Size(156, 131);
            btm_makeroom.TabIndex = 4;
            btm_makeroom.Text = "방 만들기";
            btm_makeroom.UseVisualStyleBackColor = true;
            btm_makeroom.Click += btm_makeroom_Click;
            // 
            // button3
            // 
            button3.Location = new Point(143, 73);
            button3.Name = "button3";
            button3.Size = new Size(161, 34);
            button3.TabIndex = 5;
            button3.Text = "로딩창 테스트 ";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click_1;
            // 
            // MainScene
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1093, 694);
            Controls.Add(button3);
            Controls.Add(btm_makeroom);
            Controls.Add(btn_enter);
            Controls.Add(main_label);
            Controls.Add(button2);
            Controls.Add(button1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "MainScene";
            Text = "MainScene";
            Load += MainScene_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private Label main_label;
        private Button btn_enter;
        private Button btm_makeroom;
        private Button button3;
    }
}