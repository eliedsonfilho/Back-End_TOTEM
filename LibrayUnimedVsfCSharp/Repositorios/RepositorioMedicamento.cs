using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Dados;
using MySql.Data.MySqlClient;

namespace Repositorios
{
    public class RepositorioMedicamento : Repositorio , IRepositorio<Medicamento,int>
    {
        public RepositorioMedicamento()
        {
        }

        public Medicamento ObterPorId(int autoIdBoleto, bool lazy)
        {
            throw new NotImplementedException();
        }

        public IList<Medicamento> ObterTodos(bool lazy)
        {
            IDbCommand command;
            //IDataReader dataReaderTmp;
            IList<Medicamento> medicamentosPesquisados = null;
            
            //Executando a pesquisa
            try
            {
                command = new MySqlCommand(@"Select 
                                            ValidadeRegAnvisa,
                                            UnidadeFracao,
                                            Situacao,
                                            RegistroAnvisa,
                                            PrincipioAtivo,
                                            PrecoICMS19,
                                            PrecoICMS18,
                                            PrecoICMS17,
                                            Origem,
                                            Observacoes,
                                            NomeFabricante,
                                            NomeComercial,
                                            MotivoInativaAtiva,
                                            GrupoFarmacologico,
                                            Generico,
                                            FormaFarmaceutica,
                                            DataObrigatoriedadeProduto,
                                            CodigoTnumm,
                                            CodigoTiss,
                                            CodigoBrasindice,
                                            ClasseFarmacologica,
                                            CNPJFabricante from Medicamento");
                //dataReaderTmp = GerenciadorConexaoBanco.GetInstancia(EnumTipoBanco.MySql).ExecutarConsulta(command);
                Medicamento medicamento = new Medicamento();
                medicamentosPesquisados = GerenciadorConexaoBanco.GetInstancia(EnumTipoBanco.MySql).ExecutarConsultaList(command, medicamento, lazy);
            }
            catch (Exception)
            {
                throw;
            }

            //Tratando o Retorno 
            //medicamentosPesquisados = MontarListaObjetosDoReader(dataReaderTmp, medicamento,lazy);

            return medicamentosPesquisados;
        }

        public IList<Medicamento> ObterTodos(Medicamento medicamentoPesquisado, bool lazy)
        {
            //IDataReader dataReaderTmp;
            IList<Medicamento> medicamentosPesquisados = null;
            IDbCommand command = null;
            int qtdRegistro = 100;
            StringBuilder query;
            bool where = false;
            //Montar o Comando
            if (medicamentoPesquisado != null)
            {
                query = new StringBuilder();

                command = new MySqlCommand(@"Select 
                                    ValidadeRegAnvisa,
                                    UnidadeFracao,
                                    Situacao,
                                    RegistroAnvisa,
                                    PrincipioAtivo,
                                    PrecoICMS19,
                                    PrecoICMS18,
                                    PrecoICMS17,
                                    Origem,
                                    Observacoes,
                                    NomeFabricante,
                                    NomeComercial,
                                    MotivoInativaAtiva,
                                    GrupoFarmacologico,
                                    Generico,
                                    FormaFarmaceutica,
                                    DataObrigatoriedadeProduto,
                                    CodigoTnumm,
                                    CodigoTiss,
                                    CodigoBrasindice,
                                    ClasseFarmacologica,
                                    CNPJFabricante from Medicamento");
                //Filtros
                if (!String.IsNullOrEmpty(medicamentoPesquisado.CodigoTnumm))
                {
                    query.Append("Medicamento.CodigoTnumm Like '%" + medicamentoPesquisado.CodigoTnumm.Trim() + "%'");
                    where = true;
                }

                if (!String.IsNullOrEmpty(medicamentoPesquisado.CodigoTiss))
                {
                    if (where)
                    {
                        query.Append(" and ");
                    }
                    query.Append("Medicamento.CodigoTiss ='" + medicamentoPesquisado.CodigoTiss.Trim() + "'");
                    where = true;
                }

                if (!String.IsNullOrEmpty(medicamentoPesquisado.CodigoBrasindice))
                {
                    if (where)
                    {
                        query.Append(" and ");
                    }
                    query.Append("Medicamento.CodigoBrasindice ='" + medicamentoPesquisado.CodigoBrasindice.Trim() + "'");
                    where = true;
                }

                if (!String.IsNullOrEmpty(medicamentoPesquisado.RegistroAnvisa.Trim()))
                {
                    if (where)
                    {
                        query.Append(" and ");
                    }
                    query.Append("Medicamento.RegistroAnvisa ='" + medicamentoPesquisado.RegistroAnvisa.Trim() + "'");
                    where = true;
                }

                if (!String.IsNullOrEmpty(medicamentoPesquisado.PrincipioAtivo.Trim()))
                {
                    if (where)
                    {
                        query.Append(" and ");
                    }
                    query.Append("Medicamento.PrincipioAtivo Like '%" + medicamentoPesquisado.PrincipioAtivo.Trim() + "%'");
                    where = true;
                }

                if (!String.IsNullOrEmpty(medicamentoPesquisado.GrupoFarmacologico.Trim()))
                {
                    if (where)
                    {
                        query.Append(" and ");
                    }
                    query.Append("Medicamento.GrupoFarmacologico Like '%" + medicamentoPesquisado.GrupoFarmacologico.Trim() + "%'");
                    where = true;
                }

                if (!String.IsNullOrEmpty(medicamentoPesquisado.Generico.Trim()))
                {
                    if (where)
                    {
                        query.Append(" and ");
                    }
                    query.Append("Medicamento.Generico ='" + medicamentoPesquisado.Generico.Trim() + "'");
                    where = true;
                }

                if (!String.IsNullOrEmpty(medicamentoPesquisado.NomeComercial.Trim()))
                {
                    if (where)
                    {
                        query.Append(" and ");
                    }
                    query.Append("Medicamento.NomeComercial Like '%" + medicamentoPesquisado.NomeComercial.Trim() + "%'");
                    where = true;
                }

                if (!String.IsNullOrEmpty(medicamentoPesquisado.UnidadeFracao))
                {
                    if (where)
                    {
                        query.Append(" and ");
                    }
                    query.Append("Medicamento.UnidadeFracao ='" + medicamentoPesquisado.UnidadeFracao + "'");
                    where = true;
                }

                if (!String.IsNullOrEmpty(medicamentoPesquisado.Origem))
                {
                    if (where)
                    {
                        query.Append(" and ");
                    }
                    query.Append("Medicamento.Origem ='" + medicamentoPesquisado.Origem + "'");
                    where = true;
                }

                if (!String.IsNullOrEmpty(medicamentoPesquisado.CNpjFabricante))
                {
                    if (where)
                    {
                        query.Append(" and ");
                    }
                    query.Append("Medicamento.CNpjFabricante ='" + medicamentoPesquisado.CNpjFabricante + "'");
                    where = true;
                }

                if (!String.IsNullOrEmpty(medicamentoPesquisado.NomeFabricante))
                {
                    if (where)
                    {
                        query.Append(" and ");
                    }
                    query.Append("Medicamento.NomeFabricante Like '%" + medicamentoPesquisado.NomeFabricante.Trim() + "%'");
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
                Medicamento medicamento = new Medicamento();
                medicamentosPesquisados = GerenciadorConexaoBanco.GetInstancia(EnumTipoBanco.MySql).ExecutarConsultaList(command, medicamento, lazy);
            }
            catch (Exception)
            {
                throw;
            }

            //Tratando   o Retorno 
            //medicamentosPesquisados = MontarListaObjetosDoReader(dataReaderTmp, medicamentoPesquisado, lazy);

            return medicamentosPesquisados;
        }

        //private IList<Medicamento> MontarListaDoReader(IDataReader dataReader)
        //{
        //    MySqlDataReader dataReaderTmp = (MySqlDataReader)dataReader;

        //    IList<Medicamento> medicamentosPesquisados = null;
        //    Medicamento medicamentoTmp;

        //    try
        //    {
        //        if ((dataReaderTmp != null) && (dataReaderTmp.HasRows))
        //        {
        //            //Instancia a Lista
        //            medicamentosPesquisados = new List<Medicamento>();

        //            //Lê o reader e coloca na lista
        //            while (dataReaderTmp.Read())
        //            {
        //                //Monta um Medicamento
        //                medicamentoTmp = new Medicamento();
        //                medicamentoTmp.CNpjFabricante = dataReaderTmp["CNpjFabricante"].ToString();
        //                medicamentoTmp.ClasseFarmacologica = dataReaderTmp["ClasseFarmacologica"].ToString();
        //                medicamentoTmp.CodigoBrasindice = dataReaderTmp["CodigoBrasindice"].ToString();
        //                medicamentoTmp.CodigoTiss = dataReaderTmp["CodigoTiss"].ToString();
        //                medicamentoTmp.CodigoTnumm = dataReaderTmp["CodigoTnumm"].ToString();
        //                medicamentoTmp.DataObrigatoriedadeProduto = (!String.IsNullOrEmpty(dataReaderTmp["DataObrigatoriedadeProduto"].ToString())) ? dataReaderTmp.GetDateTime("DataObrigatoriedadeProduto") : (DateTime?)null;
        //                medicamentoTmp.FormaFarmaceutica = dataReaderTmp["FormaFarmaceutica"].ToString();
        //                medicamentoTmp.Generico = dataReaderTmp["Generico"].ToString();
        //                medicamentoTmp.GrupoFarmacologico = dataReaderTmp["GrupoFarmacologico"].ToString();
        //                medicamentoTmp.MotivoInativaAtiva = dataReaderTmp["MotivoInativaAtiva"].ToString();
        //                medicamentoTmp.NomeComercial = dataReaderTmp["NomeComercial"].ToString();
        //                medicamentoTmp.NomeFabricante = dataReaderTmp["NomeFabricante"].ToString();
        //                medicamentoTmp.Observacoes = dataReaderTmp["Observacoes"].ToString();
        //                medicamentoTmp.Origem = dataReaderTmp["Origem"].ToString();
        //                medicamentoTmp.PrecoIcms17 = dataReaderTmp["PrecoIcms17"].ToString();
        //                medicamentoTmp.PrecoIcms18 = dataReaderTmp["PrecoIcms18"].ToString();
        //                medicamentoTmp.PrecoIcms19 = dataReaderTmp["PrecoIcms19"].ToString();
        //                medicamentoTmp.PrincipioAtivo = dataReaderTmp["PrincipioAtivo"].ToString();
        //                medicamentoTmp.RegistroAnvisa = dataReaderTmp["RegistroAnvisa"].ToString();
        //                medicamentoTmp.Situacao = dataReaderTmp["Situacao"].ToString();
        //                medicamentoTmp.UnidadeFracao = dataReaderTmp["UnidadeFracao"].ToString();
        //                medicamentoTmp.ValidadeRegAnvisa = (!String.IsNullOrEmpty(dataReaderTmp["ValidadeRegAnvisa"].ToString()))?dataReaderTmp.GetDateTime("ValidadeRegAnvisa"):(DateTime?) null;

        //                //Coloca na Lista
        //                medicamentosPesquisados.Add(medicamentoTmp);
        //            }
        //        }
        //    }
        //    catch (Exception exception)
        //    {
        //        throw new Exception(exception.Message);
        //    }

        //    return medicamentosPesquisados;
        //}
    }
}