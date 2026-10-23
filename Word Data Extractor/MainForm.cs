using NPOI.HWPF;
using NPOI.HWPF.Extractor;
using NPOI.XWPF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.Data;
using System.Diagnostics;

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

            btn_FilterData.Enabled = false;
            btn_reset.Enabled = false;
            btn_exportData.Enabled = false;
        }

        // Browse folder
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

                    gb_FilterContainer.Visible =
                        int.TryParse(lbl_totalFiles.Text, out int total)
                        && total > 0;
                }
            }
        }

        // Count supported files
        private void countfiles(string folderPath)
        {
            if (!Directory.Exists(folderPath))
                return;

            try
            {
                List<string> files = new List<string>();

                files.AddRange(Directory.GetFiles(
                    folderPath, "*.doc", SearchOption.AllDirectories));

                files.AddRange(Directory.GetFiles(
                    folderPath, "*.docx", SearchOption.AllDirectories));

                files.AddRange(Directory.GetFiles(
                    folderPath, "*.txt", SearchOption.AllDirectories));

                lbl_totalFiles.Text = files.Count.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        // Add filter
        private void btn_AddFilterForm_Click(object sender, EventArgs e)
        {
            string filterName = txbx_FilterName.Text.Trim();

            AddFilterPanel(filterName);
        }

        // Create dynamic filter panel
        private void AddFilterPanel(string filterName)
        {
            int number = 1;

            while (p_FilterContainer.Controls.ContainsKey($"Filter{number}"))
                number++;

            if (string.IsNullOrWhiteSpace(filterName))
                filterName = $"Filter{number}";

            int smallHeight = 20;
            int bigHeight = 165;

            GroupBox groupBoxFilter = new GroupBox
            {
                Dock = DockStyle.Fill,
                Text = filterName,
                BackColor = Color.White
            };

            Panel filterPanel = new Panel
            {
                Name = $"Filter{number}",
                Width = 500,
                Height = bigHeight,
                Dock = DockStyle.Top
            };

            groupBoxFilter.Click += (sender, e) =>
            {
                filterPanel.Height =
                    filterPanel.Height > smallHeight
                    ? smallHeight
                    : bigHeight;
            };

            //search value 
            Label lblSearchValue = new Label
            {
                Name = $"lblSearchValue{number}",
                Text = "Search Value",
                AutoSize = true,
                Location = new Point(5, 30)
            };

            TextBox txbxSearchValue = new TextBox
            {
                Name = $"txbxSearchValue{number}",
                BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle,
                Width = 200,
                Location = new Point(80, 25)
            };

            groupBoxFilter.Controls.Add(lblSearchValue);
            groupBoxFilter.Controls.Add(txbxSearchValue);

            //section interface
            Label lblSearchBetweenLine = new Label
            {
                Name = $"lblSearchBetweenLine{number}",
                Text = "Search Section",
                AutoSize = true,
                Location = new Point(5, 50)
            };

            Label lblSearchBetweenLineStart = new Label
            {
                Name = $"lblSearchBetweenLineStart{number}",
                Text = "Start",
                AutoSize = true,
                Location = new Point(5, 70)
            };

            Label lblSearchBetweenLineEnd = new Label
            {
                Name = $"lblSearchBetweenLineEnd{number}",
                Text = "End",
                AutoSize = true,
                Location = new Point(95, 70)
            };

            TextBox txbxSearchBetweenLineStart = new TextBox
            {
                Name = $"txbxSearchBetweenLineStart{number}",
                BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle,
                Width = 50,
                Location = new Point(40, 65)
            };

            TextBox txbxSearchBetweenLineEnd = new TextBox
            {
                Name = $"txbxSearchBetweenLineEnd{number}",
                BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle,
                Width = 50,
                Location = new Point(125, 65)
            };

            groupBoxFilter.Controls.Add(lblSearchBetweenLine);
            groupBoxFilter.Controls.Add(lblSearchBetweenLineStart);
            groupBoxFilter.Controls.Add(lblSearchBetweenLineEnd);
            groupBoxFilter.Controls.Add(txbxSearchBetweenLineStart);
            groupBoxFilter.Controls.Add(txbxSearchBetweenLineEnd);
            //  Range interface
            Label lblFilterBetweenLine = new Label
            {
                Name = $"lblFilterBetweenLine{number}",
                Text = "Filter Range Line",
                AutoSize = true,
                Location = new Point(5, 90)
            };

            Label lblFilterBetweenLineStart = new Label
            {
                Name = $"lblFilterBetweenLineStart{number}",
                Text = "Start",
                AutoSize = true,
                Location = new Point(5, 110)
            };

            Label lblFilterBetweenLineEnd = new Label
            {
                Name = $"lblFilterBetweenLineEnd{number}",
                Text = "End",
                AutoSize = true,
                Location = new Point(95, 110)
            };

            Label lblFilterBetweenLineLength = new Label
            {
                Name = $"lblFilterBetweenLineLength{number}",
                Text = "Length",
                AutoSize = true,
                Location = new Point(180, 110)
            };

            TextBox txbxFilterBetweenLineStart = new TextBox
            {
                Name = $"txbxFilterBetweenLineStart{number}",
                BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle,
                Width = 50,
                Location = new Point(40, 110)
            };

            TextBox txbxFilterBetweenLineEnd = new TextBox
            {
                Name = $"txbxFilterBetweenLineEnd{number}",
                BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle,
                Width = 50,
                Location = new Point(125, 110)
            };

            TextBox txbxFilterBetweenLineLength = new TextBox
            {
                Name = $"txbxFilterBetweenLineLenght{number}",
                BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle,
                Width = 50,
                Location = new Point(230, 110)
            };

            groupBoxFilter.Controls.Add(lblFilterBetweenLine);
            groupBoxFilter.Controls.Add(lblFilterBetweenLineStart);
            groupBoxFilter.Controls.Add(lblFilterBetweenLineEnd);
            groupBoxFilter.Controls.Add(lblFilterBetweenLineLength);
            groupBoxFilter.Controls.Add(txbxFilterBetweenLineStart);
            groupBoxFilter.Controls.Add(txbxFilterBetweenLineEnd);
            groupBoxFilter.Controls.Add(txbxFilterBetweenLineLength);
            //include check box
            CheckBox cbIncludeSearchText = new CheckBox
            {
                Name = $"cbIncludeSearchText{number}",
                AutoSize = true,
                Location = new Point(10, 140)
            };
            Label lblIncludeSearchText = new Label
            {
                Name = $"lblIncludeSearchText{number}",
                Text = "Include Search Text",
                AutoSize = true,
                Location = new Point(25, 140)
            };
            groupBoxFilter.Controls.Add(lblIncludeSearchText);
            groupBoxFilter.Controls.Add(cbIncludeSearchText);
            filterPanel.Controls.Add(groupBoxFilter);

            // Add newest panel to the top
            p_FilterContainer.Controls.Add(filterPanel);
            p_FilterContainer.Controls.SetChildIndex(filterPanel, 0);

            Updatebtn_FilterData();
        }

        // Reset filters
        private void btn_reset_Click(object sender, EventArgs e)
        {
            while (p_FilterContainer.Controls.Count > 0)
            {
                Control control = p_FilterContainer.Controls[0];

                p_FilterContainer.Controls.RemoveAt(0);
                control.Dispose();
            }

            dgv_FilterData.DataSource = null;
            btn_exportData.Enabled = false;

            Updatebtn_FilterData();
        }

        private void Updatebtn_FilterData()
        {
            bool hasFilters = p_FilterContainer.Controls.Count > 0;

            btn_FilterData.Enabled = hasFilters;
            btn_reset.Enabled = hasFilters;
        }

        // Filter settings
        private class FilterDefinition
        {
            public string FilterName { get; set; } = string.Empty;
            public string FindMatch { get; set; } = string.Empty;
            public int TextLenght { get; set; }
            public int sectionStartLine { get; set; }
            public int sectionEndLine { get; set; }
            public int rangeStartLine { get; set; }
            public int rangeEndLine { get; set; }
            public bool includeText { get; set; }
        }

        // Execute filtering
        private void btn_FilterData_Click(object sender, EventArgs e)
        {
            try
            {
                List<FilterDefinition> filters = GetFilters();

                if (filters.Count == 0)
                    return;

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

                files.AddRange(Directory.GetFiles(
                    txt_directory.Text, "*.doc", SearchOption.AllDirectories));

                files.AddRange(Directory.GetFiles(
                    txt_directory.Text, "*.docx", SearchOption.AllDirectories));

                files.AddRange(Directory.GetFiles(
                    txt_directory.Text, "*.txt", SearchOption.AllDirectories));

                DataTable table = new DataTable();

                table.Columns.Add("No.", typeof(int));
                table.Columns.Add("File Name", typeof(string));

                foreach (FilterDefinition filter in filters)
                {
                    string originalName = filter.FilterName;
                    string columnName = originalName;

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
                            fileMatches = true;
                    }

                    if (fileMatches)
                    {
                        table.Rows.Add(row);
                        rowNumber++;
                    }
                }

                dgv_FilterData.DataSource = table;

                dgv_FilterData.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.None;

                foreach (DataGridViewColumn column in dgv_FilterData.Columns)
                {
                    column.Width = 200;

                    column.DefaultCellStyle.WrapMode =
                        DataGridViewTriState.True;
                }

                if (dgv_FilterData.Columns.Contains("No."))
                    dgv_FilterData.Columns["No."].Width = 60;

                if (dgv_FilterData.Columns.Contains("File Name"))
                    dgv_FilterData.Columns["File Name"].Width = 250;

                dgv_FilterData.AutoSizeRowsMode =
                    DataGridViewAutoSizeRowsMode.AllCells;

                btn_exportData.Enabled = table.Rows.Count > 0;

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

        // Read TXT, DOCX and DOC
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
                                text.AppendLine(paragraph.Text);

                            foreach (var wordTable in document.Tables)
                            {
                                foreach (var row in wordTable.Rows)
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
                    $"Unsupported operation while reading:\n{filePath}\n{ex}");

                throw;
            }
            catch (Exception ex)
            {
                Debug.Print($"Cannot read file:\n{filePath}\n{ex}");

                return "";
            }
        }
        private CheckBox? FindCheckBox(Control parent, string namePrefix)
        {
            foreach (Control child in parent.Controls)
            {
                if (child is CheckBox checkBox &&
                    checkBox.Name.StartsWith(
                        namePrefix,
                        StringComparison.OrdinalIgnoreCase))
                {
                    return checkBox;
                }

                CheckBox? result = FindCheckBox(child, namePrefix);

                if (result != null)
                    return result;
            }

            return null;
        }
        // Search matching text
        private string SearchFilter(string text, FilterDefinition filter)
        {
            if (string.IsNullOrWhiteSpace(text))
                return "";

            string[] lines = text.Split(
                new[] { "\r\n", "\n", "\r" },
                StringSplitOptions.None);

            int totalLines = lines.Length;

            int sectionStart = filter.sectionStartLine > 0
                ? filter.sectionStartLine
                : 1;

            int sectionEnd = filter.sectionEndLine > 0
                ? Math.Min(filter.sectionEndLine, totalLines)
                : totalLines;

            int rangeStart = filter.rangeStartLine > 0
                ? filter.rangeStartLine
                : 1;

            int rangeEnd = filter.rangeEndLine > 0
                ? filter.rangeEndLine
                : int.MaxValue;

            string findMatch = filter.FindMatch;

            if (string.IsNullOrWhiteSpace(findMatch) ||
                sectionStart > sectionEnd ||
                sectionStart > totalLines ||
                rangeStart > rangeEnd)
            {
                return "";
            }

            for (int i = sectionStart - 1; i < sectionEnd; i++)
            {
                int matchIndex = lines[i].IndexOf(
                    findMatch,
                    StringComparison.OrdinalIgnoreCase);

                if (matchIndex < 0)
                    continue;

                List<string> results = new List<string>();
                int extractedLine = 0;

                for (int j = i; j < sectionEnd; j++)
                {
                    string line = lines[j].Trim();

                    if (string.IsNullOrWhiteSpace(line))
                        continue;

                    if (j == i && !filter.includeText)
                    {
                        int index = line.IndexOf(
                            findMatch,
                            StringComparison.OrdinalIgnoreCase);

                        if (index >= 0)
                        {
                            line = line.Remove(index, findMatch.Length).Trim();
                        }
                    }

                    extractedLine++;

                    if (extractedLine >= rangeStart &&
                        extractedLine <= rangeEnd &&
                        !string.IsNullOrWhiteSpace(line))
                    {
                        results.Add(line);
                    }

                    if (extractedLine >= rangeEnd)
                        break;
                }

                string result = string.Join(
                    Environment.NewLine, results);

                if (filter.TextLenght > 0 &&
                    result.Length > filter.TextLenght)
                {
                    result = result.Substring(0, filter.TextLenght);
                }

                return result;
            }

            return "";
        }


        // Read filter inputs
        private List<FilterDefinition> GetFilters()
        {
            List<FilterDefinition> filters = new List<FilterDefinition>();

            foreach (Control control in p_FilterContainer.Controls)
            {
                if (control is not Panel filterPanel)
                    continue;

                GroupBox? groupBox = filterPanel.Controls
                    .OfType<GroupBox>()
                    .FirstOrDefault();

                if (groupBox == null)
                    continue;

                string filterName = groupBox.Text.Trim();

                TextBox? findBox =
                    FindTextBox(groupBox, "txbxSearchValue");

                TextBox? sectionStartBox =
                    FindTextBox(groupBox, "txbxSearchBetweenLineStart");

                TextBox? sectionEndBox =
                    FindTextBox(groupBox, "txbxSearchBetweenLineEnd");

                TextBox? rangeStartBox =
                    FindTextBox(groupBox, "txbxFilterBetweenLineStart");

                TextBox? rangeEndBox =
                    FindTextBox(groupBox, "txbxFilterBetweenLineEnd");

                TextBox? lengthBox =
                    FindTextBox(groupBox, "txbxFilterBetweenLineLenght");
                CheckBox? includeTextBox =
                    FindCheckBox(groupBox, "cbIncludeSearchText");

                bool includeSearchText = includeTextBox?.Checked ?? false;
                if (findBox == null ||
                    string.IsNullOrWhiteSpace(findBox.Text))
                {
                    MessageBox.Show(
                        $"Please enter a Search Value for '{filterName}'.",
                        "Filter Data",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return new List<FilterDefinition>();
                }

                int sectionStart = 1;
                int sectionEnd = 0;
                int rangeStart = 1;
                int rangeEnd = 0;
                int textLength = 0;

                if (!TryReadOptionalInt(
                    sectionStartBox, ref sectionStart, "Search Section Start"))
                    return new List<FilterDefinition>();

                if (!TryReadOptionalInt(
                    sectionEndBox, ref sectionEnd, "Search Section End"))
                    return new List<FilterDefinition>();

                if (!TryReadOptionalInt(
                    rangeStartBox, ref rangeStart, "Filter Range Start"))
                    return new List<FilterDefinition>();

                if (!TryReadOptionalInt(
                    rangeEndBox, ref rangeEnd, "Filter Range End"))
                    return new List<FilterDefinition>();

                if (!TryReadOptionalInt(
                    lengthBox, ref textLength, "Text Length"))
                    return new List<FilterDefinition>();

                if (sectionStart < 1 ||
                    (sectionEnd > 0 && sectionEnd < sectionStart) ||
                    rangeStart < 1 ||
                    (rangeEnd > 0 && rangeEnd < rangeStart) ||
                    textLength < 0)
                {
                    MessageBox.Show(
                        $"Invalid line range or text length for '{filterName}'.",
                        "Filter Data",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return new List<FilterDefinition>();
                }

                filters.Add(new FilterDefinition
                {
                    FilterName = filterName,
                    FindMatch = findBox.Text.Trim(),
                    TextLenght = textLength,
                    sectionStartLine = sectionStart,
                    sectionEndLine = sectionEnd,
                    rangeStartLine = rangeStart,
                    rangeEndLine = rangeEnd,
                    includeText = includeSearchText
                });
            }

            return filters;
        }

        private bool TryReadOptionalInt(
            TextBox? textBox,
            ref int value,
            string fieldName)
        {
            if (textBox == null || string.IsNullOrWhiteSpace(textBox.Text))
                return true;

            if (!int.TryParse(textBox.Text.Trim(), out value))
            {
                MessageBox.Show(
                    $"Please enter a valid number for {fieldName}.",
                    "Filter Data",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }

            return true;
        }

        // Find textbox recursively
        private TextBox? FindTextBox(Control parent, string namePrefix)
        {
            foreach (Control child in parent.Controls)
            {
                if (child is TextBox textBox &&
                    textBox.Name.StartsWith(
                        namePrefix,
                        StringComparison.OrdinalIgnoreCase))
                {
                    return textBox;
                }

                TextBox? result = FindTextBox(child, namePrefix);

                if (result != null)
                    return result;
            }

            return null;
        }

        // Export DataGridView to Excel
        private void btn_exportData_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv_FilterData.Rows.Count == 0 ||
                    (dgv_FilterData.Rows.Count == 1 &&
                     dgv_FilterData.Rows[0].IsNewRow))
                {
                    MessageBox.Show(
                        "No data available to export.",
                        "Export Excel",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                using (SaveFileDialog saveDialog = new SaveFileDialog())
                {
                    saveDialog.Filter =
                        "Excel Workbook (*.xlsx)|*.xlsx";

                    saveDialog.Title = "Export Data to Excel";
                    saveDialog.FileName = "FilteredData.xlsx";
                    saveDialog.DefaultExt = "xlsx";
                    saveDialog.AddExtension = true;

                    if (saveDialog.ShowDialog() != DialogResult.OK)
                        return;
                    IWorkbook workbook = new XSSFWorkbook();
                    try
                    {
                        ISheet sheet = workbook.CreateSheet("Filtered Data");

                        // Export visible columns only.
                        List<int> visibleColumns = new List<int>();

                        for (int col = 0;
                             col < dgv_FilterData.Columns.Count;
                             col++)
                        {
                            if (dgv_FilterData.Columns[col].Visible)
                                visibleColumns.Add(col);
                        }

                        // Header
                        IRow headerRow = sheet.CreateRow(0);

                        ICellStyle headerStyle =
                            workbook.CreateCellStyle();

                        IFont headerFont = workbook.CreateFont();
                        headerFont.IsBold = true;
                        headerStyle.SetFont(headerFont);

                        for (int excelCol = 0;
                             excelCol < visibleColumns.Count;
                             excelCol++)
                        {
                            int dgvCol = visibleColumns[excelCol];

                            NPOI.SS.UserModel.ICell cell =
                                headerRow.CreateCell(excelCol);

                            cell.SetCellValue(
                                dgv_FilterData.Columns[dgvCol].HeaderText);

                            cell.CellStyle = headerStyle;
                        }

                        // Data rows
                        int excelRowIndex = 1;

                        foreach (DataGridViewRow dgvRow in dgv_FilterData.Rows)
                        {
                            if (dgvRow.IsNewRow)
                                continue;

                            IRow excelRow = sheet.CreateRow(excelRowIndex++);

                            for (int excelCol = 0;
                                 excelCol < visibleColumns.Count;
                                 excelCol++)
                            {
                                int dgvCol = visibleColumns[excelCol];

                                object? value = dgvRow.Cells[dgvCol].Value;

                                NPOI.SS.UserModel.ICell cell =
                                    excelRow.CreateCell(excelCol);

                                cell.SetCellValue(
                                    value == null || value == DBNull.Value
                                    ? ""
                                    : value.ToString());
                            }
                        }

                        // Auto-size exported columns.
                        for (int col = 0; col < visibleColumns.Count; col++)
                        {
                            sheet.AutoSizeColumn(col);
                        }

                        using (FileStream fileStream = new FileStream(
                            saveDialog.FileName,
                            FileMode.Create,
                            FileAccess.Write))
                        {
                            workbook.Write(fileStream);
                        }
                    }
                    finally
                    {
                        workbook.Close();
                    }

                    MessageBox.Show(
                        "Data exported successfully!\r\n\r\n" +
                        "File: " + saveDialog.FileName,
                        "Export Complete",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error exporting data to Excel:\r\n\r\n" + ex.Message,
                    "Export Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
