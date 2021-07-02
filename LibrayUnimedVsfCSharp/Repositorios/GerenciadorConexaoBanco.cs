using System;
using System.Collections.Generic;
using System.Data;
using Dados;
using MySql.Data.MySqlClient;

namespace Repositorios
{
    public static class GerenciadorConexaoBanco //: IConexaoBanco
    {
        private static IConexaoBanco _conexaoBanco; 

        //private GerenciadorConexaoBanco(EnumTipoBanco enumTipoBanco)
        //{
        //    switch(enumTipoBanco)
        //    {
        //        case EnumTipoBanco.MySql:
        //            {
        //                _conexaoBanco = new ConexaoBancoMySql();
        //                break;
        //            }

        //        case EnumTipoBanco.SqlServer:
        //            {
        //                _conexaoBanco = new ConexaoBancoSqlServer();
        //                break;
        //            }
        //    }
            
        //}

        #region GetInstancia

        //public static GerenciadorConexaoBanco GetInstancia(EnumTipoBanco enumTipoBanco)
        //{
        //    return Nested.SessionManager(enumTipoBanco);
        //}
        
        public static IConexaoBanco GetInstancia(EnumTipoBanco enumTipoBanco)
        {
            return Nested.SessionManager(enumTipoBanco);
        }

        #endregion

        #region Nested

        private class Nested
        {
            static Nested()
            {
            }

            //internal static GerenciadorConexaoBanco SessionManager(EnumTipoBanco enumTipoBanco)
            //{
            //   return new GerenciadorConexaoBanco(enumTipoBanco);
            //}

            internal static IConexaoBanco SessionManager(EnumTipoBanco enumTipoBanco)
            {

                switch (enumTipoBanco)
                {
                    case EnumTipoBanco.MySql:
                        {
                            if ((_conexaoBanco == null) || (_conexaoBanco.GetType() != typeof(ConexaoBancoMySql)))
                            {
                                _conexaoBanco = new ConexaoBancoMySql();    
                            }
                            break;
                        }

                    case EnumTipoBanco.SqlServer:
                        {
                            if ((_conexaoBanco == null) || (_conexaoBanco.GetType() != typeof(ConexaoBancoSqlServer)))
                            {
                                _conexaoBanco = new ConexaoBancoSqlServer();
                            }
                            break;
                        }
                }
                return _conexaoBanco;
            }
        }

        #endregion
/*
        public object Conexao
        {
            get
            {
                return _conexaoBanco;
            }
        }

        
        public IDataReader ExecutarConsulta(IDbCommand comando)
        {
            return _conexaoBanco.ExecutarConsulta(comando);
        }

        public IList<TObject> ExecutarConsultaList<TObject>(IDbCommand comando, TObject objeto, bool lazy) where TObject : class
        {
            return _conexaoBanco.ExecutarConsultaList(comando,objeto,lazy);
        }

        public TObject ExecutarConsultaObject<TObject>(IDbCommand comando, TObject objeto, bool lazy) where TObject : class
        {
            return _conexaoBanco.ExecutarConsultaObject(comando, objeto, lazy);
        }

        public int ExecutarNaoConsulta(IDbCommand comando)
        {
            return _conexaoBanco.ExecutarNaoConsulta(comando);
        }
         */
    }
}