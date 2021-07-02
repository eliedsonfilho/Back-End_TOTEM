using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dados;
using Repositorios;

namespace Negocios
{
    public class NegocioVSF_SituacaoBeneficiario
    {
        private RepositorioVSF_SituacaoBeneficiario _repositorioVsfSituacaoBeneficiario;

        public NegocioVSF_SituacaoBeneficiario()
        {
            _repositorioVsfSituacaoBeneficiario = new RepositorioVSF_SituacaoBeneficiario();
        }

        public VSF_SituacaoBeneficiario ObterPorBeneficiario(Beneficiario benenficiario)
        {
            return _repositorioVsfSituacaoBeneficiario.ObterPorId(benenficiario.AutoId, true);
        }
    }
}
