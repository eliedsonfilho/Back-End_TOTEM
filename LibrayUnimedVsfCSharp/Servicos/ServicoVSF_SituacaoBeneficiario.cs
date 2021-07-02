using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dados;
using FluorineFx;

namespace Servicos
{
    [RemotingService]
    public class ServicoVSF_SituacaoBeneficiario
    {
        public VSF_SituacaoBeneficiario ObterSituacaoBeneficiarioPorBeneficiario(Beneficiario beneficiario, string codigoSistema, TelosUser usuario)
        {
            return Fachada.GetInstancia().ObterSituacaoBeneficiarioPorBeneficiario(beneficiario, codigoSistema, usuario);
        }
    }
}
