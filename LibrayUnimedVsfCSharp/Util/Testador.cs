using System;
using System.IO;
using System.Web;
using FluorineFx.Context;

namespace Util
{
    public class Testador
    {
        public static string EscreverMensagemTexto(string mensagem)
        {
            string path = null;
            if (FluorineContext.Current != null || HttpContext.Current.Items != null)
            {
                path = HttpContext.Current.Request.ApplicationPath;
                path = HttpContext.Current.Request.MapPath(path + @"\Testes\");
            }

            Directory.CreateDirectory(path);

            string nomeArquivo = path + "Teste de Codigo" + DateTime.Now.ToString("ddMMyyyy") + ".txt";
            StreamWriter streamWriter;
            streamWriter = File.Exists(nomeArquivo)
                            ? new StreamWriter(nomeArquivo, true)
                            : new StreamWriter(nomeArquivo, false);

            streamWriter.WriteLine(mensagem);

            streamWriter.Close();

            return mensagem;
        }
    }
}