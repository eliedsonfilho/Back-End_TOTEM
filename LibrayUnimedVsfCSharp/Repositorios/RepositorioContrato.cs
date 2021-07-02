using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Dados;

namespace Repositorios
{
    public class RepositorioContrato : Repositorio , IRepositorio<Contrato, int>
    {
        public Contrato ObterPorId(int autoIdBoleto, bool lazy)
        {
            IDbCommand command;
            //IDataReader dataReaderTmp;
            Contrato objetoPesquisado = new Contrato();

            //Executando a pesquisa
            try
            {
                command = new SqlCommand(@"Select 
                                            AutoId,
                                            Codigo,
                                            Contratante,
                                            DataProposta,
                                            DataEnvio,
                                            DataAssinatura,
                                            DataParecer,
                                            InicioVigencia,
                                            ContratoFinanceiro
                                            From 
                                            Contrato where AutoId = @autoId");

                SqlParameter parameterAutoId = new SqlParameter("@autoId", autoIdBoleto);
                command.Parameters.Add(parameterAutoId);

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

        public IList<Contrato> ObterTodos(bool lazy)
        {
            throw new System.NotImplementedException();
        }

        public IList<Contrato> ObterTodos(Contrato objectPesquisado, bool lazy)
        {
            throw new System.NotImplementedException();
        }
    }
}