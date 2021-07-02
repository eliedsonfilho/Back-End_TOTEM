using System;
using System.Collections;
using System.Collections.Generic;
using Dados;
using Repositorios;

namespace Negocios
{
    public class NegocioVSF_SolicitacaoCartaoIdentificacao
    {
        private RepositorioVSF_SolicitacaoCartaoIdentificacao _repositorioVsfSolicitacaoCartaoIdentificacao;

        public NegocioVSF_SolicitacaoCartaoIdentificacao()
        {
            _repositorioVsfSolicitacaoCartaoIdentificacao = new RepositorioVSF_SolicitacaoCartaoIdentificacao();
        }

        public VSF_SolicitacaoCartaoIdentificacao ObterPorId(int autoId, bool lazy)
        {
            return _repositorioVsfSolicitacaoCartaoIdentificacao.ObterPorId(autoId, lazy);
        }

        public IList<VSF_SolicitacaoCartaoIdentificacao> ObterTodos(bool lazy)
        {
            return _repositorioVsfSolicitacaoCartaoIdentificacao.ObterTodos(lazy);
        }

        public IList<VSF_SolicitacaoCartaoIdentificacao> ObterTodos(VSF_SolicitacaoCartaoIdentificacao objetoPesquisado, bool lazy)
        {
            return _repositorioVsfSolicitacaoCartaoIdentificacao.ObterTodos(objetoPesquisado, lazy);
        }

        public VSF_SolicitacaoCartaoIdentificacao Inserir(VSF_SolicitacaoCartaoIdentificacao solicitacaoCartaoIdentificacao)
        {
            //Se tiver AutoId é Update
            if(solicitacaoCartaoIdentificacao.AutoId != 0)
            {
                throw new Exception("Erro ao Inserir Solicitação ID != 0");
            }

            //Data da Solicitação Do Servidor
            solicitacaoCartaoIdentificacao.DataSolicitacao = DateTime.Now;

            //Codigo Com Base na Hora da Solicitação
            solicitacaoCartaoIdentificacao.Codigo =
                solicitacaoCartaoIdentificacao.DataSolicitacao.GetValueOrDefault().Ticks.ToString();

            //Situação Solicitado
            solicitacaoCartaoIdentificacao.SituacaoSolicitacaoCartaoIdentificacao = EnumSituacaoSolicitacaoCartaoIdentificacao.Solicitado;

            //Grava no Banco
            solicitacaoCartaoIdentificacao = _repositorioVsfSolicitacaoCartaoIdentificacao.Inserir(solicitacaoCartaoIdentificacao);

            //Enviar Email para o Beneficiário
            NegocioEmailPessoa negocioEmailPessoa = new NegocioEmailPessoa();
            //Recupera o Email da Pessoa do Beneficiário
            EmailPessoa emailPessoa =
                negocioEmailPessoa.ObterPorPessoa(solicitacaoCartaoIdentificacao.Beneficiario.Pessoa, true);
            if (emailPessoa != null)
            {
                Util.EmailNotificationService.EnviarEmail(emailPessoa.Email, null, null, "sistemas@unimedvsf.com.br", "sistemas@unimedvsf.com.br",
                                                          "ntivsf210", "Emissão de 2ª via de Cartão,",
                                                          "Seu Cartão foi Solicitado, aguarde a Emissão do mesmo.", "", "25",
                                                          "mail.unimedvsf.com.br", false);
            }

            return solicitacaoCartaoIdentificacao;
        }

        public VSF_SolicitacaoCartaoIdentificacao Atualizar(VSF_SolicitacaoCartaoIdentificacao solicitacaoCartaoIdentificacao)
        {
            return _repositorioVsfSolicitacaoCartaoIdentificacao.Atualizar(solicitacaoCartaoIdentificacao);
        }

        public IList<VSF_SolicitacaoCartaoIdentificacao> PesquisarTodos(ObjetoPesquisa objetoPesquisa, bool lazy)
        {
            return _repositorioVsfSolicitacaoCartaoIdentificacao.PesquisarTodos(objetoPesquisa, lazy);
        }

        public VSF_SolicitacaoCartaoIdentificacao EmitirSolicitacaoCartao(VSF_SolicitacaoCartaoIdentificacao solicitacaoCartaoIdentificacao, string codigoSistema, TelosUser usuario)
        {
            if (solicitacaoCartaoIdentificacao == null )
            {
                throw new Exception("ERRO AO EMITIR SOLICITAÇÃO");
            }

            if (solicitacaoCartaoIdentificacao.SituacaoSolicitacaoCartaoIdentificacao != EnumSituacaoSolicitacaoCartaoIdentificacao.Solicitado)
            {
                throw new Exception("Situação da Solicitação NÂO Permite Emissão");
            }

            solicitacaoCartaoIdentificacao.SituacaoSolicitacaoCartaoIdentificacao=EnumSituacaoSolicitacaoCartaoIdentificacao.Emitido;

            solicitacaoCartaoIdentificacao.DataEmissao = DateTime.Now;

            solicitacaoCartaoIdentificacao.UsuarioEmissao = usuario;

            solicitacaoCartaoIdentificacao =
                _repositorioVsfSolicitacaoCartaoIdentificacao.Atualizar(solicitacaoCartaoIdentificacao);

            //Enviar Email para o Beneficiário
            NegocioEmailPessoa negocioEmailPessoa=new NegocioEmailPessoa();
            //Recupera o Email da Pessoa do Beneficiário
            EmailPessoa emailPessoa =
                negocioEmailPessoa.ObterPorPessoa(solicitacaoCartaoIdentificacao.Beneficiario.Pessoa,true);
            if (emailPessoa!=null)
            {
                Util.EmailNotificationService.EnviarEmail(emailPessoa.Email, null, null, "sistemas@unimedvsf.com.br", "sistemas@unimedvsf.com.br",
                                                          "ntivsf210", "Emissão de 2ª via de Cartão,",
                                                          "Seu Cartão foi Emitido, aguarde o envio.", "", "25",
                                                          "mail.unimedvsf.com.br", false);
            }
            

            return solicitacaoCartaoIdentificacao;
        }

        public IList<VSF_SolicitacaoCartaoIdentificacao> EmitirSolicitacoesCartao(IList solicitacoesCartaoIdentificacao, string codigoSistema, TelosUser usuario)
        {
            IList<VSF_SolicitacaoCartaoIdentificacao> listaTemp=null;
            if ((solicitacoesCartaoIdentificacao != null) && (solicitacoesCartaoIdentificacao.Count > 0))
            {
                listaTemp = new List<VSF_SolicitacaoCartaoIdentificacao>(); 
                foreach (VSF_SolicitacaoCartaoIdentificacao solicitacaoCartaoIdentificacao in solicitacoesCartaoIdentificacao)
                {
                    listaTemp.Add(EmitirSolicitacaoCartao(solicitacaoCartaoIdentificacao,codigoSistema,usuario));
                }
            }
            else
            {
                throw new Exception("Não Existe Solicitações para Emitir.");
            }
            

            return listaTemp;
        }

        public VSF_SolicitacaoCartaoIdentificacao CancelarSolicitacaoCartao(VSF_SolicitacaoCartaoIdentificacao solicitacaoCartaoIdentificacao, string codigoSistema, TelosUser usuario)
        {
            if (solicitacaoCartaoIdentificacao == null)
            {
                throw new Exception("ERRO AO EMITIR SOLICITAÇÃO");
            }

            if (solicitacaoCartaoIdentificacao.SituacaoSolicitacaoCartaoIdentificacao != EnumSituacaoSolicitacaoCartaoIdentificacao.Solicitado)
            {
                throw new Exception("Situação da Solicitação NÂO Permite Cancelamento");
            }

            solicitacaoCartaoIdentificacao.SituacaoSolicitacaoCartaoIdentificacao = EnumSituacaoSolicitacaoCartaoIdentificacao.Cancelado;

            solicitacaoCartaoIdentificacao.DataCancelamento = DateTime.Now;

            solicitacaoCartaoIdentificacao.UsuarioEmissao = usuario;

            solicitacaoCartaoIdentificacao =
                _repositorioVsfSolicitacaoCartaoIdentificacao.Atualizar(solicitacaoCartaoIdentificacao);

            return solicitacaoCartaoIdentificacao;
        }
    
        public DateTime? ValidarCodigoSolicitacao(string codigo)
        {
            DateTime? dataRetorno = null;
            if ((!String.IsNullOrEmpty(codigo))&&(codigo.Length == 18))
            {
                dataRetorno = new DateTime( Convert.ToInt64(codigo));    
            }
            return dataRetorno;
        }
    }
}