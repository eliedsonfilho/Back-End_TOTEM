using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Dados;
using MySql.Data.MySqlClient;

namespace Repositorios
{
    public class RepositorioMaterial:Repositorio, IRepositorio<Material,int>
    {
        public RepositorioMaterial()
        {
        }

        public Material ObterPorId(int autoIdBoleto, bool lazy)
        {
            throw new NotImplementedException();
        }

        public IList<Material> ObterTodos(bool lazy)
        {
            IDbCommand command;
            //IDataReader dataReaderTmp;
            IList<Material> MaterialsPesquisados = null;
            Material MaterialTmp;
            
            //Executando a pesquisa
            try
            {
                command = new MySqlCommand(@"Select 
                                            CodigoTnumm,
                                            CodigoTiss,
                                            NomeComercial,
                                            DescricaoProduto,
                                            Situacao,
                                            NomeFabricante,
                                            NomeImportador,
                                            Origem,
                                            EspecialidadeProduto,
                                            ClassificacaoAnvisa,
                                            ApresentacaoComercial,
                                            UnidadeProduto,
                                            CNPJFabricante,
                                            RegistroAnvisa,
                                            ValidadeRegAnvisa,
                                            MotivoInativaAtiva,
                                            PrecoFabrica,
                                            VlrMaxIntNac,
                                            DataObrigatoriedadeProduto,
                                            Observacoes from Material");
                //dataReaderTmp = GerenciadorConexaoBanco.GetInstancia(EnumTipoBanco.MySql).ExecutarConsulta(command);
                Material material= new Material();
                MaterialsPesquisados = GerenciadorConexaoBanco.GetInstancia(EnumTipoBanco.MySql).ExecutarConsultaList(command, material, lazy);
            }
            catch (Exception)
            {
                throw;
            }

            //Tratando o Retorno 
            //Material material= new Material();
            //MaterialsPesquisados = MontarListaObjetosDoReader(dataReaderTmp,material,lazy);

            return MaterialsPesquisados;
        }

        public IList<Material> ObterTodos(Material materialPesquisado, bool lazy)
        {
            //IDataReader dataReaderTmp;
            IList<Material> MaterialsPesquisados = null;
            IDbCommand command = null;
            int qtdRegistro = 100;
            StringBuilder query;
            bool where = false;
           
            //Montando  o Comando
            if (materialPesquisado != null)
            {
                query = new StringBuilder();

                command = new MySqlCommand(@"Select 
                                            CodigoTnumm,
                                            CodigoTiss,
                                            NomeComercial,
                                            DescricaoProduto,
                                            Situacao,
                                            NomeFabricante,
                                            NomeImportador,
                                            Origem,
                                            EspecialidadeProduto,
                                            ClassificacaoAnvisa,
                                            ApresentacaoComercial,
                                            UnidadeProduto,
                                            CNPJFabricante,
                                            RegistroAnvisa,
                                            ValidadeRegAnvisa,
                                            MotivoInativaAtiva,
                                            PrecoFabrica,
                                            VlrMaxIntNac,
                                            DataObrigatoriedadeProduto,
                                            Observacoes from Material");
                //Filtros
                if (!String.IsNullOrEmpty(materialPesquisado.CodigoTnumm))
                {
                    query.Append("Material.CodigoTnumm Like '%" + materialPesquisado.CodigoTnumm.Trim() + "%'");
                    where = true;
                }

                if (!String.IsNullOrEmpty(materialPesquisado.CodigoTiss))
                {
                    if (where)
                    {
                        query.Append(" and ");
                    }
                    query.Append("Material.CodigoTiss ='" + materialPesquisado.CodigoTiss.Trim() + "'");
                    where = true;
                }

                if (!String.IsNullOrEmpty(materialPesquisado.RegistroAnvisa.Trim()))
                {
                    if (where)
                    {
                        query.Append(" and ");
                    }
                    query.Append("Material.RegistroAnvisa ='" + materialPesquisado.RegistroAnvisa.Trim() + "'");
                    where = true;
                }

                if (!String.IsNullOrEmpty(materialPesquisado.EspecialidadeProduto.Trim()))
                {
                    if (where)
                    {
                        query.Append(" and ");
                    }
                    query.Append("Material.EspecialidadeProduto Like '%" + materialPesquisado.EspecialidadeProduto.Trim() + "%'");
                    where = true;
                }

                if (!String.IsNullOrEmpty(materialPesquisado.ClassificacaoAnvisa.Trim()))
                {
                    if (where)
                    {
                        query.Append(" and ");
                    }
                    query.Append("Material.ClassificacaoAnvisa Like '%" + materialPesquisado.ClassificacaoAnvisa.Trim() + "%'");
                    where = true;
                }

                if (!String.IsNullOrEmpty(materialPesquisado.NomeComercial.Trim()))
                {
                    if (where)
                    {
                        query.Append(" and ");
                    }
                    query.Append("Material.NomeComercial Like '%" + materialPesquisado.NomeComercial.Trim() + "%'");
                    query.Append(" or ");
                    query.Append("Material.DescricaoProduto Like '%" + materialPesquisado.NomeComercial.Trim() + "%'");
                    where = true;
                }

                if (!String.IsNullOrEmpty(materialPesquisado.UnidadeProduto))
                {
                    if (where)
                    {
                        query.Append(" and ");
                    }
                    query.Append("Material.UnidadeProduto ='" + materialPesquisado.UnidadeProduto + "'");
                    where = true;
                }

                if (!String.IsNullOrEmpty(materialPesquisado.Origem))
                {
                    if (where)
                    {
                        query.Append(" and ");
                    }
                    query.Append("Material.Origem ='" + materialPesquisado.Origem + "'");
                    where = true;
                }

                if (!String.IsNullOrEmpty(materialPesquisado.CNpjFabricante))
                {
                    if (where)
                    {
                        query.Append(" and ");
                    }
                    query.Append("Material.CNpjFabricante ='" + materialPesquisado.CNpjFabricante + "'");
                    where = true;
                }

                if (!String.IsNullOrEmpty(materialPesquisado.NomeFabricante))
                {
                    if (where)
                    {
                        query.Append(" and ");
                    }
                    query.Append("Material.NomeFabricante Like '%" + materialPesquisado.NomeFabricante.Trim() + "%'");
                    query.Append(" or ");
                    query.Append("Material.NomeImportador Like '%" + materialPesquisado.NomeFabricante.Trim() + "%'");
                    where = true;
                }

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
                Material material = new Material();
                MaterialsPesquisados = GerenciadorConexaoBanco.GetInstancia(EnumTipoBanco.MySql).ExecutarConsultaList(command, material, lazy);
            }
            catch (Exception)
            {
                throw;
            }

            //Tratando   o Retorno 
            //MaterialsPesquisados = MontarListaObjetosDoReader(dataReaderTmp,materialPesquisado,lazy);

            return MaterialsPesquisados;
        }

        //public IList<Material> MontarListaDoReader(IDataReader dataReader)
        //{
        //    MySqlDataReader dataReaderTmp = (MySqlDataReader) dataReader;
            
        //    IList<Material> materiaisPesquisados = null;
        //    Material materialTmp;
        //    try
        //    {
        //        if ((dataReaderTmp != null) && (dataReaderTmp.HasRows))
        //        {
        //            //Instancia a Lista
        //            materiaisPesquisados = new List<Material>();

        //            //Lê o reader e coloca na lista
        //            while (dataReaderTmp.Read())
        //            {
        //                //Monta um Material
        //                materialTmp = new Material();
        //                materialTmp.ApresentacaoComercial = dataReaderTmp["ApresentacaoComercial"].ToString();
        //                materialTmp.CNpjFabricante = dataReaderTmp["CNpjFabricante"].ToString();
        //                materialTmp.ClassificacaoAnvisa = dataReaderTmp["ClassificacaoAnvisa"].ToString();
        //                materialTmp.CodigoTiss = dataReaderTmp["CodigoTiss"].ToString();
        //                materialTmp.CodigoTnumm = dataReaderTmp["CodigoTnumm"].ToString();
        //                materialTmp.DataObrigatoriedadeProduto = (!String.IsNullOrEmpty(dataReaderTmp["DataObrigatoriedadeProduto"].ToString())) ? dataReaderTmp.GetDateTime("DataObrigatoriedadeProduto") : (DateTime?)null;
        //                materialTmp.DescricaoProduto = dataReaderTmp["DescricaoProduto"].ToString();
        //                materialTmp.EspecialidadeProduto = dataReaderTmp["EspecialidadeProduto"].ToString();
        //                materialTmp.MotivoInativaAtiva = dataReaderTmp["MotivoInativaAtiva"].ToString();
        //                materialTmp.NomeComercial = dataReaderTmp["NomeComercial"].ToString();
        //                materialTmp.NomeFabricante = dataReaderTmp["NomeFabricante"].ToString();
        //                materialTmp.NomeImportador = dataReaderTmp["NomeImportador"].ToString();
        //                materialTmp.Observacoes = dataReaderTmp["Observacoes"].ToString();
        //                materialTmp.Origem = dataReaderTmp["Origem"].ToString();
        //                materialTmp.PrecoFabrica = dataReaderTmp["PrecoFabrica"].ToString();
        //                materialTmp.RegistroAnvisa = dataReaderTmp["RegistroAnvisa"].ToString();
        //                materialTmp.Situacao = dataReaderTmp["Situacao"].ToString();
        //                materialTmp.UnidadeProduto = dataReaderTmp["UnidadeProduto"].ToString();
        //                materialTmp.ValidadeRegAnvisa = (!String.IsNullOrEmpty(dataReaderTmp["ValidadeRegAnvisa"].ToString()))?dataReaderTmp.GetDateTime("ValidadeRegAnvisa"):(DateTime?) null;
        //                materialTmp.VlrMaxIntNac = dataReaderTmp["VlrMaxIntNac"].ToString();
        //                //Coloca na Lista
        //                materiaisPesquisados.Add(materialTmp);
        //            }
        //        }
        //    }
        //    catch (Exception exception)
        //    {
        //        throw new Exception(exception.Message);
        //    }

        //    return materiaisPesquisados;
        //}
    }
}