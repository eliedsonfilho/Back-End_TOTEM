using System;
using System.Collections.Generic;
using System.Linq;
using Dados;
using Repositorios;
using Util;

namespace Negocios
{
    public class NegocioBoletoCobranca
    {
        private RepositorioBoletoCobranca _repositorioBoletoCobranca;

        public NegocioBoletoCobranca()
        {
            _repositorioBoletoCobranca = new RepositorioBoletoCobranca();
        }

        public BoletoCobranca ObterBoletoCobrancaPorId(int autoIdBoletoCobranca, bool lazy)
        {
            return _repositorioBoletoCobranca.ObterPorId(autoIdBoletoCobranca, lazy);
        }

        public IList<BoletoCobranca> ObterTodosBoletoCobrancaAbertosPorBeneficiario(Beneficiario beneficiario)
        {
            //Se o tipo de contratante é diferente "2-Pessoa Fisica" -> Exeção 
            if (beneficiario.Contrato.Contratante.Tipo.Codigo != 2) 
            {
                throw new Exception("Tipo de contratante diferente de pessoa fisica");
            }
            //Caso Beneficiario igual "2-Pessoa Fisica" -> Retorna lista de Boletos em aberto
            else
            {
                return _repositorioBoletoCobranca.ObterTodosBoletosAbertosPorBeneficiario(beneficiario.AutoId, true);
            }


        }

        public IList<BoletoCobranca> ObterTodosBoletosPorBeneficiario(Beneficiario beneficiario)
        {
            return _repositorioBoletoCobranca.ObterTodosBoletosPorBeneficiario(beneficiario.AutoId, true);
        }

        /// <summary>
        /// Verifica se o boleto selecionado pode ser impresso, baseando-se em algumas regras que analisam tanto o boleto, 
        /// quanto o beneficiário deste boleto
        /// </summary>
        /// <param name="boletoCobranca">Boleto a ser analisado</param>
        /// <param name="beneficiario">Beneficiario  a ser analisado</param>
        /// <param name="prazoMaximo">Prazo máximo de dias de atraso do boleto</param>
        /// <param name="inadimplenciaMaxima">Prazo máximo de dias de inadimplencia do beneficiário</param>
        /// <returns>Se o boleto poder ser impresso, retorna Verdadeiro, caso contrário, retorna Falso</returns>
        public Boolean VerificaImpressaoBoleto(BoletoCobranca boletoCobranca, Beneficiario beneficiario, int prazoMaximo, int inadimplenciaMaxima)
        {
            // Verifica se o beneficiário está ativo
            NegocioVSF_SituacaoBeneficiario negocioVsfSituacaoBeneficiario = new NegocioVSF_SituacaoBeneficiario();
            VSF_SituacaoBeneficiario vsfSituacaoBeneficiario = negocioVsfSituacaoBeneficiario.ObterPorBeneficiario(beneficiario);
            if(vsfSituacaoBeneficiario == null || !vsfSituacaoBeneficiario.Ativo)
            {
                throw new Exception("Não é possível imprimir este boleto. Favor entrar em contato com o setor Negociação e Fidelização (87) 3866-7919");
                return false;
            }

            NegocioVSF_ConfiguracaoFinanceira negocioVsfConfiguracaoFinanceira = new NegocioVSF_ConfiguracaoFinanceira();
            VSF_ConfiguracaoFinanceira vsfConfiguracaoFinanceira = negocioVsfConfiguracaoFinanceira.ObterVSF_ConfiguracaoFinanceira(false);

            if (prazoMaximo <= 0)
            {
                prazoMaximo = vsfConfiguracaoFinanceira.LimiteDiasVencido;
            }

            if (inadimplenciaMaxima <= 0)
            {
                inadimplenciaMaxima = vsfConfiguracaoFinanceira.LimiteDiasVencido;
            }

            // Verifica se o documento não está vencido, caso esteja, se o vencimento é menor ou igual ao prazo máximo 
            if(VerificaBoletoVencido(boletoCobranca) && boletoCobranca.DiasAtraso > prazoMaximo)
            {
                throw new Exception("Não é possível imprimir este boleto. Favor entrar em contato com o setor Recepção Financeiro (87) 3866-7903");
                return false;
            }

            // Verifica a quantidade máxima de inadimplencia do beneficiário
            IList<BoletoCobranca> listaBoletosAbertos = ObterTodosBoletoCobrancaAbertosPorBeneficiario(beneficiario);
            if (listaBoletosAbertos.Where(x => x.DiasAtraso > inadimplenciaMaxima).FirstOrDefault() != null)
            {
                throw new Exception("Não é possível imprimir este boleto. Favor entrar em contato com o setor Recepção Financeiro (87) 3866-7903");
                return false;
            }

            // Verifica se o documento é o mais antigo em aberto, caso não, retornará falso
            listaBoletosAbertos = listaBoletosAbertos.OrderBy(x => x.DiasAtraso).ToList(); //Força lista a ficar ordenada
            if (boletoCobranca.AutoIdDocFinan != listaBoletosAbertos[listaBoletosAbertos.Count-1].AutoIdDocFinan)
            {
                throw new Exception("Não é possível imprimir este boleto. Favor entrar em contato com o setor Recepção Financeiro (87) 3866-7903");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Verifica que o boleto está vencido, comparando a data de vencimento com o dia atual, feriados e finais de semana.
        /// </summary>
        /// <param name="boletoCobranca">Boleto para verificação</param>
        /// <returns>Se o boleto estiver vencido, retorna Verdadeiro, caso contrário, retorna Falso</returns>
        public Boolean VerificaBoletoVencido(BoletoCobranca boletoCobranca)
        {
            // Se o valor da comparação for (-1) a data de vencimento é menor que o dia atual, 
            // se o valor da comparação for (0) a data de vencimento é igual ao dia atual e 
            // se o valor da comparação for (1) a data de vencimento é maior que o dia atual
            if (boletoCobranca.DataVencimento.Date.CompareTo(DateTime.Now.Date) >= 0) // Boleto não está vencido
            {
                return false;
            }
            
            // Boleto está vencido "em tese"
            // Se o vencimento do boleto caiu em um dia útil, está vencido
            NegocioFeriado negocioFeriado = new NegocioFeriado();
            if(negocioFeriado.DiaUtil(boletoCobranca.DataVencimento))
            {
                return true;
            }
            
            // Se o vencimento do boleto NÃO caiu em um dia útil
            // Verifica se hoje é o próximo dia útil a partir da data de vencimento do boleto, 
            // caso seja, o boleto não está vencido, se não for o próximo dia útil, o boleto está vencido
            if(negocioFeriado.ProximoDiaUtil(boletoCobranca.DataVencimento).Date.CompareTo(DateTime.Now.Date).Equals(0))
            {
                return false;    
            }

            return true;
        }

        public IList<OpcaoVencimentoBoleto> ObterOpcoesVencimentosBoleto(BoletoCobranca boletoCobranca, int limiteDias, int quantidadeDatas)
        {
            IList<OpcaoVencimentoBoleto> listaOpcaoVencimentoBoletos = new List<OpcaoVencimentoBoleto>();
            OpcaoVencimentoBoleto opcaoVencimentoBoleto;

            if(VerificaBoletoVencido(boletoCobranca))
            {
                NegocioVSF_ConfiguracaoFinanceira negocioVsfConfiguracaoFinanceira = new NegocioVSF_ConfiguracaoFinanceira();
                VSF_ConfiguracaoFinanceira vsfConfiguracaoFinanceira = negocioVsfConfiguracaoFinanceira.ObterVSF_ConfiguracaoFinanceira(false);

                // Calcula as opções de vencimento
                decimal valorJurosMulta = 0;
                if(limiteDias <= 0)
                {
                    limiteDias = vsfConfiguracaoFinanceira.LimiteDiasVencido;
                }

                if (quantidadeDatas <= 0)
                {
                    quantidadeDatas = vsfConfiguracaoFinanceira.QtdOpcoesVencimento;
                }

                foreach (DateTime dataVencimento in ObterDatasVencimento(DateTime.Now.Date, limiteDias, quantidadeDatas))
                {
                    opcaoVencimentoBoleto = new OpcaoVencimentoBoleto();
                    opcaoVencimentoBoleto.DataVencimento = dataVencimento;
                    valorJurosMulta = CalculaJuros(boletoCobranca.DataVencimento, dataVencimento, boletoCobranca.ValorDocumento, 
                                                    vsfConfiguracaoFinanceira.PercentualJuros, vsfConfiguracaoFinanceira.PercentualMulta);
                    opcaoVencimentoBoleto.ValorJuros = valorJurosMulta;
                    opcaoVencimentoBoleto.ValorTotal = boletoCobranca.ValorDocumento + valorJurosMulta;

                    listaOpcaoVencimentoBoletos.Add(opcaoVencimentoBoleto);
                }
            }
            else
            {// Retorna o Vencimento Original
                opcaoVencimentoBoleto = new OpcaoVencimentoBoleto();
                opcaoVencimentoBoleto.DataVencimento = boletoCobranca.DataVencimento;
                opcaoVencimentoBoleto.ValorJuros = 0;
                opcaoVencimentoBoleto.ValorTotal = boletoCobranca.ValorDocumento;

                listaOpcaoVencimentoBoletos.Add(opcaoVencimentoBoleto);
            }

            return listaOpcaoVencimentoBoletos;
        }

        /// <summary>
        /// Calcula o valor do juros referente aquele intervalo de tempo somado a multa
        /// </summary>
        /// <param name="dataInicial">Data inicial do intervalo</param>
        /// <param name="dataFinal">Data final do intervalo</param>
        /// <param name="valorInicial">Valor inicial do boleto</param>
        /// <param name="percentualJuros">Valor do juros referente ao mes da data inicial</param>
        /// <param name="valorMulta">Valor da multa</param>
        /// <returns>Retorna o valor do juros somado a multa</returns>
        public decimal CalculaJuros(DateTime dataInicial, DateTime dataFinal, decimal valorInicial, decimal percentualJuros, decimal percentualMulta)
        {
            //int quantidadeDiasMes = DateTime.DaysInMonth(dataInicial.Year, dataInicial.Month);
            //percentualJuros = (decimal) (0.02 / 30);
            int diferencaDias = dataFinal.Subtract(dataInicial).Days + 1;
            decimal valorJurosDiario = percentualJuros * valorInicial;

            decimal valorTotalJuros = Math.Round(valorJurosDiario * diferencaDias, 2);
            decimal valorTotalMulta = Math.Round(valorInicial * percentualMulta, 2);

            return Convert.ToDecimal((valorTotalJuros + valorTotalMulta).ToString("N2"));
        }

        /// <summary>
        /// Obtem a lista das possíveis datas de vencimento do boleto
        /// </summary>
        /// <param name="dataReferencia">Data de referência</param>
        /// <param name="limiteDias">Quantidade de dias para que seja verificado a faixa em que as possiveis datas estejam</param>
        /// <param name="quantidadeDatas">Quantidade máxima de possiveis datas</param>
        /// <returns>Retorna a lista das possíveis datas</returns>
        public IList<DateTime> ObterDatasVencimento(DateTime dataReferencia, int limiteDias, int quantidadeDatas)
        {
            IList<DateTime> listaDatas = new List<DateTime>();
            DateTime ultimoVencimento = dataReferencia.AddDays(limiteDias);
            DateTime vencimento = dataReferencia;
            
            // Adiciona de início a data do dia da impressão ou o próximo dia útil
            NegocioFeriado negocioFeriado = new NegocioFeriado();
            listaDatas.Add(negocioFeriado.DiaUtil(vencimento) 
                        ? vencimento
                        : vencimento = negocioFeriado.ProximoDiaUtil(vencimento));

            #region Verificando se o dia da impressão é maior que o último vencimento ou se o próximo dia útil é maior que o último vencimento
            /*
            if (ultimoVencimento.Date.CompareTo(vencimento) >= 0) // Vencimento é maior que o último vencimento
            {
                if(Utils.DiaUtil(vencimento))
                {
                    listaDatas.Add(vencimento);
                }
                else
                {
                    if (ultimoVencimento.Date.CompareTo(Utils.ProximoDiaUtil(vencimento)) >= 0) // Vencimento é maior que o último vencimento
                    {
                        listaDatas.Add(Utils.ProximoDiaUtil(vencimento));
                    }
                }
            }
             */
            #endregion

            for (int i = 1; i < quantidadeDatas; i++)
            {
                vencimento = negocioFeriado.ProximoDiaUtil(vencimento);
                // Verifica se o vencimento é maior que o ultimo vencimento.
                // Se o valor da comparação for (-1) a data do último vencimento é menor que o dia do vencimento, 
                // se o valor for (0) a data do último vencimento é igual ao dia do vencimento e 
                // se o valor for (1) a data do último vencimento é maior que o dia do vencimento
                if(ultimoVencimento.Date.CompareTo(vencimento).Equals(-1)) // Vencimento é maior que o último vencimento
                {
                    break;
                }
                
                // Vencimento é menor que o último vencimento
                listaDatas.Add(vencimento);
            }

            return listaDatas;
        }
    }
}