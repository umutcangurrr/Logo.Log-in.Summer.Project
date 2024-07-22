namespace Settings_Application
{
    partial class Form1
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
            Start_btn = new Button();
            MonitorInterval_nud = new NumericUpDown();
            MInterval_lbl = new Label();
            panel1 = new Panel();
            label1 = new Label();
            Choice_lb = new Label();
            ServiceName_txt = new TextBox();
            SelectionService_cb = new ComboBox();
            panel2 = new Panel();
            panel3 = new Panel();
            LogLevelSelection_cb = new ComboBox();
            LogLevel_lbl = new Label();
            ((System.ComponentModel.ISupportInitialize)MonitorInterval_nud).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // Start_btn
            // 
            Start_btn.Location = new Point(349, 488);
            Start_btn.Name = "Start_btn";
            Start_btn.Size = new Size(142, 40);
            Start_btn.TabIndex = 0;
            Start_btn.Text = "Start";
            Start_btn.UseVisualStyleBackColor = true;
            Start_btn.Click += Start_btn_Click;
            // 
            // MonitorInterval_nud
            // 
            MonitorInterval_nud.Location = new Point(44, 32);
            MonitorInterval_nud.Name = "MonitorInterval_nud";
            MonitorInterval_nud.Size = new Size(173, 31);
            MonitorInterval_nud.TabIndex = 2;
            // 
            // MInterval_lbl
            // 
            MInterval_lbl.AutoSize = true;
            MInterval_lbl.Location = new Point(336, 267);
            MInterval_lbl.Name = "MInterval_lbl";
            MInterval_lbl.Size = new Size(164, 25);
            MInterval_lbl.TabIndex = 8;
            MInterval_lbl.Text = "Monitoring Interval";
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveCaption;
            panel1.Controls.Add(label1);
            panel1.Controls.Add(Choice_lb);
            panel1.Controls.Add(ServiceName_txt);
            panel1.Controls.Add(SelectionService_cb);
            panel1.Location = new Point(34, 52);
            panel1.Name = "panel1";
            panel1.Size = new Size(270, 158);
            panel1.TabIndex = 9;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(16, 67);
            label1.Name = "label1";
            label1.Size = new Size(119, 25);
            label1.TabIndex = 19;
            label1.Text = "Service Name";
            // 
            // Choice_lb
            // 
            Choice_lb.AutoSize = true;
            Choice_lb.Location = new Point(20, 2);
            Choice_lb.Name = "Choice_lb";
            Choice_lb.Size = new Size(143, 25);
            Choice_lb.TabIndex = 18;
            Choice_lb.Text = "Service Selection";
            // 
            // ServiceName_txt
            // 
            ServiceName_txt.Location = new Point(16, 95);
            ServiceName_txt.Name = "ServiceName_txt";
            ServiceName_txt.Size = new Size(182, 31);
            ServiceName_txt.TabIndex = 17;
            // 
            // SelectionService_cb
            // 
            SelectionService_cb.FormattingEnabled = true;
            SelectionService_cb.Items.AddRange(new object[] { "Windows Service", "WebAPI Service" });
            SelectionService_cb.Location = new Point(16, 25);
            SelectionService_cb.Name = "SelectionService_cb";
            SelectionService_cb.Size = new Size(182, 33);
            SelectionService_cb.TabIndex = 16;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.Info;
            panel2.Controls.Add(MonitorInterval_nud);
            panel2.Location = new Point(292, 295);
            panel2.Name = "panel2";
            panel2.Size = new Size(262, 91);
            panel2.TabIndex = 10;
            // 
            // panel3
            // 
            panel3.BackColor = Color.RosyBrown;
            panel3.Controls.Add(LogLevelSelection_cb);
            panel3.Location = new Point(506, 52);
            panel3.Name = "panel3";
            panel3.Size = new Size(292, 112);
            panel3.TabIndex = 14;
            // 
            // LogLevelSelection_cb
            // 
            LogLevelSelection_cb.FormattingEnabled = true;
            LogLevelSelection_cb.Items.AddRange(new object[] { "Fatal", "Error", "Warn", "Information", "Debug" });
            LogLevelSelection_cb.Location = new Point(59, 38);
            LogLevelSelection_cb.Name = "LogLevelSelection_cb";
            LogLevelSelection_cb.Size = new Size(182, 33);
            LogLevelSelection_cb.TabIndex = 20;
            // 
            // LogLevel_lbl
            // 
            LogLevel_lbl.AutoSize = true;
            LogLevel_lbl.Location = new Point(574, 24);
            LogLevel_lbl.Name = "LogLevel_lbl";
            LogLevel_lbl.Size = new Size(162, 25);
            LogLevel_lbl.TabIndex = 15;
            LogLevel_lbl.Text = "Log Level Selection";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(922, 554);
            Controls.Add(LogLevel_lbl);
            Controls.Add(panel3);
            Controls.Add(MInterval_lbl);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(Start_btn);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)MonitorInterval_nud).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Start_btn;
        private NumericUpDown MonitorInterval_nud;
        private Label MInterval_lbl;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Label LogLevel_lbl;
        private ComboBox SelectionService_cb;
        private TextBox ServiceName_txt;
        private Label label1;
        private Label Choice_lb;
        private ComboBox LogLevelSelection_cb;
    }
}
