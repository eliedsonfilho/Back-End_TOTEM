using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Dados;

namespace Repositorios
{
    public class RepositorioVSF_ConfiguracaoSistema : Repositorio, IRepositorio<VSF_ConfiguracaoSistema, int>
    {
        public VSF_ConfiguracaoSistema ObterPorId(int autoIdBoleto, bool lazy)
        {
            IDbCommand command;
            //IDataReader dataReaderTmp;
            VSF_ConfiguracaoSistema objetoPesquisado = new VSF_ConfiguracaoSistema();

            //Executando a pesquisa
            try
            {
                command = new SqlCommand(@"Select 
                                            *
                                            From 
                                            VSF_ConfiguracaoSistema where autoId = @autoId");

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

        public IList<VSF_ConfiguracaoSistema> ObterTodos(bool lazy)
        {
            //IDataReader dataReaderTmp;
            IList<VSF_ConfiguracaoSistema> listaObjetosPesquisados = null;
            VSF_ConfiguracaoSistema objetoPesquisado = new VSF_ConfiguracaoSistema();
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
                                           VSF_ConfiguracaoSistema");
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

        public IList<VSF_ConfiguracaoSistema> ObterTodos(VSF_ConfiguracaoSistema objetoPesquisado, bool lazy)
        {
            //IDataReader dataReaderTmp;
            IList<VSF_ConfiguracaoSistema> listaObjetosPesquisados = null;
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
                                           VSF_ConfiguracaoSistema");
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

        public VSF_ConfiguracaoSistema Inserir(VSF_ConfiguracaoSistema configuracaoSistema)
        {
            IDbCommand command;
            
            //Executando a Insert
            try
            {
                command = new SqlCommand(@"INSERT INTO [dbo].[VSF_ConfiguracaoSistema]
                                           ([Sistema]
                                           ,[HeigthBotaoPrincipal]
                                           ,[WeightBotaoPrincipal]
                                           ,[HeigthBotaoRodape]
                                           ,[WeightBotaoRodape]
                                           ,[HeigthBotao]
                                           ,[WeightBotao]
                                           ,[FontePrincipal]
                                           ,[FonteTextInput]
                                           ,[FonteLabel]
                                           ,[TempoProtege]
                                           ,[LinhasConsulta]
                                           ,[NumeroMaximoTentativas]
                                           ,[UltimaAtualizacao])
                                     VALUES
                                           (@Sistema,
                                            @HeigthBotaoPrincipal,
                                            @WeightBotaoPrincipal,
                                            @HeigthBotaoRodape,
                                            @WeightBotaoRodape,
                                            @HeigthBotao,
                                            @WeightBotao,
                                            @FontePrincipal,
                                            @FonteTextInput,
                                            @FonteLabel,
                                            @TempoProtege,
                                            @LinhasConsulta,
                                            @NumeroMaximoTentativas,
                                            @UltimaAtualizacao)
                                            SELECT SCOPE_IDENTITY()");//Essa Linha Retorna O ID do Objeto Inserido
                
                //Sistema
                if (configuracaoSistema.Sistema != null)
                {
                    SqlParameter Sistema = new SqlParameter("@Sistema", configuracaoSistema.Sistema.AutoId);
                    command.Parameters.Add(Sistema);    
                }
                else
                {
                    SqlParameter Sistema = new SqlParameter("@Sistema", DBNull.Value);
                    command.Parameters.Add(Sistema);
                }

                SqlParameter HeigthBotaoPrincipal = new SqlParameter("@HeigthBotaoPrincipal", configuracaoSistema.HeigthBotaoPrincipal);
                command.Parameters.Add(HeigthBotaoPrincipal);

                SqlParameter WeightBotaoPrincipal = new SqlParameter("@WeightBotaoPrincipal", configuracaoSistema.WeightBotaoPrincipal);
                command.Parameters.Add(WeightBotaoPrincipal);

                SqlParameter HeigthBotaoRodape = new SqlParameter("@HeigthBotaoRodape", configuracaoSistema.HeigthBotaoRodape);
                command.Parameters.Add(HeigthBotaoRodape);

                SqlParameter WeightBotaoRodape = new SqlParameter("@WeightBotaoRodape", configuracaoSistema.WeightBotaoRodape);
                command.Parameters.Add(WeightBotaoRodape);

                SqlParameter HeigthBotao = new SqlParameter("@HeigthBotao", configuracaoSistema.HeigthBotao);
                command.Parameters.Add(HeigthBotao);

                SqlParameter WeightBotao = new SqlParameter("@WeightBotao", configuracaoSistema.WeightBotao);
                command.Parameters.Add(WeightBotao);

                SqlParameter FontePrincipal = new SqlParameter("@FontePrincipal", configuracaoSistema.FontePrincipal);
                command.Parameters.Add(FontePrincipal);

                SqlParameter FonteTextInput = new SqlParameter("@FonteTextInput", configuracaoSistema.FonteTextInput);
                command.Parameters.Add(FonteTextInput);

                SqlParameter FonteLabel = new SqlParameter("@FonteLabel", configuracaoSistema.FonteLabel);
                command.Parameters.Add(FonteLabel);

                SqlParameter TempoProtege = new SqlParameter("@TempoProtege", configuracaoSistema.TempoProtege);
                command.Parameters.Add(TempoProtege);

                SqlParameter LinhasConsulta = new SqlParameter("@LinhasConsulta", configuracaoSistema.LinhasConsulta);
                command.Parameters.Add(LinhasConsulta);

                SqlParameter NumeroMaximoTentativas = new SqlParameter("@NumeroMaximoTentativas", configuracaoSistema.NumeroMaximoTentativas);
                command.Parameters.Add(NumeroMaximoTentativas);

                //UltimaAtualizacao
                if (configuracaoSistema.UltimaAtualizacao.HasValue)
                {
                    SqlParameter UltimaAtualizacao = new SqlParameter("@UltimaAtualizacao", configuracaoSistema.UltimaAtualizacao.GetValueOrDefault());
                    command.Parameters.Add(UltimaAtualizacao);
                }
                else
                {
                    SqlParameter UltimaAtualizacao = new SqlParameter("@UltimaAtualizacao", DBNull.Value);
                    command.Parameters.Add(UltimaAtualizacao);
                }
                
                //Pegar o Retorno do Insert
                configuracaoSistema.AutoId = GerenciadorConexaoBanco.GetInstancia(EnumTipoBanco.SqlServer).ExecutarNaoConsulta(command);
            }
            catch (Exception)
            {
                configuracaoSistema = null;
                throw;
            }
            
            return configuracaoSistema;
        }

        public VSF_ConfiguracaoSistema Atualizar(VSF_ConfiguracaoSistema configuracaoSistema)
        {
            IDbCommand command;

            //Executando a Insert
            try
            {
                command = new SqlCommand(@"UPDATE [dbo].[VSF_ConfiguracaoSistema] SET
                                              [Sistema] = @Sistema,
                                              [HeigthBotaoPrincipal] = @HeigthBotaoPrincipal,
                                              [WeightBotaoPrincipal] = @WeightBotaoPrincipal,
                                              [HeigthBotaoRodape] = @HeigthBotaoRodape,
                                              [WeightBotaoRodape] = @WeightBotaoRodape,
                                              [HeigthBotao] = @HeigthBotao,
                                              [WeightBotao] = @WeightBotao,
                                              [FontePrincipal] = @FontePrincipal,
                                              [FonteTextInput] = @FonteTextInput,
                                              [FonteLabel] = @FonteLabel,
                                              [TempoProtege] = @TempoProtege,
                                              [LinhasConsulta] = @LinhasConsulta,
                                              [NumeroMaximoTentativas] = @NumeroMaximoTentativas,
                                              [UltimaAtualizacao] = @UltimaAtualizacao
                                         WHERE AutoId = @AutoId;");
               
                    
                SqlParameter AutoId = new SqlParameter("@AutoId", configuracaoSistema.AutoId);
                command.Parameters.Add(AutoId);

                //Sistema
                if (configuracaoSistema.Sistema != null)
                {
                    SqlParameter Sistema = new SqlParameter("@sistema", configuracaoSistema.Sistema.AutoId);
                    command.Parameters.Add(Sistema);
                }
                else
                {
                    SqlParameter Sistema = new SqlParameter("@Sistema", DBNull.Value);
                    command.Parameters.Add(Sistema);
                }

                SqlParameter HeigthBotaoPrincipal = new SqlParameter("@HeigthBotaoPrincipal", configuracaoSistema.HeigthBotaoPrincipal);
                command.Parameters.Add(HeigthBotaoPrincipal);

                SqlParameter WeightBotaoPrincipal = new SqlParameter("@WeightBotaoPrincipal", configuracaoSistema.WeightBotaoPrincipal);
                command.Parameters.Add(WeightBotaoPrincipal);

                SqlParameter HeigthBotaoRodape = new SqlParameter("@HeigthBotaoRodape", configuracaoSistema.HeigthBotaoRodape);
                command.Parameters.Add(HeigthBotaoRodape);

                SqlParameter WeightBotaoRodape = new SqlParameter("@WeightBotaoRodape", configuracaoSistema.WeightBotaoRodape);
                command.Parameters.Add(WeightBotaoRodape);

                SqlParameter HeigthBotao = new SqlParameter("@HeigthBotao", configuracaoSistema.HeigthBotao);
                command.Parameters.Add(HeigthBotao);

                SqlParameter WeightBotao = new SqlParameter("@WeightBotao", configuracaoSistema.WeightBotao);
                command.Parameters.Add(WeightBotao);

                SqlParameter FontePrincipal = new SqlParameter("@FontePrincipal", configuracaoSistema.FontePrincipal);
                command.Parameters.Add(FontePrincipal);

                SqlParameter FonteTextInput = new SqlParameter("@FonteTextInput", configuracaoSistema.FonteTextInput);
                command.Parameters.Add(FonteTextInput);

                SqlParameter FonteLabel = new SqlParameter("@FonteLabel", configuracaoSistema.FonteLabel);
                command.Parameters.Add(FonteLabel);

                SqlParameter TempoProtege = new SqlParameter("@TempoProtege", configuracaoSistema.TempoProtege);
                command.Parameters.Add(TempoProtege);

                SqlParameter LinhasConsulta = new SqlParameter("@LinhasConsulta", configuracaoSistema.LinhasConsulta);
                command.Parameters.Add(LinhasConsulta);

                SqlParameter NumeroMaximoTentativas = new SqlParameter("@NumeroMaximoTentativas", configuracaoSistema.NumeroMaximoTentativas);
                command.Parameters.Add(NumeroMaximoTentativas);

                //UltimaAtualizacao
                if (configuracaoSistema.UltimaAtualizacao.HasValue)
                {
                    SqlParameter UltimaAtualizacao = new SqlParameter("@UltimaAtualizacao", configuracaoSistema.UltimaAtualizacao.GetValueOrDefault());
                    command.Parameters.Add(UltimaAtualizacao);
                }
                else
                {
                    SqlParameter UltimaAtualizacao = new SqlParameter("@UltimaAtualizacao", DBNull.Value);
                    command.Parameters.Add(UltimaAtualizacao);
                }

                //Pegar o Retorno do Insert
                configuracaoSistema.AutoId = GerenciadorConexaoBanco.GetInstancia(EnumTipoBanco.SqlServer).ExecutarNaoConsulta(command);
            }
            catch (Exception)
            {
                configuracaoSistema = null;
                throw;
            }

            return configuracaoSistema;
        }

        public VSF_ConfiguracaoSistema ObterPorSistema(VSF_Sistema sistema, bool lazy)
        {
            IDbCommand command;
            //IDataReader dataReaderTmp;
            VSF_ConfiguracaoSistema objetoPesquisado = new VSF_ConfiguracaoSistema();

            //Executando a pesquisa
            try
            {
                command = new SqlCommand(@"Select TOP 1
                                            *
                                            From 
                                            VSF_ConfiguracaoSistema where Sistema = @Sistema ORDER BY AutoId Desc");

                SqlParameter parametersistema = new SqlParameter("@Sistema", sistema.AutoId);
                command.Parameters.Add(parametersistema);

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
    }
}