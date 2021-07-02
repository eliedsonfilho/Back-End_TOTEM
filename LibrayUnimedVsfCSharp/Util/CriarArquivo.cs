using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Windows.Forms;
using Util.TratamentoErros;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;

namespace Util
{
    public class CriarArquivo
    {
        public static bool CriarDoc(object arquivo, string nomeArquivo, Page page)
        {
            bool retorno = false;
            if (arquivo != null)
            {
                try
                {
                    if (HttpContext.Current != null)
                    {
                        page.Response.Clear();
                        page.Response.Charset = "";
                        page.Response.ContentType = "application/vnd.ms-word";
                        page.Response.AddHeader("content-disposition", "attachment;filename=" + nomeArquivo + ".doc");
                        page.EnableViewState = false;
                        page.Request.ContentEncoding = Encoding.UTF8;
                        page.Response.Write(arquivo);
                        page.Response.Flush();
                        page.Response.End();
                    }
                    else
                    {

                    }

                    retorno = true;
                }
                catch (Exception exception)
                {
                    string mensagemErro = TratamentoExcecoes.CriarArquivoLog(exception);
                    throw new Exception(mensagemErro);
                }
            }
            else
            {
                MessageBox.Show("Não há dados a serem exportados!", "Solutions", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            return retorno;
        }

        public static bool CriarXls(object arquivo, string nomeArquivo, Page page)
        {
            bool retorno = false;
            if (arquivo != null)
            {
                try
                {
                    if (HttpContext.Current != null)
                    {
                        page.Response.Clear();
                        page.Response.Charset = "";
                        page.Response.ContentType = "application/vnd.ms-excel";
                        page.Response.AddHeader("content-disposition", "attachment;filename=" + nomeArquivo + ".xls");
                        page.EnableViewState = false;
                        page.Request.ContentEncoding = Encoding.UTF8;
                        page.Response.Write(arquivo);
                        page.Response.Flush();
                        page.Response.End();
                    }
                    else
                    {

                    }

                    retorno = true;
                }
                catch (Exception exception)
                {
                    string mensagemErro = TratamentoExcecoes.CriarArquivoLog(exception);
                    throw new Exception(mensagemErro);
                }
            }
            else
            {
                MessageBox.Show("Não há dados a serem exportados!", "Solutions", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            return retorno;
        }

        public static bool CriarPdf(object arquivo, string nomeArquivo, Page page)
        {
            bool retorno = false;
            if (arquivo != null)
            {
                try
                {
                    if (HttpContext.Current != null)
                    {
                        page.Response.Clear();
                        page.Response.Charset = "";
                        page.Response.AddHeader("content-disposition",
                                                    "attachment; filename=" + nomeArquivo + ".pdf");
                        page.Response.ContentType = "application/pdf";
                        page.EnableViewState = false;
                        page.Request.ContentEncoding = Encoding.UTF8;
                        page.Response.Write(arquivo);
                        page.Response.Flush();
                        page.Response.End();
                    }
                    else
                    {

                    }

                    retorno = true;
                }
                catch (Exception exception)
                {
                    string mensagemErro = TratamentoExcecoes.CriarArquivoLog(exception);
                    throw new Exception(mensagemErro);
                }
            }
            else
            {
                MessageBox.Show("Não há dados a serem exportados!", "Solutions", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            return retorno;
        }

        public static bool CriarPdf(string arquivo)
        {
            bool retorno = false;
            if (arquivo != null)
            {
                try
                {
                    // Captura ou atribui o HTML a ser convertido - no caso estou baixando de uma URL
                    string html = GerarImagem(arquivo);//@"<img src="+GerarImagem(arquivo)+" />";
                    // Cria o documento aplicando o tamanho e margens
                    Document documento = new Document(PageSize.A4);
                    // Memory Stream para ser usado na conversão e emissão
                    //MemoryStream ms = new MemoryStream();
                    // Inicializa o gravador
                    arquivo = Path.ChangeExtension(arquivo, "pdf");
                    PdfWriter.GetInstance(documento, new FileStream(arquivo, FileMode.Create));
                    // Lê o HTML e atribui
                    //StringReader conteudo = new StringReader(html);
                    // Objeto de conversão do HTML
                    //HTMLWorker objeto = new HTMLWorker(documento);
                    // Abre o documento
                    documento.Open();
                    iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(html);
                    image.SetAbsolutePosition(5, 5);
                    documento.Add(image);
                    // Aplica o parser para análise de conversão
                    // Geralmente aqui ocasiona muitos erros - irei explicar no post
                    //objeto.Parse(conteudo);
                    // Fecha o documento
                    documento.Close();
                    // Força o download do PDF gerado - se desejável você pode salvar em disco também
                    
                    //HttpContext.Current.Response.Clear();
                    //HttpContext.Current.Response.AddHeader("content-disposition", "attachment; filename=" + Path.GetFileName(arquivo));
                    //HttpContext.Current.Response.ContentType = "application/pdf";
                    //HttpContext.Current.Response.Buffer = true;
                    //HttpContext.Current.Response.OutputStream.Write(ms.GetBuffer(), 0, ms.GetBuffer().Length);
                    //HttpContext.Current.Response.OutputStream.Flush();
                    //HttpContext.Current.Response.End();

                    retorno = true;
                }
                catch (Exception exception)
                {
                    string mensagemErro = TratamentoExcecoes.CriarArquivoLog(exception);
                    throw new Exception(mensagemErro);
                }
            }
            else
            {
                MessageBox.Show("Não há dados a serem exportados!", "Solutions", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            return retorno;
        }

        public static bool CriarPdf(StringBuilder arquivo, string nomeArquivo)
        {
            bool retorno = false;
            if (arquivo != null)
            {
                Document document;
                try
                {
                    document = new Document(PageSize.A4);
                    StringReader se = new StringReader(arquivo.ToString());
                    HTMLWorker obj = new HTMLWorker(document);
                    document.Open();
                    obj.Parse(se);
                    document.Close();
                    MemoryStream memoryStream = new MemoryStream();
                    PdfWriter.GetInstance(document, memoryStream);

                    if (memoryStream.Length > 0)
                    {
                        HttpContext.Current.Response.Clear();
                        HttpContext.Current.Response.AddHeader("content-disposition", "attachment; filename=" + nomeArquivo);
                        HttpContext.Current.Response.ContentType = "application/pdf";
                        HttpContext.Current.Response.Buffer = true;
                        HttpContext.Current.Response.OutputStream.Write(memoryStream.GetBuffer(), 0, memoryStream.GetBuffer().Length);
                        HttpContext.Current.Response.OutputStream.Flush();
                        HttpContext.Current.Response.End();
                    }
                    else
                    {
                        MessageBox.Show("Não há dados a serem exportados!", "Solutions", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }

                    retorno = true;
                }
                catch (Exception exception)
                {
                    string mensagemErro = TratamentoExcecoes.CriarArquivoLog(exception);
                    throw new Exception(mensagemErro);
                }
            }
            else
            {
                MessageBox.Show("Não há dados a serem exportados!", "Solutions", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            return retorno;
        }

        public static void ExluirArquivo(string nomeArquivo)
        {
            if (File.Exists(nomeArquivo))
            {
                File.Delete(nomeArquivo);
            }
        }

        public static string GerarImagem(string nomeArquivo)
        {
            string address = nomeArquivo;
            int width = 580;
            int height = 800;

            int webBrowserWidth = 670;
            int webBrowserHeight = 800;

            Bitmap bmp = WebsiteThumbnailImageGenerator.GetWebSiteThumbnail(address, webBrowserWidth, webBrowserHeight, width, height);

            string file = Path.ChangeExtension(nomeArquivo, "bmp");

            bmp.Save(file);

            return file;
        }
    }
}