namespace Word_Data_Extractor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MainForm childForm = new MainForm();
            ShowChildForm(childForm);
        }
        private void ShowChildForm(Form childForm)
        {
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            p_Body.Controls.Clear();
            p_Body.Controls.Add(childForm);
            childForm.Show();
            childForm.BringToFront();
        }
    }
}
