using System;
using System.Text;
using Relatorios;
using Util;

namespace WebFluorine
{
    public partial class Export : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string tipo = Context.Request.QueryString["Tipo"];
            string nomeArquivo = Context.Request.QueryString["Arquivo"];
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(Request["htmltable"]);

            switch(tipo.ToLower())
            {
                case "doc":
                    {
                        CriarArquivo.CriarDoc(stringBuilder, nomeArquivo, this);

                        break;
                    }
                case "xls":
                    {
                        CriarArquivo.CriarXls(stringBuilder, nomeArquivo, this);

                        break;
                    }
                case "pdf":
                    {
                        CriarArquivo.CriarPdf(stringBuilder, nomeArquivo, this);

                        break;
                    }
                case "print":
                    {
                        GerenciadorRelatorios.GerarRelatorio(nomeArquivo);

                        break;
                    }
            }
        }
    }
}