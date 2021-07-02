using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Windows.Forms;
using FluorineFx.Context;
using Dados;

namespace Util.TratamentoErros
{
    public class TratamentoExcecoes : Exception
    {
        public TratamentoExcecoes()
        {}

        public static void TratarExcecaoMessageBox(string mensagem, MessageBoxButtons botoes, MessageBoxIcon icone)
        {
            CriarArquivoLog(mensagem, null, null, null);
            MessageBox.Show("Erro: " + mensagem, "Solutions", botoes, icone);
        }

        public static void TratarExcecaoTelaWinForms(Exception exception, string mensagem, MessageBoxButtons botoes, MessageBoxIcon icone)
        {
            string mensagemExcessao = TratarRecursaoExcecao(exception);

            CriarArquivoLog(mensagem + Environment.NewLine + mensagemExcessao, exception.StackTrace, exception.GetType().Name, exception.Source);

            IList<string> mensagens = new List<string>();
            int index = -1;
            string tmp1 = mensagem + "\n" + mensagemExcessao;
            while (tmp1.Contains("\n"))
            {
                index = tmp1.IndexOf('\n');
                if (index >= 0)
                {
                    mensagens.Add(tmp1.Substring(0, index));
                    tmp1 = tmp1.Substring(index + 1);
                }
            }
            mensagens.Add(tmp1);

            IList<string> detalhes = new List<string>();
            index = -1;
            tmp1 = exception.StackTrace;
            detalhes.Add("PILHA DE EXECUÇÃO: ");
            while (tmp1.Contains("\n"))
            {
                index = tmp1.IndexOf('\n');
                if (index >= 0)
                {
                    detalhes.Add(tmp1.Substring(0, index));
                    tmp1 = tmp1.Substring(index + 2);
                }
            }
            detalhes.Add(tmp1);
            detalhes.Add("CLASSE DA EXCEÇÃO: " + exception.GetType().Name);
            detalhes.Add("ORIGEM DA EXCEÇÃO: " + exception.Source);
            frmVisualizarErro frmVisualizarErro = new frmVisualizarErro(mensagens, detalhes, icone);
            frmVisualizarErro.ShowDialog();
        }

        public static void TratarExcecaoTelaWinForms(Exception exception, MessageBoxButtons botoes, MessageBoxIcon icone)
        {
            string mensagem = TratarRecursaoExcecao(exception);

            CriarArquivoLog(mensagem, exception.StackTrace, exception.GetType().Name, exception.Source);

            IList<string> mensagens = new List<string>();
            int index = -1;
            string tmp1 = mensagem;
            while (tmp1.Contains("\n"))
            {
                index = tmp1.IndexOf('\n');
                if (index >= 0)
                {
                    mensagens.Add(tmp1.Substring(0, index));
                    tmp1 = tmp1.Substring(index + 1);
                }
            }
            mensagens.Add(tmp1);

            IList<string> detalhes = new List<string>();
            index = -1;
            tmp1 = exception.StackTrace;
            detalhes.Add("PILHA DE EXECUÇÃO: ");
            while (tmp1.Contains("\n"))
            {
                index = tmp1.IndexOf('\n');
                if (index >= 0)
                {
                    detalhes.Add(tmp1.Substring(0, index));
                    tmp1 = tmp1.Substring(index + 2);
                }
            }
            detalhes.Add(tmp1);
            detalhes.Add("CLASSE DA EXCEÇÃO: " + exception.GetType().Name);
            detalhes.Add("ORIGEM DA EXCEÇÃO: " + exception.Source);
            frmVisualizarErro frmVisualizarErro = new frmVisualizarErro(mensagens, detalhes, icone);
            frmVisualizarErro.ShowDialog();
        }

        public static string TratarRecursaoExcecao(Exception exception)
        {
            string retorno = "";
            if(exception.InnerException != null)
            {
                retorno += TratarRecursaoExcecao(exception.InnerException);
            }

            retorno += exception.Message + Environment.NewLine;
            
            return retorno;
        }

        public static string CriarArquivoLog(string mensagem, string pilhaExecucao, string nomeClasse, string origemExcecao)
        {
            string path = null;
            if(FluorineContext.Current != null || HttpContext.Current.Items != null)
            {
                path = HttpContext.Current.Request.ApplicationPath;
                path = HttpContext.Current.Request.MapPath(path + @"\Logs\");
            }
            else
            {
                path = Application.StartupPath + @"\" + Application.ProductName + @"\Logs\";
            }

            Directory.CreateDirectory(path);

            string nomeArquivo = path + Application.ProductName + DateTime.Now.ToString("ddMMyyyy") + ".log";
            StreamWriter streamWriter;
            streamWriter = File.Exists(nomeArquivo) 
                            ? new StreamWriter(nomeArquivo, true) 
                            : new StreamWriter(nomeArquivo, false);

            streamWriter.WriteLine(new string('-', 30) + DateTime.Now.ToString("HH:mm:ss") + new string('-', 30));
            streamWriter.WriteLine("Mensagem de Erro:-> " + mensagem + "<=");
            streamWriter.WriteLine("Pilha de Execução:-> " + pilhaExecucao + "<=");
            streamWriter.WriteLine("Classe da Exceção:-> " + nomeClasse + "<=");
            streamWriter.WriteLine("Origem da Exceção:-> " + origemExcecao +"<=");
            streamWriter.WriteLine(new string('=', 30) + DateTime.Now.ToString("HH:mm:ss") + new string('=', 30));
            streamWriter.Close();

            return mensagem;
        }

        public static string CriarArquivoLog(Exception exception)
        {
            return CriarArquivoLog(TratarRecursaoExcecao(exception), exception.StackTrace, exception.GetType().Name, exception.Source);
        }

        public static string CriarLog(string campo, EnumOperacaoBanco enumOperacaoBanco, long idTabela, string nomeTabela, string usuario, string valueVelho, string valueNovo)
        {
            string path = null;
            string retorno=string.Empty;
            if (FluorineContext.Current != null || HttpContext.Current.Items != null)
            {
                path = Path.GetDirectoryName(HttpContext.Current.Request.Path);
                path = HttpContext.Current.Request.MapPath(path + @"\Logs\");
            }
            else
            {
                path = Application.StartupPath + @"\" + Application.ProductName + @"\Logs\";
            }

            Directory.CreateDirectory(path);

            string nomeArquivo = path + Application.ProductName +"LogBanco"+ DateTime.Now.ToString("ddMMyyyy") + ".log";
            StreamWriter streamWriter;
            streamWriter = File.Exists(nomeArquivo)
                            ? new StreamWriter(nomeArquivo, true)
                            : new StreamWriter(nomeArquivo, false);

            streamWriter.WriteLine(enumOperacaoBanco + " executado pelo Usuário: " + usuario + " em " + DateTime.Now.ToString("HH:mm:ss"));
            streamWriter.WriteLine("Informação Tabela:-> idTabela: " + idTabela + " Nome da Tabela: "+ nomeTabela);
            streamWriter.WriteLine("Valores:-> Valor Velho: " +valueVelho + " Valor Novo: " + valueNovo);
            streamWriter.WriteLine(retorno);
            streamWriter.Close();
            return retorno;
        }
    }
}
