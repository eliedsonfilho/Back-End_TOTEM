using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Dados;

namespace Repositorios
{
    public class RepositorioBoletoCobranca : Repositorio, IRepositorio<BoletoCobranca, int>
    {
        public BoletoCobranca ObterPorId(int autoIdBoleto, bool lazy)
        {
            IDbCommand command;
            //IDataReader dataReaderTmp;
            BoletoCobranca objetoPesquisado = new BoletoCobranca();

            //Executando a pesquisa
            try
            {
                command = new SqlCommand(@"SELECT BoletoCobranca.AutoId,
                                            Contrato.Codigo AS Contrato, 
			                                Pessoa.Nome AS Contratante,
			                                VSF_Situacao_Contrato.Situacao SituacaoContrato,
			                                DocFinanceiro.AutoId AS AutoIdDocFinan, 
			                                DocFinanceiro.Numero AS NumeroDocumento, 
                                            SUBSTRING(CONVERT(VARCHAR, DocFinanceiro.CompFinanceira), 5, 2) + '-' + SUBSTRING(CONVERT(VARCHAR, DocFinanceiro.CompFinanceira), 1, 4) AS CompFin, 
                                            DocFinanceiro.DataVencimento, 
			                                CONVERT(Decimal(10, 2), DocFinanceiro.ValorLiquido) AS ValorDocumento,
			                                CASE 
				                                WHEN CONVERT(int, CONVERT(datetime, CONVERT(varchar, getdate(), 23)) - DocFinanceiro.DataVencimento) <= 0 THEN 0 
				                                ELSE CONVERT(int, CONVERT(datetime, CONVERT(varchar, getdate(), 23)) - DocFinanceiro.DataVencimento) 
			                                END AS DiasAtraso,
			                                SituacaoDocumento.Nome SituacaoDocFinan,
			                                NULL Historico,
			                                NULL ValorPago,
			                                NULL DataPagamento,
                                            BoletoCobranca.NossoNumero
                    FROM            DocFinanceiro INNER JOIN
                                             ContratoFinanceiro ON DocFinanceiro.ContratoFinanceiro = ContratoFinanceiro.AutoId LEFT OUTER JOIN
                                             QuitacaoDocFinan ON DocFinanceiro.AutoId = QuitacaoDocFinan.DocFinanceiro INNER JOIN
                                             Contrato ON ContratoFinanceiro.AutoId = Contrato.ContratoFinanceiro INNER JOIN
                                             Pessoa ON Contrato.Contratante = Pessoa.AutoId LEFT OUTER JOIN
                                             VSF_Situacao_Contrato ON Contrato.AutoId = VSF_Situacao_Contrato.AutoId_Cont INNER JOIN
                                             Beneficiario ON Contrato.AutoId = Beneficiario.Contrato INNER JOIN
                                             BoletoCobranca ON DocFinanceiro.AutoId = BoletoCobranca.DocFinanceiro INNER JOIN
						                     SituacaoDocumento ON DocFinanceiro.SituacaoDocumento = SituacaoDocumento.Codigo
                    WHERE        (BoletoCobranca.AutoId = @AutoIdBoleto)

                    ORDER BY Contrato, DocFinanceiro.DataVencimento DESC");

                SqlParameter parametercolunaChave = new SqlParameter("@AutoIdBoleto", autoIdBoleto);
                command.Parameters.Add(parametercolunaChave);

                //dataReaderTmp = GerenciadorConexaoBanco.GetInstancia(EnumTipoBanco.SqlServer).ExecutarConsulta(command);
                objetoPesquisado = GerenciadorConexaoBanco.GetInstancia(EnumTipoBanco.SqlServer).ExecutarConsultaObject(command, objetoPesquisado, lazy);
            }
            catch (Exception)
            {
                throw;
            }

            //Tratando o Retorno 
            //objetoPesquisado = MontarObjetoDoReader(dataReaderTmp, objetoPesquisado, lazy);

            return objetoPesquisado;
        }

        public IList<BoletoCobranca> ObterTodos(bool lazy)
        {
            //IDataReader dataReaderTmp;
            IList<BoletoCobranca> listaObjetosPesquisados = null;
            BoletoCobranca objetoPesquisado = new BoletoCobranca();
            IDbCommand command = null;
            int qtdRegistro = 100;
            StringBuilder filtros;
            bool where = false;
            //Montar o Comando
            if (objetoPesquisado != null)
            {
                filtros = new StringBuilder();

                //Filtros


                //Se foi passado algun filtro
                if (where)
                {
                    command = new SqlCommand(@"Select TOP " + qtdRegistro.ToString() + " * From BoletoCobranca WHERE ");
                }
                else
                {
                    command = new SqlCommand(@"Select TOP " + qtdRegistro.ToString() + " * From BoletoCobranca");

                }

                //Concatena a string
                command.CommandText += filtros.ToString();

            }


            //Executando a pesquisa
            try
            {
                //dataReaderTmp = GerenciadorConexaoBanco.GetInstancia(EnumTipoBanco.SqlServer).ExecutarConsulta(command);
                listaObjetosPesquisados = GerenciadorConexaoBanco.GetInstancia(EnumTipoBanco.SqlServer).ExecutarConsultaList(command, objetoPesquisado, lazy);
            }
            catch (Exception)
            {
                throw;
            }

            //Tratando   o Retorno 
            //listaObjetosPesquisados = MontarListaObjetosDoReader(dataReaderTmp, objetoPesquisado, lazy);

            return listaObjetosPesquisados;
        }

        public IList<BoletoCobranca> ObterTodos(BoletoCobranca objetoPesquisado, bool lazy)
        {
            //IDataReader dataReaderTmp;
            IList<BoletoCobranca> listaObjetosPesquisados = null;
            IDbCommand command = null;
            int qtdRegistro = 100;
            StringBuilder filtros;
            bool where = false;
            //Montar o Comando
            if (objetoPesquisado != null)
            {
                filtros = new StringBuilder();

                /*
                //Filtros
                if (objetoPesquisado.Propiedade != null)
                {
                    filtros.Append("Propiedade = " + objetoPesquisado.Propiedade.ToString());
                    where = true;
                }
                */

                //Se foi passado algun filtro
                if (where)
                {
                    command = new SqlCommand(@"Select TOP " + qtdRegistro.ToString() + " * From BoletoCobranca WHERE ");
                }
                else
                {
                    command = new SqlCommand(@"Select TOP " + qtdRegistro.ToString() + " * From BoletoCobranca");

                }

                //Concatena a string
                command.CommandText += filtros.ToString();

            }


            //Executando a pesquisa
            try
            {
                //dataReaderTmp = GerenciadorConexaoBanco.GetInstancia(EnumTipoBanco.SqlServer).ExecutarConsulta(command);
                listaObjetosPesquisados = GerenciadorConexaoBanco.GetInstancia(EnumTipoBanco.SqlServer).ExecutarConsultaList(command, objetoPesquisado, lazy);
            }
            catch (Exception)
            {
                throw;
            }

            //Tratando   o Retorno 
            //listaObjetosPesquisados = MontarListaObjetosDoReader(dataReaderTmp, objetoPesquisado, lazy);

            return listaObjetosPesquisados;
        }

        public IList<BoletoCobranca> ObterTodosBoletosAbertosPorBeneficiario(int autoIdBeneficiario, bool lazy)
        {
            IList<BoletoCobranca> listaObjetosPesquisados = null;
            BoletoCobranca objetoPesquisado = new BoletoCobranca();
            IDbCommand command = new SqlCommand();
            StringBuilder query;
            bool where = false;
            //Montar o Comando
            if (objetoPesquisado != null)
            {
                query = new StringBuilder();

                      query.Append(@"SELECT BoletoCobranca.AutoId,
                                            Contrato.Codigo AS Contrato, 
			                                Pessoa.Nome AS Contratante,
			                                VSF_Situacao_Contrato.Situacao SituacaoContrato,
			                                DocFinanceiro.AutoId AS AutoIdDocFinan, 
			                                DocFinanceiro.Numero AS NumeroDocumento, 
                                            SUBSTRING(CONVERT(VARCHAR, DocFinanceiro.CompFinanceira), 5, 2) + '-' + SUBSTRING(CONVERT(VARCHAR, DocFinanceiro.CompFinanceira), 1, 4) AS CompFin, 
                                            DocFinanceiro.DataVencimento, 
			                                CONVERT(Decimal(10, 2), DocFinanceiro.ValorLiquido) AS ValorDocumento,
			                                CASE 
				                                WHEN CONVERT(int, CONVERT(datetime, CONVERT(varchar, getdate(), 23)) - DocFinanceiro.DataVencimento) <= 0 THEN 0 
				                                ELSE CONVERT(int, CONVERT(datetime, CONVERT(varchar, getdate(), 23)) - DocFinanceiro.DataVencimento) 
			                                END AS DiasAtraso,
			                                SituacaoDocumento.Nome SituacaoDocFinan,
			                                NULL Historico,
			                                NULL ValorPago,
			                                NULL DataPagamento,
                                            BoletoCobranca.NossoNumero
                    FROM            DocFinanceiro INNER JOIN
                                             ContratoFinanceiro ON DocFinanceiro.ContratoFinanceiro = ContratoFinanceiro.AutoId LEFT OUTER JOIN
                                             QuitacaoDocFinan ON DocFinanceiro.AutoId = QuitacaoDocFinan.DocFinanceiro INNER JOIN
                                             Contrato ON ContratoFinanceiro.AutoId = Contrato.ContratoFinanceiro INNER JOIN
                                             Pessoa ON Contrato.Contratante = Pessoa.AutoId INNER JOIN
                                             VSF_Situacao_Contrato ON Contrato.AutoId = VSF_Situacao_Contrato.AutoId_Cont INNER JOIN
                                             Beneficiario ON Contrato.AutoId = Beneficiario.Contrato INNER JOIN
                                             BoletoCobranca ON DocFinanceiro.AutoId = BoletoCobranca.DocFinanceiro INNER JOIN
						                     SituacaoDocumento ON DocFinanceiro.SituacaoDocumento = SituacaoDocumento.Codigo
                    WHERE        (QuitacaoDocFinan.Cancelada = 0 OR
                                             QuitacaoDocFinan.Cancelada IS NULL) AND (DocFinanceiro.DataVencimento >= GETDATE() - 365) AND (DocFinanceiro.Classe = 2) AND 
                                             (DocFinanceiro.SituacaoDocumento = 1) AND (DocFinanceiro.DataEmissao <= GETDATE()) AND 
                                             (BoletoCobranca.FormaCobranca NOT IN (4, 7)) AND (Beneficiario.AutoId = @AutoIdBenef)
                                        
                    ORDER BY Contrato, DocFinanceiro.DataVencimento DESC");

                //query.Replace("@AutoIdBenef", autoIdBeneficiario.ToString());
                //Concatena a string
                command.CommandText += query.ToString();

                SqlParameter ParAutoIdBenef = new SqlParameter("@AutoIdBenef",autoIdBeneficiario);

                command.Parameters.Add(ParAutoIdBenef);

            }

            //Executando a pesquisa
            try
            {
                listaObjetosPesquisados = GerenciadorConexaoBanco.GetInstancia(EnumTipoBanco.SqlServer).ExecutarConsultaList(command, objetoPesquisado, lazy);
            }
            catch (Exception)
            {
                throw;
            }

            return listaObjetosPesquisados;
        }

        public IList<BoletoCobranca> ObterTodosBoletosPorBeneficiario(int autoIdBeneficiario, bool lazy)
        {
            IList<BoletoCobranca> listaObjetosPesquisados = null;
            BoletoCobranca objetoPesquisado = new BoletoCobranca();
            IDbCommand command = new SqlCommand();
            StringBuilder query;
            bool where = false;
            //Montar o Comando
            if (objetoPesquisado != null)
            {
                query = new StringBuilder();

                query.Append(@"SELECT   BoletoCobranca.AutoId,
                                        Contrato.Codigo Contrato, 
		                                Pessoa.Nome Contratante,
		                                DocFinanceiro.autoId AutoIdDocFinan,
		                                SC.Situacao SituacaoContrato, 
		                                DocFinanceiro.Numero NumeroDocumento, 
		                                DocFinanceiro.CompFinanceira CompFin,
                                        convert(varchar,DocFinanceiro.DataVencimento,103) DataVencimento, 
		                                DocFinanceiro.ValorLiquido ValorDocumento, 
                                        convert(varchar,QuitacaoDocFinan.DataQuitacao,103) DataPagamento, 
		                                QuitacaoDocFinan.ValorTotal ValorPago,
		                                case when DocFinanceiro.SituacaoDocumento=4 then 'Doc Fin Cancelado'
		                                else case when QuitacaoDocFinan.ValorTotal is null and convert(int, convert(datetime, convert(varchar,getdate(),23)) -DocFinanceiro.DataVencimento) <= 0 then 'Parcela Não Vencida'
		                                else case when QuitacaoDocFinan.ValorTotal is null and PSC.Susp_Max_Cont > DocFinanceiro.DataVencimento 
				                                  then 'Parcela em aberto há ' + convert(varchar,convert(int,  PSC.Susp_Max_Cont - DocFinanceiro.DataVencimento )) + ' dia(s)' 

		                                else case when QuitacaoDocFinan.ValorTotal is null and PSC.Susp_Max_Cont <= DocFinanceiro.DataVencimento 
				                                  then 'Parcela não vencida '

		                                else case when QuitacaoDocFinan.ValorTotal is null then 'Parcela em aberto há ' + 
						                                convert(varchar, convert(int, convert(datetime, convert(varchar,getdate(),23)) - DocFinanceiro.DataVencimento  )) + ' dia(s)' 

		                                else case when convert(int, convert(datetime, convert(varchar,QuitacaoDocFinan.DataQuitacao,23))- convert(datetime, convert(varchar,DocFinanceiro.DataVencimento,23))) <= 0 then 'Pago em Dia' 
		                                else 'Pago com atraso de '+ convert(varchar, convert(int, convert(datetime, convert(varchar,QuitacaoDocFinan.DataQuitacao,23))- convert(datetime, convert(varchar,DocFinanceiro.DataVencimento,23))) ) +' Dia(s)' end end end end end end Historico,
		                                SituacaoDocumento.Nome SituacaoDocFinan,
		                                convert(varchar, convert(int, convert(datetime, convert(varchar,QuitacaoDocFinan.DataQuitacao,23))- convert(datetime, convert(varchar,DocFinanceiro.DataVencimento,23))) ) DiasAtraso,
                                        BoletoCobranca.NossoNumero
                                FROM    DocFinanceiro INNER JOIN
                                        BoletoCobranca ON DocFinanceiro.AutoId = BoletoCobranca.DocFinanceiro INNER JOIN
                                        ContratoFinanceiro ON DocFinanceiro.ContratoFinanceiro = ContratoFinanceiro.AutoId LEFT OUTER JOIN
                                        QuitacaoDocFinan ON DocFinanceiro.AutoId = QuitacaoDocFinan.DocFinanceiro INNER JOIN
                                        Contrato ON ContratoFinanceiro.AutoId = Contrato.ContratoFinanceiro INNER JOIN
                                        SituacaoDocumento ON DocFinanceiro.SituacaoDocumento = SituacaoDocumento.Codigo INNER JOIN
                                        Pessoa ON Contrato.Contratante = Pessoa.AutoId INNER JOIN
		                                VSF_Permanencia_Suspensao_Cont AS PSC ON Contrato.AutoId = PSC.Id_Cont INNER JOIN
                                        VSF_Situacao_Contrato AS SC ON Contrato.AutoId = SC.AutoId_Cont
                                WHERE   (QuitacaoDocFinan.Cancelada = 0 OR QuitacaoDocFinan.Cancelada IS NULL) 
                                and DocFinanceiro.DataVencimento between getdate()-365 and getdate()+60
                                AND ContratoFinanceiro.codigo in (  
									                                SELECT     ContratoFinanceiro.Codigo
									                                FROM         Beneficiario INNER JOIN
														                                  Contrato ON Beneficiario.Contrato = Contrato.AutoId INNER JOIN
														                                  ContratoFinanceiro ON Contrato.ContratoFinanceiro = ContratoFinanceiro.AutoId
									                                WHERE     (Beneficiario.Autoid = @AutoIdBenef)
								                                 )

                                order by  Contrato.Codigo, DocFinanceiro.CompFinanceira desc");

                command.CommandText += query.ToString();

                SqlParameter ParAutoIdBenef = new SqlParameter("@AutoIdBenef", autoIdBeneficiario);

                command.Parameters.Add(ParAutoIdBenef);
            }

            //Executando a pesquisa
            try
            {
                listaObjetosPesquisados = GerenciadorConexaoBanco.GetInstancia(EnumTipoBanco.SqlServer).ExecutarConsultaList(command, objetoPesquisado, lazy);
            }
            catch (Exception)
            {
                throw;
            }

            return listaObjetosPesquisados;
        }

    }
}