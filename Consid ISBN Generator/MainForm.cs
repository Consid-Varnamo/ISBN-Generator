using System;
using System.Text;
using System.Windows.Forms;
using static Consid.Isbn.Core.Generator;

namespace Consid.ISBN.Generator
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CreateIsbns();

        }

        private void CreateIsbns()
        {
            StringBuilder sb = new StringBuilder();

            foreach (string s in Generate(10))
            {
                sb.AppendLine(s);
            }

            txtISBNList.Text = sb.ToString();

            Focus();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            CreateIsbns();
        }
    }
}
