using System.Collections.Generic;
using Dados;
using Repositorios;

namespace Negocios
{
    public class NegocioCartaoIdentificacao
    {
        private RepositorioCartaoIdentificacao _repositorioCartaoIdentificacao;

        public NegocioCartaoIdentificacao()
        {
            _repositorioCartaoIdentificacao = new RepositorioCartaoIdentificacao();
        }

        public CartaoIdentificacao ObterPorId(int autoId, bool lazy)
        {
            return _repositorioCartaoIdentificacao.ObterPorId(autoId, lazy);
        }

        public IList<CartaoIdentificacao> ObterTodos(bool lazy)
        {
            return _repositorioCartaoIdentificacao.ObterTodos(lazy);
        }

        public IList<CartaoIdentificacao> ObterTodos(CartaoIdentificacao objetoPesquisado, bool lazy)
        {
            return _repositorioCartaoIdentificacao.ObterTodos(objetoPesquisado, lazy);
        }

        public CartaoIdentificacao ObterPorCodigo(string codigo, bool lazy)
        {
            return _repositorioCartaoIdentificacao.ObterPorCodigo(codigo, lazy);
        }
    }
}