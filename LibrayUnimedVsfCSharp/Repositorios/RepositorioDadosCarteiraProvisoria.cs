using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Dados;

namespace Repositorios
{
    public class RepositorioDadosCarteiraProvisoria : Repositorio, IRepositorio<DadosCarteiraProvisoria, long>
    {
        public DadosCarteiraProvisoria ObterPorId(long autoIdBoleto, bool lazy)
        {
            IDbCommand command;
            //IDataReader dataReaderTmp;
            DadosCarteiraProvisoria objetoPesquisado = new DadosCarteiraProvisoria();

            //Executando a pesquisa
            try
            {
                command = new SqlCommand(@"SELECT  '0' +' '+
		                                    substring(convert(varchar,Beneficiario.Codigo),1,3) +' '+
		                                    substring(convert(varchar,Beneficiario.Codigo),4,12) +' '+
		                                    substring(convert(varchar,Beneficiario.Codigo),16,1) Cod_Ben,					-- Campo 1 (Códigodo Beneficiário)

		                                    convert(varchar,Pessoa.DataNascimento,103) DataNascimento,						-- Campo 2 (Data Nascimento)

		                                    CASE WHEN ModuloOperadora.TipoContratacao in (1,2,5) THEN '2-Física'
		                                    ELSE '3-Empresarial' end Natureza_Cont,											-- Campo 3 (Natureza da Contratação)

		                                    CASE WHEN ModuloOperadora.Acomodacao='A' THEN 'Individual'
		                                    ELSE CASE WHEN ModuloOperadora.Acomodacao='C' THEN 'Coletiva'
		                                    ELSE 'Erro' end end Acomodacao,													-- Campo 4 (Acomodacao)

		                                    convert(varchar,getdate() + 7,103) Validade,									-- Campo 5 (Validade)
		                                    upper(Pessoa.NomeReduzido) Nome,												-- Campo 7 (Nome)
		                                    TipoRedeReferenciada.CodigoExterno Rede,										-- Campo 8 (Rede)
		                                    '0210' Atend,																	-- Campo 9 (Atendimento)
		                                    ModuloOperadoraInter.NomeReduzido Plano,										-- Campo 10 (Plano)
		                                    case when ModuloOperadora.Linha=2 then 'Plano Regulamentado'
		                                    else 'Plano Não Regulamentado' end Desc_Plano,									-- Campo 10 (Desc_Plano)
		                                    AbrangenciaGeografica.Nome AS Abrangencia,										-- Campo 11 (Abrangencia)
		                                    '0' + convert(varchar,CartaoIdentificacao.Via) Via,								-- Campo 12 (Via)

		                                    case when (CPT.Data_CPT is null or CPT.Data_CPT < getdate() ) then 'NAO HA'
		                                    else convert(varchar,CPT.Data_CPT,103) end CPT,									-- Campo 13 (Cobertura Parcial Temporária)

		                                    ModuloOperadora.NomeReduzido Contratante,										-- Campo 14 (Contratante)
		                                    convert(varchar,Beneficiario.InicioVigencia,103) Inclusao,						-- Campo 15 (Inclusão)
		                                    case when ModuloOperadora.NumRegistroExterno is null 
			                                     then convert(varchar,ModuloOperadora.Codigo)
		                                    else convert(varchar,ModuloOperadora.NumRegistroExterno) end Plano_ANS,			-- Campo 16 (Numero Plano ANS)

		                                    --VSF_Situacao_Financeira.Dias_Inad,											-- Campo 17 (Dias Inadimplencia)
		                                    --VSF_Situacao_Financeira.Sit_Fin,												-- Campo 18 (Situação Financeira)
		                                    --VSF_Situacao_Benef.Situacao,													-- Campo 19 (Situação Benef)

		                                    case when VSF_Situacao_Benef.Situacao in ('A') and VSF_Situacao_Financeira.Dias_Inad>59 
			                                     then 'Código 100: Não foi possível gerar carteira provisória, favor entrar em contato com a Recepção de Cadastro.'
		                                    else case when VSF_Situacao_Benef.Situacao in ('I') 
			                                     then 'Código 100: Não foi possível gerar carteira provisória, favor entrar em contato com a Recepção de Cadastro.'
		                                    else case when ModuloOperadora.TipoContratacao not in (1,2,5)
												 then 'Código 104: Não é possível solicitar 2ª vida de cartao de identificação para contrato do tipo Jurídico.'
											else 'Ok' end end end Mens1,															-- Campo 20 (Mensagem)

		                                    'ATENÇÃO: Esta carteira provisória vale apenas por 7 dias' Mens2,				-- Campo 21 (Mensagem 2)
											case when AbrangenciaGeografica.Nome = 'NACIONAL' then null
											else 'Abrangência Local/Regional: Petrolina/PE, Juazeiro/BA.' end MensObsAbragencia, --Mensagem de observação para atendimento
											case when AbrangenciaGeografica.Nome = 'NACIONAL' then null
											else 'Atendimento nacional apenas para urgência e emergência.(Decorrente de acidente pessoal )' end MensObsAtendimento	-- Mensagem de observação para abrangencia



                                    FROM            Beneficiario INNER JOIN
                                                             CartaoIdentificacao ON Beneficiario.AutoId = CartaoIdentificacao.Beneficiario INNER JOIN
                                                             ModuloBeneficiario ON Beneficiario.AutoId = ModuloBeneficiario.Beneficiario INNER JOIN
                                                             ModuloOperadora ON ModuloBeneficiario.Modulo = ModuloOperadora.AutoId INNER JOIN
                                                             Pessoa ON Beneficiario.Pessoa = Pessoa.AutoId INNER JOIN
                                                             VSF_Situacao_Benef ON Beneficiario.AutoId = VSF_Situacao_Benef.AutoId_Ben INNER JOIN
                                                             VSF_Situacao_Financeira ON Beneficiario.Contrato = VSF_Situacao_Financeira.Id_Cont LEFT JOIN
                                                             ModuloOperadoraInter ON ModuloOperadora.ProdutoIntercambio = ModuloOperadoraInter.AutoId LEFT JOIN
                                                             RedeRefClPrestador ON ModuloOperadora.AutoId = RedeRefClPrestador.ModuloOperadora LEFT JOIN
                                                             TipoRedeReferenciada ON RedeRefClPrestador.TipoRede = TipoRedeReferenciada.Codigo INNER JOIN
                                                             AbrangenciaGeografica ON ModuloOperadora.Abrangencia = AbrangenciaGeografica.Codigo INNER JOIN

						                                     -- Maior carteira com data de validade
						                                    (SELECT        Beneficiario.Codigo, max(CartaoIdentificacao.DataValidadeFinal) max_data
						                                    FROM            Beneficiario INNER JOIN
													                                    CartaoIdentificacao ON Beneficiario.AutoId = CartaoIdentificacao.Beneficiario
						                                    where  CartaoIdentificacao.Bloqueado=0
						                                    and Beneficiario.Codigo=@Cod_Ben
						                                    group by Beneficiario.Codigo)  Cartao ON    Cartao.Codigo = Beneficiario.Codigo 
																                                    and Cartao.max_data = CartaoIdentificacao.DataValidadeFinal   LEFT JOIN
						                                    -- fim

						                                    -- Maior data de Doença (CPT)
						                                    (SELECT        Beneficiario.Codigo, max(DoencaBeneficiario.FimVigencia) Data_CPT
						                                    FROM            Beneficiario INNER JOIN
													                                    DoencaBeneficiario ON Beneficiario.AutoId = DoencaBeneficiario.Beneficiario
						                                    WHERE      Beneficiario.Codigo=@Cod_Ben
						                                    group by  Beneficiario.Codigo) AS CPT ON CPT.Codigo = Beneficiario.Codigo
						                                    -- fim

                                    where    ModuloBeneficiario.FimVigencia is null
                                    and CartaoIdentificacao.Bloqueado=0
                                    and ModuloOperadora.Tipo=1
                                    and Beneficiario.tipo<>9
                                    and Beneficiario.Codigo=@Cod_Ben");

                SqlParameter parametercodigo = new SqlParameter("@Cod_Ben", autoIdBoleto);
                command.Parameters.Add(parametercodigo);

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

        public IList<DadosCarteiraProvisoria> ObterTodos(bool lazy)
        {
            //IDataReader dataReaderTmp;
            IList<DadosCarteiraProvisoria> listaObjetosPesquisados = null;
            DadosCarteiraProvisoria objetoPesquisado = new DadosCarteiraProvisoria();
            IDbCommand command = null;
            int qtdRegistro = 100;
            StringBuilder filtros;
            bool where = false;
            //Montar o Comando
            if (objetoPesquisado != null)
            {
                filtros = new StringBuilder();

                //Filtros


                //Se foi passado algun filtro
                if (where)
                {
                    command = new SqlCommand(@"Select TOP " + qtdRegistro.ToString() + " * From DadosCarteiraProvisoria WHERE ");
                }
                else
                {
                    command = new SqlCommand(@"Select TOP " + qtdRegistro.ToString() + " * From DadosCarteiraProvisoria");

                }

                //Concatena a string
                command.CommandText += filtros.ToString();

            }


            //Executando a pesquisa
            try
            {
                //dataReaderTmp = GerenciadorConexaoBanco.GetInstancia(EnumTipoBanco.SqlServer).ExecutarConsulta(command);
                listaObjetosPesquisados = GerenciadorConexaoBanco.GetInstancia(EnumTipoBanco.SqlServer).ExecutarConsultaList(command, objetoPesquisado, lazy);
            }
            catch (Exception)
            {
                throw;
            }

            //Tratando   o Retorno 
            //listaObjetosPesquisados = MontarListaObjetosDoReader(dataReaderTmp, objetoPesquisado, lazy);

            return listaObjetosPesquisados;
        }

        public IList<DadosCarteiraProvisoria> ObterTodos(DadosCarteiraProvisoria objetoPesquisado, bool lazy)
        {
            //IDataReader dataReaderTmp;
            IList<DadosCarteiraProvisoria> listaObjetosPesquisados = null;
            IDbCommand command = null;
            int qtdRegistro = 100;
            StringBuilder filtros;
            bool where = false;
            //Montar o Comando
            if (objetoPesquisado != null)
            {
                filtros = new StringBuilder();


                //Filtros
                if (objetoPesquisado.Cod_Ben != null)
                {
                    filtros.Append("Propiedade = " + objetoPesquisado.Cod_Ben);
                    where = true;
                }


                //Se foi passado algun filtro
                if (where)
                {
                    command = new SqlCommand(@"Select TOP " + qtdRegistro.ToString() + " * From DadosCarteiraProvisoria WHERE ");
                }
                else
                {
                    command = new SqlCommand(@"Select TOP " + qtdRegistro.ToString() + " * From DadosCarteiraProvisoria");

                }

                //Concatena a string
                command.CommandText += filtros.ToString();

            }


            //Executando a pesquisa
            try
            {
                //dataReaderTmp = GerenciadorConexaoBanco.GetInstancia(EnumTipoBanco.SqlServer).ExecutarConsulta(command);
                listaObjetosPesquisados = GerenciadorConexaoBanco.GetInstancia(EnumTipoBanco.SqlServer).ExecutarConsultaList(command, objetoPesquisado, lazy);
            }
            catch (Exception)
            {
                throw;
            }

            //Tratando   o Retorno 
            //listaObjetosPesquisados = MontarListaObjetosDoReader(dataReaderTmp, objetoPesquisado, lazy);

            return listaObjetosPesquisados;
        }

    }
}