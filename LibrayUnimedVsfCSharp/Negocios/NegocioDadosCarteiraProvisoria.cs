using System.Collections.Generic;
using Dados;
using Repositorios;

namespace Negocios
{
    public class NegocioDadosCarteiraProvisoria
    {
        private Repositorios.RepositorioDadosCarteiraProvisoria _repositorioDadosCarteiraProvisoria;

        public NegocioDadosCarteiraProvisoria()
        {
            _repositorioDadosCarteiraProvisoria = new RepositorioDadosCarteiraProvisoria();
        }

        public DadosCarteiraProvisoria ObterDadosCarteiraProvisoriaPorCodigo(long codigo, bool lazy)
        {
            return _repositorioDadosCarteiraProvisoria.ObterPorId(codigo, lazy);
        }

        public IList<DadosCarteiraProvisoria> ObterTodos(bool lazy)
        {
            return _repositorioDadosCarteiraProvisoria.ObterTodos(lazy);
        }

        public IList<DadosCarteiraProvisoria> ObterTodos(DadosCarteiraProvisoria objetoPesquisado, bool lazy)
        {
            return _repositorioDadosCarteiraProvisoria.ObterTodos(objetoPesquisado, lazy);
        }
    }
}