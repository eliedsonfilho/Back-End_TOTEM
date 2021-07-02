using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.Text;
using Dados;

namespace Util
{
    public class Utils
    {
        public static void TirarHoraDatasObjetos<TClasse>(ref TClasse objeto) where TClasse : class
        {
            Type tipo = typeof (TClasse);
            DateTime dataSemHora;
            DateTime dataComHora;
            foreach (PropertyInfo infoPropiedade in tipo.GetProperties())
            {
                if ((infoPropiedade.PropertyType.Name == typeof(DateTime).Name)&&(infoPropiedade.GetValue(objeto,null) != null))
                {
                    //Setar o Valor da Data sem as Horas
                    dataComHora = (DateTime) objeto.GetType().GetProperty(infoPropiedade.Name).GetValue(objeto, null);
                    dataSemHora = dataComHora.Date;
                    objeto.GetType().GetProperty(infoPropiedade.Name).SetValue(objeto, dataSemHora,null);
                }
            }
        }

        public static void CompararIgualdadePropriedade<TClasse>(TClasse velho, TClasse novo, EnumOperacaoBanco enumOperacaoBanco, long idTabela, string nomeTabela, string usuario) where TClasse : class
        {
            if (velho != null && novo != null)
            {
                Type type = typeof(TClasse);

                if (!enumOperacaoBanco.Equals(EnumOperacaoBanco.Exclusao))
                {
                    switch (enumOperacaoBanco)
                    {
                        case EnumOperacaoBanco.Atualizacao:
                            {
                                //StreamWriter streamWriter = new StreamWriter(@"D:\Testes\setup\propertys.txt");

                                object valueVelho;
                                object valueNovo;

                                foreach (PropertyInfo pi in type.GetProperties())
                                {
                                    //streamWriter.WriteLine(pi.Name);

                                    valueVelho = type.GetProperty(pi.Name).GetValue(velho, null);
                                    valueNovo = type.GetProperty(pi.Name).GetValue(novo, null);

                                    if (valueVelho != null && valueNovo != null && !valueVelho.Equals(valueNovo))
                                    {
                                        //streamWriter.WriteLine("Valor Velho: " + valueVelho.ToString() + "   Valor Novo: " + valueNovo.ToString());
                                       TratamentoErros.TratamentoExcecoes.CriarLog(pi.Name, enumOperacaoBanco, idTabela, nomeTabela, usuario, valueVelho.ToString(), valueNovo.ToString());
                                    }
                                }
                                //streamWriter.Close();

                                break;
                            }

                        case EnumOperacaoBanco.Insercao:
                            {
                                object valueNovo;
                                foreach (PropertyInfo pi in type.GetProperties())
                                {
                                    valueNovo = type.GetProperty(pi.Name).GetValue(novo, null);
                                    if (valueNovo != null && !string.IsNullOrEmpty(valueNovo.ToString()))
                                    {
                                        TratamentoErros.TratamentoExcecoes.CriarLog(pi.Name, enumOperacaoBanco, idTabela, nomeTabela, usuario, string.Empty, valueNovo.ToString());
                                    }
                                }

                                break;
                            }
                    }

                }
                else
                {
                    TratamentoErros.TratamentoExcecoes.CriarLog(string.Empty, enumOperacaoBanco, idTabela, nomeTabela, usuario, string.Empty, string.Empty);
                }
            }
        }

        public static T Clonar<T>(T objOriginal, string[]camposParaNaoCopiar , string entidadeParaNaoCopiar)
        {
            //Cria nova referência
            object objClonado = Activator.CreateInstance(typeof(T));

            //Pega as propriedades
            PropertyDescriptorCollection propriedades = TypeDescriptor.GetProperties(objOriginal);

            //Seta as propriedades
            for (int i = 0; i < propriedades.Count; i++)
            {
                if (camposParaNaoCopiar != null)
                {
                    foreach (string s in camposParaNaoCopiar)
                    {
                        if (!s.Equals(propriedades[i].DisplayName))
                        {
                            if (!string.IsNullOrEmpty(entidadeParaNaoCopiar))
                            {
                                if (!propriedades[i].PropertyType.FullName.Contains(entidadeParaNaoCopiar))
                                {

                                    if (propriedades[i].PropertyType.Name == typeof(IList).Name)
                                    {
                                        IList lista = new ArrayList(); 
                                        for (int j = 0; j < (propriedades[i].GetValue(objOriginal) as IList).Count; j++)
                                        {
                                            var item = (propriedades[i].GetValue(objOriginal) as IList)[j];
                                            lista.Add(item);
                                        }
                                        propriedades[i].SetValue(objClonado, lista);
                                    }
                                    else
                                    {
                                        propriedades[i].SetValue(objClonado, propriedades[i].GetValue(objOriginal));
                                    } 
                                }
                            }
                            else
                            {
                                if (propriedades[i].PropertyType.Name == typeof(IList).Name)
                                {
                                    IList lista = new ArrayList(); 
                                    for (int j = 0; j < (propriedades[i].GetValue(objOriginal) as IList).Count; j++)
                                    {
                                        var item = (propriedades[i].GetValue(objOriginal) as IList)[j];
                                        lista.Add(item);
                                    }
                                    propriedades[i].SetValue(objClonado, lista);
                                }
                                else
                                {
                                    propriedades[i].SetValue(objClonado, propriedades[i].GetValue(objOriginal));
                                } 
                            }
                        }
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(entidadeParaNaoCopiar))
                    {
                        if (!propriedades[i].PropertyType.FullName.Contains(entidadeParaNaoCopiar))
                        {
                            if (propriedades[i].PropertyType.Name == typeof(IList).Name)
                            {
                                IList lista = new ArrayList(); 
                                for (int j = 0; j < (propriedades[i].GetValue(objOriginal) as IList).Count; j++)
                                {
                                    var item = (propriedades[i].GetValue(objOriginal) as IList)[j];
                                    lista.Add(item);
                                }
                                propriedades[i].SetValue(objClonado, lista);
                            }
                            else
                            {
                                propriedades[i].SetValue(objClonado, propriedades[i].GetValue(objOriginal));
                            } 
                        }
                    }
                    else
                    {
                      
                        if (propriedades[i].PropertyType.Name == typeof(IList).Name)
                        {
                            IList lista = new ArrayList();
                            for (int j = 0; j < (propriedades[i].GetValue(objOriginal) as IList).Count; j++)
                            {
                                var item = (propriedades[i].GetValue(objOriginal) as IList)[j];
                                lista.Add(item);
                            }
                            propriedades[i].SetValue(objClonado, lista);
                        }
                        else
                        {
                            propriedades[i].SetValue(objClonado, propriedades[i].GetValue(objOriginal));
                        }  
                    }
                }
            }

            //Retorna objeto clonado
            return (T)objClonado;
        }

        public static string NumeroContaFormatado(string numero)
        {
            string retorno="";
            if(numero.Length > 1)
            {
                retorno = numero.Substring(0, numero.Length - 1);
                retorno += "-";
                retorno += numero.Substring(numero.Length - 1, 1);
            }
            else
            {
                retorno = numero;
            }
            return retorno;
        }

        public static bool ValidarCodigoCartao(string codigo)
        {
            bool retorno = false;

            if ((!String.IsNullOrEmpty(codigo)) && (codigo.Length == 17))
            {
                string digitoCodigo = codigo.Substring(codigo.Length - 1, 1);
                string digitoCriado = GeradorCodigo.GerarDigito(codigo.Substring(0,codigo.Length-1));
                retorno = digitoCodigo == digitoCriado;
            }
            return retorno;
        }

        public static string CodigoBeneficiarioMascarado(long codigo)
        {
            string retornoFormatado = codigo.ToString().PadLeft(17,Convert.ToChar(0));
            
            retornoFormatado = retornoFormatado.Substring(0, 1) + " " + retornoFormatado.Substring(1, 3) + " " +
                                   retornoFormatado.Substring(4, 12) + " " + retornoFormatado.Substring(16, 1);    
            
            return retornoFormatado;
        }

        public static string DataPorExtenso(DateTime data)
        {
            return data.ToString("dddd, dd 'de' MMMM 'de' yyyy", System.Globalization.CultureInfo.GetCultureInfo("pt-BR"));
        }
    }
}