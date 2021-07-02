using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Dados;

namespace Repositorios
{
    public class RepositorioArquivo : Repositorio, IRepositorio<Arquivo, int>
    {
        public Arquivo ObterPorId(int autoIdBoleto, bool lazy)
        {
            IDbCommand command;
            //IDataReader dataReaderTmp;
            Arquivo objetoPesquisado = new Arquivo();

            //Executando a pesquisa
            try
            {
                command = new SqlCommand(@"Select 
                                            *
                                            From 
                                            Arquivo where autoId = @autoId");

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

        public IList<Arquivo> ObterTodos(bool lazy)
        {
            //IDataReader dataReaderTmp;
            IList<Arquivo> listaObjetosPesquisados = null;
            Arquivo objetoPesquisado = new Arquivo();
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
                    command = new SqlCommand(@"Select TOP " + qtdRegistro.ToString() + " * From Arquivo WHERE ");
                }
                else
                {
                    command = new SqlCommand(@"Select TOP " + qtdRegistro.ToString() + " * From Arquivo");

                }

                //Concatena a string
                command.CommandText += filtros.ToString();

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

            //Tratando   o Retorno 
            //listaObjetosPesquisados = MontarListaObjetosDoReader(dataReaderTmp, objetoPesquisado, lazy);
            

            return listaObjetosPesquisados;
        }

        public IList<Arquivo> ObterTodos(Arquivo objetoPesquisado, bool lazy)
        {
            //IDataReader dataReaderTmp;
            IList<Arquivo> listaObjetosPesquisados = null;
            IDbCommand command = null;
            int qtdRegistro = 100;
            StringBuilder filtros;
            bool where = false;
            //Montar o Comando
            if (objetoPesquisado != null)
            {
                filtros = new StringBuilder();


                /*Filtros 
                if (objetoPesquisado.Propiedade != null)
                {
                    filtros.Append("Propiedade = " + objetoPesquisado.Propiedade.ToString());
                    where = true;
                }
                 */


                //Se foi passado algun filtro
                if (where)
                {
                    command = new SqlCommand(@"Select TOP " + qtdRegistro.ToString() + " * From Arquivo WHERE ");
                }
                else
                {
                    command = new SqlCommand(@"Select TOP " + qtdRegistro.ToString() + " * From Arquivo");

                }

                //Concatena a string
                command.CommandText += filtros.ToString();

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

            //Tratando   o Retorno 
            //listaObjetosPesquisados = MontarListaObjetosDoReader(dataReaderTmp, objetoPesquisado, lazy);

            return listaObjetosPesquisados;
        }
        
        public Arquivo Inserir(Arquivo ObjetoInserido)
        {
            IDbCommand command;

            //Executando a Insert
            try
            {
                command = new SqlCommand(@"INSERT INTO [dbo].[Arquivo]
				       ([NomeArquivoServidor]
                        ,[Descricao]
                        ,[ChavePai]
                        ,[NomePai]
                        )
				 VALUES
				       (@NomeArquivoServidor
				       ,@Descricao
                       ,@ChavePai
                       ,@NomePai
                        )
					SELECT SCOPE_IDENTITY()");//Essa Linha Retorna O ID do Objeto Inserido

                SqlParameter NomeArquivoServidor = new SqlParameter("@NomeArquivoServidor", ObjetoInserido.NomeArquivoServidor);
                command.Parameters.Add(NomeArquivoServidor);

                SqlParameter Descricao = new SqlParameter("@Descricao", ObjetoInserido.Descricao);
                command.Parameters.Add(Descricao);

                SqlParameter ChavePai = new SqlParameter("@ChavePai", ObjetoInserido.ChavePai);
                command.Parameters.Add(ChavePai);

                SqlParameter NomePai = new SqlParameter("@NomePai", ObjetoInserido.NomePai);
                command.Parameters.Add(NomePai);

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

        public Arquivo Atualizar(Arquivo ObjetoInserido)
        {
            IDbCommand command;

            //Executando a Insert
            try
            {
                command = new SqlCommand(@"UPDATE [dbo].[Arquivo]
					   SET [NomeArquivoServidor] = @NomeArquivoServidor
					      ,[Descricao] = @Descricao
                          ,[ChavePai] = @ChavePai
                          ,[NomePai] = @NomePai
					 WHERE AutoId = @AutoId;
					 SELECT SCOPE_IDENTITY()");//Essa Linha Retorna O ID do Objeto Inserido

                SqlParameter AutoId = new SqlParameter("@AutoId", ObjetoInserido.AutoId);
                command.Parameters.Add(AutoId);

                SqlParameter NomeArquivoServidor = new SqlParameter("@NomeArquivoServidor", ObjetoInserido.NomeArquivoServidor);
                command.Parameters.Add(NomeArquivoServidor);

                SqlParameter Descricao = new SqlParameter("@Descricao", ObjetoInserido.Descricao);
                command.Parameters.Add(Descricao);

                SqlParameter ChavePai = new SqlParameter("@ChavePai", ObjetoInserido.ChavePai);
                command.Parameters.Add(ChavePai);

                SqlParameter NomePai = new SqlParameter("@NomePai", ObjetoInserido.NomePai);
                command.Parameters.Add(NomePai);

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