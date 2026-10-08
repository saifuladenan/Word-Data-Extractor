namespace Word_Data_Extractor
{
    partial class MainForm
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
            p_Setting = new Panel();
            gb_FilterContainer = new GroupBox();
            p_FilterContainer = new Panel();
            p_FilterSetting = new Panel();
            panel2 = new Panel();
            cb_FilterForm = new ComboBox();
            panel1 = new Panel();
            btn_AddFilterForm = new Button();
            gb_DirectoryContainer = new GroupBox();
            lbl_totalFiles = new Label();
            lbl_FileFound = new Label();
            btn_browse = new Button();
            txt_directory = new TextBox();
            p_Data = new Panel();
            dataGridView1 = new DataGridView();
            panel3 = new Panel();
            btn_reset = new Button();
            btn_FilterData = new Button();
            button1 = new Button();
            panel5 = new Panel();
            panel7 = new Panel();
            panel8 = new Panel();
            p_Setting.SuspendLayout();
            gb_FilterContainer.SuspendLayout();
            p_FilterSetting.SuspendLayout();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            gb_DirectoryContainer.SuspendLayout();
            p_Data.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // p_Setting
            // 
            p_Setting.Controls.Add(gb_FilterContainer);
            p_Setting.Controls.Add(gb_DirectoryContainer);
            p_Setting.Dock = DockStyle.Left;
            p_Setting.Location = new Point(10, 0);
            p_Setting.Name = "p_Setting";
            p_Setting.Size = new Size(312, 650);
            p_Setting.TabIndex = 0;
            // 
            // gb_FilterContainer
            // 
            gb_FilterContainer.Controls.Add(p_FilterContainer);
            gb_FilterContainer.Controls.Add(p_FilterSetting);
            gb_FilterContainer.Dock = DockStyle.Fill;
            gb_FilterContainer.Location = new Point(0, 66);
            gb_FilterContainer.Name = "gb_FilterContainer";
            gb_FilterContainer.Size = new Size(312, 584);
            gb_FilterContainer.TabIndex = 2;
            gb_FilterContainer.TabStop = false;
            gb_FilterContainer.Text = "Select Filter";
            // 
            // p_FilterContainer
            // 
            p_FilterContainer.AutoScroll = true;
            p_FilterContainer.AutoSize = true;
            p_FilterContainer.Dock = DockStyle.Fill;
            p_FilterContainer.Location = new Point(3, 44);
            p_FilterContainer.Name = "p_FilterContainer";
            p_FilterContainer.Size = new Size(306, 537);
            p_FilterContainer.TabIndex = 1;
            // 
            // p_FilterSetting
            // 
            p_FilterSetting.Controls.Add(panel2);
            p_FilterSetting.Controls.Add(panel1);
            p_FilterSetting.Dock = DockStyle.Top;
            p_FilterSetting.Location = new Point(3, 19);
            p_FilterSetting.Name = "p_FilterSetting";
            p_FilterSetting.Size = new Size(306, 25);
            p_FilterSetting.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Controls.Add(cb_FilterForm);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(222, 25);
            panel2.TabIndex = 1;
            // 
            // cb_FilterForm
            // 
            cb_FilterForm.Dock = DockStyle.Fill;
            cb_FilterForm.FormattingEnabled = true;
            cb_FilterForm.Location = new Point(0, 0);
            cb_FilterForm.Name = "cb_FilterForm";
            cb_FilterForm.Size = new Size(222, 23);
            cb_FilterForm.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(btn_AddFilterForm);
            panel1.Dock = DockStyle.Right;
            panel1.Location = new Point(222, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(84, 25);
            panel1.TabIndex = 0;
            // 
            // btn_AddFilterForm
            // 
            btn_AddFilterForm.Dock = DockStyle.Fill;
            btn_AddFilterForm.Location = new Point(0, 0);
            btn_AddFilterForm.Name = "btn_AddFilterForm";
            btn_AddFilterForm.Size = new Size(84, 25);
            btn_AddFilterForm.TabIndex = 0;
            btn_AddFilterForm.Text = "Add Filter";
            btn_AddFilterForm.UseVisualStyleBackColor = true;
            btn_AddFilterForm.Click += btn_AddFilterForm_Click;
            // 
            // gb_DirectoryContainer
            // 
            gb_DirectoryContainer.Controls.Add(lbl_totalFiles);
            gb_DirectoryContainer.Controls.Add(lbl_FileFound);
            gb_DirectoryContainer.Controls.Add(btn_browse);
            gb_DirectoryContainer.Controls.Add(txt_directory);
            gb_DirectoryContainer.Dock = DockStyle.Top;
            gb_DirectoryContainer.Location = new Point(0, 0);
            gb_DirectoryContainer.Name = "gb_DirectoryContainer";
            gb_DirectoryContainer.Size = new Size(312, 66);
            gb_DirectoryContainer.TabIndex = 1;
            gb_DirectoryContainer.TabStop = false;
            gb_DirectoryContainer.Text = "Select Directory";
            // 
            // lbl_totalFiles
            // 
            lbl_totalFiles.AutoSize = true;
            lbl_totalFiles.Location = new Point(67, 48);
            lbl_totalFiles.Name = "lbl_totalFiles";
            lbl_totalFiles.Size = new Size(72, 15);
            lbl_totalFiles.TabIndex = 3;
            lbl_totalFiles.Text = "lbl_totalFiles";
            // 
            // lbl_FileFound
            // 
            lbl_FileFound.AutoSize = true;
            lbl_FileFound.Location = new Point(3, 48);
            lbl_FileFound.Name = "lbl_FileFound";
            lbl_FileFound.Size = new Size(68, 15);
            lbl_FileFound.TabIndex = 2;
            lbl_FileFound.Text = "File Found :";
            // 
            // btn_browse
            // 
            btn_browse.Location = new Point(225, 22);
            btn_browse.Name = "btn_browse";
            btn_browse.Size = new Size(75, 23);
            btn_browse.TabIndex = 1;
            btn_browse.Text = "Browse";
            btn_browse.UseVisualStyleBackColor = true;
            btn_browse.Click += btn_browse_Click;
            // 
            // txt_directory
            // 
            txt_directory.Location = new Point(6, 22);
            txt_directory.Name = "txt_directory";
            txt_directory.Size = new Size(213, 23);
            txt_directory.TabIndex = 0;
            // 
            // p_Data
            // 
            p_Data.Controls.Add(dataGridView1);
            p_Data.Controls.Add(panel3);
            p_Data.Dock = DockStyle.Fill;
            p_Data.Location = new Point(322, 0);
            p_Data.Name = "p_Data";
            p_Data.Size = new Size(769, 650);
            p_Data.TabIndex = 1;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(769, 606);
            dataGridView1.TabIndex = 2;
            // 
            // panel3
            // 
            panel3.Controls.Add(btn_reset);
            panel3.Controls.Add(btn_FilterData);
            panel3.Controls.Add(button1);
            panel3.Dock = DockStyle.Bottom;
            panel3.Location = new Point(0, 606);
            panel3.Name = "panel3";
            panel3.Size = new Size(769, 44);
            panel3.TabIndex = 1;
            // 
            // btn_reset
            // 
            btn_reset.Dock = DockStyle.Right;
            btn_reset.Enabled = false;
            btn_reset.Location = new Point(319, 0);
            btn_reset.Name = "btn_reset";
            btn_reset.Size = new Size(150, 44);
            btn_reset.TabIndex = 0;
            btn_reset.Text = "Reset Filter";
            btn_reset.UseVisualStyleBackColor = true;
            btn_reset.Click += btn_reset_Click;
            // 
            // btn_FilterData
            // 
            btn_FilterData.Dock = DockStyle.Right;
            btn_FilterData.Enabled = false;
            btn_FilterData.Location = new Point(469, 0);
            btn_FilterData.Name = "btn_FilterData";
            btn_FilterData.Size = new Size(150, 44);
            btn_FilterData.TabIndex = 0;
            btn_FilterData.Text = "Filter Data";
            btn_FilterData.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Dock = DockStyle.Right;
            button1.Enabled = false;
            button1.Location = new Point(619, 0);
            button1.Name = "button1";
            button1.Size = new Size(150, 44);
            button1.TabIndex = 0;
            button1.Text = "Extract Data";
            button1.UseVisualStyleBackColor = true;
            // 
            // panel5
            // 
            panel5.Dock = DockStyle.Right;
            panel5.Location = new Point(1091, 0);
            panel5.Name = "panel5";
            panel5.Size = new Size(10, 650);
            panel5.TabIndex = 1;
            // 
            // panel7
            // 
            panel7.Dock = DockStyle.Bottom;
            panel7.Location = new Point(10, 650);
            panel7.Name = "panel7";
            panel7.Size = new Size(1091, 10);
            panel7.TabIndex = 4;
            // 
            // panel8
            // 
            panel8.Dock = DockStyle.Left;
            panel8.Location = new Point(0, 0);
            panel8.Name = "panel8";
            panel8.Size = new Size(10, 660);
            panel8.TabIndex = 5;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1101, 660);
            Controls.Add(p_Data);
            Controls.Add(panel5);
            Controls.Add(p_Setting);
            Controls.Add(panel7);
            Controls.Add(panel8);
            Name = "MainForm";
            Text = "MainForm";
            Load += MainForm_Load;
            p_Setting.ResumeLayout(false);
            gb_FilterContainer.ResumeLayout(false);
            gb_FilterContainer.PerformLayout();
            p_FilterSetting.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            gb_DirectoryContainer.ResumeLayout(false);
            gb_DirectoryContainer.PerformLayout();
            p_Data.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel p_Setting;
        private Panel p_Data;
        private GroupBox gb_DirectoryContainer;
        private Button btn_browse;
        private TextBox txt_directory;
        private Label lbl_totalFiles;
        private Label lbl_FileFound;
        private GroupBox gb_FilterContainer;
        private Panel p_FilterSetting;
        private Panel panel2;
        private ComboBox cb_FilterForm;
        private Panel panel1;
        private Button btn_AddFilterForm;
        private Panel p_FilterContainer;
        private Panel panel3;
        private Button btn_FilterData;
        private Button button1;
        private Panel panel5;
        private Panel panel7;
        private Panel panel8;
        private DataGridView dataGridView1;
        private Button btn_reset;
    }
}