using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using Dados;
using Negocios;
using Util.TratamentoErros;

namespace Servicos
{
    public class Fachada
    {
        #region Atributos

        private NegocioMedicamento _negocioMedicamento;
        private NegocioMaterial _negocioMaterial;
        private NegocioCartaoIdentificacao _negocioCartaoIdentificacao;
        private NegocioVSF_ConfiguracaoSistema _negocioVsfConfiguracaoSistema;
        private NegocioVSF_LogSistema _negocioVsfLogSistema;
        private NegocioVSF_SolicitacaoCartaoIdentificacao _negocioVsfSolicitacaoCartaoIdentificacao;
        private NegocioVSF_Sistema _negocioVsfSistema;
        private NegocioTelosUser _negocioTelosUser;
        private NegocioArquivo _negocioArquivo;
        private NegocioDadosCarteiraProvisoria _negocioDadosCarteiraProvisoria;
        private NegocioBoletoCobranca _negocioBoletoCobranca;
        private NegocioDadosBoletoCobranca _negocioDadosBoletoCobranca;
        private NegocioFeriado _negocioFeriado;
        private NegocioVSF_FaleConosco _negocioVsfFaleConosco;
        private NegocioVSF_SituacaoBeneficiario _negocioVsfSituacaoBeneficiario;
        private NegocioVSF_ConfiguracaoFinanceira _negocioVsfConfiguracaoFinanceira;
        private NegocioMovDocFinan _negocioMovDocFinan;

        #endregion

        #region Construtor

        private Fachada()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
            _negocioMedicamento = new NegocioMedicamento();
            _negocioMaterial = new NegocioMaterial();
            _negocioCartaoIdentificacao = new NegocioCartaoIdentificacao();
            _negocioVsfSistema = new NegocioVSF_Sistema();
            _negocioVsfConfiguracaoSistema = new NegocioVSF_ConfiguracaoSistema();
            _negocioVsfLogSistema = new NegocioVSF_LogSistema();
            _negocioVsfSolicitacaoCartaoIdentificacao = new NegocioVSF_SolicitacaoCartaoIdentificacao();
            _negocioTelosUser = new NegocioTelosUser();
            _negocioArquivo = new NegocioArquivo();
            _negocioDadosCarteiraProvisoria = new NegocioDadosCarteiraProvisoria();
            _negocioBoletoCobranca = new NegocioBoletoCobranca();
            _negocioVsfFaleConosco = new NegocioVSF_FaleConosco();
            _negocioDadosBoletoCobranca = new NegocioDadosBoletoCobranca();
            _negocioVsfConfiguracaoFinanceira = new NegocioVSF_ConfiguracaoFinanceira();
            _negocioMovDocFinan = new NegocioMovDocFinan();
        }

        #endregion

        #region GetInstancia

        public static Fachada GetInstancia()
        {
            return Nested.SessionManager;
        }

        #endregion

        #region Nested

        private class Nested
        {
            static Nested()
            {
            }

            internal static readonly Fachada SessionManager = new Fachada();
        }

        #endregion

        #region Arquivo
        
        public Arquivo ObterArquivoPorId(int autoId, bool lazy, string codigoSistema, TelosUser usuario)
        {
            Arquivo arquivoTmp;
            try
            {
                arquivoTmp = _negocioArquivo.ObterPorId(autoId, lazy);
            }
            catch (Exception exception)
            {
                arquivoTmp = null;
                VSF_LogSistema logSistema = new VSF_LogSistema();
                logSistema.Mensagem = TratamentoExcecoes.TratarRecursaoExcecao(exception);
                logSistema.Mensagem += " _negocioArquivo.ObterPorId";
                logSistema.Sistema = GetInstancia().ObterVSF_SistemaPoCodigo(codigoSistema, true, codigoSistema, usuario);
                GetInstancia().InserirVSF_LogSistema(logSistema, codigoSistema, usuario);
                throw new Exception(exception.Message);
            }
            return arquivoTmp;
        }

        public IList<Arquivo> ObterTodosArquivos(bool lazy, string codigoSistema, TelosUser usuario)
        {
            IList<Arquivo> objetosTmp;
            try
            {
                objetosTmp = _negocioArquivo.ObterTodos(lazy);
            }
            catch (Exception exception)
            {
                objetosTmp = null;
                VSF_LogSistema logSistema = new VSF_LogSistema();
                logSistema.Mensagem = TratamentoExcecoes.TratarRecursaoExcecao(exception);
                logSistema.Mensagem += " _negocioArquivo.ObterTodos";
                logSistema.Sistema = GetInstancia().ObterVSF_SistemaPoCodigo(codigoSistema, true, codigoSistema, usuario);
                GetInstancia().InserirVSF_LogSistema(logSistema, codigoSistema, usuario);
                throw new Exception(exception.Message);
            }

            return objetosTmp;
        }

        public IList<Arquivo> ObterTodosArquivos(Arquivo objeto, bool lazy, string codigoSistema, TelosUser usuario)
        {
            IList<Arquivo> objetosTmp;
            try
            {
                objetosTmp = _negocioArquivo.ObterTodos(objeto, lazy);
            }
            catch (Exception exception)
            {

                objetosTmp = null;
                VSF_LogSistema logSistema = new VSF_LogSistema();
                logSistema.Mensagem = TratamentoExcecoes.TratarRecursaoExcecao(exception);
                logSistema.Mensagem += " _negocioArquivo.ObterTodos";
                logSistema.Sistema = GetInstancia().ObterVSF_SistemaPoCodigo(codigoSistema, true, codigoSistema, usuario);
                GetInstancia().InserirVSF_LogSistema(logSistema, codigoSistema, usuario);
                throw new Exception(exception.Message);
            }

            return objetosTmp;
        }

        public Arquivo InserirArquivo(Arquivo objeto, string codigoSistema, TelosUser usuario)
        {
            Arquivo objetoTmp;
            try
            {
                objetoTmp = _negocioArquivo.Inserir(objeto);
            }
            catch (Exception exception)
            {
                objetoTmp = null;
                VSF_LogSistema logSistema = new VSF_LogSistema();
                logSistema.Mensagem = TratamentoExcecoes.TratarRecursaoExcecao(exception);
                logSistema.Mensagem += " _negocioArquivo.Inserir";
                logSistema.Sistema = GetInstancia().ObterVSF_SistemaPoCodigo(codigoSistema, true, codigoSistema, usuario);
                GetInstancia().InserirVSF_LogSistema(logSistema, codigoSistema, usuario);
                throw new Exception(exception.Message);
            }
            return objetoTmp;
        }

        public Arquivo AtualizarArquivo(Arquivo objeto, string codigoSistema, TelosUser usuario)
        {
            Arquivo objetoTmp;
            try
            {
                objetoTmp = _negocioArquivo.Atualizar(objeto);
            }
            catch (Exception exception)
            {
                objetoTmp = null;
                VSF_LogSistema logSistema = new VSF_LogSistema();
                logSistema.Mensagem = TratamentoExcecoes.TratarRecursaoExcecao(exception);
                logSistema.Mensagem += " _negocioArquivo.Atualizar";
                logSistema.Sistema = GetInstancia().ObterVSF_SistemaPoCodigo(codigoSistema, true, codigoSistema, usuario);
                GetInstancia().InserirVSF_LogSistema(logSistema, codigoSistema, usuario);
                throw new Exception(exception.Message);
            }
            return objetoTmp;
        }

        #endregion

        #region BoletoCobranca

        public BoletoCobranca ObterBoletoCobrancaPorId(int autoIdBoletoCobranca, bool lazy, string codigoSistema, TelosUser usuario)
        {
            BoletoCobranca boletoTmps;
            
            try
            {
                boletoTmps = _negocioBoletoCobranca.ObterBoletoCobrancaPorId(autoIdBoletoCobranca, lazy);
            }
            catch (Exception exception)
            {
                boletoTmps = null;
                VSF_LogSistema logSistema = new VSF_LogSistema();
                logSistema.Mensagem = TratamentoExcecoes.TratarRecursaoExcecao(exception);
                logSistema.Mensagem += "  _negocioBoletoCobranca.ObterBoletoCobrancaPorId";
                logSistema.Sistema = GetInstancia().ObterVSF_SistemaPoCodigo(codigoSistema, true, codigoSistema, usuario);
                GetInstancia().InserirVSF_LogSistema(logSistema, codigoSistema, usuario);
                throw new Exception(exception.Message); 
        }
            return boletoTmps;
        }

        public IList<BoletoCobranca> ObterTodosBoletoCobrancaAbertosPorBeneficiario(Beneficiario beneficiario, string codigoSistema, TelosUser usuario)
        {
            IList<BoletoCobranca> boletoTmps;
            try
            {
                boletoTmps = _negocioBoletoCobranca.ObterTodosBoletoCobrancaAbertosPorBeneficiario(beneficiario);
            }
            catch (Exception exception)
            {
                boletoTmps = null;
                VSF_LogSistema logSistema = new VSF_LogSistema();
                logSistema.Mensagem = TratamentoExcecoes.TratarRecursaoExcecao(exception);
                logSistema.Mensagem += " _negocioBoletoCobranca.ObterTodosBoletoCobrancaAbertosPorBeneficiario";
                logSistema.Sistema = GetInstancia().ObterVSF_SistemaPoCodigo(codigoSistema, true, codigoSistema, usuario);
                GetInstancia().InserirVSF_LogSistema(logSistema, codigoSistema, usuario);
                throw new Exception(exception.Message);
            }

            return boletoTmps;
        }

        public IList<BoletoCobranca> ObterTodosBoletosPorBeneficiario(Beneficiario beneficiario, string codigoSistema, TelosUser usuario)
        {
            IList<BoletoCobranca> boletoTmps;
            try
            {
                boletoTmps = _negocioBoletoCobranca.ObterTodosBoletosPorBeneficiario(beneficiario);
            }
            catch (Exception exception)
            {
                boletoTmps = null;
                VSF_LogSistema logSistema = new VSF_LogSistema();
                logSistema.Mensagem = TratamentoExcecoes.TratarRecursaoExcecao(exception);
                logSistema.Mensagem += " _negocioBoletoCobranca.ObterTodosBoletosPorBeneficiario";
                logSistema.Sistema = GetInstancia().ObterVSF_SistemaPoCodigo(codigoSistema, true, codigoSistema, usuario);
                GetInstancia().InserirVSF_LogSistema(logSistema, codigoSistema, usuario);
                throw new Exception(exception.Message);
            }

            return boletoTmps;
        }

        public bool VerificaBoletoVencido(BoletoCobranca boletoCobranca)
        {
            return _negocioBoletoCobranca.VerificaBoletoVencido(boletoCobranca);
        }

        public IList<DateTime> ObterDatasVencimento(DateTime dataReferencia, int limiteDias, int quantidadeDatas)
        {
            return _negocioBoletoCobranca.ObterDatasVencimento(dataReferencia, limiteDias, quantidadeDatas);
        }

        public bool VerificaImpressaoBoleto(BoletoCobranca boletoCobranca, Beneficiario beneficiario, int prazoMaximo, int inadimplenciaMaxima)
        {
            return _negocioBoletoCobranca.VerificaImpressaoBoleto(boletoCobranca, beneficiario, prazoMaximo, inadimplenciaMaxima);
        }

        public IList<OpcaoVencimentoBoleto> ObterOpcoesVencimentosBoleto(BoletoCobranca boletoCobranca, int limiteDias, int quantidadeDatas)
        {
            return _negocioBoletoCobranca.ObterOpcoesVencimentosBoleto(boletoCobranca, limiteDias, quantidadeDatas);
        }

        public decimal CalculaJurosBoleto(DateTime dataInicial, DateTime dataFinal, decimal valorInicial, decimal percentualJuros, decimal percentualMulta)
        {
            return _negocioBoletoCobranca.CalculaJuros(dataInicial, dataFinal, valorInicial, percentualJuros, percentualMulta);
        }

        #endregion

        #region CartaoIdentificacao

        public CartaoIdentificacao ObterCartaoIdentificacaoPorId(int autoId, bool lazy)
        {
            CartaoIdentificacao cartaoIdentificacaoTmp;
            try
            {
                cartaoIdentificacaoTmp = _negocioCartaoIdentificacao.ObterPorId(autoId, lazy);
            }
            catch (Exception exception)
            {
                cartaoIdentificacaoTmp = null;
                throw new Exception(exception.Message);
            }
            return cartaoIdentificacaoTmp;
        }

        public IList<CartaoIdentificacao> ObterTodosCartaoIdentificacao(bool lazy)
        {
            return _negocioCartaoIdentificacao.ObterTodos(lazy);
        }

        public IList<CartaoIdentificacao> ObterTodosCartaoIdentificacao(CartaoIdentificacao objetoPesquisado, bool lazy)
        {
            return _negocioCartaoIdentificacao.ObterTodos(objetoPesquisado, lazy);
        }

        public CartaoIdentificacao ObterCartaoIdentificacaoPorCodigo(string codigo, bool lazy)
        {
            CartaoIdentificacao cartaoIdentificacaoTmp;
            try
            {
                cartaoIdentificacaoTmp = _negocioCartaoIdentificacao.ObterPorCodigo(codigo, lazy);
            }
            catch (Exception exception)
            {
                cartaoIdentificacaoTmp = null;
                VSF_LogSistema logSistema = new VSF_LogSistema();
                logSistema.Mensagem = TratamentoExcecoes.CriarArquivoLog(exception);
                logSistema.Mensagem += " _negocioCartaoIdentificacao.ObterPorCodigo";
                //logSistema.Sistema = GetInstancia().ObterVSF_SistemaPoCodigo(codigoSistema, true, codigoSistema, usuario);
                GetInstancia().InserirVSF_LogSistema(logSistema, null, null);
                throw new Exception(exception.Message);
            }
            return cartaoIdentificacaoTmp;
        }

        #endregion

        #region ConfiguracaoSistema

        public VSF_ConfiguracaoSistema ObterVSF_ConfiguracaoSistemaPorId(int autoId, bool lazy, string codigoSistema, TelosUser usuario)
        {
            VSF_ConfiguracaoSistema configuracaoSistemaTmp;
            try
            {
                configuracaoSistemaTmp = _negocioVsfConfiguracaoSistema.ObterPorId(autoId, lazy);
            }
            catch (Exception exception)
            {
                configuracaoSistemaTmp = null;
                VSF_LogSistema logSistema = new VSF_LogSistema();
                logSistema.Mensagem = TratamentoExcecoes.TratarRecursaoExcecao(exception);
                logSistema.Mensagem += " _negocioVsfConfiguracaoSistema.ObterPorId";
                _negocioVsfSistema = new NegocioVSF_Sistema();
                logSistema.Sistema = _negocioVsfSistema.ObterPorCodigo(codigoSistema, true);
                _negocioVsfLogSistema.Inserir(logSistema);
                throw new Exception(exception.Message);
            }
            return configuracaoSistemaTmp;
        }

        public IList<VSF_ConfiguracaoSistema> ObterTodosVSF_ConfiguracaoSistemas(bool lazy, string codigoSistema, TelosUser usuario)
        {
            IList<VSF_ConfiguracaoSistema> configuracaoSistemasTmp;
            try
            {
                configuracaoSistemasTmp = _negocioVsfConfiguracaoSistema.ObterTodos(lazy);
            }
            catch (Exception exception)
            {
                configuracaoSistemasTmp = null;
                VSF_LogSistema logSistema = new VSF_LogSistema();
                logSistema.Mensagem = TratamentoExcecoes.TratarRecursaoExcecao(exception);
                logSistema.Mensagem += " _negocioVsfConfiguracaoSistema.ObterTodos";
                _negocioVsfSistema = new NegocioVSF_Sistema();
                logSistema.Sistema = _negocioVsfSistema.ObterPorCodigo(codigoSistema, true);
                _negocioVsfLogSistema.Inserir(logSistema);
                throw new Exception(exception.Message);
            }

            return configuracaoSistemasTmp;
        }

        public IList<VSF_ConfiguracaoSistema> ObterTodosVSF_ConfiguracaoSistemas(VSF_ConfiguracaoSistema configuracaoSistema, bool lazy, string codigoSistema, TelosUser usuario)
        {
            IList<VSF_ConfiguracaoSistema> configuracaoSistemasTmp;
            try
            {
                configuracaoSistemasTmp = _negocioVsfConfiguracaoSistema.ObterTodos(configuracaoSistema, lazy);
            }
            catch (Exception exception)
            {

                configuracaoSistemasTmp = null;
                VSF_LogSistema logSistema = new VSF_LogSistema();
                logSistema.Mensagem = TratamentoExcecoes.TratarRecursaoExcecao(exception);
                logSistema.Mensagem += " _negocioVsfConfiguracaoSistema.ObterTodos";
                _negocioVsfSistema = new NegocioVSF_Sistema();
                logSistema.Sistema = _negocioVsfSistema.ObterPorCodigo(codigoSistema, true);
                _negocioVsfLogSistema.Inserir(logSistema);
                throw new Exception(exception.Message);
            }

            return configuracaoSistemasTmp;
        }

        public VSF_ConfiguracaoSistema InserirVSF_ConfiguracaoSistema(VSF_ConfiguracaoSistema configuracaoSistema, string codigoSistema, TelosUser usuario)
        {
            VSF_ConfiguracaoSistema configuracaoSistemaTmp;
            try
            {
                configuracaoSistemaTmp = _negocioVsfConfiguracaoSistema.Inserir(configuracaoSistema);
            }
            catch (Exception exception)
            {
                configuracaoSistemaTmp = null;
                VSF_LogSistema logSistema = new VSF_LogSistema();
                logSistema.Mensagem = TratamentoExcecoes.TratarRecursaoExcecao(exception);
                logSistema.Mensagem += " _negocioVsfConfiguracaoSistema.Inserir";
                _negocioVsfSistema = new NegocioVSF_Sistema();
                logSistema.Sistema = _negocioVsfSistema.ObterPorCodigo(codigoSistema, true);
                _negocioVsfLogSistema.Inserir(logSistema);
                throw new Exception(exception.Message);
            }
            return configuracaoSistemaTmp;
        }

        public VSF_ConfiguracaoSistema AtualizarVSF_ConfiguracaoSistema(VSF_ConfiguracaoSistema configuracaoSistema, string codigoSistema, TelosUser usuario)
        {
            VSF_ConfiguracaoSistema configuracaoSistemaTmp;
            try
            {
                configuracaoSistemaTmp = _negocioVsfConfiguracaoSistema.Atualizar(configuracaoSistema);
            }
            catch (Exception exception)
            {
                configuracaoSistemaTmp = null;
                VSF_LogSistema logSistema = new VSF_LogSistema();
                logSistema.Mensagem = TratamentoExcecoes.TratarRecursaoExcecao(exception);
                logSistema.Mensagem += " _negocioVsfConfiguracaoSistema.Atualizar";
                _negocioVsfSistema = new NegocioVSF_Sistema();
                logSistema.Sistema = _negocioVsfSistema.ObterPorCodigo(codigoSistema, true);
                _negocioVsfLogSistema.Inserir(logSistema);
                throw new Exception(exception.Message);
            }
            return configuracaoSistemaTmp;
        }
      
        #endregion
        
        #region DadosBoletoCobranca

        public DadosBoletoCobranca ObterPorDocFinanceiro(BoletoCobranca boletoCobranca, string codigoSistema, TelosUser usuario)
        {
            DadosBoletoCobranca dadosBoletoTmp;
            try
            {
                dadosBoletoTmp = _negocioDadosBoletoCobranca.ObterPorDocFinanceiro(boletoCobranca);
            }
            catch (Exception exception)
            {
                dadosBoletoTmp = null;
                VSF_LogSistema logSistema = new VSF_LogSistema();
                logSistema.Mensagem = TratamentoExcecoes.CriarArquivoLog(exception);
                logSistema.Mensagem += " _negocioDadosBoletoCobranca.ObterPorDocFinaicero";
                logSistema.Sistema = GetInstancia().ObterVSF_SistemaPoCodigo(codigoSistema, true, codigoSistema, usuario);
                GetInstancia().InserirVSF_LogSistema(logSistema, codigoSistema, usuario);
                throw new Exception(exception.Message);
            }

            return dadosBoletoTmp;
        }

        public DadosBoletoCobranca ObterPorDocFinanceiro(int autoIdDocFin, string codigoSistema, TelosUser usuario)
        {
            DadosBoletoCobranca dadosBoletoTmp;
            try
            {
                dadosBoletoTmp = _negocioDadosBoletoCobranca.ObterPorDocFinanceiro(autoIdDocFin);
            }
            catch (Exception exception)
            {
                dadosBoletoTmp = null;
                VSF_LogSistema logSistema = new VSF_LogSistema();
                logSistema.Mensagem = TratamentoExcecoes.CriarArquivoLog(exception);
                logSistema.Mensagem += " _negocioDadosBoletoCobranca.ObterPorDocFinaicero";
                logSistema.Sistema = GetInstancia().ObterVSF_SistemaPoCodigo(codigoSistema, true, codigoSistema, usuario);
                GetInstancia().InserirVSF_LogSistema(logSistema, codigoSistema, usuario);
                throw new Exception(exception.Message);
            }

            return dadosBoletoTmp;
        }
        #endregion

        #region DadosCarteiraProvisoria

        public DadosCarteiraProvisoria ObterDadosCarteiraProvisoriaPorCodigo(long autoId, bool lazy, string codigoSistema, TelosUser usuario)
        {
            DadosCarteiraProvisoria DadosCarteiraProvisoriaTmp;
            try
            {
                DadosCarteiraProvisoriaTmp = _negocioDadosCarteiraProvisoria.ObterDadosCarteiraProvisoriaPorCodigo(autoId, lazy);
            }
            catch (Exception exception)
            {
                DadosCarteiraProvisoriaTmp = null;
                VSF_LogSistema logSistema = new VSF_LogSistema();
                logSistema.Mensagem = TratamentoExcecoes.TratarRecursaoExcecao(exception);
                logSistema.Mensagem += " _negocioDadosCarteiraProvisoria.ObterDadosCarteiraProvisoriaPorCodigo";
                logSistema.Sistema = GetInstancia().ObterVSF_SistemaPoCodigo(codigoSistema, true, codigoSistema, usuario);
                GetInstancia().InserirVSF_LogSistema(logSistema, codigoSistema, usuario);
                throw new Exception(exception.Message);
            }
            return DadosCarteiraProvisoriaTmp;
        }

        public IList<DadosCarteiraProvisoria> ObterTodosDadosCarteiraProvisorias(bool lazy, string codigoSistema, TelosUser usuario)
        {
            IList<DadosCarteiraProvisoria> DadosCarteiraProvisoriasTmp;
            try
            {
                DadosCarteiraProvisoriasTmp = _negocioDadosCarteiraProvisoria.ObterTodos(lazy);
            }
            catch (Exception exception)
            {
                DadosCarteiraProvisoriasTmp = null;
                VSF_LogSistema logSistema = new VSF_LogSistema();
                logSistema.Mensagem = TratamentoExcecoes.TratarRecursaoExcecao(exception);
                logSistema.Mensagem += " _negocioDadosCarteiraProvisoria.ObterTodos";
                logSistema.Sistema = GetInstancia().ObterVSF_SistemaPoCodigo(codigoSistema, true, codigoSistema, usuario);
                GetInstancia().InserirVSF_LogSistema(logSistema, codigoSistema, usuario);
                throw new Exception(exception.Message);
            }

            return DadosCarteiraProvisoriasTmp;
        }

        public IList<DadosCarteiraProvisoria> ObterTodosDadosCarteiraProvisorias(DadosCarteiraProvisoria DadosCarteiraProvisoria, bool lazy, string codigoSistema, TelosUser usuario)
        {
            IList<DadosCarteiraProvisoria> DadosCarteiraProvisoriasTmp;
            try
            {
                DadosCarteiraProvisoriasTmp = _negocioDadosCarteiraProvisoria.ObterTodos(DadosCarteiraProvisoria, lazy);
            }
            catch (Exception exception)
            {

                DadosCarteiraProvisoriasTmp = null;
                VSF_LogSistema logSistema = new VSF_LogSistema();
                logSistema.Mensagem = TratamentoExcecoes.TratarRecursaoExcecao(exception);
                logSistema.Mensagem += " _negocioDadosCarteiraProvisoria.ObterTodos";
                logSistema.Sistema = GetInstancia().ObterVSF_SistemaPoCodigo(codigoSistema, true, codigoSistema, usuario);
                GetInstancia().InserirVSF_LogSistema(logSistema, codigoSistema, usuario);
                throw new Exception(exception.Message);
            }

            return DadosCarteiraProvisoriasTmp;
        }
        
        #endregion

        #region Feriado

        public Feriado ObterFeriadoPorData(DateTime data, string codigoSistema, TelosUser usuario)
        {
            Feriado feriadoTmp;
            try
            {
                feriadoTmp = _negocioFeriado.ObterFeriadoPorData(data);
            }
            catch (Exception exception)
            {
                feriadoTmp = null;
                VSF_LogSistema logSistema = new VSF_LogSistema();
                logSistema.Mensagem = TratamentoExcecoes.CriarArquivoLog(exception);
                logSistema.Mensagem += " _negocioFeriado.ObterFeriadoPorData";
                logSistema.Sistema = GetInstancia().ObterVSF_SistemaPoCodigo(codigoSistema, true, codigoSistema, usuario);
                GetInstancia().InserirVSF_LogSistema(logSistema, codigoSistema, usuario);
                throw new Exception(exception.Message);
            }

            return feriadoTmp;
        }
        #endregion

        #region Fale Conosco

        public VSF_FaleConosco ObterVSF_FaleConoscoPorId(int autoId, bool lazy, string codigoSistema, TelosUser usuario)
        {
            VSF_FaleConosco VSF_FaleConoscoTmp;
            try
            {
                VSF_FaleConoscoTmp = _negocioVsfFaleConosco.ObterVSF_FaleConoscoPorId(autoId, lazy);
            }
            catch (Exception exception)
            {
                VSF_FaleConoscoTmp = null;
                VSF_LogSistema logSistema = new VSF_LogSistema();
                logSistema.Mensagem = TratamentoExcecoes.TratarRecursaoExcecao(exception);
                logSistema.Mensagem += " _negocioVSF_FaleConosco.ObterPorId";
                logSistema.Sistema = GetInstancia().ObterVSF_SistemaPoCodigo(codigoSistema, true, codigoSistema, usuario);
                GetInstancia().InserirVSF_LogSistema(logSistema, codigoSistema, usuario);
                throw new Exception(exception.Message);
            }
            return VSF_FaleConoscoTmp;
        }

        public IList<VSF_FaleConosco> ObterTodosVSF_FaleConoscos(bool lazy, string codigoSistema, TelosUser usuario)
        {
            IList<VSF_FaleConosco> VSF_FaleConoscosTmp;
            try
            {
                VSF_FaleConoscosTmp = _negocioVsfFaleConosco.ObterTodosVSF_FaleConosco(lazy);
            }
            catch (Exception exception)
            {
                VSF_FaleConoscosTmp = null;
                VSF_LogSistema logSistema = new VSF_LogSistema();
                logSistema.Mensagem = TratamentoExcecoes.TratarRecursaoExcecao(exception);
                logSistema.Mensagem += " _negocioVSF_FaleConosco.ObterTodos";
                logSistema.Sistema = GetInstancia().ObterVSF_SistemaPoCodigo(codigoSistema, true, codigoSistema, usuario);
                GetInstancia().InserirVSF_LogSistema(logSistema, codigoSistema, usuario);
                throw new Exception(exception.Message);
            }

            return VSF_FaleConoscosTmp;
        }

        public IList<VSF_FaleConosco> ObterTodosVSF_FaleConoscos(VSF_FaleConosco VSF_FaleConosco, bool lazy, string codigoSistema, TelosUser usuario)
        {
            IList<VSF_FaleConosco> VSF_FaleConoscosTmp;
            try
            {
                VSF_FaleConoscosTmp = _negocioVsfFaleConosco.ObterTodosVSF_FaleConosco(VSF_FaleConosco, lazy);
            }
            catch (Exception exception)
            {

                VSF_FaleConoscosTmp = null;
                VSF_LogSistema logSistema = new VSF_LogSistema();
                logSistema.Mensagem = TratamentoExcecoes.TratarRecursaoExcecao(exception);
                logSistema.Mensagem += " _negocioVSF_FaleConosco.ObterTodos";
                logSistema.Sistema = GetInstancia().ObterVSF_SistemaPoCodigo(codigoSistema, true, codigoSistema, usuario);
                GetInstancia().InserirVSF_LogSistema(logSistema, codigoSistema, usuario);
                throw new Exception(exception.Message);
            }

            return VSF_FaleConoscosTmp;
        }

        public VSF_FaleConosco InserirVSF_FaleConosco(VSF_FaleConosco VSF_FaleConosco, string codigoSistema, TelosUser usuario)
        {
            VSF_FaleConosco VSF_FaleConoscoTmp;
            try
            {
                VSF_FaleConoscoTmp = _negocioVsfFaleConosco.InserirVSF_FaleConosco(VSF_FaleConosco);
            }
            catch (Exception exception)
            {
                VSF_FaleConoscoTmp = null;
                VSF_LogSistema logSistema = new VSF_LogSistema();
                logSistema.Mensagem = TratamentoExcecoes.TratarRecursaoExcecao(exception);
                logSistema.Mensagem += " _negocioVSF_FaleConosco.Inserir";
                logSistema.Sistema = GetInstancia().ObterVSF_SistemaPoCodigo(codigoSistema, true, codigoSistema, usuario);
                GetInstancia().InserirVSF_LogSistema(logSistema, codigoSistema, usuario);
                throw new Exception(exception.Message);
            }
            return VSF_FaleConoscoTmp;
        }

        public VSF_FaleConosco AtualizarVSF_FaleConosco(VSF_FaleConosco VSF_FaleConosco, string codigoSistema, TelosUser usuario)
        {
            VSF_FaleConosco VSF_FaleConoscoTmp;
            try
            {
                VSF_FaleConoscoTmp = _negocioVsfFaleConosco.AtualizarVSF_FaleConosco(VSF_FaleConosco);
            }
            catch (Exception exception)
            {
                VSF_FaleConoscoTmp = null;
                VSF_LogSistema logSistema = new VSF_LogSistema();
                logSistema.Mensagem = TratamentoExcecoes.TratarRecursaoExcecao(exception);
                logSistema.Mensagem += " _negocioVSF_FaleConosco.Atualizar";
                logSistema.Sistema = GetInstancia().ObterVSF_SistemaPoCodigo(codigoSistema, true, codigoSistema, usuario);
                GetInstancia().InserirVSF_LogSistema(logSistema, codigoSistema, usuario);
                throw new Exception(exception.Message);
            }
            return VSF_FaleConoscoTmp;
        }
      
        #endregion

        #region LogSistema

        public VSF_LogSistema ObterVSF_LogSistemaPorId(int autoId, bool lazy, string codigoSistema, TelosUser usuario)
        {
            VSF_LogSistema logSistemaTmp;
            try
            {
                logSistemaTmp = _negocioVsfLogSistema.ObterPorId(autoId, lazy);
            }
            catch (Exception exception)
            {
                logSistemaTmp = null;
                throw new Exception(exception.Message);
            }
            return logSistemaTmp;
        }

        public IList<VSF_LogSistema> ObterTodosVSF_LogSistemas(bool lazy, string codigoSistema, TelosUser usuario)
        {
            IList<VSF_LogSistema> logSistemasTmp;
            try
            {
                logSistemasTmp = _negocioVsfLogSistema.ObterTodos(lazy);
            }
            catch (Exception exception)
            {
                logSistemasTmp = null;
                throw new Exception(exception.Message);
            }

            return logSistemasTmp;
        }

        public IList<VSF_LogSistema> ObterTodosVSF_LogSistemas(VSF_LogSistema logSistema, bool lazy, string codigoSistema, TelosUser usuario)
        {
            IList<VSF_LogSistema> logSistemasTmp;
            try
            {
                logSistemasTmp = _negocioVsfLogSistema.ObterTodos(logSistema, lazy);
            }
            catch (Exception exception)
            {

                logSistemasTmp = null;
                throw new Exception(exception.Message);
            }

            return logSistemasTmp;
        }

        public VSF_LogSistema InserirVSF_LogSistema(VSF_LogSistema logSistema, string codigoSistema, TelosUser usuario)
        {
            VSF_LogSistema logSistemaTmp;
            try
            {
                logSistemaTmp = _negocioVsfLogSistema.Inserir(logSistema);
            }
            catch (Exception exception)
            {
                logSistemaTmp = null;
                throw new Exception(exception.Message);
            }
            return logSistemaTmp;
        }

        public VSF_LogSistema AtualizarVSF_LogSistema(VSF_LogSistema logSistema, string codigoSistema, TelosUser usuario)
        {
            VSF_LogSistema logSistemaTmp;
            try
            {
                logSistemaTmp = _negocioVsfLogSistema.Atualizar(logSistema);
            }
            catch (Exception exception)
            {
                logSistemaTmp = null;
                throw new Exception(exception.Message);
            }
            return logSistemaTmp;
        }
      
        #endregion

        #region Medicamentos

        public IList<Medicamento> ObterTodosMedicamentos(Medicamento medicamento, bool lazy)
        {
            IList<Medicamento> medicamentosTmp;

            try
            {
                medicamentosTmp = _negocioMedicamento.ObterTodosMedicamentos(medicamento,lazy);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }

            return medicamentosTmp;
        }

        #endregion

        #region Materiais

        public IList<Material> ObterTodosMateriais(Material material, bool lazy)
        {
            IList<Material> materiaisTmp;
            try
            {
                materiaisTmp = _negocioMaterial.ObterTodosMateriais(material,lazy);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }

            return materiaisTmp;
        }

        #endregion

        #region Sistema

        public VSF_Sistema ObterVSF_SistemaPorId(int autoId, bool lazy, string codigoSistema, TelosUser usuario)
        {
            VSF_Sistema sistemaTmp;
            try
            {
                sistemaTmp = _negocioVsfSistema.ObterPorId(autoId, lazy);
            }
            catch (Exception exception)
            {
                sistemaTmp = null;
                VSF_LogSistema logSistema = new VSF_LogSistema();
                logSistema.Mensagem = TratamentoExcecoes.TratarRecursaoExcecao(exception);
                logSistema.Mensagem += " _negocioVsfSistema.ObterPorId";
                _negocioVsfSistema = new NegocioVSF_Sistema();
                logSistema.Sistema = _negocioVsfSistema.ObterPorCodigo(codigoSistema, true);
                _negocioVsfLogSistema.Inserir(logSistema);
                throw new Exception(exception.Message);
            }
            return sistemaTmp;
        }

        public VSF_Sistema ObterVSF_SistemaPoCodigo(string codigo, bool lazy, string codigoSistema, TelosUser usuario)
        {
            VSF_Sistema sistemaTmp;
            try
            {
                sistemaTmp = _negocioVsfSistema.ObterPorCodigo(codigo, lazy);
            }
            catch (Exception exception)
            {
                sistemaTmp = null;
                VSF_LogSistema logSistema = new VSF_LogSistema();
                logSistema.Mensagem = TratamentoExcecoes.TratarRecursaoExcecao(exception);
                logSistema.Mensagem += " _negocioVsfSistema.ObterPorCodigo";
                _negocioVsfSistema = new NegocioVSF_Sistema();
                logSistema.Sistema = _negocioVsfSistema.ObterPorCodigo(codigoSistema, true);
                _negocioVsfLogSistema.Inserir(logSistema);
                throw new Exception(exception.Message);
            }
            return sistemaTmp;
        }

        public IList<VSF_Sistema> ObterTodosVSF_Sistemas(bool lazy, string codigoSistema, TelosUser usuario)
        {
            IList<VSF_Sistema> sistemasTmp;
            try
            {
                sistemasTmp = _negocioVsfSistema.ObterTodos(lazy);
            }
            catch (Exception exception)
            {
                sistemasTmp = null;
                VSF_LogSistema logSistema = new VSF_LogSistema();
                logSistema.Mensagem = TratamentoExcecoes.TratarRecursaoExcecao(exception);
                logSistema.Mensagem += " _negocioVsfSistema.ObterTodos";
                _negocioVsfSistema = new NegocioVSF_Sistema();
                logSistema.Sistema = _negocioVsfSistema.ObterPorCodigo(codigoSistema, true);
                _negocioVsfLogSistema.Inserir(logSistema);
                throw new Exception(exception.Message);
            }

            return sistemasTmp;
        }

        public IList<VSF_Sistema> ObterTodosVSF_Sistemas(VSF_Sistema sistema, bool lazy, string codigoSistema, TelosUser usuario)
        {
            IList<VSF_Sistema> sistemasTmp;
            try
            {
                sistemasTmp = _negocioVsfSistema.ObterTodos(sistema, lazy);
            }
            catch (Exception exception)
            {

                sistemasTmp = null;
                VSF_LogSistema logSistema = new VSF_LogSistema();
                logSistema.Mensagem = TratamentoExcecoes.TratarRecursaoExcecao(exception);
                logSistema.Mensagem += " _negocioVsfSistema.ObterTodos";
                _negocioVsfSistema = new NegocioVSF_Sistema();
                logSistema.Sistema = _negocioVsfSistema.ObterPorCodigo(codigoSistema, true);
                _negocioVsfLogSistema.Inserir(logSistema);
                throw new Exception(exception.Message);
            }

            return sistemasTmp;
        }

        #endregion

        #region SolicitacaoCartaoIdentificacao

        public VSF_SolicitacaoCartaoIdentificacao ObterVSF_SolicitacaoCartaoIdentificacaoPorId(int autoId, bool lazy, string codigoSistema, TelosUser usuario)
        {
            VSF_SolicitacaoCartaoIdentificacao solicitacaoCartaoTmp;
            try
            {
                solicitacaoCartaoTmp = _negocioVsfSolicitacaoCartaoIdentificacao.ObterPorId(autoId, lazy);
            }
            catch (Exception exception)
            {
                solicitacaoCartaoTmp = null;
                VSF_LogSistema logSistema = new VSF_LogSistema();
                logSistema.Mensagem = TratamentoExcecoes.TratarRecursaoExcecao(exception);
                logSistema.Mensagem += " _negocioVsfSolicitacaoCartaoIdentificacao.ObterPorId";
                logSistema.Sistema = GetInstancia().ObterVSF_SistemaPoCodigo(codigoSistema, true, codigoSistema, usuario);
                GetInstancia().InserirVSF_LogSistema(logSistema, codigoSistema, usuario);
                throw new Exception(exception.Message);
            }
            return solicitacaoCartaoTmp;
        }

        public IList<VSF_SolicitacaoCartaoIdentificacao> ObterTodosVSF_SolicitacaoCartaoIdentificacaos(bool lazy, string codigoSistema, TelosUser usuario)
        {
            IList<VSF_SolicitacaoCartaoIdentificacao> solicitacaoCartaosTmp;
            try
            {
                solicitacaoCartaosTmp = _negocioVsfSolicitacaoCartaoIdentificacao.ObterTodos(lazy);
            }
            catch (Exception exception)
            {
                solicitacaoCartaosTmp = null;
                VSF_LogSistema logSistema = new VSF_LogSistema();
                logSistema.Mensagem = TratamentoExcecoes.TratarRecursaoExcecao(exception);
                logSistema.Mensagem += " _negocioVsfSolicitacaoCartaoIdentificacao.ObterTodos";
                logSistema.Sistema = GetInstancia().ObterVSF_SistemaPoCodigo(codigoSistema, true, codigoSistema, usuario);
                GetInstancia().InserirVSF_LogSistema(logSistema, codigoSistema, usuario);
                throw new Exception(exception.Message);
            }

            return solicitacaoCartaosTmp;
        }

        public IList<VSF_SolicitacaoCartaoIdentificacao> ObterTodosVSF_SolicitacaoCartaoIdentificacaos(VSF_SolicitacaoCartaoIdentificacao solicitacaoCartao, bool lazy, string codigoSistema, TelosUser usuario)
        {
            IList<VSF_SolicitacaoCartaoIdentificacao> solicitacaoCartaosTmp;
            try
            {
                solicitacaoCartaosTmp = _negocioVsfSolicitacaoCartaoIdentificacao.ObterTodos(solicitacaoCartao, lazy);
            }
            catch (Exception exception)
            {

                solicitacaoCartaosTmp = null;
                VSF_LogSistema logSistema = new VSF_LogSistema();
                logSistema.Mensagem = TratamentoExcecoes.TratarRecursaoExcecao(exception);
                logSistema.Mensagem += " _negocioVsfSolicitacaoCartaoIdentificacao.ObterTodos";
                logSistema.Sistema = GetInstancia().ObterVSF_SistemaPoCodigo(codigoSistema, true, codigoSistema, usuario);
                GetInstancia().InserirVSF_LogSistema(logSistema, codigoSistema, usuario);
                throw new Exception(exception.Message);
            }

            return solicitacaoCartaosTmp;
        }

        public VSF_SolicitacaoCartaoIdentificacao InserirVSF_SolicitacaoCartaoIdentificacao(VSF_SolicitacaoCartaoIdentificacao solicitacaoCartao, string codigoSistema, TelosUser usuario)
        {
            VSF_SolicitacaoCartaoIdentificacao solicitacaoCartaoTmp;
            try
            {
                solicitacaoCartaoTmp = _negocioVsfSolicitacaoCartaoIdentificacao.Inserir(solicitacaoCartao);
            }
            catch (Exception exception)
            {
                solicitacaoCartaoTmp = null;
                VSF_LogSistema logSistema = new VSF_LogSistema();
                logSistema.Mensagem = TratamentoExcecoes.TratarRecursaoExcecao(exception);
                logSistema.Mensagem += " _negocioVsfSolicitacaoCartaoIdentificacao.Inserir";
                logSistema.Sistema = GetInstancia().ObterVSF_SistemaPoCodigo(codigoSistema, true,codigoSistema,usuario);
                GetInstancia().InserirVSF_LogSistema(logSistema,codigoSistema,usuario);
                throw new Exception(exception.Message);
            }
            return solicitacaoCartaoTmp;
        }

        public VSF_SolicitacaoCartaoIdentificacao AtualizarVSF_SolicitacaoCartaoIdentificacao(VSF_SolicitacaoCartaoIdentificacao solicitacaoCartao, string codigoSistema, TelosUser usuario)
        {
            VSF_SolicitacaoCartaoIdentificacao solicitacaoCartaoTmp;
            try
            {
                solicitacaoCartaoTmp = _negocioVsfSolicitacaoCartaoIdentificacao.Atualizar(solicitacaoCartao);
            }
            catch (Exception exception)
            {
                solicitacaoCartaoTmp = null;
                VSF_LogSistema logSistema = new VSF_LogSistema();
                logSistema.Mensagem = TratamentoExcecoes.TratarRecursaoExcecao(exception);
                logSistema.Mensagem += " _negocioVsfSolicitacaoCartaoIdentificacao.Atualizar";
                logSistema.Sistema = GetInstancia().ObterVSF_SistemaPoCodigo(codigoSistema, true, codigoSistema, usuario);
                GetInstancia().InserirVSF_LogSistema(logSistema, codigoSistema, usuario);
                throw new Exception(exception.Message);
            }
            return solicitacaoCartaoTmp;
        }

        public IList<VSF_SolicitacaoCartaoIdentificacao> PesquisarTodosSolicitacaoCartaoIdentificacao(ObjetoPesquisa objetoPesquisa, bool lazy, string codigoSistema, TelosUser usuario)
        {
            IList<VSF_SolicitacaoCartaoIdentificacao> solicitacaoCartaosTmp;
            try
            {
                solicitacaoCartaosTmp = _negocioVsfSolicitacaoCartaoIdentificacao.PesquisarTodos(objetoPesquisa, lazy);
            }
            catch (Exception exception)
            {
                solicitacaoCartaosTmp = null;
                VSF_LogSistema logSistema = new VSF_LogSistema();
                logSistema.Mensagem = TratamentoExcecoes.TratarRecursaoExcecao(exception);
                logSistema.Mensagem += " _negocioVsfSolicitacaoCartaoIdentificacao.ObterTodos";
                logSistema.Sistema = GetInstancia().ObterVSF_SistemaPoCodigo(codigoSistema, true, codigoSistema, usuario);
                GetInstancia().InserirVSF_LogSistema(logSistema, codigoSistema, usuario);
                throw new Exception(exception.Message);
            }

            return solicitacaoCartaosTmp;
        }

        public VSF_SolicitacaoCartaoIdentificacao EmitirSolicitacaoCartao(VSF_SolicitacaoCartaoIdentificacao solicitacaoCartaoIdentificacao, string codigoSistema, TelosUser usuario)
        {
            VSF_SolicitacaoCartaoIdentificacao solicitacaoCartaoTmp;
            try
            {
                solicitacaoCartaoTmp = _negocioVsfSolicitacaoCartaoIdentificacao.EmitirSolicitacaoCartao(solicitacaoCartaoIdentificacao, codigoSistema, usuario);
            }
            catch (Exception exception)
            {
                solicitacaoCartaoTmp = null;
                VSF_LogSistema logSistema = new VSF_LogSistema();
                logSistema.Mensagem = TratamentoExcecoes.TratarRecursaoExcecao(exception);
                logSistema.Mensagem += " _negocioVsfSolicitacaoCartaoIdentificacao.EmitirSolicitacaoCartao";
                logSistema.Sistema = GetInstancia().ObterVSF_SistemaPoCodigo(codigoSistema, true, codigoSistema, usuario);
                GetInstancia().InserirVSF_LogSistema(logSistema, codigoSistema, usuario);
                throw new Exception(exception.Message);
            }
            return solicitacaoCartaoTmp;
        }

        public IList<VSF_SolicitacaoCartaoIdentificacao> EmitirSolicitacoesCartao(IList solicitacoesCartaoIdentificacao, string codigoSistema, TelosUser usuario)
        {
            IList<VSF_SolicitacaoCartaoIdentificacao> solicitacaoCartaosTmp;
            try
            {
                solicitacaoCartaosTmp = _negocioVsfSolicitacaoCartaoIdentificacao.EmitirSolicitacoesCartao(solicitacoesCartaoIdentificacao, codigoSistema, usuario);
            }
            catch (Exception exception)
            {
                solicitacaoCartaosTmp = null;
                VSF_LogSistema logSistema = new VSF_LogSistema();
                logSistema.Mensagem = TratamentoExcecoes.TratarRecursaoExcecao(exception);
                logSistema.Mensagem += " _negocioVsfSolicitacaoCartaoIdentificacao.EmitirSolicitacoesCartao";
                logSistema.Sistema = GetInstancia().ObterVSF_SistemaPoCodigo(codigoSistema, true, codigoSistema, usuario);
                GetInstancia().InserirVSF_LogSistema(logSistema, codigoSistema, usuario);
                throw new Exception(exception.Message);
            }
            return solicitacaoCartaosTmp;
       }

        public VSF_SolicitacaoCartaoIdentificacao CancelarSolicitacaoCartao(VSF_SolicitacaoCartaoIdentificacao solicitacaoCartaoIdentificacao, string codigoSistema, TelosUser usuario)
        {
            VSF_SolicitacaoCartaoIdentificacao solicitacaoCartaoTmp;
            try
            {
                solicitacaoCartaoTmp = _negocioVsfSolicitacaoCartaoIdentificacao.CancelarSolicitacaoCartao(solicitacaoCartaoIdentificacao, codigoSistema, usuario);
            }
            catch (Exception exception)
            {
                solicitacaoCartaoTmp = null;
                VSF_LogSistema logSistema = new VSF_LogSistema();
                logSistema.Mensagem = TratamentoExcecoes.TratarRecursaoExcecao(exception);
                logSistema.Mensagem += " _negocioVsfSolicitacaoCartaoIdentificacao.CancelarSolicitacaoCartao";
                logSistema.Sistema = GetInstancia().ObterVSF_SistemaPoCodigo(codigoSistema, true, codigoSistema, usuario);
                GetInstancia().InserirVSF_LogSistema(logSistema, codigoSistema, usuario);
                throw new Exception(exception.Message);
            }
            return solicitacaoCartaoTmp;
        }

        public DateTime? ValidarCodigoSolicitacao(string codigo)
        {
            return _negocioVsfSolicitacaoCartaoIdentificacao.ValidarCodigoSolicitacao(codigo);
        }

        #endregion

        #region TelosUser

        public TelosUser ObterTelosUserPorId(string code, bool lazy, string codigoSistema, TelosUser usuario)
        {
            TelosUser usuarioTmp;
            try
            {
                usuarioTmp = _negocioTelosUser.ObterPorId(code, lazy);
            }
            catch (Exception exception)
            {
                usuarioTmp = null;
                VSF_LogSistema logSistema = new VSF_LogSistema();
                logSistema.Mensagem = TratamentoExcecoes.TratarRecursaoExcecao(exception);
                logSistema.Mensagem += " _negocioTelosUser.ObterPorId";
                logSistema.Sistema = GetInstancia().ObterVSF_SistemaPoCodigo(codigoSistema, true, codigoSistema, usuario);
                GetInstancia().InserirVSF_LogSistema(logSistema, codigoSistema, usuario);
                throw new Exception(exception.Message);
            }
            return usuarioTmp;
        }

        public TelosUser ValidarLoginUsuario(string code, string senha, bool lazy, string codigoSistema, TelosUser usuario)
        {
            TelosUser usuarioTmp;
            try
            {
                usuarioTmp = _negocioTelosUser.ValidarLogin(code, senha, lazy);
            }
            catch (Exception exception)
            {
                usuarioTmp = null;
                VSF_LogSistema logSistema = new VSF_LogSistema();
                logSistema.Mensagem = TratamentoExcecoes.TratarRecursaoExcecao(exception);
                logSistema.Mensagem += " _negocioTelosUser.ObterPorId";
                logSistema.Sistema = GetInstancia().ObterVSF_SistemaPoCodigo(codigoSistema, true, codigoSistema, usuario);
                GetInstancia().InserirVSF_LogSistema(logSistema, codigoSistema, usuario);
                throw new Exception(exception.Message);
            }
            return usuarioTmp;
        }

        public IList<TelosUser> ObterTodosTelosUsers(bool lazy, string codigoSistema, TelosUser usuario)
        {
            IList<TelosUser> usuariosTmp;
            try
            {
                usuariosTmp = _negocioTelosUser.ObterTodos(lazy);
            }
            catch (Exception exception)
            {
                usuariosTmp = null;
                VSF_LogSistema logSistema = new VSF_LogSistema();
                logSistema.Mensagem = TratamentoExcecoes.TratarRecursaoExcecao(exception);
                logSistema.Mensagem += " _negocioTelosUser.ObterTodos";
                logSistema.Sistema = GetInstancia().ObterVSF_SistemaPoCodigo(codigoSistema, true, codigoSistema, usuario);
                GetInstancia().InserirVSF_LogSistema(logSistema, codigoSistema, usuario);
                throw new Exception(exception.Message);
            }

            return usuariosTmp;
        }

        public IList<TelosUser> ObterTodosTelosUsers(TelosUser usuarioPesquisado, bool lazy, string codigoSistema, TelosUser usuario)
        {
            IList<TelosUser> usuariosTmp;
            try
            {
                usuariosTmp = _negocioTelosUser.ObterTodos(usuarioPesquisado, lazy);
            }
            catch (Exception exception)
            {

                usuariosTmp = null;
                VSF_LogSistema logSistema = new VSF_LogSistema();
                logSistema.Mensagem = TratamentoExcecoes.TratarRecursaoExcecao(exception);
                logSistema.Mensagem += " _negocioTelosUser.ObterTodos";
                logSistema.Sistema = GetInstancia().ObterVSF_SistemaPoCodigo(codigoSistema, true, codigoSistema, usuario);
                GetInstancia().InserirVSF_LogSistema(logSistema, codigoSistema, usuario);
                throw new Exception(exception.Message);
            }

            return usuariosTmp;
        }

        #endregion

        #region VSF_SituacaoBeneficiario

        public VSF_SituacaoBeneficiario ObterSituacaoBeneficiarioPorBeneficiario(Beneficiario beneficiario, string codigoSistema, TelosUser usuario)
        {
            VSF_SituacaoBeneficiario vsf_SituacaoBeneficiarioTmp;
            try
            {
                vsf_SituacaoBeneficiarioTmp = _negocioVsfSituacaoBeneficiario.ObterPorBeneficiario(beneficiario);
            }
            catch (Exception exception)
            {
                vsf_SituacaoBeneficiarioTmp = null;
                VSF_LogSistema logSistema = new VSF_LogSistema();
                logSistema.Mensagem = TratamentoExcecoes.CriarArquivoLog(exception);
                logSistema.Mensagem += " _negocioVsfSituacaoBeneficiario.ObterPorBeneficiario";
                logSistema.Sistema = GetInstancia().ObterVSF_SistemaPoCodigo(codigoSistema, true, codigoSistema, usuario);
                GetInstancia().InserirVSF_LogSistema(logSistema, codigoSistema, usuario);
                throw new Exception(exception.Message);
            }

            return vsf_SituacaoBeneficiarioTmp;
        }

        #endregion

        #region ConfiguracaoFinanceira

        public VSF_ConfiguracaoFinanceira ObterVSF_ConfiguracaoFinanceira(bool lazy, string codigoSistema, TelosUser usuario)
        {
            VSF_ConfiguracaoFinanceira configuracaoFinanceiraTmp;
            try
            {
                configuracaoFinanceiraTmp = _negocioVsfConfiguracaoFinanceira.ObterVSF_ConfiguracaoFinanceira(lazy);
            }
            catch (Exception exception)
            {
                configuracaoFinanceiraTmp = null;
                VSF_LogSistema logSistema = new VSF_LogSistema();
                logSistema.Mensagem = TratamentoExcecoes.TratarRecursaoExcecao(exception);
                logSistema.Mensagem += " _negocioVsfConfiguracaoFinanceira.ObterConfiguracaoFinanceira";
                _negocioVsfSistema = new NegocioVSF_Sistema();
                logSistema.Sistema = _negocioVsfSistema.ObterPorCodigo(codigoSistema, true);
                _negocioVsfLogSistema.Inserir(logSistema);
                throw new Exception(exception.Message);
            }
            return configuracaoFinanceiraTmp;
        }

        #endregion

        #region MovimentacaoDocFinanceiro

        public MovDocFinan InserirPorDocFinan(int AutoIdMovDocFinan)
        {
            MovDocFinan movDocFinanTmp;
            try
            {
                movDocFinanTmp = _negocioMovDocFinan.InserirPorDocFinan(AutoIdMovDocFinan);
            }
            catch (Exception exception)
            {
                movDocFinanTmp = null;
                VSF_LogSistema logSistema = new VSF_LogSistema();
                logSistema.Mensagem = TratamentoExcecoes.TratarRecursaoExcecao(exception);
                logSistema.Mensagem += " _negocioMovDocFinan.InserirPorDocFinan";
                logSistema.Sistema = GetInstancia().ObterVSF_SistemaPoCodigo("TOTEM", true, "TOTEM", null);
                GetInstancia().InserirVSF_LogSistema(logSistema, "TOTEM", null);
                throw new Exception(exception.Message);
            }
            return movDocFinanTmp;
        }

        #endregion 
    }
}