using System;
using System.IO;
using System.Web;
using Dados;
using FluorineFx;
using FluorineFx.Context;
using Util;
using Util.TratamentoErros;

namespace Servicos
{
    [RemotingService]
    public class ServicoUtil
    {
        public string EscreverValorPorExtenso(string valor)
        {
            EscreverValorPorExtenso escreverValorPorExtenso = new EscreverValorPorExtenso(Convert.ToDecimal(valor));
            return escreverValorPorExtenso.ToString();
        }

        public void EnviarEmail(string toEmailAddress, string ccEmailAddress, string bccEmailAddress, string fromEmailAddress, string fromDisplayName, string senha,
            string subject, string body, string attachment, string portServer, string host, bool enableSsl)
        {
            EmailNotificationService.EnviarEmail(toEmailAddress, ccEmailAddress, bccEmailAddress, fromEmailAddress, fromDisplayName, senha,
                                                        subject, body, attachment, portServer, host, enableSsl);
        }

        public bool ValidarCodigoCartao(string codigo)
        {
            return Utils.ValidarCodigoCartao(codigo);
        }

        public string CodigoBeneficiarioMascarado(long codigo)
        {
            return Utils.CodigoBeneficiarioMascarado(codigo);
        }

        public string DataPorExtenso(DateTime data)
        {
            return Utils.DataPorExtenso(data);
        }

        public void ImprimirArquivo(string nomeImpressora, string nomeArquivo)
        {
            RawPrinterHelper.ImpressaoArquivo(nomeImpressora, nomeArquivo);
        }

        public void ImprimirArquivoBoleto(string nomeImpressora, string nomeArquivo)
        {
            RawPrinterHelper.ImpressaoArquivo(nomeImpressora, nomeArquivo);
        }

        public void ExcluirArquivo(string nomeArquivo)
        {
            CriarArquivo.ExluirArquivo(nomeArquivo);
        }

        public void ExcluirArquivoBoleto(string nomeArquivo)
        {
            string path = HttpContext.Current.Server.MapPath(@"~/Boletos/");
            CriarArquivo.ExluirArquivo(path +  nomeArquivo);

            nomeArquivo = Path.ChangeExtension(nomeArquivo, "pdf");
            CriarArquivo.ExluirArquivo(path + nomeArquivo);

            nomeArquivo = Path.ChangeExtension(nomeArquivo, "bmp");
            CriarArquivo.ExluirArquivo(path + nomeArquivo);
        }
    }
}