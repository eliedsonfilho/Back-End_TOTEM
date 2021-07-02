using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dados;
using Repositorios;

namespace Negocios
{
    public class NegocioVSF_ConfiguracaoFinanceira
    {
        private RepositorioVSF_ConfiguracaoFinanceira _repositorioVsfConfiguracaoFinanceira;
        
        public NegocioVSF_ConfiguracaoFinanceira()
        {
            _repositorioVsfConfiguracaoFinanceira = new RepositorioVSF_ConfiguracaoFinanceira();
        }

        public VSF_ConfiguracaoFinanceira ObterVSF_ConfiguracaoFinanceira(bool lazy)
        {
            return _repositorioVsfConfiguracaoFinanceira.Obter(lazy);
        }
    }
}
