using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
            Generate();
            
        }

        private void Generate()
        {
            StringBuilder sb = new StringBuilder();

            foreach (string s in Common.GenerateISBNNumberSeries())
                sb.AppendLine(s);

            txtISBNList.Text = sb.ToString();
            
            this.Focus();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            Generate();
        }
    }
}
