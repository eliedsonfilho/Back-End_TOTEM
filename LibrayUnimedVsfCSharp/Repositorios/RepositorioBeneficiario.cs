using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Dados;

namespace Repositorios
{
    public class RepositorioBeneficiario: Repositorio, IRepositorio<Beneficiario,int>
    {
        public Beneficiario ObterPorId(int autoIdBoleto, bool lazy)
        {
            IDbCommand comando;
            //IDataReader dataReaderTmp;
            Beneficiario objetoPesquisado = new Beneficiario();

            //Executando a pesquisa
            try
            {
                comando = new SqlCommand(@"Select 
                                            AutoId,
                                            Pessoa,
                                            Contrato,
                                            RDP,
                                            Familia,
                                            Codigo,
                                            Tipo,
                                            Titular,
                                            InicioVigencia,
                                            DataBaseCalc,
                                            DataInicioContribuicao,
                                            DataAposentadoDemitido,
                                            SituacaoBeneficiario,
                                            Matricula,
                                            DataAdmissao,
                                            GrauDependencia,
                                            BenefTemporario
                                            From 
                                            Beneficiario where AutoId = @autoId");

                SqlParameter parameterAutoId = new SqlParameter("@autoId", autoIdBoleto);
                comando.Parameters.Add(parameterAutoId);

                //dataReaderTmp = GerenciadorConexaoBanco.GetInstancia(EnumTipoBanco.SqlServer).ExecutarConsulta(command);
                objetoPesquisado = GerenciadorConexaoBanco.GetInstancia(EnumTipoBanco.SqlServer).ExecutarConsultaObject(comando, objetoPesquisado, lazy);
            }
            catch (Exception)
            {
                throw;
            }

            //Tratando o Retorno 
            
            //objetoPesquisado = MontarObjetoDoReader(dataReaderTmp, objetoPesquisado, lazy);
            
            
            return objetoPesquisado;
        }

        public IList<Beneficiario> ObterTodos(bool lazy)
        {
            IDbCommand command;
            //IDataReader dataReaderTmp;
            IList<Beneficiario> listaObjetosPesquisados = null;

            //Executando a pesquisa
            try
            {
                command = new SqlCommand(@"Select top 1
                                            AutoId,
                                            Pessoa,
                                            Contrato,
                                            RDP,
                                            Familia,
                                            Codigo,
                                            Tipo,
                                            Titular,
                                            InicioVigencia,
                                            DataBaseCalc,
                                            DataInicioContribuicao,
                                            DataAposentadoDemitido,
                                            SituacaoBeneficiario,
                                            Matricula,
                                            DataAdmissao,
                                            GrauDependencia,
                                            BenefTemporario
                                            From 
                                            Beneficiario");
                //dataReaderTmp = GerenciadorConexaoBanco.GetInstancia(EnumTipoBanco.SqlServer).ExecutarConsulta(command);
                Beneficiario beneficiario = new Beneficiario();
                listaObjetosPesquisados = GerenciadorConexaoBanco.GetInstancia(EnumTipoBanco.SqlServer).ExecutarConsultaList(command, beneficiario, lazy);
            }
            catch (Exception)
            {
                throw;
            }

            //Tratando o Retorno 
            //objetosPesquisados = MontarListaObjetosDoReader(dataReaderTmp, beneficiario, lazy);

            return listaObjetosPesquisados;
        }

        public IList<Beneficiario> ObterTodos(Beneficiario objetoPesquisado, bool lazy)
        {
            //IDataReader dataReaderTmp;
            IList<Beneficiario> listaObjetosPesquisados = null;

            IDbCommand command = null;
            int qtdRegistro = 100;
            StringBuilder query;
            bool where = false;
            //Montar o Comando
            if (objetoPesquisado != null)
            {
                query = new StringBuilder();

                command = new SqlCommand(@"Select                                    
                                    
                                    From 
                                    Medicamento");
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
                //dataReaderTmp = GerenciadorConexaoBanco.GetInstancia(EnumTipoBanco.MySql).ExecutarConsulta(command);
                listaObjetosPesquisados = GerenciadorConexaoBanco.GetInstancia(EnumTipoBanco.SqlServer).ExecutarConsultaList(command, objetoPesquisado, lazy);

            }
            catch (Exception)
            {
                throw;
            }

            //Tratando   o Retorno 
            //listaObjetosPesquisados = MontarListaObjetosDoReader(dataReaderTmp, objectPesquisado, lazy);
            

            return listaObjetosPesquisados;
        }
    
    }
}