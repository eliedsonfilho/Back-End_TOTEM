using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dados;
using Repositorios;

namespace Negocios
{
    public class NegocioDadosBoletoCobranca
    {
        private RepositorioDadosBoletoCobranca _repositrioDadosBoletoCobranca;

        public NegocioDadosBoletoCobranca()
        {
            _repositrioDadosBoletoCobranca = new RepositorioDadosBoletoCobranca();
        }

        public DadosBoletoCobranca ObterPorDocFinanceiro(BoletoCobranca boletoCobranca)
        {
            return _repositrioDadosBoletoCobranca.ObterPorDocFinanceiro(boletoCobranca.AutoIdDocFinan, true);
        }

        public DadosBoletoCobranca ObterPorDocFinanceiro(int autoIdDocFinan)
        {
            return _repositrioDadosBoletoCobranca.ObterPorDocFinanceiro(autoIdDocFinan, true);
        }
    }
}
