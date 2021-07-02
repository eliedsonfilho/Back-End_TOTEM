using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Dados;

namespace Repositorios
{
    public class RepositorioVSF_SolicitacaoCartaoIdentificacao : Repositorio, IRepositorio<VSF_SolicitacaoCartaoIdentificacao, int>
    {
        public VSF_SolicitacaoCartaoIdentificacao ObterPorId(int autoIdBoleto, bool lazy)
        {
            IDbCommand command;
            //IDataReader dataReaderTmp;
            VSF_SolicitacaoCartaoIdentificacao objetoPesquisado = new VSF_SolicitacaoCartaoIdentificacao();

            //Executando a pesquisa
            try
            {
                command = new SqlCommand(@"Select 
                                            *
                                            From 
                                            VSF_SolicitacaoCartaoIdentificacao where autoId = @autoId");

                SqlParameter parameterautoId = new SqlParameter("@autoId", autoIdBoleto);
                command.Parameters.Add(parameterautoId);

               // dataReaderTmp = GerenciadorConexaoBanco.GetInstancia(EnumTipoBanco.SqlServer).ExecutarConsulta(command);
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

        public IList<VSF_SolicitacaoCartaoIdentificacao> ObterTodos(bool lazy)
        {
            //IDataReader dataReaderTmp;
            IList<VSF_SolicitacaoCartaoIdentificacao> listaObjetosPesquisados = null;
            VSF_SolicitacaoCartaoIdentificacao objetoPesquisado = new VSF_SolicitacaoCartaoIdentificacao();
            IDbCommand command = null;
            int qtdRegistro = 100;
            //Montar o Comando
            if (objetoPesquisado != null)
            {
                command = new SqlCommand(@"Select  TOP " + qtdRegistro.ToString() + " * From VSF_SolicitacaoCartaoIdentificacao");
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

        public IList<VSF_SolicitacaoCartaoIdentificacao> ObterTodos(VSF_SolicitacaoCartaoIdentificacao objetoPesquisado, bool lazy)
        {
            //IDataReader dataReaderTmp;
            IList<VSF_SolicitacaoCartaoIdentificacao> listaObjetosPesquisados = null;
            IDbCommand command = null;
            int qtdRegistro = 100;
            StringBuilder filtros;
            bool where = false;
            //Montar o Comando
            if (objetoPesquisado != null)
            {
                filtros = new StringBuilder();

                //Filtros
                if (objetoPesquisado.Beneficiario != null)
                {
                    filtros.Append(" Beneficiario = " + objetoPesquisado.Beneficiario.AutoId.ToString());
                    where = true;
                }

                if (!String.IsNullOrEmpty(objetoPesquisado.Codigo))
                {
                    if (where)
                    {
                        filtros.Append(" and ");
                    }

                    filtros.Append(" Codigo = " + objetoPesquisado.Codigo);
                    where = true;
                }

                if (objetoPesquisado.DataCancelamento.HasValue)
                {
                    if (where)
                    {
                        filtros.Append(" and ");
                    }

                    filtros.Append(" DataCancelamento >= " + objetoPesquisado.DataCancelamento.GetValueOrDefault().Date.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                    where = true;
                }

                if (objetoPesquisado.DataEmissao.HasValue)
                {
                    if (where)
                    {
                        filtros.Append(" and ");
                    }

                    filtros.Append(" DataEmissao >= " + objetoPesquisado.DataEmissao.GetValueOrDefault().Date.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                    where = true;
                }

                if (objetoPesquisado.DataSolicitacao.HasValue)
                {
                    if (where)
                    {
                        filtros.Append(" and ");
                    }

                    filtros.Append(" DataSolicitacao >= " + objetoPesquisado.DataSolicitacao.GetValueOrDefault().Date.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                    where = true;
                }

                if (objetoPesquisado.SituacaoSolicitacaoCartaoIdentificacao > 0)
                {
                    if (where)
                    {
                        filtros.Append(" and ");
                    }

                    filtros.Append(" SituacaoSolicitacaoCartaoIdentificacao = " +
                                   (int) objetoPesquisado.SituacaoSolicitacaoCartaoIdentificacao);
                    where = true;
                }

                //Se foi passado algun filtro
                if (where)
                {
                    command = new SqlCommand(@"Select * From VSF_SolicitacaoCartaoIdentificacao WHERE ");
                }
                else
                {
                    command = new SqlCommand(@"Select top " + qtdRegistro.ToString() + " * From VSF_SolicitacaoCartaoIdentificacao");
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

        public IList<VSF_SolicitacaoCartaoIdentificacao> PesquisarTodos(ObjetoPesquisa objetoPesquisa, bool lazy)
        {
            //IDataReader dataReaderTmp;
            IList<VSF_SolicitacaoCartaoIdentificacao> listaObjetosPesquisados = null;
            VSF_SolicitacaoCartaoIdentificacao objetoPesquisado = new VSF_SolicitacaoCartaoIdentificacao() ;
            IDbCommand command = null;
            int qtdRegistro = 100;
            StringBuilder filtros;
            bool where = false;
            //Montar o Comando
            if (objetoPesquisa != null)
            {
                filtros = new StringBuilder();

                //Filtros
                if (objetoPesquisa.AutoIdBeneficiario != 0)
                {
                    filtros.Append(" Beneficiario = " + objetoPesquisa.AutoIdBeneficiario.ToString());
                    where = true;
                }

                if (!String.IsNullOrEmpty(objetoPesquisa.Codigo))
                {
                    if (where)
                    {
                        filtros.Append(" and ");
                    }

                    filtros.Append(" Codigo = " + objetoPesquisa.Codigo);
                    where = true;
                }

                if (objetoPesquisa.DataCancelamentoInicial.HasValue)
                {
                    if (where)
                    {
                        filtros.Append(" and ");
                    }

                    filtros.Append(" DataCancelamento >= '" + objetoPesquisa.DataCancelamentoInicial.GetValueOrDefault().Date.ToString("yyyy-MM-dd HH:mm:ss.fff") + "'");

                    //Data Final
                    if (objetoPesquisa.DataCancelamentoFinal.HasValue)
                    {
                        filtros.Append(" and DataCancelamento <= '" + objetoPesquisa.DataCancelamentoFinal.GetValueOrDefault().Date.ToString("yyyy-MM-dd 23:59:59.fff") + "'");
                    }
                    
                    where = true;
                }

                if (objetoPesquisa.DataEmissaoInicial.HasValue)
                {
                    if (where)
                    {
                        filtros.Append(" and ");
                    }

                    filtros.Append(" DataEmissao >= '" + objetoPesquisa.DataEmissaoInicial.GetValueOrDefault().Date.ToString("yyyy-MM-dd HH:mm:ss.fff") + "'");

                    //Data Final
                    if (objetoPesquisa.DataEmissaoFinal.HasValue)
                    {
                        filtros.Append(" and DataEmissao <= '" + objetoPesquisa.DataEmissaoFinal.GetValueOrDefault().Date.ToString("yyyy-MM-dd 23:59:59.fff") + "'");
                    }
                    
                    where = true;
                }

                if (objetoPesquisa.DataSolicitacaoInicial.HasValue)
                {
                    if (where)
                    {
                        filtros.Append(" and ");
                    }

                    filtros.Append(" DataSolicitacao >= '" + objetoPesquisa.DataSolicitacaoInicial.GetValueOrDefault().Date.ToString("yyyy-MM-dd HH:mm:ss.fff") + "'");

                    //Data Final
                    if (objetoPesquisa.DataSolicitacaoFinal.HasValue)
                    {
                        filtros.Append(" and DataSolicitacao <= '" + objetoPesquisa.DataSolicitacaoFinal.GetValueOrDefault().Date.ToString("yyyy-MM-dd 23:59:59.fff") + "'");
                    }
                    
                    where = true;
                }

                if (objetoPesquisa.Situacao > 0)
                {
                    if (where)
                    {
                        filtros.Append(" and ");
                    }

                    filtros.Append(" SituacaoSolicitacaoCartaoIdentificacao = " +
                                   (int)objetoPesquisa.Situacao);
                    where = true;
                }

                //Se foi passado algun filtro
                if (where)
                {
                    command = new SqlCommand(@"Select * From VSF_SolicitacaoCartaoIdentificacao WHERE ");
                }
                else
                {
                    command = new SqlCommand(@"Select top " + qtdRegistro.ToString() + " * From VSF_SolicitacaoCartaoIdentificacao");
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
            //listaObjetosPesquisados = MontarListaObjetosDoReader(dataReaderTmp, new VSF_SolicitacaoCartaoIdentificacao(), lazy);

            return listaObjetosPesquisados;
        }

        public VSF_SolicitacaoCartaoIdentificacao Inserir(VSF_SolicitacaoCartaoIdentificacao solicitacaoCartaoIdentificacao)
        {
            IDbCommand command;

            //Executando a Insert
            try
            {
                command = new SqlCommand(@"INSERT INTO [dbo].[VSF_SolicitacaoCartaoIdentificacao]
                                               ([Codigo]
                                               ,[Beneficiario]
                                               ,[SituacaoSolicitacaoCartaoIdentificacao]
                                               ,[EnderecoPessoa]
                                               ,[RegistrarEnderecoPessoa]
                                               ,[EmailPessoa]
                                               ,[RegistrarEmailPessoa]
                                               ,[DataSolicitacao]
                                               ,[DataEmissao]
                                               ,[DataCancelamento]
                                               ,[UsuarioEmissao])
                                         VALUES
                                               (@Codigo
                                               ,@Beneficiario
                                               ,@SituacaoSolicitacaoCartaoIdentificacao
                                               ,@EnderecoPessoa
                                               ,@RegistrarEnderecoPessoa
                                               ,@EmailPessoa
                                               ,@RegistrarEmailPessoa
                                               ,@DataSolicitacao
                                               ,@DataEmissao
                                               ,@DataCancelamento
                                               ,@UsuarioEmissao)
                                            SELECT SCOPE_IDENTITY()");//Essa Linha Retorna O ID do Objeto Inserido

                SqlParameter Codigo = new SqlParameter("@Codigo", solicitacaoCartaoIdentificacao.Codigo);
                command.Parameters.Add(Codigo);

                //Beneficiario
                if (solicitacaoCartaoIdentificacao.Beneficiario != null)
                {
                    SqlParameter Beneficiario = new SqlParameter("@Beneficiario", solicitacaoCartaoIdentificacao.Beneficiario.AutoId);
                    command.Parameters.Add(Beneficiario);
                }
                else
                {
                    SqlParameter Beneficiario = new SqlParameter("@Beneficiario", DBNull.Value);
                    command.Parameters.Add(Beneficiario);
                }

                //SituacaoSolicitacao
                SqlParameter SituacaoSolicitacaoCartaoIdentificacao = new SqlParameter("@SituacaoSolicitacaoCartaoIdentificacao", solicitacaoCartaoIdentificacao.SituacaoSolicitacaoCartaoIdentificacao);
                command.Parameters.Add(SituacaoSolicitacaoCartaoIdentificacao);

                //Endereco
                if (solicitacaoCartaoIdentificacao.EnderecoPessoa != null)
                {
                    SqlParameter EnderecoPessoa = new SqlParameter("@EnderecoPessoa", solicitacaoCartaoIdentificacao.EnderecoPessoa.AutoId);
                    command.Parameters.Add(EnderecoPessoa);
                }
                else
                {
                    SqlParameter EnderecoPessoa = new SqlParameter("@EnderecoPessoa", DBNull.Value);
                    command.Parameters.Add(EnderecoPessoa);
                }

                //Registrar Endereco
                SqlParameter RegistrarEnderecoPessoa = new SqlParameter("@RegistrarEnderecoPessoa", solicitacaoCartaoIdentificacao.RegistrarEnderecoPessoa);
                command.Parameters.Add(RegistrarEnderecoPessoa);

                //Email
                if (solicitacaoCartaoIdentificacao.EmailPessoa != null)
                {
                    SqlParameter EmailPessoa = new SqlParameter("@EmailPessoa", solicitacaoCartaoIdentificacao.EmailPessoa.AutoId);
                    command.Parameters.Add(EmailPessoa);
                }
                else
                {
                    SqlParameter EmailPessoa = new SqlParameter("@EmailPessoa", DBNull.Value);
                    command.Parameters.Add(EmailPessoa);
                }

                //Registrar Email
                SqlParameter RegistrarEmailPessoa = new SqlParameter("@RegistrarEmailPessoa", solicitacaoCartaoIdentificacao.RegistrarEmailPessoa);
                command.Parameters.Add(RegistrarEmailPessoa);

                //DataSolicitacao
                if (solicitacaoCartaoIdentificacao.DataSolicitacao.HasValue)
                {
                    SqlParameter DataSolicitacao = new SqlParameter("@DataSolicitacao", solicitacaoCartaoIdentificacao.DataSolicitacao.GetValueOrDefault());
                    command.Parameters.Add(DataSolicitacao);
                }
                else
                {
                    SqlParameter DataSolicitacao = new SqlParameter("@DataSolicitacao", DBNull.Value);
                    command.Parameters.Add(DataSolicitacao);
                }

                //DataEmissao
                if (solicitacaoCartaoIdentificacao.DataEmissao.HasValue)
                {
                    SqlParameter DataEmissao = new SqlParameter("@DataEmissao", solicitacaoCartaoIdentificacao.DataEmissao.GetValueOrDefault());
                    command.Parameters.Add(DataEmissao);
                }
                else
                {
                    SqlParameter DataEmissao = new SqlParameter("@DataEmissao", DBNull.Value);
                    command.Parameters.Add(DataEmissao);
                }
                
                //DataCancelamento
                if (solicitacaoCartaoIdentificacao.DataCancelamento.HasValue)
                {
                    SqlParameter DataCancelamento = new SqlParameter("@DataCancelamento", solicitacaoCartaoIdentificacao.DataCancelamento.GetValueOrDefault());
                    command.Parameters.Add(DataCancelamento);
                }
                else
                {
                    SqlParameter DataCancelamento = new SqlParameter("@DataCancelamento", DBNull.Value);
                    command.Parameters.Add(DataCancelamento);
                }

                //Usuario
                if (solicitacaoCartaoIdentificacao.UsuarioEmissao != null)
                {
                    SqlParameter UsuarioEmissao = new SqlParameter("@UsuarioEmissao", solicitacaoCartaoIdentificacao.UsuarioEmissao.Code);
                    command.Parameters.Add(UsuarioEmissao);
                }
                else
                {
                    SqlParameter UsuarioEmissao = new SqlParameter("@UsuarioEmissao", DBNull.Value);
                    command.Parameters.Add(UsuarioEmissao);
                }

                //Pegar o Retorno do Insert
                solicitacaoCartaoIdentificacao.AutoId = GerenciadorConexaoBanco.GetInstancia(EnumTipoBanco.SqlServer).ExecutarNaoConsulta(command);
            }
            catch (Exception)
            {
                throw;
            }

            return solicitacaoCartaoIdentificacao;
        }

        public VSF_SolicitacaoCartaoIdentificacao Atualizar(VSF_SolicitacaoCartaoIdentificacao solicitacaoCartaoIdentificacao)
        {
            IDbCommand command;

            //Executando a Insert
            try
            {
                command = new SqlCommand(@"UPDATE [dbo].[VSF_SolicitacaoCartaoIdentificacao]
                                           SET [Codigo] = @Codigo
                                              ,[Beneficiario] = @Beneficiario
                                              ,[SituacaoSolicitacaoCartaoIdentificacao] = @SituacaoSolicitacaoCartaoIdentificacao
                                              ,[EnderecoPessoa] = @EnderecoPessoa
                                              ,[RegistrarEnderecoPessoa] = @RegistrarEnderecoPessoa
                                              ,[EmailPessoa] = @EmailPessoa
                                              ,[RegistrarEmailPessoa] = @RegistrarEmailPessoa
                                              ,[DataSolicitacao] = @DataSolicitacao
                                              ,[DataEmissao] = @DataEmissao
                                              ,[DataCancelamento] = @DataCancelamento
                                              ,[UsuarioEmissao] = @UsuarioEmissao
                                         WHERE AutoId = @AutoId;");

                SqlParameter AutoId = new SqlParameter("@AutoId", solicitacaoCartaoIdentificacao.AutoId);
                command.Parameters.Add(AutoId);

                SqlParameter Codigo = new SqlParameter("@Codigo", solicitacaoCartaoIdentificacao.Codigo);
                command.Parameters.Add(Codigo);

                //Beneficiario
                if (solicitacaoCartaoIdentificacao.Beneficiario != null)
                {
                    SqlParameter Beneficiario = new SqlParameter("@Beneficiario", solicitacaoCartaoIdentificacao.Beneficiario.AutoId);
                    command.Parameters.Add(Beneficiario);
                }
                else
                {
                    SqlParameter Beneficiario = new SqlParameter("@Beneficiario",DBNull.Value);
                    command.Parameters.Add(Beneficiario.Value);
                }

                //SituacaoSolicitacao
                SqlParameter SituacaoSolicitacaoCartaoIdentificacao = new SqlParameter("@SituacaoSolicitacaoCartaoIdentificacao", solicitacaoCartaoIdentificacao.SituacaoSolicitacaoCartaoIdentificacao);
                command.Parameters.Add(SituacaoSolicitacaoCartaoIdentificacao);

                //Endereco
                if (solicitacaoCartaoIdentificacao.EnderecoPessoa != null)
                {
                    SqlParameter EnderecoPessoa = new SqlParameter("@EnderecoPessoa", solicitacaoCartaoIdentificacao.EnderecoPessoa.AutoId);
                    command.Parameters.Add(EnderecoPessoa);
                }
                else
                {
                    SqlParameter EnderecoPessoa = new SqlParameter("@EnderecoPessoa", DBNull.Value);
                    command.Parameters.Add(EnderecoPessoa);
                }

                //Registrar Endereco
                SqlParameter RegistrarEnderecoPessoa = new SqlParameter("@RegistrarEnderecoPessoa", solicitacaoCartaoIdentificacao.RegistrarEnderecoPessoa);
                command.Parameters.Add(RegistrarEnderecoPessoa);

                //Email
                if (solicitacaoCartaoIdentificacao.EmailPessoa != null)
                {
                    SqlParameter EmailPessoa = new SqlParameter("@EmailPessoa", solicitacaoCartaoIdentificacao.EmailPessoa.AutoId);
                    command.Parameters.Add(EmailPessoa);
                }
                else
                {
                    SqlParameter EmailPessoa = new SqlParameter("@EmailPessoa", DBNull.Value);
                    command.Parameters.Add(EmailPessoa);
                }

                //Registrar Email
                SqlParameter RegistrarEmailPessoa = new SqlParameter("@RegistrarEmailPessoa", solicitacaoCartaoIdentificacao.RegistrarEmailPessoa);
                command.Parameters.Add(RegistrarEmailPessoa);

                //DataSolicitacao
                if (solicitacaoCartaoIdentificacao.DataSolicitacao.HasValue)
                {
                    SqlParameter DataSolicitacao = new SqlParameter("@DataSolicitacao", solicitacaoCartaoIdentificacao.DataSolicitacao.GetValueOrDefault());
                    command.Parameters.Add(DataSolicitacao);
                }
                else
                {
                    SqlParameter DataSolicitacao = new SqlParameter("@DataSolicitacao", DBNull.Value);
                    command.Parameters.Add(DataSolicitacao);
                }

                //DataEmissao
                if (solicitacaoCartaoIdentificacao.DataEmissao.HasValue)
                {
                    SqlParameter DataEmissao = new SqlParameter("@DataEmissao", solicitacaoCartaoIdentificacao.DataEmissao.GetValueOrDefault());
                    command.Parameters.Add(DataEmissao);
                }
                else
                {
                    SqlParameter DataEmissao = new SqlParameter("@DataEmissao", DBNull.Value);
                    command.Parameters.Add(DataEmissao);
                }
                
                //DataCancelamento
                if (solicitacaoCartaoIdentificacao.DataCancelamento.HasValue)
                {
                    SqlParameter DataCancelamento = new SqlParameter("@DataCancelamento", solicitacaoCartaoIdentificacao.DataCancelamento.GetValueOrDefault());
                    command.Parameters.Add(DataCancelamento);
                }
                else
                {
                    SqlParameter DataCancelamento = new SqlParameter("@DataCancelamento", DBNull.Value);
                    command.Parameters.Add(DataCancelamento);
                }

                //Usuario
                if (solicitacaoCartaoIdentificacao.UsuarioEmissao != null)
                {
                    SqlParameter UsuarioEmissao = new SqlParameter("@UsuarioEmissao", solicitacaoCartaoIdentificacao.UsuarioEmissao.Code);
                    command.Parameters.Add(UsuarioEmissao);
                }
                else
                {
                    SqlParameter UsuarioEmissao = new SqlParameter("@UsuarioEmissao", DBNull.Value);
                    command.Parameters.Add(UsuarioEmissao);
                }

                //Pegar o Retorno do Insert
                solicitacaoCartaoIdentificacao.AutoId = GerenciadorConexaoBanco.GetInstancia(EnumTipoBanco.SqlServer).ExecutarNaoConsulta(command);
            }
            catch (Exception)
            {
                throw;
            }

            return solicitacaoCartaoIdentificacao;
        }
    }
}