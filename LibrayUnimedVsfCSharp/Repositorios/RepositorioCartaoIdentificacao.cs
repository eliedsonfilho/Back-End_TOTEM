using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Dados;

namespace Repositorios
{
    public class RepositorioCartaoIdentificacao : Repositorio, IRepositorio<CartaoIdentificacao, int>
    {
        public CartaoIdentificacao ObterPorId(int autoIdBoleto, bool lazy)
        {
            IDbCommand command;
            ////IDataReader dataReaderTmp;
            CartaoIdentificacao objetoPesquisado = new CartaoIdentificacao();

            //Executando a pesquisa
            try
            {
                command = new SqlCommand(@"Select 
                                            *
                                            From 
                                            CartaoIdentificacao where autoId = @autoId");

                SqlParameter parameterautoId = new SqlParameter("@autoId", autoIdBoleto);
                command.Parameters.Add(parameterautoId);

                ////dataReaderTmp = GerenciadorConexaoBanco.GetInstancia(EnumTipoBanco.SqlServer).ExecutarConsulta(command);
                objetoPesquisado = GerenciadorConexaoBanco.GetInstancia(EnumTipoBanco.SqlServer).ExecutarConsultaObject(command,objetoPesquisado,lazy);
            }
            catch (Exception)
            {
                throw;
            }

            //Tratando o Retorno 
            
            ////objetoPesquisado = MontarObjetoDoReader(dataReaderTmp, objetoPesquisado, lazy);
            

            return objetoPesquisado;
        }

        public IList<CartaoIdentificacao> ObterTodos(bool lazy)
        {
            IList<CartaoIdentificacao> listaObjetosPesquisados = null;
            CartaoIdentificacao objetoPesquisado = new CartaoIdentificacao();
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
                                           CartaoIdentificacao");
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
                ////dataReaderTmp = GerenciadorConexaoBanco.GetInstancia(EnumTipoBanco.SqlServer).ExecutarConsulta(command);
                listaObjetosPesquisados = GerenciadorConexaoBanco.GetInstancia(EnumTipoBanco.SqlServer).ExecutarConsultaList(command, objetoPesquisado, lazy);
            }
            catch (Exception)
            {
                throw;
            }

            //Tratando   o Retorno 
            ////listaObjetosPesquisados = MontarListaObjetosDoReader(dataReaderTmp, objetoPesquisado, lazy);

            return listaObjetosPesquisados;
        }

        public IList<CartaoIdentificacao> ObterTodos(CartaoIdentificacao objetoPesquisado, bool lazy)
        {
            IList<CartaoIdentificacao> listaObjetosPesquisados = null;
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
                                           CartaoIdentificacao");
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
                listaObjetosPesquisados = GerenciadorConexaoBanco.GetInstancia(EnumTipoBanco.SqlServer).ExecutarConsultaList(command,objetoPesquisado,lazy);
            }
            catch (Exception)
            {
                throw;
            }

            //Tratando   o Retorno 
            ////listaObjetosPesquisados = MontarListaObjetosDoReader(dataReaderTmp, objetoPesquisado, lazy);

            return listaObjetosPesquisados;
        }

        public CartaoIdentificacao ObterPorCodigo(string codigo, bool lazy)
        {
            IDbCommand command;
            //IDataReader dataReaderTmp;
            IList<CartaoIdentificacao> listaObjetosPesquisados = null;
            CartaoIdentificacao objetoPesquisado = new CartaoIdentificacao();

            //Executando a pesquisa
            try
            {
                command = new SqlCommand(@"Select top 1
                                            *
                                            From 
                                            CartaoIdentificacao where Codigo = @Codigo order By AutoId desc");

                SqlParameter parameterCodigo = new SqlParameter("@Codigo", codigo);
                command.Parameters.Add(parameterCodigo);

                ////dataReaderTmp = GerenciadorConexaoBanco.GetInstancia(EnumTipoBanco.SqlServer).ExecutarConsulta(command);

                objetoPesquisado =
                GerenciadorConexaoBanco.GetInstancia(EnumTipoBanco.SqlServer).ExecutarConsultaObject(command, objetoPesquisado,
                                                                                               lazy);
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