using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Word_Data_Extractor
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            lbl_FileFound.Visible = false;
            lbl_totalFiles.Visible = false;
            gb_FilterContainer.Visible = false;
            p_FilterContainer.HorizontalScroll.Visible = false;
        }

        private void btn_browse_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Select a folder";

                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    txt_directory.Text = folderDialog.SelectedPath;
                  
                    countfiles(txt_directory.Text);
                    lbl_FileFound.Visible = true;
                    lbl_totalFiles.Visible = true;
                    if (lbl_totalFiles.Text != "0") { 
                        gb_FilterContainer.Visible = true;
                        LoadCBFilterForm();
                    }
                }
            }
        }
        private void countfiles(string folderPath)
        {
            if (!Directory.Exists(folderPath))
            {
                return;
            }
            try
            {
                List<string> files = new List<string>();

                files.AddRange(
                    Directory.GetFiles(folderPath, "*.doc", SearchOption.AllDirectories)
                );
                files.AddRange(
                    Directory.GetFiles(folderPath, "*.docx", SearchOption.AllDirectories)
                );
                files.AddRange(
                    Directory.GetFiles(folderPath, "*.txt", SearchOption.AllDirectories)
                );
                int totalFiles = files.Count;
                lbl_totalFiles.Text = totalFiles.ToString();
       
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }
        private void LoadCBFilterForm()
        {
            cb_FilterForm.Items.Clear();

            cb_FilterForm.Items.Add("Text Contains");
            cb_FilterForm.Items.Add("Text Starts With");
            cb_FilterForm.Items.Add("Text Ends With");
            cb_FilterForm.Items.Add("Text Equals");
            cb_FilterForm.Items.Add("Number Phone");
            cb_FilterForm.Items.Add("Email Address");
            cb_FilterForm.Items.Add("Regex");

            cb_FilterForm.SelectedIndex = -1;
        }

        private void btn_AddFilterForm_Click(object sender, EventArgs e)
        {
            if (cb_FilterForm.SelectedItem is not string filterType)
            {
                MessageBox.Show("Please select a filter type.");
                return;
            }
            AddFilterPanel(filterType);
        }
        private void AddFilterPanel(string filterType)
        {
            int number = 1;

            while (this.p_FilterContainer.Controls.ContainsKey($"panelFilter{number}"))
            {
                number++;
            }

            GroupBox groupboxfilter = new GroupBox
            {
                Dock = DockStyle.Fill,
                Text = filterType + $"      panelFilter{number}"
            };
            Panel filterPanel = new Panel
            {
                Name = $"panelFilter{number}",
                Width = 500,
                Height = 100,
                Dock = DockStyle.Top
            };
            Button btnRemove = new Button
            {
                Name = $"btnRemoveFilter{number}",
                Text = "X",
                Width = 20,
                Height = 20,
                Location = new Point(10, 70),
                FlatStyle = FlatStyle.Flat,
                ForeColor = Color.Red,
                Font = new Font("Segoe UI", 7, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnRemove.Click += (sender, e) =>
            {
                p_FilterContainer.Controls.Remove(filterPanel);
                filterPanel.Dispose();
                Updatebtn_FilterData();
            };

            Label filterPanelName = new Label
            {
                Name = $"filterpanelName{number}",
                Text = "Name",
                AutoSize = true,
                Location = new Point(5, 20)
            };
            TextBox filterBoxName = new TextBox
            {
                Name = $"filterboxName{number}",
                BorderStyle = BorderStyle.FixedSingle,
                Width = 250,
                Location = new Point(50, 15)
            };

            if (filterType != "Number Phone" && filterType != "Email Address")
            {
                Label filterPanelvalue = new Label
                {
                    Name = $"filterPanelvalue{number}",
                    Text = "Value",
                    AutoSize = true,
                    Location = new Point(5, 45)
                };
                TextBox filterBoxvalue = new TextBox
                {
                    Name = $"filterBoxvalue{number}",
                    BorderStyle = BorderStyle.FixedSingle,
                    Width = 250,
                    Location = new Point(50, 40)
                };

                RadioButton RBInclude = new RadioButton
                {
                    Name = $"RBInclude{number}",
                    Text = "Include",
                    Location = new Point(50, 65),

                };
                RadioButton RBExclude = new RadioButton
                {
                    Name = $"RBExclude{number}",
                    Text = "Exclude",
                    Location = new Point(170, 65)
                };
                groupboxfilter.Controls.Add(filterPanelvalue);
                groupboxfilter.Controls.Add(filterBoxvalue);
                groupboxfilter.Controls.Add(RBInclude);
                groupboxfilter.Controls.Add(RBExclude);
            }
            groupboxfilter.Controls.Add(filterPanelName);
            groupboxfilter.Controls.Add(filterBoxName);
            groupboxfilter.Controls.Add(btnRemove);

            filterPanel.Controls.Add(groupboxfilter);
            this.p_FilterContainer.Controls.Add(filterPanel);
            Updatebtn_FilterData();
        }
        private void btn_reset_Click(object sender, EventArgs e)
        {
            while (p_FilterContainer.Controls.Count > 0)
            {
                Control control = p_FilterContainer.Controls[0];

                p_FilterContainer.Controls.RemoveAt(0);
                control.Dispose();
                Updatebtn_FilterData();
            }
        }
        private void Updatebtn_FilterData()
        {
            btn_FilterData.Enabled = p_FilterContainer.Controls.Count > 0;
            btn_reset.Enabled = p_FilterContainer.Controls.Count > 0;
        }
    }
}
