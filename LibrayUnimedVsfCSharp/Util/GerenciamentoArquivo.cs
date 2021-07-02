using System.IO;
using System.Web;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using FluorineFx.Context;

namespace Util
{
    public class GerenciamentoArquivo
    {
        private string _nomePasta;
        private string _nomeArquivo;

        public GerenciamentoArquivo()
        {
        }

        public string NomePasta
        {
            get { return _nomePasta; }
            set { _nomePasta = value; }
        }

        public string NomeArquivo
        {
            get { return _nomeArquivo; }
            set { _nomeArquivo = value; }
        }


        private string CaminhoArquivos()
        {
            string path = null;
            if (FluorineContext.Current != null || HttpContext.Current.Items != null)
            {
                path = HttpContext.Current.Request.ApplicationPath;
                path = HttpContext.Current.Request.MapPath(path + @"\Arquivos\");
            }
            else
            {
                path = Application.StartupPath + @"\" + Application.ProductName + @"\Arquivos\";
            }

            path += @"\" + _nomePasta + @"\";

            Directory.CreateDirectory(path);

            return path;
        }

        public string Upload()
        {
            string resposta = string.Empty;
            FileUpload fileUpload1 = new FileUpload();

            if (fileUpload1.PostedFile.FileName == "")
            {
                resposta = "Escolha um arquivo";
            }
            else
            {
                string strCaminho = CaminhoArquivos() + _nomeArquivo;
                fileUpload1.PostedFile.SaveAs(strCaminho);
            }

            return resposta;
        }

        private void VerificarNomeArquivo()
        {
            if(_nomeArquivo.Contains(@"\") || _nomeArquivo.Contains(@"/") || _nomeArquivo.Contains(":"))
            {
                string novoNomeArquivo = string.Empty;

            }
        }
    }
}