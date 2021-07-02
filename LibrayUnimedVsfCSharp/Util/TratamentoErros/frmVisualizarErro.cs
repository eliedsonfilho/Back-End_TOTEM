using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Util.TratamentoErros
{
    public partial class frmVisualizarErro : Form
    {
        public frmVisualizarErro()
        {
            InitializeComponent();
            btnOk.Focus();
        }

        public frmVisualizarErro(IList<string> mensagemErro, IList<string> detalhes, MessageBoxIcon messageBoxIcon)
        {
            InitializeComponent();

            lstDetalhesErro.Visible = false;
            this.Size = new Size(546, 184);

            switch (messageBoxIcon)
            {
                case MessageBoxIcon.Information:
                {
                    pctTipoErro.Image = Properties.Resources.Informacao;
                    break;
                }
                case MessageBoxIcon.Error:
                {
                    pctTipoErro.Image = Properties.Resources.Pare;
                    break;
                }
                case MessageBoxIcon.Exclamation:
                {
                    pctTipoErro.Image = Properties.Resources.Exclamacao;
                    break;
                }
                case MessageBoxIcon.Question:
                {
                    pctTipoErro.Image = Properties.Resources.Interrogacao;
                    break;
                }
            }

            foreach (string mensagem in mensagemErro)
            {
                string texto = mensagem;
                if (texto.Length > 70)
                {
                    texto = texto.Substring(0, 70);
                    int indice = texto.Length - 1;

                    while (texto.Substring(indice - 1, 1) != " ")
                    {
                        texto = texto.Substring(0, texto.Length - 1);
                        indice--;
                    }

                    texto = texto.Substring(0, texto.Length - 1);
                }

                lstMensagemErro.Items.Add(texto);
                lstMensagemErro.Items.Add(mensagem.Substring(texto.Length));
            }

            foreach (string detalhe in detalhes)
            {
                lstDetalhesErro.Items.Add(detalhe);
            }

            btnOk.Focus();
        }

        private void btnDetalhes_Click(object sender, EventArgs e)
        {
            lstDetalhesErro.Visible = !lstDetalhesErro.Visible;
            this.Size = lstDetalhesErro.Visible ? new Size(546, 338) : new Size(546, 184);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}