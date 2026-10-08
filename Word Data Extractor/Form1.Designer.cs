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
            p_Body = new Panel();
            SuspendLayout();
            // 
            // p_Body
            // 
            p_Body.Dock = DockStyle.Fill;
            p_Body.Location = new Point(0, 0);
            p_Body.Name = "p_Body";
            p_Body.Size = new Size(1275, 753);
            p_Body.TabIndex = 1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1275, 753);
            Controls.Add(p_Body);
            Name = "Form1";
            Text = "Word Data Extractor";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion
        private Panel p_Body;
    }
}
