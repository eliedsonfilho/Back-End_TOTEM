using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace Repositorios
{
    public class ConexaoBancoMySql : Repositorio, IConexaoBanco
    {
        #region Atributos
        private string _connectionString = "Server=192.168.0.111;" +
                                           "Database=tnumm;" +
                                           "Uid=user.tnumm;" +
                                           "Pwd=tnumm210";

        private MySqlConnection _connection;
        private MySqlDataAdapter _dataAdapter;
        private MySqlDataReader _dataReader;
        #endregion

        public ConexaoBancoMySql()
        {
            _connection = new MySqlConnection(_connectionString);
        }

        #region Metodos
        
        public IDataReader ExecutarConsulta(IDbCommand command)
        {
            IDataReader dataReader = null;
            try
            {
                command.Connection = AbrirConexao();
                dataReader = command.ExecuteReader();
            }
            catch (Exception)
            {
                FecharConexao((MySqlConnection)command.Connection);
                throw;
            }

            return dataReader;
        }

        public int ExecutarNaoConsulta(IDbCommand command)
        {
            int idRetorno = 0;
            try
            {
                command.Connection = AbrirConexao();
                //command.Parameters.AddWithValue("@nome", produto.Nome);
                idRetorno = Convert.ToInt32(command.ExecuteScalar());
            }
            catch (Exception)
            {
                FecharConexao((MySqlConnection)command.Connection);
                throw;
            }
            finally
            {
                FecharConexao((MySqlConnection) command.Connection);
            }

            return idRetorno;
        }

        public IList<TObject> ExecutarConsultaList<TObject>(IDbCommand comando, TObject objeto, bool lazy) where TObject : class
        {
            IDataReader dataReader = null;
            IList<TObject> objetosPesquisados = null;
            try
            {
                if (_connection.State == ConnectionState.Open)
                {
                    MySqlConnection novaConnection = new MySqlConnection(_connectionString);
                    novaConnection.Open();
                    comando.Connection = novaConnection;
                }
                else
                {
                    comando.Connection = AbrirConexao();
                }

                dataReader = comando.ExecuteReader();
                objetosPesquisados = MontarListaObjetosDoReader(dataReader, objeto, lazy);
                if ((dataReader != null) && (!dataReader.IsClosed))
                {
                    dataReader.Close();
                }
                FecharConexao((MySqlConnection)comando.Connection);
            }
            catch (Exception)
            {
                FecharConexao((MySqlConnection)comando.Connection);
                throw;
            }
            return objetosPesquisados;
        }

        public TObject ExecutarConsultaObject<TObject>(ref IDbCommand comando, TObject objeto, bool lazy) where TObject : class
        {
            throw new NotImplementedException();
        }

        public TObject ExecutarConsultaObject<TObject>(IDbCommand comando, TObject objeto, bool lazy) where TObject : class
        {
            IDataReader dataReader = null;
            TObject objetoPesquisado = null;
            try
            {
                if (_connection.State == ConnectionState.Open)
                {
                    MySqlConnection novaConnection = new MySqlConnection(_connectionString);
                    novaConnection.Open();
                    comando.Connection = novaConnection;
                }
                else
                {
                    comando.Connection = AbrirConexao();
                }

                dataReader = comando.ExecuteReader();
                objetoPesquisado = MontarObjetoDoReader(dataReader, objeto, lazy);
                if ((dataReader != null) && (!dataReader.IsClosed))
                {
                    dataReader.Close();
                }
                FecharConexao((MySqlConnection)comando.Connection);
            }
            catch (Exception)
            {
                FecharConexao((MySqlConnection)comando.Connection);
                throw;
            }
            return objetoPesquisado;
        }

        public MySqlConnection AbrirConexao()
        {
            try
            {
                if (_connection.State == ConnectionState.Closed)
                {
                    _connection.Open();
                }
                else
                {
                    _connection.Close();
                    _connection.Open();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return _connection;
        }

        public void FecharConexao(MySqlConnection conexao)
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
                throw;
            }
        }
        #endregion
    }
}