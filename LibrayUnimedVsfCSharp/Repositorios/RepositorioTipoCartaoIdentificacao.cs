using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Dados;

namespace Repositorios
{
    public class RepositorioTipoCartaoIdentificacao : Repositorio, IRepositorio<TipoCartaoIdentificacao, int>
    {
        public TipoCartaoIdentificacao ObterPorId(int autoIdBoleto, bool lazy)
        {
            IDbCommand command;
            //IDataReader dataReaderTmp;
            TipoCartaoIdentificacao objetoPesquisado = new TipoCartaoIdentificacao();

            //Executando a pesquisa
            try
            {
                command = new SqlCommand(@"Select 
                                            *
                                            From 
                                            TipoCartaoIdentificacao where codigo = @codigo");

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

        public IList<TipoCartaoIdentificacao> ObterTodos(bool lazy)
        {
            //IDataReader dataReaderTmp;
            IList<TipoCartaoIdentificacao> listaObjetosPesquisados = null;
            TipoCartaoIdentificacao objetoPesquisado = new TipoCartaoIdentificacao();
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
                                           TipoCartaoIdentificacao");
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

        public IList<TipoCartaoIdentificacao> ObterTodos(TipoCartaoIdentificacao objetoPesquisado, bool lazy)
        {
            //IDataReader dataReaderTmp;
            IList<TipoCartaoIdentificacao> listaObjetosPesquisados = null;
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
                                           TipoCartaoIdentificacao");
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