using System;
using System.Collections.Generic;
using Dados;
using FluorineFx;

namespace Servicos
{
    [RemotingService]
    public class ServicoCartaoIdentificacao
    {
        public CartaoIdentificacao ObterCartaoIdentificacaoPorId(int autoId, bool lazy)
        {
            return Fachada.GetInstancia().ObterCartaoIdentificacaoPorId(autoId,lazy);
        }

        public IList<CartaoIdentificacao> ObterTodosCartaoIdentificacao(bool lazy)
        {
            return Fachada.GetInstancia().ObterTodosCartaoIdentificacao(lazy);
        }

        public IList<CartaoIdentificacao> ObterTodosCartaoIdentificacao(CartaoIdentificacao objetoPesquisado, bool lazy)
        {
            return Fachada.GetInstancia().ObterTodosCartaoIdentificacao(objetoPesquisado, lazy);
        }

        public CartaoIdentificacao ObterCartaoIdentificacaoPorCodigo(string codigo, bool lazy)
        {
            return Fachada.GetInstancia().ObterCartaoIdentificacaoPorCodigo(codigo, lazy);
        }
    }
}