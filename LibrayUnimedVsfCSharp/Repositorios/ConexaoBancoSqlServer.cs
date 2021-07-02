using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Repositorios
{
    public class ConexaoBancoSqlServer : Repositorio, IConexaoBanco     
    {
        #region Atributos

        private string _connectionString = @"Data Source=192.168.0.127;User ID=sa;Password=uni40853vsf!;Initial Catalog=Cardio";
         
        private SqlConnection _connection;
        private SqlDataAdapter _dataAdapter;
        private SqlDataReader _dataReader;

        #endregion

        public ConexaoBancoSqlServer()
        {
            _connection = new SqlConnection(_connectionString);
        }
        
        #region Metodos

        public IDataReader ExecutarConsulta(IDbCommand comando)
        {
            IDataReader dataReader = null;
            try
            {
                comando.Connection = AbrirConexao();
                dataReader = comando.ExecuteReader();
            }
            catch (Exception)
            {
                FecharConexao((SqlConnection)comando.Connection);
                throw;// new Exception("ExecutarConsulta - ConexaoBancoSqlServer");
            }
            return dataReader;
        }

        public IList<TObject> ExecutarConsultaList<TObject>(IDbCommand command,TObject objeto, bool lazy) where TObject : class
        {
            IDataReader dataReader = null;
            IList<TObject> objetosPesquisados = null;
            try
            {
                if (_connection.State == ConnectionState.Open)
                {
                    SqlConnection novaConnection = new SqlConnection(_connectionString);
                    novaConnection.Open();
                    command.Connection = novaConnection;
                }
                else
                {
                    command.Connection = AbrirConexao();
                }

                dataReader = command.ExecuteReader();
                objetosPesquisados = MontarListaObjetosDoReader(dataReader,objeto,lazy);
                if ((dataReader != null) && (!dataReader.IsClosed))
                {
                    dataReader.Close();
                }
                FecharConexao((SqlConnection) command.Connection);
            }
            catch (Exception)
            {
                FecharConexao((SqlConnection)command.Connection);
                throw; //new Exception("ExecutarConsultaList - ConexaoBancoSqlServer");
            }
            return objetosPesquisados;
        }

        public TObject ExecutarConsultaObject<TObject>(ref IDbCommand comando, TObject objeto, bool lazy) where TObject : class
        {
            throw new NotImplementedException();
        }

        public TObject ExecutarConsultaObject<TObject>(IDbCommand command, TObject objeto, bool lazy) where TObject : class
        {
            IDataReader dataReader = null;
            TObject objetoPesquisado = null;
            try
            {
                if(_connection.State == ConnectionState.Open)
                {
                    SqlConnection novaConnection = new SqlConnection(_connectionString);
                    novaConnection.Open();
                    command.Connection = novaConnection;
                }
                else
                {
                    command.Connection = AbrirConexao();    
                }

                dataReader = command.ExecuteReader();
                objetoPesquisado = MontarObjetoDoReader(dataReader, objeto, lazy);
                if ((dataReader != null) && (!dataReader.IsClosed))
                {
                    dataReader.Close();
                }
                FecharConexao((SqlConnection)command.Connection);
            }
            catch (Exception ex)
            {
                FecharConexao((SqlConnection)command.Connection);
                throw;// new Exception("ExecutarConsultaObject - ConexaoBancoSqlServer"+ex.Message);
            }
            return objetoPesquisado;
        }

        public int ExecutarNaoConsulta(IDbCommand command)
        {
            int idRetorno = 0;
            try
            {
                command.Connection =  AbrirConexao();
                //command.Parameters.AddWithValue("@nome", produto.Nome);
                idRetorno = Convert.ToInt32(command.ExecuteScalar());
            }
            catch (Exception)
            {
                FecharConexao((SqlConnection)command.Connection);
                throw;
            }
            finally
            {
               FecharConexao((SqlConnection)command.Connection);
            }

            return idRetorno;
        }

        public SqlConnection AbrirConexao()
        {
            try
            {
                if (_connection.State == ConnectionState.Closed)
                {
                    _connection.Open();
                }
                //else
                //{
                //    _connection.Close();
                //    _connection.Open();
                //}
            }
            catch (Exception ex)
            {
                throw;// new Exception("ExecutarNaoConsulta - ConexaoBancoSqlServer" + ex.Message);
            }
            return _connection;
        }

        public void FecharConexao(SqlConnection conexao)
        {
            try
            {
                if (conexao.State == ConnectionState.Open)
                {
                    conexao.Close();
                }
            }
            catch (Exception)
            {
                throw;// new Exception("FecharConexao - ConexaoBancoSqlServer");
            }
        }
        #endregion
     }
}