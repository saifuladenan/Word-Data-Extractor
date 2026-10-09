using NPOI.HWPF;
using NPOI.HWPF.Extractor;
using NPOI.XWPF.UserModel;
using System.Data;
using System.Diagnostics;
using System.Drawing.Imaging.Effects;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using RegexMatch = System.Text.RegularExpressions.Match;
using RegexMatchCollection = System.Text.RegularExpressions.MatchCollection;
using System.Text;
namespace Word_Data_Extractor
{

    public partial class MainForm : Form
    {
        public MainForm()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            lbl_FileFound.Visible = false;
            lbl_totalFiles.Visible = false;
            gb_FilterContainer.Visible = false;
            p_FilterContainer.HorizontalScroll.Visible = false;
            dgv_FilterData.DataSource = null;
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
                    if (lbl_totalFiles.Text != "0")
                    {
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
            cb_FilterForm.Items.Add("Lines Number");
            cb_FilterForm.Items.Add("After Lines Matched");
            cb_FilterForm.Items.Add("Before Lines Matched");

            //cb_FilterForm.Items.Add("Text Contains");
            //cb_FilterForm.Items.Add("Text Starts With");
            //cb_FilterForm.Items.Add("Text Ends With");
            //cb_FilterForm.Items.Add("Text Equals");
            //cb_FilterForm.Items.Add("Number Phone");
            //cb_FilterForm.Items.Add("Email Address");
            //cb_FilterForm.Items.Add("Regex");

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

            System.Windows.Forms.GroupBox groupboxfilter = new System.Windows.Forms.GroupBox
            {
                Dock = DockStyle.Fill,
                Text = filterType,
                BackColor = Color.White,
            };
            Panel filterPanel = new Panel
            {
                Name = $"panelFilter{number}",
                Width = 500,
                Height = 100,
                Dock = DockStyle.Top
            };
            groupboxfilter.Click += (sender, e) =>
            {
                int smallHeight = 15;
                int bigHeight = 100;
               if(filterPanel.Height > smallHeight)
                    filterPanel.Height = smallHeight;
                else
                    filterPanel.Height = bigHeight             
;

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

            if (filterType == "Lines Number") 
            {
                Label lblLinesStart = new Label
                {
                    Name = $"lblLinesStart{number}",
                            Text = "Start  :",
                            AutoSize = true,
                           Location = new Point(5, 45)
                };
                TextBox tbxLinesStart = new TextBox
                {
                    Name = $"tbxLinesStart{number}",
                    BorderStyle = BorderStyle.FixedSingle,
                    Width = 50,
                    Location = new Point(50, 40)
                };
                Label lblLinesEnd = new Label
                {
                    Name = $"lblLinesEnd{number}",
                    Text = "End  :",
                    AutoSize = true,
                    Location = new Point(120, 45)
                };
                TextBox tbxLinesEnd = new TextBox
                {
                    Name = $"tbxLinesEnd{number}",
                    BorderStyle = BorderStyle.FixedSingle,
                    Width = 50,
                    Location = new Point(160, 40)
                };
                tbxLinesStart.KeyPress += (sender, e) =>
                {
                    if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                    {
                        e.Handled = true;
                    }
                };
                tbxLinesEnd.KeyPress += (sender, e) =>
                {
                    if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                    {
                        e.Handled = true;
                    }
                };
                groupboxfilter.Controls.Add(lblLinesStart);
                groupboxfilter.Controls.Add(tbxLinesStart);
                groupboxfilter.Controls.Add(lblLinesEnd);
                groupboxfilter.Controls.Add(tbxLinesEnd);
            }
            if (filterType == "Before Lines Matched" || filterType == "After Lines Matched")
            { 
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
                dgv_FilterData.DataSource = null;
                Updatebtn_FilterData();
            }
        }
        private void Updatebtn_FilterData()
        {
            btn_FilterData.Enabled = p_FilterContainer.Controls.Count > 0;
            btn_reset.Enabled = p_FilterContainer.Controls.Count > 0;
        }

           private class FilterDefinition
            {
                public string FilterType { get; set; }
                public string Name { get; set; }
                public string Value { get; set; }
                public int StartLine { get; set; }
                public int EndLine { get; set; }
            }
   
        private void btn_FilterData_Click(object sender, EventArgs e)
        {
            try
            {
                List<FilterDefinition> filters = GetFilters();

                if (filters.Count == 0)
                {
                    return;
                }
                if (!Directory.Exists(txt_directory.Text))
                {
                    MessageBox.Show(
                        "Please select a valid folder.",
                        "Folder",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }
                List<string> files = new List<string>();
                files.AddRange(Directory.GetFiles(txt_directory.Text, "*.doc", SearchOption.AllDirectories));
                files.AddRange(Directory.GetFiles(txt_directory.Text, "*.docx", SearchOption.AllDirectories));
                files.AddRange(Directory.GetFiles(txt_directory.Text, "*.txt", SearchOption.AllDirectories));

                DataTable table = new DataTable();
                table.Columns.Add("No.", typeof(int));
                table.Columns.Add("File Name", typeof(string));
                foreach (FilterDefinition filter in filters)
                {
                    string columnName = filter.Name;
                    if (string.IsNullOrWhiteSpace(columnName))
                    {
                        columnName = filter.FilterType;
                    }

                    string originalName = columnName;
                    int number = 2;
                    while (table.Columns.Contains(columnName))
                    {
                        columnName = originalName + " " + number;
                        number++;
                    }
                    table.Columns.Add(columnName, typeof(string));
                }
                int rowNumber = 1;

                foreach (string file in files)
                {
                    string text = ReadFileText(file);
                    if (string.IsNullOrWhiteSpace(text))
                        continue;

                    DataRow row = table.NewRow();

                    row["No."] = rowNumber;
                    row["File Name"] = Path.GetFileName(file);

                    bool fileMatches = false;

                    for (int i = 0; i < filters.Count; i++)
                    {
                        FilterDefinition filter = filters[i];

                        string result = SearchFilter(text, filter);

                        row[i + 2] = result;

                        if (!string.IsNullOrWhiteSpace(result))
                        {
                            fileMatches = true;
                        }
                    }

                    if (fileMatches)
                    {
                        table.Rows.Add(row);
                        rowNumber++;
                    }
                }
                        dgv_FilterData.DataSource = table;

                        dgv_FilterData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

                        foreach (DataGridViewColumn column in dgv_FilterData.Columns)
                        {
                            column.Width = 200;
                            column.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                        }

                        if (dgv_FilterData.Columns.Contains("No."))
                        {
                            dgv_FilterData.Columns["No."].Width = 60;
                        }

                        if (dgv_FilterData.Columns.Contains("File Name"))
                        {
                            dgv_FilterData.Columns["File Name"].Width = 250;
                        }
                        dgv_FilterData.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

                        MessageBox.Show(
                            $"Filtering completed.\r\n\r\n" +
                            $"Files searched: {files.Count}\r\n" +
                            $"Files detected: {table.Rows.Count}",
                            "Complete",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);


                    }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error while filtering files:\r\n\r\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private string ReadFileText(string filePath)
        {
            string extension = Path.GetExtension(filePath).ToLowerInvariant();

            try
            {
                switch (extension)
                {
                    case ".txt":
                        return File.ReadAllText(filePath);

                    case ".docx":
                        using (FileStream fs = new FileStream(
                            filePath,
                            FileMode.Open,
                            FileAccess.Read,
                            FileShare.ReadWrite))
                        {
                            XWPFDocument document = new XWPFDocument(fs);

                            StringBuilder text = new StringBuilder();

                            foreach (var paragraph in document.Paragraphs)
                            {
                                text.AppendLine(paragraph.Text);
                            }

                            foreach (var table in document.Tables)
                            {
                                foreach (var row in table.Rows)
                                {
                                    foreach (var cell in row.GetTableCells())
                                    {
                                        text.Append(cell.GetText());
                                        text.Append(" ");
                                    }

                                    text.AppendLine();
                                }
                            }

                            return text.ToString();
                        }

                    case ".doc":
                        using (FileStream fs = new FileStream(
                            filePath,
                            FileMode.Open,
                            FileAccess.Read,
                            FileShare.ReadWrite))
                        {
                            HWPFDocument document = new HWPFDocument(fs);
                            WordExtractor extractor = new WordExtractor(document);

                            return extractor.Text;
                        }

                    default:
                        return "";
                }
            }
            catch (NotSupportedException ex)
            {
               Debug.Print(
                    $"Unsupported operation while reading:\n{filePath}\n\n" +
                    $"Error: {ex.Message}\n\n" +
                    $"Details:\n{ex.StackTrace}");

                throw;
            }
            catch (Exception ex)
            {
                Debug.Print(
                    $"Cannot read file:\n{filePath}\n\n{ex}");

                return "";
            }

        }
        private string SearchFilter(string text, FilterDefinition filter)
        {
            if (string.IsNullOrWhiteSpace(text))
                return "";

            switch (filter.FilterType)
            {
                case "Lines Number":
                    return SearchLines(
                        text,
                        filter.StartLine,
                        filter.EndLine);

                default:
                    return "";
            }
        }
        private string SearchLines(string text, int startLine, int endLine)
        {
            if (string.IsNullOrWhiteSpace(text))
                return "";

            string[] lines = text.Split(
                new[] { "\r\n", "\n", "\r" },
                StringSplitOptions.None);

            if (startLine < 1 || endLine < startLine)
                return "";

            List<string> results = new List<string>();

            int firstLine = startLine - 1;
            int lastLine = Math.Min(endLine, lines.Length);

            for (int i = firstLine; i < lastLine; i++)
            {
                string line = lines[i].Trim();

                if (!string.IsNullOrWhiteSpace(line))
                {
                    results.Add(line);
                }
            }

            return string.Join(Environment.NewLine, results);
        }
        private List<FilterDefinition> GetFilters()
        {
            List<FilterDefinition> filters = new List<FilterDefinition>();

            foreach (Control control in p_FilterContainer.Controls)
            {
                if (control is not Panel filterPanel)
                    continue;

                if (filterPanel.Controls.Count == 0)
                    continue;

                if (filterPanel.Controls[0] is not GroupBox groupBox)
                    continue;

                string filterType = groupBox.Text.Trim();

                TextBox startBox = null;
                TextBox endBox = null;
                TextBox nameBox = null;

                foreach (Control child in groupBox.Controls)
                {
                    if (child is TextBox textBox)
                    {
                        if (textBox.Name.StartsWith("tbxLinesStart"))
                            startBox = textBox;
                        else if (textBox.Name.StartsWith("tbxLinesEnd"))
                            endBox = textBox;
                        else if (textBox.Name.StartsWith("filterboxName"))
                            nameBox = textBox;
                    }
                }

                if (startBox == null || endBox == null ||
    !int.TryParse(startBox.Text, out int start) ||
    !int.TryParse(endBox.Text, out int end) ||
    start < 1 || end < start)
                {
                    MessageBox.Show(
                        "Please enter valid Start and End line numbers.",
                        "Invalid Line Range",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return new List<FilterDefinition>();
                }

                FilterDefinition filter = new FilterDefinition
                {
                    FilterType = filterType,
                    Name = nameBox?.Text.Trim() ?? "",
                    StartLine = start,
                    EndLine = end
                };

                filters.Add(filter);
            }

            return filters;
        }


    }
}