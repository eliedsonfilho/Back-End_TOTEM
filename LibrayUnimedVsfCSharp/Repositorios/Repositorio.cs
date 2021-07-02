using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;
using System.Reflection;

namespace Repositorios
{
    public class Repositorio
    {
        internal IList<TObject> MontarListaObjetosDoReader<TObject>(IDataReader dataReader, TObject objeto, bool lazy) where TObject : class
        {
            IList<TObject> objetosPesquisados = null;
            IDataReader dataReaderTmp = dataReader;
            
            try
            {
                if ((dataReader != null)&&(objeto !=null)&& (DataReaderHasHows(dataReader)))
                {
                    //Instancia a Lista
                    objetosPesquisados = new List<TObject>();
                    //Lê o reader e coloca na lista
                    while (dataReader.Read())
                    {
                        //Coloca na Lista
                        objetosPesquisados.Add(MontarObjetoDoReaderSemRead(dataReaderTmp, objeto, lazy));
                    }
                }
            }
            catch (Exception)
            {
                throw;// new Exception("MontarListaObjetosDoReader - Repositorio");
            }
            finally
            {
                if((dataReader != null)&&(!dataReader.IsClosed))
                {
                    dataReader.Close();    
                }
                
            }
            return objetosPesquisados;
        }

        internal TObject MontarObjetoDoReader<TObject>(IDataReader dataReader, TObject objeto, bool lazy) where TObject : class
        {
            try
            {
                dataReader.Read();
                TObject retorno = MontarObjetoDoReaderSemRead(dataReader, objeto, lazy);
                if ((dataReader != null) && (!dataReader.IsClosed))
                {
                    dataReader.Close();
                }

                return (TObject)retorno;
            }
            catch (Exception)
            {
                throw;// new Exception("MontarObjetoDoReader - Repositorio");                
            }
            
        }

        internal TObject MontarObjetoDoReaderSemRead<TObject>(IDataReader dataReader, TObject objeto, bool lazy) where TObject : class
        {
            try
            {

            object objetoCriado=null;
        
            if ((dataReader != null) && (objeto != null) && (DataReaderHasHows(dataReader)))//Primeiro IF
            {
                //Instacia Objetos
                objetoCriado = Activator.CreateInstance(typeof(TObject));
                    
                //Pega o Tipo do Objetos
                Type tipo = typeof(TObject);

               //Monta um Objeto
                foreach (PropertyInfo infoPropiedade in tipo.GetProperties())//Primeiro Foreach
                {
                    //Tratar Primeiro Nullable Segundo IF
                    if ((infoPropiedade.PropertyType.IsGenericType) && (infoPropiedade.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>)))
                    {
                        //No Futuro Tratar outros tipos de Nullable
                        if (!String.IsNullOrEmpty(dataReader[infoPropiedade.Name].ToString()))
                        {
                            DateTime value = Convert.ToDateTime(dataReader[infoPropiedade.Name].ToString());
                            objetoCriado.GetType().GetProperty(infoPropiedade.Name).SetValue(objetoCriado,value, null);
                        }
                    }
                    else
                    {

                        switch (infoPropiedade.PropertyType.Name)//switch
                        {
                            case "DateTime":
                                {
                                    if (!String.IsNullOrEmpty(dataReader[infoPropiedade.Name].ToString()))
                                    {
                                        DateTime value = Convert.ToDateTime(dataReader[infoPropiedade.Name].ToString());
                                        objetoCriado.GetType().GetProperty(infoPropiedade.Name).SetValue(objetoCriado,value, null);
                                    }
                                    break;
                                }

                            case "Int32":
                                {
                                    if (!String.IsNullOrEmpty(dataReader[infoPropiedade.Name].ToString()))
                                    {
                                        int value = Convert.ToInt32(dataReader[infoPropiedade.Name].ToString());
                                        objetoCriado.GetType().GetProperty(infoPropiedade.Name).SetValue(objetoCriado,value, null);
                                    }
                                    break;
                                }

                            case "Boolean":
                                {
                                    if (!String.IsNullOrEmpty(dataReader[infoPropiedade.Name].ToString()))
                                    {
                                        bool value = Convert.ToBoolean(dataReader[infoPropiedade.Name].ToString());
                                        objetoCriado.GetType().GetProperty(infoPropiedade.Name).SetValue(objetoCriado, value, null);
                                    }
                                    break;
                                }

                            case "bool":
                                {
                                    if (!String.IsNullOrEmpty(dataReader[infoPropiedade.Name].ToString()))
                                    {
                                        bool value = Convert.ToBoolean(dataReader[infoPropiedade.Name].ToString());
                                        objetoCriado.GetType().GetProperty(infoPropiedade.Name).SetValue(objetoCriado, value, null);
                                    }
                                    break;
                                }

                            case "Int64":
                                {
                                    if (!String.IsNullOrEmpty(dataReader[infoPropiedade.Name].ToString()))
                                    {
                                        long value = Convert.ToInt64(dataReader[infoPropiedade.Name].ToString());
                                        objetoCriado.GetType().GetProperty(infoPropiedade.Name).SetValue(objetoCriado, value, null);
                                    }
                                    break;
                                }

                            case "Decimal":
                                {
                                    if (!String.IsNullOrEmpty(dataReader[infoPropiedade.Name].ToString()))
                                    {
                                        decimal value = Convert.ToDecimal(dataReader[infoPropiedade.Name].ToString());
                                        objetoCriado.GetType().GetProperty(infoPropiedade.Name).SetValue(objetoCriado, value, null);
                                    }
                                    break;
                                }

                            case "Int16":
                                {
                                    if (!String.IsNullOrEmpty(dataReader[infoPropiedade.Name].ToString()))
                                    {
                                        short value = Convert.ToInt16(dataReader[infoPropiedade.Name].ToString());
                                        objetoCriado.GetType().GetProperty(infoPropiedade.Name).SetValue(objetoCriado, value, null);
                                    }
                                    break;
                                }

                            case "string":
                                {
                                    if (!String.IsNullOrEmpty(dataReader[infoPropiedade.Name].ToString()))
                                    {
                                        string value = dataReader[infoPropiedade.Name].ToString();
                                        objetoCriado.GetType().GetProperty(infoPropiedade.Name).SetValue(objetoCriado, value, null);
                                    }
                                    break;
                                }

                            case "String":
                                {
                                    if (!String.IsNullOrEmpty(dataReader[infoPropiedade.Name].ToString()))
                                    {
                                        string value = dataReader[infoPropiedade.Name].ToString();
                                        objetoCriado.GetType().GetProperty(infoPropiedade.Name).SetValue(objetoCriado, value, null);
                                    }
                                    break;
                                }

                            default : //Parte do Objetos e Tratamento de Lazy load
                                {
                                    if (!String.IsNullOrEmpty(dataReader[infoPropiedade.Name].ToString()))//Terceiro IF
                                    {
                                        string nomeClasse = infoPropiedade.PropertyType.Name;
                                        string valorStringBanco = dataReader[infoPropiedade.Name].ToString();
                                        nomeClasse = "Dados." + nomeClasse + ",Dados";
                                        
                                        Type tipoObjetoPropiedade = Type.GetType(nomeClasse);

                                        object value=null;
                                        
                                        //Regex Para Validar se A Chave é Inteiro ou String
                                        Regex regex = new Regex(@"[0-9]+");

                                        //se for Codigo é String
                                        if (regex.IsMatch(valorStringBanco))
                                        {
                                            //Valor Inteiro
                                            value = Convert.ToInt32(valorStringBanco);
                                        }
                                        else
                                        {
                                            value = valorStringBanco;
                                        }

                                        //Se gerou Classe e não é Enumerador
                                        if ((tipoObjetoPropiedade != null) &&
                                            (tipoObjetoPropiedade.BaseType.Name != typeof (Enum).Name))
                                        {
                                            //Caso seja Objeto Verifica o Lazy e recupera de acordo
                                            var propiedadeObjeto = Activator.CreateInstance(tipoObjetoPropiedade);
                                            //AutoId ou Codigo
                                            string nomeColunaChaveObjetoCriado = NomeColunaChave(propiedadeObjeto);
                                            
                                            if (!lazy)
                                            {
                                                string nomeRepositorio = infoPropiedade.PropertyType.Name;
                                                nomeRepositorio = "Repositorios." + "Repositorio" + nomeRepositorio +
                                                                  ",Repositorios";
                                                Type tipoRepositorio = Type.GetType(nomeRepositorio);

                                                if ((tipoRepositorio != null) &&
                                                    (
                                                        (objetoCriado.GetType().Name != propiedadeObjeto.GetType().Name) ||
                                                        (value.ToString() !=
                                                         objetoCriado.GetType().GetProperty(nomeColunaChaveObjetoCriado).GetValue(
                                                             objetoCriado, null).ToString()))
                                                    )
                                                {
                                                    try
                                                    {
                                                        object _repositorio = Activator.CreateInstance(tipoRepositorio);
                                                        propiedadeObjeto = _repositorio.GetType().InvokeMember("ObterPorId",
                                                                                                               BindingFlags.
                                                                                                                   InvokeMethod |
                                                                                                               BindingFlags.
                                                                                                                   Instance |
                                                                                                               BindingFlags.
                                                                                                                   Public,
                                                                                                               null,
                                                                                                               _repositorio,
                                                                                                               new object[] { value, lazy });

                                                        objetoCriado.GetType().GetProperty(infoPropiedade.Name).SetValue(
                                                            objetoCriado, propiedadeObjeto, null);
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        throw;// new Exception("MontarObjetoDoReaderSemRead (Lazy) - Repositorio");
                                                    }
                                                    
                                                }

                                            }
                                            else//Não pega Todos os campos 
                                            {
                                                propiedadeObjeto.GetType().GetProperty(nomeColunaChaveObjetoCriado).SetValue(propiedadeObjeto,
                                                                                                          value, null);
                                                objetoCriado.GetType().GetProperty(infoPropiedade.Name).SetValue(
                                                    objetoCriado, propiedadeObjeto, null);
                                            }
                                        }
                                        else
                                        {
                                            objetoCriado.GetType().GetProperty(infoPropiedade.Name).SetValue(objetoCriado,
                                                                                                             value, null);
                                        }
                                
                                    }//Terceiro IF

                                    break;
                            }//Parte do Objetos e Tratamento de Lazy load

                        }//switch

                    }//Segundo IF

                }//Primeiro Foreach
              
            }//Primeiro IF

            return (TObject) objetoCriado;

            }
            catch (Exception)
            {
                throw;// new Exception("MontarObjetoDoReaderSemRead - Repositorio");
            }
        }//metodo

        //Pegar o Nome da coluna Chave AutoID ou Codigo
        private string NomeColunaChave(Object objeto)
        {
            try
            {
                return objeto.GetType().GetProperty("AutoId") != null ? "AutoId" :
                objeto.GetType().GetProperty("Codigo") != null ? "Codigo" : "Code";
            }
            catch (Exception)
            {
                throw;// new Exception("NomeColunaChave - Repositorio");
            }
        }

        private bool DataReaderHasHows(IDataReader dataReader)
        {
            try
            {
                return (bool)dataReader.GetType().GetProperty("HasRows").GetValue(dataReader, null);
            }
            catch (Exception)
            {
                throw;// new Exception("DataReaderHasHows - Repositorio");
            }
        }

        public static void TirarHoraDatasObjetos<TClasse>(ref TClasse objeto) where TClasse : class
        {
            Type tipo = typeof(TClasse);
            DateTime dataSemHora;
            DateTime dataComHora;
            foreach (PropertyInfo infoPropiedade in tipo.GetProperties())
            {
                if ((infoPropiedade.PropertyType.Name == typeof(DateTime).Name) && (infoPropiedade.GetValue(objeto, null) != null))
                {
                    //Setar o Valor da Data sem as Horas
                    dataComHora = (DateTime)objeto.GetType().GetProperty(infoPropiedade.Name).GetValue(objeto, null);
                    dataSemHora = dataComHora.Date;
                    objeto.GetType().GetProperty(infoPropiedade.Name).SetValue(objeto, dataSemHora, null);
                }
            }
        }
    }
}