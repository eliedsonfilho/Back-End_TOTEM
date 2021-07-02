using System;
using System.Collections.Generic;
using Dados;
using FluorineFx;

namespace Servicos
{
    [RemotingService]
    public class ServicoBoletoCobranca
    {
        public BoletoCobranca ObterBoletoCobrancaPorId(int autoIdBoletoCobranca, bool lazy, string codigoSitema, TelosUser usuario)
        {
            return Fachada.GetInstancia().ObterBoletoCobrancaPorId(autoIdBoletoCobranca, lazy, codigoSitema, usuario);
        }

        public IList<BoletoCobranca> ObterTodosBoletoCobrancaAbertosPorBeneficiario(Beneficiario beneficiario, string codigoSistema, TelosUser usuario)
        {
            return Fachada.GetInstancia().ObterTodosBoletoCobrancaAbertosPorBeneficiario(beneficiario,codigoSistema,usuario);
        }

        public IList<BoletoCobranca> ObterTodosBoletosPorBeneficiario(Beneficiario beneficiario, string codigoSistema, TelosUser usuario)
        {
            return Fachada.GetInstancia().ObterTodosBoletosPorBeneficiario(beneficiario, codigoSistema, usuario);
        }

        public bool VerificaBoletoVencido(BoletoCobranca boletoCobranca)
        {
            return Fachada.GetInstancia().VerificaBoletoVencido(boletoCobranca);
        }

        public IList<DateTime> ObterDatasVencimento(DateTime dataReferencia, int limiteDias, int quantidadeDatas)
        {
            return Fachada.GetInstancia().ObterDatasVencimento(dataReferencia, limiteDias, quantidadeDatas);
        }

        public bool VerificaImpressaoBoleto(BoletoCobranca boletoCobranca, Beneficiario beneficiario, int prazoMaximo, int inadimplenciaMaxima)
        {
            return Fachada.GetInstancia().VerificaImpressaoBoleto(boletoCobranca, beneficiario, prazoMaximo, inadimplenciaMaxima);
        }

        public IList<OpcaoVencimentoBoleto> ObterOpcoesVencimentosBoleto(BoletoCobranca boletoCobranca, int limiteDias, int quantidadeDatas)
        {
            return Fachada.GetInstancia().ObterOpcoesVencimentosBoleto(boletoCobranca, limiteDias, quantidadeDatas);
        }

        public decimal CalculaJurosBoleto(DateTime dataInicial, DateTime dataFinal, decimal valorInicial, decimal percentualJuros, decimal percentualMulta)
        {
            return Fachada.GetInstancia().CalculaJurosBoleto(dataInicial, dataFinal, valorInicial, percentualJuros, percentualMulta);
        }
    }
}