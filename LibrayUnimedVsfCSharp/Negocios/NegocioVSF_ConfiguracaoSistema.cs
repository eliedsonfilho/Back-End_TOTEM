using System.Collections.Generic;
using Dados;
using Repositorios;

namespace Negocios
{
    public class NegocioVSF_ConfiguracaoSistema
    {
        private RepositorioVSF_ConfiguracaoSistema _repositorioVsfConfiguracaoSistema;

        public NegocioVSF_ConfiguracaoSistema()
        {
            _repositorioVsfConfiguracaoSistema = new RepositorioVSF_ConfiguracaoSistema();
        }

        public VSF_ConfiguracaoSistema ObterPorId(int autoId, bool lazy)
        {
            return _repositorioVsfConfiguracaoSistema.ObterPorId(autoId, lazy);
        }

        public IList<VSF_ConfiguracaoSistema> ObterTodos(bool lazy)
        {
            return _repositorioVsfConfiguracaoSistema.ObterTodos(lazy);
        }

        public IList<VSF_ConfiguracaoSistema> ObterTodos(VSF_ConfiguracaoSistema objetoPesquisado, bool lazy)
        {
            return _repositorioVsfConfiguracaoSistema.ObterTodos(objetoPesquisado, lazy);
        }

        public VSF_ConfiguracaoSistema Inserir(VSF_ConfiguracaoSistema configuracaoSistema)
        {
            return _repositorioVsfConfiguracaoSistema.Inserir(configuracaoSistema);
        }

        public VSF_ConfiguracaoSistema Atualizar(VSF_ConfiguracaoSistema configuracaoSistema)
        {
            return _repositorioVsfConfiguracaoSistema.Atualizar(configuracaoSistema);
        }

        public VSF_ConfiguracaoSistema ObterConfiguracaoSistemaPorCodigoSistema(string codigo, bool lazy)
        {
            NegocioVSF_Sistema negocioVsfSistema = new NegocioVSF_Sistema();

            return _repositorioVsfConfiguracaoSistema.ObterPorSistema(negocioVsfSistema.ObterPorCodigo(codigo,true), lazy);
        }
    }
}