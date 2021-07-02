using System;
using System.IO;
using System.Windows.Forms;
using BoletoNet;

namespace TestesWinForms
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void impressãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NBoleto form = new NBoleto();
            form.MdiParent = this;
            form.Show();
        }

        private void fecharToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }
    }
}