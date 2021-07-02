using System;
using System.Collections;
using System.Collections.Generic;
using Dados;
using FluorineFx;

namespace Servicos
{
    [RemotingService]
    public class ServicoVSF_SolicitacaoCartaoIdentificacao
    {
        public VSF_SolicitacaoCartaoIdentificacao ObterVSF_SolicitacaoCartaoIdentificacaoPorId(int autoId, bool lazy, string codigoSistema, TelosUser usuario)
        {
            return Fachada.GetInstancia().ObterVSF_SolicitacaoCartaoIdentificacaoPorId(autoId,lazy,codigoSistema,usuario);
        }

        public IList<VSF_SolicitacaoCartaoIdentificacao> ObterTodosVSF_SolicitacaoCartaoIdentificacaos(bool lazy, string codigoSistema, TelosUser usuario)
        {
            return Fachada.GetInstancia().ObterTodosVSF_SolicitacaoCartaoIdentificacaos(lazy,codigoSistema,usuario);
        }

        public IList<VSF_SolicitacaoCartaoIdentificacao> ObterTodosVSF_SolicitacaoCartaoIdentificacaos(VSF_SolicitacaoCartaoIdentificacao solicitacaoCartao, bool lazy, string codigoSistema, TelosUser usuario)
        {
            return Fachada.GetInstancia().ObterTodosVSF_SolicitacaoCartaoIdentificacaos(solicitacaoCartao,lazy, codigoSistema, usuario);
        }

        public VSF_SolicitacaoCartaoIdentificacao InserirVSF_SolicitacaoCartaoIdentificacao(VSF_SolicitacaoCartaoIdentificacao solicitacaoCartao, string codigoSistema, TelosUser usuario)
        {
            return Fachada.GetInstancia().InserirVSF_SolicitacaoCartaoIdentificacao(solicitacaoCartao, codigoSistema, usuario);
        }

        public VSF_SolicitacaoCartaoIdentificacao AtualizarVSF_SolicitacaoCartaoIdentificacao(VSF_SolicitacaoCartaoIdentificacao solicitacaoCartao, string codigoSistema, TelosUser usuario)
        {
            return Fachada.GetInstancia().AtualizarVSF_SolicitacaoCartaoIdentificacao(solicitacaoCartao,codigoSistema,usuario);
        }

        public IList<VSF_SolicitacaoCartaoIdentificacao> PesquisarTodosSolicitacaoCartaoIdentificacao(ObjetoPesquisa objetoPesquisa, bool lazy, string codigoSistema, TelosUser usuario)
        {
            return Fachada.GetInstancia().PesquisarTodosSolicitacaoCartaoIdentificacao(objetoPesquisa, lazy,
                                                                                       codigoSistema, usuario);
        }

        public VSF_SolicitacaoCartaoIdentificacao EmitirSolicitacaoCartao(VSF_SolicitacaoCartaoIdentificacao solicitacaoCartaoIdentificacao, string codigoSistema, TelosUser usuario)
        {
            return Fachada.GetInstancia().EmitirSolicitacaoCartao(solicitacaoCartaoIdentificacao, codigoSistema, usuario);
        }

        public IList<VSF_SolicitacaoCartaoIdentificacao> EmitirSolicitacoesCartao(IList solicitacoesCartaoIdentificacao, string codigoSistema, TelosUser usuario)
        {
            return Fachada.GetInstancia().EmitirSolicitacoesCartao(solicitacoesCartaoIdentificacao, codigoSistema,
                                                                   usuario);
        }

        public VSF_SolicitacaoCartaoIdentificacao CancelarSolicitacaoCartao(VSF_SolicitacaoCartaoIdentificacao solicitacaoCartaoIdentificacao, string codigoSistema, TelosUser usuario)
        {
            return Fachada.GetInstancia().CancelarSolicitacaoCartao(solicitacaoCartaoIdentificacao, codigoSistema, usuario);
        }

        public DateTime? ValidarCodigoSolicitacao(string codigo)
        {
            return Fachada.GetInstancia().ValidarCodigoSolicitacao(codigo);
        }
    }
}