using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Dados;

namespace Repositorios
{
    public class RepositorioDadosBoletoCobranca : Repositorio, IRepositorio<RepositorioDadosBoletoCobranca, int>
    {
        public DadosBoletoCobranca ObterPorDocFinanceiro(int autoIdDocFinanceiro, bool lazy)
        {
            IDbCommand command;
            //IDataReader dataReaderTmp;
            DadosBoletoCobranca objetoPesquisado = new DadosBoletoCobranca();

            //Executando a pesquisa
            try
            {
                command = new SqlCommand(@"SELECT TOP 1
                                            DadosBoleto.AutoIdBoleto AutoId,
		                                    DadosBoleto.DataVencimento,
		                                    DadosBoleto.ValorLiquido,
                                            NULL JurosMulta,
                                            NULL ValorCobrado,
		                                    DadosBoleto.NumeroDocumento,
		                                    DadosBoleto.NossoNumero,
		                                    DadosBoleto.Carteira,
		                                    DadosBoleto.Banco, 
		                                    DadosBoleto.Agencia,
		                                    DadosBoleto.NumeroConta,
                                            null Observacoes,		 
		                                    -------------------------
		                                    DadosCedente.CodigoCedente,
		                                    DadosCedente.CnpCedente,
		                                    DadosCedente.NomeCedente,
		                                    -------------------------
		                                    DadosSacado.CnpSacado,
		                                    DadosSacado.NomeSacado,
		                                    DadosSacado.EnderecoSacado,
		                                    DadosSacado.BairroSacado,
		                                    DadosSacado.CidadeSacado,
		                                    DadosSacado.UFSacado,
		                                    DadosSacado.CEPSacado
 
                                    FROM

	                                    -- Dados do Boleto --
	                                    (SELECT        BoletoCobranca.AutoId AutoIdBoleto, DocFinanceiro.AutoId AS DocFinAutoId, REPLICATE('0',(3 - LEN(CAST(AgenciaBancaria.Banco AS VARCHAR)))) + CAST(AgenciaBancaria.Banco AS VARCHAR) Banco, 
					                                    CONVERT(VARCHAR, DocFinanceiro.DataVencimento, 103) DataVencimento, DocFinanceiro.ValorLiquido, DocFinanceiro.Numero AS NumeroDocumento, BoletoCobranca.NossoNumero, 
							                                     'SR' AS Carteira, 
							                                     CASE WHEN LEN(AgenciaBancaria.Codigo) = 4 THEN 
								                                     CASE AgenciaBancaria.Banco 
								                                     WHEN '104' THEN AgenciaBancaria.Codigo + '8700'
								                                     WHEN '748' THEN AgenciaBancaria.Codigo + '016'
							                                     END
							                                     ELSE AgenciaBancaria.Codigo  END AS Agencia, 
							                                     ContaCorrente.Numero AS NumeroConta, LayoutBancario.Codigo AS CodigoLayout
	                                    FROM            DocFinanceiro INNER JOIN
							                                     BoletoCobranca ON DocFinanceiro.AutoId = BoletoCobranca.DocFinanceiro INNER JOIN
							                                     ContaCorrente ON BoletoCobranca.ContaCorrente = ContaCorrente.Codigo INNER JOIN
							                                     AgenciaBancaria ON ContaCorrente.AgenciaBancaria = AgenciaBancaria.AutoId INNER JOIN
							                                     NegociacaoBancaria ON BoletoCobranca.NegociacaoBancaria = NegociacaoBancaria.AutoId INNER JOIN
							                                     LayoutBancario ON NegociacaoBancaria.LayoutBancario = LayoutBancario.Codigo
	                                    WHERE        (DocFinanceiro.AutoId = @AutoIdDocFinan)) AS DadosBoleto LEFT OUTER JOIN 


	                                    -- Dados do Cedente --
	                                    (SELECT        DefLayoutBancario.LayoutBancario, MAX(ConvenioBanco.CodigoConvenio) AS CodigoCedente, Pessoa.Nome AS NomeCedente, Pessoa.Cnp CnpCedente
	                                    FROM            DefLayoutBancario INNER JOIN
							                                     ConvenioDefLayoutBancario ON DefLayoutBancario.AutoId = ConvenioDefLayoutBancario.DefLayoutBancario INNER JOIN
							                                     ConvenioBanco ON ConvenioDefLayoutBancario.ConvenioBanco = ConvenioBanco.AutoId,
							                                     ConfigOperadora INNER JOIN
							                                     PrestadorServico ON ConfigOperadora.EstaOperadora = PrestadorServico.AutoId INNER JOIN
							                                     Pessoa ON PrestadorServico.Pessoa = Pessoa.AutoId
	                                    WHERE  (DefLayoutBancario.ClasseDocFinanceiro = 2) AND (DefLayoutBancario.Tipo = 2)
	                                    GROUP BY DefLayoutBancario.LayoutBancario, Pessoa.Nome, Pessoa.Cnp) AS DadosCedente ON DadosBoleto.CodigoLayout = DadosCedente.LayoutBancario  LEFT OUTER JOIN



	                                    -- Dados do Sacado --
	                                    (SELECT Sacado.*, MaxEnd.* FROM

										(SELECT        DocFinanceiro.AutoId AS DocFinAutoId, Pessoa.Cnp AS CnpSacado, Pessoa.Nome AS NomeSacado, Pessoa.AutoId AS AutoIdPessoa1
										FROM            DocFinanceiro INNER JOIN
																	ContratoFinanceiro ON DocFinanceiro.ContratoFinanceiro = ContratoFinanceiro.AutoId INNER JOIN
																	Pessoa ON ContratoFinanceiro.Pessoa = Pessoa.AutoId
										WHERE        (DocFinanceiro.AutoId = @AutoIdDocFinan)) Sacado LEFT OUTER JOIN

										(SELECT EnderecoPessoa.Logradouro + ', ' + EnderecoPessoa.NumLogradouro + ' ' + EnderecoPessoa.ComplLogradouro AS EnderecoSacado, EnderecoPessoa.Bairro BairroSacado, 
																										CidadePais.Nome AS CidadeSacado, CidadePais.UF AS UfSacado, EnderecoPessoa.CEP AS CepSacado, Pessoa.AutoId AutoIdPessoa2
																				FROM            DocFinanceiro INNER JOIN
																											ContratoFinanceiro ON DocFinanceiro.ContratoFinanceiro = ContratoFinanceiro.AutoId INNER JOIN
																											Pessoa ON ContratoFinanceiro.Pessoa = Pessoa.AutoId LEFT OUTER JOIN
																											EnderecoPessoa ON Pessoa.AutoId = EnderecoPessoa.Pessoa INNER JOIN
																											CidadePais ON EnderecoPessoa.Cidade = CidadePais.Codigo
																				WHERE        (DocFinanceiro.AutoId = @AutoIdDocFinan)

											AND EnderecoPessoa.AutoId IN (SELECT MAX(EnderecoPessoa.AutoId) AutoId
																				FROM            DocFinanceiro INNER JOIN
																											ContratoFinanceiro ON DocFinanceiro.ContratoFinanceiro = ContratoFinanceiro.AutoId INNER JOIN
																											Pessoa ON ContratoFinanceiro.Pessoa = Pessoa.AutoId LEFT OUTER JOIN
																											EnderecoPessoa ON Pessoa.AutoId = EnderecoPessoa.Pessoa
																				WHERE        (DocFinanceiro.AutoId = @AutoIdDocFinan)
																				AND (EnderecoPessoa.FimVigencia IS NULL) AND (EnderecoPessoa.ParaCobranca = 1))
										) MaxEnd ON Sacado.AutoIdPessoa1 = MaxEnd.AutoIdPessoa2)  AS DadosSacado ON DadosBoleto.DocFinAutoId = DadosSacado.DocFinAutoId");

                SqlParameter parAutoIdDocFian = new SqlParameter("@AutoIdDocFinan", autoIdDocFinanceiro);
                command.Parameters.Add(parAutoIdDocFian);

                //dataReaderTmp = GeranciadorConexaoBanco.GetInstancia(EnumTipoBanco.SqlServer).executarConsulta(command);
                objetoPesquisado = GerenciadorConexaoBanco.GetInstancia(EnumTipoBanco.SqlServer).ExecutarConsultaObject(command, objetoPesquisado, lazy);

            }
            catch (Exception)
            {

                throw;
            }

            return objetoPesquisado;
        }

        public RepositorioDadosBoletoCobranca ObterPorId(int autoIdBoleto, bool lazy)
        {
            throw new NotImplementedException();
        }

        public IList<RepositorioDadosBoletoCobranca> ObterTodos(bool lazy)
        {
            throw new NotImplementedException();
        }

        public IList<RepositorioDadosBoletoCobranca> ObterTodos(RepositorioDadosBoletoCobranca objectPesquisado, bool lazy)
        {
            throw new NotImplementedException();
        }
    }
}
