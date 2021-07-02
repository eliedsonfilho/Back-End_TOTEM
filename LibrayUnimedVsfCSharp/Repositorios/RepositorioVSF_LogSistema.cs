using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Dados;

namespace Repositorios
{
    public class RepositorioVSF_LogSistema : Repositorio, IRepositorio<VSF_LogSistema, int>
    {
        public VSF_LogSistema ObterPorId(int autoIdBoleto, bool lazy)
        {
            IDbCommand command;
            //IDataReader dataReaderTmp;
            VSF_LogSistema objetoPesquisado = new VSF_LogSistema();

            //Executando a pesquisa
            try
            {
                command = new SqlCommand(@"Select 
                                            *
                                            From 
                                            VSF_LogSistema where autoId = @autoId");

                SqlParameter parameterautoId = new SqlParameter("@autoId", autoIdBoleto);
                command.Parameters.Add(parameterautoId);

                //dataReaderTmp = GerenciadorConexaoBanco.GetInstancia(EnumTipoBanco.SqlServer).ExecutarConsulta(command);
                objetoPesquisado = GerenciadorConexaoBanco.GetInstancia(EnumTipoBanco.SqlServer).ExecutarConsultaObject(command, objetoPesquisado, lazy);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }

            //Tratando o Retorno 
            //objetoPesquisado = MontarObjetoDoReader(dataReaderTmp, objetoPesquisado, lazy);
            

            return objetoPesquisado;
        }

        public IList<VSF_LogSistema> ObterTodos(bool lazy)
        {
            //IDataReader dataReaderTmp;
            IList<VSF_LogSistema> listaObjetosPesquisados = null;
            VSF_LogSistema objetoPesquisado = new VSF_LogSistema();
            IDbCommand command = null;
            int qtdRegistro = 100;
            StringBuilder query;
            bool where = false;
            //Montar o Comando
            if (objetoPesquisado != null)
            {
                query = new StringBuilder();

                command = new SqlCommand(@"Select                                    
                                           *
                                           From 
                                           VSF_LogSistema");
                //Filtros


                //Se foi passado algun filtro
                if (where)
                {
                    command.CommandText += " where ";
                }
                else
                {
                    query.Append(" LIMIT " + qtdRegistro);
                }

                //Concatena a string
                command.CommandText += query.ToString();

            }


            //Executando a pesquisa
            try
            {
                //dataReaderTmp = GerenciadorConexaoBanco.GetInstancia(EnumTipoBanco.SqlServer).ExecutarConsulta(command);
                listaObjetosPesquisados = GerenciadorConexaoBanco.GetInstancia(EnumTipoBanco.SqlServer).ExecutarConsultaList(command, objetoPesquisado, lazy);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }

            //Tratando   o Retorno 
            //listaObjetosPesquisados = MontarListaObjetosDoReader(dataReaderTmp, objetoPesquisado, lazy);

            return listaObjetosPesquisados;
        }

        public IList<VSF_LogSistema> ObterTodos(VSF_LogSistema objetoPesquisado, bool lazy)
        {
            //IDataReader dataReaderTmp;
            IList<VSF_LogSistema> listaObjetosPesquisados = null;
            IDbCommand command = null;
            int qtdRegistro = 100;
            StringBuilder query;
            bool where = false;
            //Montar o Comando
            if (objetoPesquisado != null)
            {
                query = new StringBuilder();

                command = new SqlCommand(@"Select                                    
                                           *
                                           From 
                                           VSF_LogSistema");
                //Filtros


                //Se foi passado algun filtro
                if (where)
                {
                    command.CommandText += " where ";
                }
                else
                {
                    query.Append(" LIMIT " + qtdRegistro);
                }

                //Concatena a string
                command.CommandText += query.ToString();

            }


            //Executando a pesquisa
            try
            {
                //dataReaderTmp = GerenciadorConexaoBanco.GetInstancia(EnumTipoBanco.SqlServer).ExecutarConsulta(command);
                listaObjetosPesquisados = GerenciadorConexaoBanco.GetInstancia(EnumTipoBanco.SqlServer).ExecutarConsultaList(command, objetoPesquisado, lazy);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }

            //Tratando   o Retorno 
            //listaObjetosPesquisados = MontarListaObjetosDoReader(dataReaderTmp, objetoPesquisado, lazy);
            

            return listaObjetosPesquisados;
        }

        public VSF_LogSistema Inserir(VSF_LogSistema logSistema)
        {
            IDbCommand command;

            //Executando a Insert
            try
            {
                command = new SqlCommand(@"INSERT INTO [dbo].[VSF_LogSistema]
                                           ([Sistema]
                                           ,[Mensagem]
                                           ,[DataLog])
                                     VALUES
                                           (@Sistema
                                           ,@Mensagem
                                           ,@DataLog)
                                            SELECT SCOPE_IDENTITY()");//Essa Linha Retorna O ID do Objeto Inserido

                //Sistema
                if (logSistema.Sistema != null)
                {
                    SqlParameter Sistema = new SqlParameter("@Sistema", logSistema.Sistema.AutoId);
                    command.Parameters.Add(Sistema);
                }
                else
                {
                    SqlParameter Sistema = new SqlParameter("@Sistema", DBNull.Value);
                    command.Parameters.Add(Sistema);
                }
                
                //Mensagem
                SqlParameter Mensagem = new SqlParameter("@Mensagem", logSistema.Mensagem);
                command.Parameters.Add(Mensagem);

                //DataLog
                if (logSistema.DataLog.HasValue)
                {
                    SqlParameter DataLog = new SqlParameter("@DataLog", logSistema.DataLog.GetValueOrDefault());
                    command.Parameters.Add(DataLog);    
                }
                else
                {
                    SqlParameter DataLog = new SqlParameter("@DataLog", DBNull.Value);
                    command.Parameters.Add(DataLog);
                }
                

                //Pegar o Retorno do Insert
                logSistema.AutoId = GerenciadorConexaoBanco.GetInstancia(EnumTipoBanco.SqlServer).ExecutarNaoConsulta(command);
            }
            catch (Exception)
            {
                logSistema = null;
                throw;
            }

            return logSistema;
        }

        public VSF_LogSistema Atualizar(VSF_LogSistema logSistema)
        {
            IDbCommand command;

            //Executando a Insert
            try
            {
                command = new SqlCommand(@"UPDATE [dbo].[VSF_LogSistema]
                                           SET [Sistema] = @Sistema
                                              ,[Mensagem] = @Mensagem
                                              ,[DataLog] = @DataLog
                                         WHERE AutoId = @AutoId;");

                SqlParameter AutoId = new SqlParameter("@AutoId", logSistema.AutoId);
                command.Parameters.Add(AutoId);
                
                //Sistema
                if (logSistema.Sistema != null)
                {
                    SqlParameter Sistema = new SqlParameter("@Sistema", logSistema.Sistema.AutoId);
                    command.Parameters.Add(Sistema);
                }
                else
                {
                    SqlParameter Sistema = new SqlParameter("@Sistema", DBNull.Value);
                    command.Parameters.Add(Sistema);
                }

                SqlParameter Mensagem = new SqlParameter("@Mensagem", logSistema.Mensagem);
                command.Parameters.Add(Mensagem);

                //DataLog
                if (logSistema.DataLog.HasValue)
                {
                    SqlParameter DataLog = new SqlParameter("@DataLog", logSistema.DataLog.GetValueOrDefault());
                    command.Parameters.Add(DataLog);
                }
                else
                {
                    SqlParameter DataLog = new SqlParameter("@DataLog", DBNull.Value);
                    command.Parameters.Add(DataLog);
                }

                //Pegar o Retorno do Insert
                logSistema.AutoId = GerenciadorConexaoBanco.GetInstancia(EnumTipoBanco.SqlServer).ExecutarNaoConsulta(command);
            }
            catch (Exception)
            {
                logSistema = null;
                throw;
            }

            return logSistema;
        }

    }
}