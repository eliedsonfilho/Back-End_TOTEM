using System.Windows.Forms;
using System.Drawing;

namespace TestesWinForms
{
    public partial class FormVisualizarImagem : Form
    {
        public FormVisualizarImagem(string fileName)
        {
            InitializeComponent();

            pictureBox1.Image = Image.FromFile(fileName);
        }
    }
}
