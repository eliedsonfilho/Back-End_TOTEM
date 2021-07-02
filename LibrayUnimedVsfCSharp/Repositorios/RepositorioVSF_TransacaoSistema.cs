using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Dados;

namespace Repositorios
{
    public class RepositorioVSF_TransacaoSistema : Repositorio, IRepositorio<VSF_TransacaoSistema, int>
    {
        public VSF_TransacaoSistema ObterPorId(int autoIdBoleto, bool lazy)
        {
            IDbCommand command;
            //IDataReader dataReaderTmp;
            VSF_TransacaoSistema objetoPesquisado = new VSF_TransacaoSistema();

            //Executando a pesquisa
            try
            {
                command = new SqlCommand(@"Select 
                                            *
                                            From 
                                            VSF_TransacaoSistema where autoId = @autoId");

                SqlParameter parameterautoId = new SqlParameter("@autoId", autoIdBoleto);
                command.Parameters.Add(parameterautoId);

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

        public IList<VSF_TransacaoSistema> ObterTodos(bool lazy)
        {
            //IDataReader dataReaderTmp;
            IList<VSF_TransacaoSistema> listaObjetosPesquisados = null;
            VSF_TransacaoSistema objetoPesquisado = new VSF_TransacaoSistema();
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
                                           VSF_TransacaoSistema");
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
            catch (Exception)
            {
                throw;
            }

            //Tratando   o Retorno 
            //listaObjetosPesquisados = MontarListaObjetosDoReader(dataReaderTmp, objetoPesquisado, lazy);

            return listaObjetosPesquisados;
        }

        public IList<VSF_TransacaoSistema> ObterTodos(VSF_TransacaoSistema objetoPesquisado, bool lazy)
        {
            //IDataReader dataReaderTmp;
            IList<VSF_TransacaoSistema> listaObjetosPesquisados = null;
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
                                           VSF_TransacaoSistema");
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
            catch (Exception)
            {
                throw;
            }

            //Tratando   o Retorno 
            //listaObjetosPesquisados = MontarListaObjetosDoReader(dataReaderTmp, objetoPesquisado, lazy);

            return listaObjetosPesquisados;
        }

        public VSF_TransacaoSistema Inserir(VSF_TransacaoSistema transacaoSistema)
        {
            IDbCommand command;

            //Executando a Insert
            try
            {
                command = new SqlCommand(@"INSERT INTO [dbo].[VSF_TransacaoSistema]
                                            ([Acao]
                                            ,[DataTransacao]
                                            ,[Beneficiario]
                                            ,[Usuario]
                                            ,[Sistema])
                                        VALUES
                                            (@Acao
                                            ,@DataTransacao
                                            ,@Beneficiario
                                            ,@Usuario
                                            ,@Sistema)
                                            SELECT SCOPE_IDENTITY()");//Essa Linha Retorna O ID do Objeto Inserido

                SqlParameter Acao = new SqlParameter("@Acao", transacaoSistema.Acao);
                command.Parameters.Add(Acao);

                //DataTransacao
                if (transacaoSistema.DataTransacao.HasValue)
                {
                    SqlParameter DataTransacao = new SqlParameter("@DataTransacao", transacaoSistema.DataTransacao.GetValueOrDefault());
                    command.Parameters.Add(DataTransacao);
                }
                else
                {
                    SqlParameter DataTransacao = new SqlParameter("@DataTransacao", DBNull.Value);
                    command.Parameters.Add(DataTransacao);
                }
                
                //Beneficiario
                if (transacaoSistema.Beneficiario != null)
                {
                    SqlParameter Beneficiario = new SqlParameter("@Beneficiario", transacaoSistema.Beneficiario.AutoId);
                    command.Parameters.Add(Beneficiario);
                }
                else
                {
                    SqlParameter Beneficiario = new SqlParameter("@Beneficiario", DBNull.Value);
                    command.Parameters.Add(Beneficiario);
                }

                //Usuario
                if (transacaoSistema.Usuario != null)
                {
                    SqlParameter Usuario = new SqlParameter("@Usuario", transacaoSistema.Usuario.Code);
                    command.Parameters.Add(Usuario);
                }
                else
                {
                    SqlParameter Usuario = new SqlParameter("@Usuario", DBNull.Value);
                    command.Parameters.Add(Usuario);
                }

                //Sistema
                if (transacaoSistema.Sistema != null)
                {
                    SqlParameter Sistema = new SqlParameter("@Sistema", transacaoSistema.Sistema.AutoId);
                    command.Parameters.Add(Sistema);    
                }
                else
                {
                    SqlParameter Sistema = new SqlParameter("@Sistema", DBNull.Value);
                    command.Parameters.Add(Sistema); 
                }

                //Pegar o Retorno do Insert
                transacaoSistema.AutoId = GerenciadorConexaoBanco.GetInstancia(EnumTipoBanco.SqlServer).ExecutarNaoConsulta(command);
            }
            catch (Exception)
            {
                throw;
            }

            return transacaoSistema;
        }

        public VSF_TransacaoSistema Atualizar(VSF_TransacaoSistema transacaoSistema)
        {
            IDbCommand command;

            //Executando a Insert
            try
            {
                command = new SqlCommand(@"UPDATE [dbo].[VSF_TransacaoSistema]
                                       SET [Acao] = @Acao
                                          ,[DataTransacao] = @DataTransacao
                                          ,[Beneficiario] = @Beneficiario
                                          ,[Usuario] = @Usuario
                                          ,[Sistema] = @Sistema
                                         WHERE AutoId = @AutoId;");

                SqlParameter AutoId = new SqlParameter("@AutoId", transacaoSistema.AutoId);
                command.Parameters.Add(AutoId);

                SqlParameter Acao = new SqlParameter("@Acao", transacaoSistema.Acao);
                command.Parameters.Add(Acao);

                //DataTransacao
                if (transacaoSistema.DataTransacao.HasValue)
                {
                    SqlParameter DataTransacao = new SqlParameter("@DataTransacao", transacaoSistema.DataTransacao.GetValueOrDefault());
                    command.Parameters.Add(DataTransacao);
                }
                else
                {
                    SqlParameter DataTransacao = new SqlParameter("@DataTransacao", DBNull.Value);
                    command.Parameters.Add(DataTransacao);
                }
               

                //Beneficiario
                if (transacaoSistema.Beneficiario != null)
                {
                    SqlParameter Beneficiario = new SqlParameter("@Beneficiario", transacaoSistema.Beneficiario.AutoId);
                    command.Parameters.Add(Beneficiario);
                }
                else
                {
                    SqlParameter Beneficiario = new SqlParameter("@Beneficiario", DBNull.Value);
                    command.Parameters.Add(Beneficiario);
                }

                //Usuario
                if (transacaoSistema.Usuario != null)
                {
                    SqlParameter Usuario = new SqlParameter("@Usuario", transacaoSistema.Usuario.Code);
                    command.Parameters.Add(Usuario);
                }
                else
                {
                    SqlParameter Usuario = new SqlParameter("@Usuario", DBNull.Value);
                    command.Parameters.Add(Usuario);
                }

                //Sistema
                if (transacaoSistema.Sistema != null)
                {
                    SqlParameter Sistema = new SqlParameter("@Sistema", transacaoSistema.Sistema.AutoId);
                    command.Parameters.Add(Sistema);
                }
                else
                {
                    SqlParameter Sistema = new SqlParameter("@Sistema", DBNull.Value);
                    command.Parameters.Add(Sistema);
                }

                //Pegar o Retorno do Insert
                transacaoSistema.AutoId = GerenciadorConexaoBanco.GetInstancia(EnumTipoBanco.SqlServer).ExecutarNaoConsulta(command);
            }
            catch (Exception)
            {
                throw;
            }

            return transacaoSistema;
        }
    }
}