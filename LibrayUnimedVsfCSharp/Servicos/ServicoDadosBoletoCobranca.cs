using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dados;
using FluorineFx;

namespace Servicos
{
    [RemotingService]
    public class ServicoDadosBoletoCobranca
    {
        public DadosBoletoCobranca ObterPorDocFinanceiro(BoletoCobranca boletoCobranca, string codigoSistema, TelosUser usuario)
        {
            return Fachada.GetInstancia().ObterPorDocFinanceiro(boletoCobranca, codigoSistema, usuario);
        }

        public DadosBoletoCobranca ObterPorDocFinanceiro(int autoIdDocFin, string codigoSistema, TelosUser usuario)
        {
            return Fachada.GetInstancia().ObterPorDocFinanceiro(autoIdDocFin, codigoSistema, usuario);
        }

        
    }
}
