using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UnimedVsfSystem
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            NameValueCollection nvcQuerystring = new NameValueCollection();

            //DADOS DO BOLETO
            nvcQuerystring.Add("banco", txtBanco.Text);
            nvcQuerystring.Add("vencimento", txtVencimento.Text);
            nvcQuerystring.Add("valor", txtValorBoleto.Text);
            nvcQuerystring.Add("moramulta", txtMoraMulta.Text);
            nvcQuerystring.Add("valorcobrado", txtValorCobrado.Text);
            nvcQuerystring.Add("nossonumero", txtNossoNumeroBoleto.Text);
            nvcQuerystring.Add("numerodocumento", txtNumeroDocumentoBoleto.Text);
            nvcQuerystring.Add("carteira", txtCarteira.Text);

            //DADOS DO CEDENTE
            nvcQuerystring.Add("cnpcedente", txtCPFCNPJ.Text);
            nvcQuerystring.Add("codigocedente", txtCodigoCedente.Text);
            nvcQuerystring.Add("nomecedente", txtNomeCedente.Text);
            nvcQuerystring.Add("agenciacedente", txtAgenciaCedente.Text);
            nvcQuerystring.Add("contacedente", txtContaCedente.Text);
            nvcQuerystring.Add("instrucoes", txtInstrucoes.Text);

            //DADOS DO SACADO
            nvcQuerystring.Add("cnpsacado", txtCPFCNPJSacado.Text);
            nvcQuerystring.Add("nomesacado", txtNomeSacado.Text);
            nvcQuerystring.Add("enderecosacado", txtEnderecoSacado.Text);
            nvcQuerystring.Add("bairrosacado", txtBairroSacado.Text);
            nvcQuerystring.Add("cidadesacado", txtCidadeSacado.Text);
            nvcQuerystring.Add("cepsacado", txtCEPSacado.Text);
            nvcQuerystring.Add("ufsacado", txtUFSacado.Text);

            string strNovaQuerystring = string.Empty;
            //foreach para montar a nova Querystring
            foreach (string key in nvcQuerystring.Keys)
            {
                strNovaQuerystring += key + "=" + nvcQuerystring[key] + "&";
            }

            //Adiciona '?' e remove o último '&'
            if (!string.IsNullOrEmpty(strNovaQuerystring))
                strNovaQuerystring = "?" + strNovaQuerystring.TrimEnd('&');

            //Fazer o redirect para a nova URL
            // Response.Redirect(Request.Url.AbsolutePath + strNovaQuerystring);
            Response.Redirect("/Boleto.aspx" + strNovaQuerystring);
        }
    }
}