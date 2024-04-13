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
            button1 = new Button();
            button2 = new Button();
            label1 = new Label();
            btn_enter = new Button();
            btm_makeroom = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(672, 113);
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
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(442, 70);
            label1.Name = "label1";
            label1.Size = new Size(82, 25);
            label1.TabIndex = 2;
            label1.Text = "1번 화면";
            label1.Click += label1_Click;
            // 
            // btn_enter
            // 
            btn_enter.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btn_enter.Location = new Point(218, 285);
            btn_enter.Name = "btn_enter";
            btn_enter.Size = new Size(155, 131);
            btn_enter.TabIndex = 3;
            btn_enter.Text = "방 입장";
            btn_enter.UseVisualStyleBackColor = true;
            btn_enter.Click += button3_Click;
            // 
            // btm_makeroom
            // 
            btm_makeroom.Location = new Point(704, 285);
            btm_makeroom.Name = "btm_makeroom";
            btm_makeroom.Size = new Size(155, 131);
            btm_makeroom.TabIndex = 4;
            btm_makeroom.Text = "방 만들기";
            btm_makeroom.UseVisualStyleBackColor = true;
            // 
            // MainScene
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1093, 694);
            Controls.Add(btm_makeroom);
            Controls.Add(btn_enter);
            Controls.Add(label1);
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
        private Label label1;
        private Button btn_enter;
        private Button btm_makeroom;
    }
}
