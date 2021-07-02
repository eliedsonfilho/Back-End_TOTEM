using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Dados;

namespace Repositorios
{
    public class RepositorioMotivoBloqueioCartao : Repositorio, IRepositorio<MotivoBloqueioCartao, int>
    {
        public MotivoBloqueioCartao ObterPorId(int autoIdBoleto, bool lazy)
        {
            IDbCommand command;
            //IDataReader dataReaderTmp;
            MotivoBloqueioCartao objetoPesquisado = new MotivoBloqueioCartao();

            //Executando a pesquisa
            try
            {
                command = new SqlCommand(@"Select 
                                            *
                                            From 
                                            MotivoBloqueioCartao where codigo = @codigo");

                SqlParameter parametercodigo = new SqlParameter("@codigo", autoIdBoleto);
                command.Parameters.Add(parametercodigo);

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

        public IList<MotivoBloqueioCartao> ObterTodos(bool lazy)
        {
            //IDataReader dataReaderTmp;
            IList<MotivoBloqueioCartao> listaObjetosPesquisados = null;
            MotivoBloqueioCartao objetoPesquisado = new MotivoBloqueioCartao();
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
                                           MotivoBloqueioCartao");
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

        public IList<MotivoBloqueioCartao> ObterTodos(MotivoBloqueioCartao objetoPesquisado, bool lazy)
        {
            //IDataReader dataReaderTmp;
            IList<MotivoBloqueioCartao> listaObjetosPesquisados = null;
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
                                           MotivoBloqueioCartao");
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

    }
}