using System;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;

namespace TestesWinForms
{
    public partial class ImpressaoBoleto : Form
    {
        string _arquivo = string.Empty;
        public string Arquivo
        {
            get { return _arquivo; }
            set { _arquivo = value; }
        }

        public bool Impressao { get; set; }
        public bool NaoVisualizar { get; set; }

        public ImpressaoBoleto()
        {
            InitializeComponent();

            this.Shown += OnShown;
        }

        private void OnShown(object sender, EventArgs eventArgs)
        {
            if (Impressao || NaoVisualizar)
            {
                webBrowser.Navigate("");
                Close();
            }
        }

        private void visualizarImagemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormVisualizarImagem form = new FormVisualizarImagem(GerarImagem());
            form.ShowDialog();
        }

        private void enviarImagemPorEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EnviarEmail form = new EnviarEmail(GerarImagem());
            form.ShowDialog();
        }

        private string GerarImagem()
        {
            string address = _arquivo;
            int width = 670;
            int height = 805;

            int webBrowserWidth = 670;
            int webBrowserHeight = 805;

            Bitmap bmp = WebsiteThumbnailImageGenerator.GetWebSiteThumbnail(address, webBrowserWidth, webBrowserHeight, width, height);

            string file = Path.Combine(Path.GetTempPath(), Path.GetFileNameWithoutExtension(_arquivo) + ".bmp");

            bmp.Save(file);

            return file;
        }
    }
}