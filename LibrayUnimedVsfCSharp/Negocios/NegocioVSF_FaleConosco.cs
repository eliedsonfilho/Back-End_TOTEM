using System;
using System.Collections.Generic;
using System.Globalization;
using Dados;
using Repositorios;
using Util;

namespace Negocios
{
    public class NegocioVSF_FaleConosco
    {
        private RepositorioVSF_FaleConosco _repositorioVsfFaleConosco;

        public NegocioVSF_FaleConosco()
        {
            _repositorioVsfFaleConosco = new RepositorioVSF_FaleConosco();
        }

        public VSF_FaleConosco ObterVSF_FaleConoscoPorId(int colunaChave, bool lazy)
        {
            return _repositorioVsfFaleConosco.ObterPorId(colunaChave, lazy);
        }

        public IList<VSF_FaleConosco> ObterTodosVSF_FaleConosco(bool lazy)
        {
            return _repositorioVsfFaleConosco.ObterTodos(lazy);
        }

        public IList<VSF_FaleConosco> ObterTodosVSF_FaleConosco(VSF_FaleConosco objetoPesquisado, bool lazy)
        {
            return _repositorioVsfFaleConosco.ObterTodos(objetoPesquisado, lazy);
        }

        public VSF_FaleConosco InserirVSF_FaleConosco(VSF_FaleConosco ObjetoInserido)
        {
            //Colocando a Data do momento como Código
            ObjetoInserido.CodigoMensagem = DateTime.Now.Ticks.ToString();

            if (ObjetoInserido == null)
            {
                throw new Exception("Erro ao Inserir Fale Conosco.");
            }

            if(ObjetoInserido.Assunto.Length == 0 )
            {
                throw new Exception("Assunto da Mensagem é obrigatório.");
            }

            if (ObjetoInserido.Mensagem.Length == 0)
            {
                throw new Exception("Mensagem é obrigatória.");
            }

            ObjetoInserido = _repositorioVsfFaleConosco.Inserir(ObjetoInserido);

            if (ObjetoInserido.Email.Length > 0)
            {
                try
                {
                    string enderecoToMail = ObjetoInserido.Email;
                    string Mensagem = @"Recebemos sua "+ObjetoInserido.Motivo+" aguarde o retorno da UNIMED";
                    string Assunto = @"Fale Conosco";
                    string displayMail = "UNIMED Vale do são Francisco";
                    
                    //Configurações
                    string emailSistemaFrom = "sistemas@unimedvsf.com.br";
                    string senhaEmailSistema = "ntivsf210";
                    string portaServerMail = "25";
                    string hostServerMail = "mail.unimedvsf.com.br";
                    
                    Util.EmailNotificationService.EnviarEmail(enderecoToMail, null, null, emailSistemaFrom, displayMail, senhaEmailSistema, Assunto,
                                                             Mensagem, null, portaServerMail, hostServerMail, false);
                }
                catch
                {
                    //Desconsidera Erro de Envio de Mail
                }
                
            }
            
            return ObjetoInserido;
        }

        public VSF_FaleConosco AtualizarVSF_FaleConosco(VSF_FaleConosco ObjetoInserido)
        {
            if (ObjetoInserido == null)
            {
                throw new Exception("Erro ao Inserir Fale Conosco.");
            }

            if (ObjetoInserido.Assunto.Length == 0)
            {
                throw new Exception("Assunto da Mensagem é obrigatório.");
            }

            if (ObjetoInserido.Mensagem.Length == 0)
            {
                throw new Exception("Mensagem é obrigatória.");
            }

            ObjetoInserido = _repositorioVsfFaleConosco.Atualizar(ObjetoInserido);

            if (ObjetoInserido.Email.Length > 0)
            {
                try
                {
                    string enderecoToMail = ObjetoInserido.Email;
                    string Mensagem = @"Recebemos sua " + ObjetoInserido.Motivo + " aguarde o retorno da UNIMED";
                    string Assunto = @"Fale Conosco";
                    string displayMail = "UNIMED Vale do são Francisco";

                    //Configurações
                    string emailSistemaFrom = "sistemas@unimedvsf.com.br";
                    string senhaEmailSistema = "ntivsf210";
                    string portaServerMail = "25";
                    string hostServerMail = "mail.unimedvsf.com.br";

                    Util.EmailNotificationService.EnviarEmail(enderecoToMail, null, null, emailSistemaFrom, displayMail, senhaEmailSistema, Assunto,
                                                             Mensagem, null, portaServerMail, hostServerMail, false);
                }
                catch
                {
                    //Desconsidera Erro de Envio de Mail
                }

            }

            return ObjetoInserido;
        }
    }
}