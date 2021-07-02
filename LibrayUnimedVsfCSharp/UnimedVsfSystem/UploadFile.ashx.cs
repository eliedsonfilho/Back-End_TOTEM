using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Dados;
using Servicos;

namespace WebFluorine
{
    /// <summary>
    /// Summary description for UploadFile
    /// </summary>
    public class UploadFile : IHttpHandler
    {
        private string _caminhoArquivo;
        private Arquivo _arquivo;
        
        public void ProcessRequest(HttpContext context)
        {
            string objetoPai = context.Request.QueryString["ObjetoPai"];
            string nomeArquivoServidor = context.Request.QueryString["NomeArquivoServidor"];
            CaminhoArquivo = HttpContext.Current.Server.MapPath("~/Arquivos/" + objetoPai + "/");
            if(context.Request.Files.Count == 0)
            {
                context.Response.Write("<result><status>Error</status><message>Sem arquivos Selecionados!</message></result>");  
                return;
            }
            
            try 
            {
                foreach (string indiceArquivo in context.Request.Files)
                {
                    HttpPostedFile arquivo = context.Request.Files[indiceArquivo];
                    Directory.CreateDirectory(CaminhoArquivo);

                    arquivo.SaveAs(Path.Combine(CaminhoArquivo, nomeArquivoServidor));
                }

                context.Response.Write("<result><status>Success</status><message>Upload Completo</message></result>");
            }
            catch (HttpException exception)
            {
                    
                throw;
            }
        }

        public virtual string CaminhoArquivo
        {
            get { return _caminhoArquivo; }
            set { _caminhoArquivo = value; }
        }

        public virtual Arquivo Arquivo
        {
            get { return _arquivo; }
            set { _arquivo = value; }
        }

        public bool IsReusable
        {
            get
            {
                return true;
            }
        }
    }
}