using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Dados;

namespace Repositorios
{
    public class RepositorioPessoa : Repositorio , IRepositorio<Pessoa, int>
    {
        public Pessoa ObterPorId(int autoIdBoleto, bool lazy)
        {
            IDbCommand command;
            //IDataReader dataReaderTmp;
            Pessoa objetoPesquisado = new Pessoa();

            //Executando a pesquisa
            try
            {
                command = new SqlCommand(@"Select 
                                            AutoId,
                                            Nome,
                                            NomeReduzido,
                                            Tipo,
                                            Cnp,
                                            Classe,
                                            DataNascimento,
                                            Sexo,
                                            EstadoCivil,
                                            Escolaridade,
                                            NomePai,
                                            NomeMae,
                                            NomeConjuge,
                                            Nacionalidade,
                                            Naturalidade,
                                            DataFalecimento,
                                            DataFundacao
                                            From 
                                            Pessoa where AutoId = @autoId");

                SqlParameter parameterAutoId = new SqlParameter("@autoId",autoIdBoleto);
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

        public IList<Pessoa> ObterTodos(bool lazy)
        {
            throw new System.NotImplementedException();
        }

        public IList<Pessoa> ObterTodos(Pessoa objectPesquisado, bool lazy)
        {
            throw new System.NotImplementedException();
        }
    }
}