namespace Word_Data_Extractor
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
            p_Header = new FlowLayoutPanel();
            p_Body = new Panel();
            p_leftSpacing = new Panel();
            p_rightSpacing = new Panel();
            SuspendLayout();
            // 
            // p_Header
            // 
            p_Header.Dock = DockStyle.Top;
            p_Header.Location = new Point(0, 0);
            p_Header.Name = "p_Header";
            p_Header.Size = new Size(1275, 19);
            p_Header.TabIndex = 0;
            // 
            // p_Body
            // 
            p_Body.Dock = DockStyle.Fill;
            p_Body.Location = new Point(21, 19);
            p_Body.Name = "p_Body";
            p_Body.Size = new Size(1254, 734);
            p_Body.TabIndex = 1;
            // 
            // p_leftSpacing
            // 
            p_leftSpacing.Dock = DockStyle.Left;
            p_leftSpacing.Location = new Point(0, 19);
            p_leftSpacing.Name = "p_leftSpacing";
            p_leftSpacing.Size = new Size(21, 734);
            p_leftSpacing.TabIndex = 0;
            // 
            // p_rightSpacing
            // 
            p_rightSpacing.Dock = DockStyle.Right;
            p_rightSpacing.Location = new Point(1243, 19);
            p_rightSpacing.Name = "p_rightSpacing";
            p_rightSpacing.Size = new Size(32, 734);
            p_rightSpacing.TabIndex = 1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1275, 753);
            Controls.Add(p_rightSpacing);
            Controls.Add(p_Body);
            Controls.Add(p_leftSpacing);
            Controls.Add(p_Header);
            Name = "Form1";
            Text = "Word Data Extractor";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel p_Header;
        private Panel p_Body;
        private Panel p_rightSpacing;
        private Panel p_leftSpacing;
    }
}
