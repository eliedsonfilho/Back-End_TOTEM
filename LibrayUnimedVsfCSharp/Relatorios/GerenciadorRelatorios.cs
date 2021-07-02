using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Windows.Forms;
using FluorineFx.Context;
using Util.TratamentoErros;

namespace Relatorios
{
    public class GerenciadorRelatorios
    {
        public GerenciadorRelatorios()
        { }

        private static string _nomeArquivo;

        public static bool GerarRelatorio(string nomeArquivo)
        {
            _nomeArquivo = nomeArquivo;
            bool retorno = false;
            try
            {
                SelecionarRelatorio();
                retorno = true;
            }
            catch (Exception exception)
            {
                string mensagemErro = TratamentoExcecoes.CriarArquivoLog(exception);
                throw new Exception(mensagemErro);
            }

            return retorno;
        }

        private static void SelecionarRelatorio()
        {
            string path = null;
            if (FluorineContext.Current != null || HttpContext.Current.Items != null)
            {
                path = HttpContext.Current.Request.ApplicationPath;
                path = HttpContext.Current.Request.MapPath(path + @"\bin\Relatorios\");
            }
            else
            {
                path = Application.StartupPath + @"\" + Application.ProductName + @"\Relatorios\";
            }

            if (Directory.Exists(path))
            {
                DirectoryInfo di = new DirectoryInfo(path);
                FileInfo[] smFiles = di.GetFiles("*.aspx", SearchOption.AllDirectories);
                string nomeRelatorio;
                foreach (FileInfo fileInfo in smFiles.Where(x => Path.GetFileNameWithoutExtension(x.Name) != null
                                                                && Path.GetFileNameWithoutExtension(x.Name).Equals(_nomeArquivo)))
                {
                    nomeRelatorio = fileInfo.Name;
                    break;
                }

                //System.Web.HttpResponse response = new HttpResponse();
                //response.Redirect(nomeRelatorio);
            }
            else
            {
                throw new Exception("Diretório de Relatório não localizado!");
            }
        } 
    }
}