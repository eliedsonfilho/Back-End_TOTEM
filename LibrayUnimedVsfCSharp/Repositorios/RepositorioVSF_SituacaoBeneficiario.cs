using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Dados;

namespace Repositorios
{
    public class RepositorioVSF_SituacaoBeneficiario : Repositorio, IRepositorio<VSF_SituacaoBeneficiario, int>
    {
        public VSF_SituacaoBeneficiario ObterPorId(int autoIdBoleto, bool lazy)
        {
            IDbCommand comando;
            //IDataReader dataReaderTmp;
            VSF_SituacaoBeneficiario objetoPesquisado = new VSF_SituacaoBeneficiario();

            //Executando a pesquisa
            try
            {
                comando = new SqlCommand(@"SELECT 
                                                AutoId_Ben AutoId, 
                                                Situacao,
                                                CASE Situacao 
                                                    WHEN 'A' THEN 'True' 
                                                    WHEN 'I' THEN 'False' End Ativo
                                                FROM  VSF_Situacao_Benef
                                                WHERE AutoId_Ben = @autoId");

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

        public IList<VSF_SituacaoBeneficiario> ObterTodos(bool lazy)
        {
            throw new NotImplementedException();
        }

        public IList<VSF_SituacaoBeneficiario> ObterTodos(VSF_SituacaoBeneficiario objectPesquisado, bool lazy)
        {
            throw new NotImplementedException();
        }
    }
}
