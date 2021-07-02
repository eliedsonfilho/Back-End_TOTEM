using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Dados;

namespace Repositorios
{
    public class RepositorioFeriado : Repositorio, IRepositorio<RepositorioFeriado, DateTime>
    {
        public Feriado ObterPorData(DateTime data, bool lazy)
        {
            IDbCommand command;
            //IDataReader dataReaderTmp;
            Feriado objetoPesquisado = new Feriado();

            //Executando a pesquisa
            try
            {
                command = new SqlCommand(@"Select 
                                            DataFeriado,
                                            Descricao
                                            From Feriado
                                            where DataFeriado = @data");

                SqlParameter parameterData = new SqlParameter("@data", data);
                command.Parameters.Add(parameterData);

                //dataReaderTmp = GerenciadorConexaoBanco.GetInstancia(EnumTipoBanco.SqlServer).ExecutarConsulta(command);
                objetoPesquisado = GerenciadorConexaoBanco.GetInstancia(EnumTipoBanco.SqlServer).ExecutarConsultaObject(command, objetoPesquisado, lazy);
            }
            catch (Exception exception)
            {
                throw;
            }

            return objetoPesquisado;
  
        }


        public RepositorioFeriado ObterPorId(DateTime autoIdBoleto, bool lazy)
        {
            throw new NotImplementedException();
        }

        public IList<RepositorioFeriado> ObterTodos(bool lazy)
        {
            throw new NotImplementedException();
        }

        public IList<RepositorioFeriado> ObterTodos(RepositorioFeriado objectPesquisado, bool lazy)
        {
            throw new NotImplementedException();
        }
    }
}
