using System.Collections.Generic;
using Dados;
using Repositorios;

namespace Negocios
{
    public class NegocioVSF_Sistema
    {
        private RepositorioVSF_Sistema _repositorioVsfSistema;

        public NegocioVSF_Sistema()
        {
            _repositorioVsfSistema= new RepositorioVSF_Sistema();
        }

        public VSF_Sistema ObterPorCodigo(string codigo, bool lazy)
        {
            return _repositorioVsfSistema.ObterPorCodigo(codigo, lazy);
        }

        public VSF_Sistema ObterPorId(int codigo, bool lazy)
        {
            return _repositorioVsfSistema.ObterPorId(codigo, lazy);
        }

        public IList<VSF_Sistema> ObterTodos(bool lazy)
        {
            return _repositorioVsfSistema.ObterTodos(lazy);
        }

        public IList<VSF_Sistema> ObterTodos(VSF_Sistema objetoPesquisado, bool lazy)
        {
            return _repositorioVsfSistema.ObterTodos(objetoPesquisado, lazy);
        }
    }
}