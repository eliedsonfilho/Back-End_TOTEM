using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dados;
using FluorineFx;

namespace Servicos
{
    [RemotingService]
    public class ServicoVSF_ConfiguracaoFinanceira
    {
        public VSF_ConfiguracaoFinanceira ObterVSF_ConfiguracaoFinanceira(bool lazy, string codigoSistema, TelosUser usuario)
        {
            return Fachada.GetInstancia().ObterVSF_ConfiguracaoFinanceira(lazy, codigoSistema, usuario);
        }
    }
}
