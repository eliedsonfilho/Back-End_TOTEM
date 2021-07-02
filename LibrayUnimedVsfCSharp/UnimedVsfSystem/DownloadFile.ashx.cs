using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Neturion.WebFluorine
{
    /// <summary>
    /// Summary description for DownloadFile
    /// </summary>
    public class DownloadFile : IHttpHandler
    {
        private String _caminhoArquivo;

        public void ProcessRequest(HttpContext context)
        {
            if(context.Request.Files.Count == 0)
            {
                context.Response.Write("<result><status>Error</status><message>Sem arquivos Selecionados!</message></result>");
                return;
            }
        }

        public virtual string CaminhoArquivo
        {
            get { return _caminhoArquivo; }
            set { _caminhoArquivo = value; }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}