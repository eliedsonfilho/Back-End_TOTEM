using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Dados;

namespace Repositorios
{
    public class RepositorioMovDocFinan : Repositorio, IRepositorio<MovDocFinan, int>
    {

        public MovDocFinan ObterPorId(int autoIdBoleto, bool lazy)
        {
            throw new NotImplementedException();
        }

        public IList<MovDocFinan> ObterTodos(bool lazy)
        {
            throw new NotImplementedException();
        }

        public IList<MovDocFinan> ObterTodos(MovDocFinan objectPesquisado, bool lazy)
        {
            throw new NotImplementedException();
        }

        public IList<RepositorioMovDocFinan> ObterTodos(RepositorioMovDocFinan objectPesquisado, bool lazy)
        {
            throw new NotImplementedException();
        }

        public MovDocFinan Inserir(MovDocFinan dadosMovDocFinan)
        {
            IDbCommand command;

            //Executando a Insert
            try
            {
                command = new SqlCommand(@"INSERT INTO [dbo].[MovDocFinan]
				       ([DocFinanceiro], 
                            [DataMov], 
                            [Tipo], 
                            [Motivo], 
                            [Complemento], 
                            [DataCont], 
                            [TelosRgUs], 
                            [TelosRgDt], 
                            [TelosUpUs], 
                            [TelosUpDt], 
                            [TelosCtrler], 
                            [TipoCompl])
                       VALUES
				       (@DocFinanceiro
				       ,@DataMov
                       ,@Tipo 
                       ,@Motivo 
                       ,@Complemento 
                       ,@DataCont 
                       ,@TelosRgUs 
                       ,@TelosRgDt 
                       ,@TelosUpUs 
                       ,@TelosUpDt 
                       ,@TelosCtrler 
                       ,@TipoCompl)
					SELECT SCOPE_IDENTITY()");//Essa Linha Retorna O ID do Objeto Inserido

                //DocFinanceiro
                if (dadosMovDocFinan.DocFinanceiro != null)
                {
                    SqlParameter DocFinanceiro = new SqlParameter("@DocFinanceiro", dadosMovDocFinan.DocFinanceiro);
                    command.Parameters.Add(DocFinanceiro);                  
                }
                else
                {
                    SqlParameter DocFinanceiro = new SqlParameter("@DocFinanceiro", DBNull.Value);
                    command.Parameters.Add(DocFinanceiro);                                   
                }

                //DataMovimento 
                if (dadosMovDocFinan.DataMov != null)
                {
                    SqlParameter DataMov = new SqlParameter("@DataMov", dadosMovDocFinan.DataMov);
                    command.Parameters.Add(DataMov);
                }
                else
                {
                    SqlParameter DataMov = new SqlParameter("@DataMov", DBNull.Value);
                    command.Parameters.Add(DataMov);
                }

                //TipoMovimento
                if (dadosMovDocFinan.Tipo != null)
                {
                    SqlParameter Tipo = new SqlParameter("@Tipo", dadosMovDocFinan.Tipo);
                    command.Parameters.Add(Tipo);
                }
                else
                {
                    SqlParameter Tipo = new SqlParameter("@Tipo", DBNull.Value);
                    command.Parameters.Add(Tipo);
                }

                SqlParameter Motivo = new SqlParameter("@Motivo", DBNull.Value);
                command.Parameters.Add(Motivo);

                if (dadosMovDocFinan.Complemento != null)
                {
                    SqlParameter Complemento = new SqlParameter("@Complemento", dadosMovDocFinan.Complemento);
                    command.Parameters.Add(Complemento);
                }
                else
                {
                    SqlParameter Complemento = new SqlParameter("@Complemento", DBNull.Value);
                    command.Parameters.Add(Complemento);
                }

               SqlParameter DataCont = new SqlParameter("@DataCont", DBNull.Value);
               command.Parameters.Add(DataCont);
               
                if (dadosMovDocFinan.TelosRgUs != null)
                {
                    SqlParameter TelosRgUs = new SqlParameter("@TelosRgUs", dadosMovDocFinan.TelosRgUs);
                    command.Parameters.Add(TelosRgUs);
                }
                else
                {
                    SqlParameter TelosRgUs = new SqlParameter("@TelosRgUs", DBNull.Value);
                    command.Parameters.Add(TelosRgUs);
                }

                if (dadosMovDocFinan.TelosRgDt != null)
                {
                    SqlParameter TelosRgDt = new SqlParameter("@TelosRgDt", dadosMovDocFinan.TelosRgDt);
                    command.Parameters.Add(TelosRgDt);
                }
                else
                {
                    SqlParameter TelosRgDt = new SqlParameter("@TelosRgDt", DBNull.Value);
                    command.Parameters.Add(TelosRgDt);
                }

                if (dadosMovDocFinan.TelosUpUs != null)
                {
                    SqlParameter TelosUpUs = new SqlParameter("@TelosUpUs", dadosMovDocFinan.TelosUpUs);
                    command.Parameters.Add(TelosUpUs);
                }
                else
                {
                    SqlParameter TelosUpUs = new SqlParameter("@TelosUpUs", DBNull.Value);
                    command.Parameters.Add(TelosUpUs);
                }

                if (dadosMovDocFinan.TelosUpDt != null)
                {
                    SqlParameter TelosUpDt = new SqlParameter("@TelosUpDt", dadosMovDocFinan.TelosUpDt);
                    command.Parameters.Add(TelosUpDt);
                }
                else
                {
                    SqlParameter TelosUpDt = new SqlParameter("@TelosUpDt", DBNull.Value);
                    command.Parameters.Add(TelosUpDt);
                }

                if (dadosMovDocFinan.TelosCtrler != null)
                {
                    SqlParameter TelosCtrler = new SqlParameter("@TelosCtrler", dadosMovDocFinan.TelosCtrler);
                    command.Parameters.Add(TelosCtrler);
                }
                else
                {
                    SqlParameter TelosCtrler = new SqlParameter("@TelosCtrler", DBNull.Value);
                    command.Parameters.Add(TelosCtrler);
                }

                
                SqlParameter TipoCompl = new SqlParameter("@TipoCompl", DBNull.Value);
                command.Parameters.Add(TipoCompl);
              

                //Pegar o Retorno do Insert
                dadosMovDocFinan.AutoId = GerenciadorConexaoBanco.GetInstancia(EnumTipoBanco.SqlServer).ExecutarNaoConsulta(command);
            }
            catch (Exception)
            {
                throw;
            }

            return dadosMovDocFinan;
        }
  
   	
    }

}
