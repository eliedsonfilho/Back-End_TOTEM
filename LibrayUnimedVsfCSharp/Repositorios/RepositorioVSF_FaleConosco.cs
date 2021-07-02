using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Dados;

namespace Repositorios
{
    public class RepositorioVSF_FaleConosco : Repositorio, IRepositorio<VSF_FaleConosco, int>
    {
        public VSF_FaleConosco ObterPorId(int autoIdBoleto, bool lazy)
        {
            IDbCommand command;
            //IDataReader dataReaderTmp;
            VSF_FaleConosco objetoPesquisado = new VSF_FaleConosco();

            //Executando a pesquisa
            try
            {
                command = new SqlCommand(@"Select 
                                            *
                                            From 
                                            VSF_FaleConosco where AutoId = @colunaChave");

                SqlParameter parametercolunaChave = new SqlParameter("@colunaChave", autoIdBoleto);
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

        public IList<VSF_FaleConosco> ObterTodos(bool lazy)
        {
            //IDataReader dataReaderTmp;
            IList<VSF_FaleConosco> listaObjetosPesquisados = null;
            VSF_FaleConosco objetoPesquisado = new VSF_FaleConosco();
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
                    command = new SqlCommand(@"Select TOP " + qtdRegistro.ToString() + " * From VSF_FaleConosco WHERE ");
                }
                else
                {
                    command = new SqlCommand(@"Select TOP " + qtdRegistro.ToString() + " * From VSF_FaleConosco");

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

        public IList<VSF_FaleConosco> ObterTodos(VSF_FaleConosco objetoPesquisado, bool lazy)
        {
            //IDataReader dataReaderTmp;
            IList<VSF_FaleConosco> listaObjetosPesquisados = null;
            IDbCommand command = null;
            int qtdRegistro = 100;
            StringBuilder filtros;
            bool where = false;
            //Montar o Comando
            if (objetoPesquisado != null)
            {
                filtros = new StringBuilder();



                //Se foi passado algun filtro
                if (where)
                {
                    command = new SqlCommand(@"Select TOP " + qtdRegistro.ToString() + " * From VSF_FaleConosco WHERE ");
                }
                else
                {
                    command = new SqlCommand(@"Select TOP " + qtdRegistro.ToString() + " * From VSF_FaleConosco");

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
        
        public VSF_FaleConosco Inserir(VSF_FaleConosco ObjetoInserido)
        {
            IDbCommand command;

            //Executando a Insert
            try
            {
                command = new SqlCommand(@"INSERT INTO [dbo].[VSF_FaleConosco]
                                                           ([CodigoMensagem]
                                                           ,[Nome]
                                                           ,[CodigoBeneficiario]
                                                           ,[Email]
                                                           ,[RespostaEmail]
                                                           ,[NoticiaEmail]
                                                           ,[Telefone]
                                                           ,[RespostaTelefone]
                                                           ,[NoticiaTelefone]
                                                           ,[Motivo]
                                                           ,[Assunto]
                                                           ,[Mensagem]
                                                           ,[DataMensagem]
                                                           ,[DataEmissao]
                                                           ,[UsuarioEmissao])
                                                     VALUES
                                                           (@CodigoMensagem
                                                           ,@Nome
                                                           ,@CodigoBeneficiario
                                                           ,@Email
                                                           ,@RespostaEmail
                                                           ,@NoticiaEmail
                                                           ,@Telefone
                                                           ,@RespostaTelefone
                                                           ,@NoticiaTelefone
                                                           ,@Motivo
                                                           ,@Assunto
                                                           ,@Mensagem
                                                           ,GetDate()
                                                           ,NULL
                                                           ,NULL)
					                                        SELECT SCOPE_IDENTITY()");//Essa Linha Retorna O ID do Objeto Inserido

                SqlParameter parCodigoMensagem = new SqlParameter("@CodigoMensagem", ObjetoInserido.CodigoMensagem);
                command.Parameters.Add(parCodigoMensagem);

                //Nome
                if (!String.IsNullOrEmpty(ObjetoInserido.Nome))
                {
                    SqlParameter parNome = new SqlParameter("@Nome", ObjetoInserido.Nome);
                    command.Parameters.Add(parNome);
                }
                else
                {
                    SqlParameter parNome = new SqlParameter("@Nome", DBNull.Value);
                    command.Parameters.Add(parNome);
                }

                //CodigoBeneficiario
                if (!String.IsNullOrEmpty(ObjetoInserido.CodigoBeneficiario))
                {
                    SqlParameter parCodigoBeneficiario = new SqlParameter("@CodigoBeneficiario", ObjetoInserido.CodigoBeneficiario);
                    command.Parameters.Add(parCodigoBeneficiario);
                }
                else
                {
                    SqlParameter parCodigoBeneficiario = new SqlParameter("@CodigoBeneficiario", DBNull.Value);
                    command.Parameters.Add(parCodigoBeneficiario);
                }

                //Email
                if (!String.IsNullOrEmpty(ObjetoInserido.Email))
                {
                    SqlParameter parEmail = new SqlParameter("@Email", ObjetoInserido.Email);
                    command.Parameters.Add(parEmail);
                }
                else
                {
                    SqlParameter parEmail = new SqlParameter("@Email", DBNull.Value);
                    command.Parameters.Add(parEmail);
                }

                //RespostaEmail
                SqlParameter parRespostaEmail = new SqlParameter("@RespostaEmail", ObjetoInserido.RespostaEmail);
                command.Parameters.Add(parRespostaEmail);

                //NoticiaEmail
                SqlParameter parNoticiaEmail = new SqlParameter("@NoticiaEmail", ObjetoInserido.NoticiaEmail);
                command.Parameters.Add(parNoticiaEmail);

                //Telefone
                if (!String.IsNullOrEmpty(ObjetoInserido.Telefone))
                {
                    SqlParameter parTelefone = new SqlParameter("@Telefone", ObjetoInserido.Telefone);
                    command.Parameters.Add(parTelefone);
                }
                else
                {
                    SqlParameter parTelefone = new SqlParameter("@Telefone", DBNull.Value);
                    command.Parameters.Add(parTelefone);
                }

                //RespostaTelefone
                SqlParameter parRespostaTelefone = new SqlParameter("@RespostaTelefone", ObjetoInserido.RespostaTelefone);
                command.Parameters.Add(parRespostaTelefone);

                //NoticiaTelefone
                SqlParameter parNoticiaTelefone = new SqlParameter("@NoticiaTelefone", ObjetoInserido.NoticiaTelefone);
                command.Parameters.Add(parNoticiaTelefone);

                //Motivo
                if (!String.IsNullOrEmpty(ObjetoInserido.Motivo))
                {
                    SqlParameter parMotivo = new SqlParameter("@Motivo", ObjetoInserido.Motivo);
                    command.Parameters.Add(parMotivo);
                }
                else
                {
                    SqlParameter parMotivo = new SqlParameter("@Motivo", DBNull.Value);
                    command.Parameters.Add(parMotivo);
                }

                //Assunto
                if (!String.IsNullOrEmpty(ObjetoInserido.Assunto))
                {
                    SqlParameter parAssunto = new SqlParameter("@Assunto", ObjetoInserido.Assunto);
                    command.Parameters.Add(parAssunto);
                }
                else
                {
                    SqlParameter parAssunto = new SqlParameter("@Assunto", DBNull.Value);
                    command.Parameters.Add(parAssunto);
                }

                //Mensagem
                if (!String.IsNullOrEmpty(ObjetoInserido.Mensagem))
                {
                    SqlParameter parMensagem = new SqlParameter("@Mensagem", ObjetoInserido.Mensagem);
                    command.Parameters.Add(parMensagem);
                }
                else
                {
                    SqlParameter parMensagem = new SqlParameter("@Mensagem", DBNull.Value);
                    command.Parameters.Add(parMensagem);
                }

                //Pegar o Retorno do Insert
                ObjetoInserido.AutoId = GerenciadorConexaoBanco.GetInstancia(EnumTipoBanco.SqlServer).ExecutarNaoConsulta(command);
            }
            catch (Exception)
            {
                ObjetoInserido = null;
                throw;
            }

            return ObjetoInserido;
        }

        public VSF_FaleConosco Atualizar(VSF_FaleConosco ObjetoInserido)
        {
            IDbCommand command;

            //Executando a Insert
            try
            {
                command = new SqlCommand(@"UPDATE [dbo].[VSF_FaleConosco]
                                               SET [CodigoMensagem] = @CodigoMensagem
                                                  ,[Nome] = @Nome
                                                  ,[CodigoBeneficiario] = @CodigoBeneficiario
                                                  ,[Email] = @Email
                                                  ,[RespostaEmail] = @RespostaEmail
                                                  ,[NoticiaEmail] = @NoticiaEmail
                                                  ,[Telefone] = @Telefone
                                                  ,[RespostaTelefone] = @RespostaTelefone
                                                  ,[NoticiaTelefone] = @NoticiaTelefone
                                                  ,[Motivo] = @Motivo
                                                  ,[Assunto] = @Assunto
                                                  ,[Mensagem] = @Mensagem
                                                  ,[DataMensagem] = @DataMensagem
                                                  ,[DataEmissao] = GetDate()
                                                  ,[UsuarioEmissao] = @UsuarioEmissao
                                                  WHERE AutoId = @AutoId");                            

                SqlParameter AutoId = new SqlParameter("@AutoId", ObjetoInserido.AutoId);
                command.Parameters.Add(AutoId);

                SqlParameter parCodigoMensagem = new SqlParameter("@CodigoMensagem", ObjetoInserido.CodigoMensagem);
                command.Parameters.Add(parCodigoMensagem);

                //Nome
                if (!String.IsNullOrEmpty(ObjetoInserido.Nome))
                {
                    SqlParameter parNome = new SqlParameter("@Nome", ObjetoInserido.Nome);
                    command.Parameters.Add(parNome);
                }
                else
                {
                    SqlParameter parNome = new SqlParameter("@Nome", DBNull.Value);
                    command.Parameters.Add(parNome);
                }

                //CodigoBeneficiario
                if (!String.IsNullOrEmpty(ObjetoInserido.CodigoBeneficiario))
                {
                    SqlParameter parCodigoBeneficiario = new SqlParameter("@CodigoBeneficiario", ObjetoInserido.CodigoBeneficiario);
                    command.Parameters.Add(parCodigoBeneficiario);
                }
                else
                {
                    SqlParameter parCodigoBeneficiario = new SqlParameter("@CodigoBeneficiario", DBNull.Value);
                    command.Parameters.Add(parCodigoBeneficiario);
                }

                //Email
                if (!String.IsNullOrEmpty(ObjetoInserido.Email))
                {
                    SqlParameter parEmail = new SqlParameter("@Email", ObjetoInserido.Email);
                    command.Parameters.Add(parEmail);
                }
                else
                {
                    SqlParameter parEmail = new SqlParameter("@Email", DBNull.Value);
                    command.Parameters.Add(parEmail);
                }

                //RespostaEmail
                SqlParameter parRespostaEmail = new SqlParameter("@RespostaEmail", ObjetoInserido.RespostaEmail);
                command.Parameters.Add(parRespostaEmail);

                //NoticiaEmail
                SqlParameter parNoticiaEmail = new SqlParameter("@NoticiaEmail", ObjetoInserido.NoticiaEmail);
                command.Parameters.Add(parNoticiaEmail);

                //Telefone
                if (!String.IsNullOrEmpty(ObjetoInserido.Telefone))
                {
                    SqlParameter parTelefone = new SqlParameter("@Telefone", ObjetoInserido.Telefone);
                    command.Parameters.Add(parTelefone);
                }
                else
                {
                    SqlParameter parTelefone = new SqlParameter("@Telefone", DBNull.Value);
                    command.Parameters.Add(parTelefone);
                }

                //RespostaTelefone
                SqlParameter parRespostaTelefone = new SqlParameter("@RespostaTelefone", ObjetoInserido.RespostaTelefone);
                command.Parameters.Add(parRespostaTelefone);

                //NoticiaTelefone
                SqlParameter parNoticiaTelefone = new SqlParameter("@NoticiaTelefone", ObjetoInserido.NoticiaTelefone);
                command.Parameters.Add(parNoticiaTelefone);

                //Motivo
                if (!String.IsNullOrEmpty(ObjetoInserido.Motivo))
                {
                    SqlParameter parMotivo = new SqlParameter("@Motivo", ObjetoInserido.Motivo);
                    command.Parameters.Add(parMotivo);
                }
                else
                {
                    SqlParameter parMotivo = new SqlParameter("@Motivo", DBNull.Value);
                    command.Parameters.Add(parMotivo);
                }

                //Assunto
                if (!String.IsNullOrEmpty(ObjetoInserido.Assunto))
                {
                    SqlParameter parAssunto = new SqlParameter("@Assunto", ObjetoInserido.Assunto);
                    command.Parameters.Add(parAssunto);
                }
                else
                {
                    SqlParameter parAssunto = new SqlParameter("@Assunto", DBNull.Value);
                    command.Parameters.Add(parAssunto);
                }

                //Mensagem
                if (!String.IsNullOrEmpty(ObjetoInserido.Mensagem))
                {
                    SqlParameter parMensagem = new SqlParameter("@Mensagem", ObjetoInserido.Mensagem);
                    command.Parameters.Add(parMensagem);
                }
                else
                {
                    SqlParameter parMensagem = new SqlParameter("@Mensagem", DBNull.Value);
                    command.Parameters.Add(parMensagem);
                }

                //DataEmissao
                SqlParameter parDataEmissao = new SqlParameter("@DataMensagem", ObjetoInserido.DataMensagem);
                command.Parameters.Add(parDataEmissao);
               
                //UsuarioEmissao
                if (!String.IsNullOrEmpty(ObjetoInserido.UsuarioEmissao))
                {
                    SqlParameter parUsuarioEmissao = new SqlParameter("@UsuarioEmissao", ObjetoInserido.UsuarioEmissao);
                    command.Parameters.Add(parUsuarioEmissao);
                }
                else
                {
                    SqlParameter parUsuarioEmissao = new SqlParameter("@UsuarioEmissao", DBNull.Value);
                    command.Parameters.Add(parUsuarioEmissao);
                }

                //Pegar o Retorno do Insert
                ObjetoInserido.AutoId = GerenciadorConexaoBanco.GetInstancia(EnumTipoBanco.SqlServer).ExecutarNaoConsulta(command);
            }
            catch (Exception)
            {
                ObjetoInserido = null;
                throw;
            }

            return ObjetoInserido;
        }
    }
}