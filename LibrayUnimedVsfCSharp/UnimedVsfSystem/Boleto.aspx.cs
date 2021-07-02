using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web;
using Dados;
using Microsoft.VisualBasic;
using BoletoNet;
using Servicos;
using Util.TratamentoErros;

namespace UnimedVsfSystem
{
    public partial class Boleto : System.Web.UI.Page
    {
        private Servicos.ServicoDadosBoletoCobranca _servicoDadosBoletoCobranca;
        private Dados.DadosBoletoCobranca _dadosBoletoCobranca;
        
        private Servicos.ServicoVSF_ConfiguracaoFinanceira _servicoVsfConfiguracaoFinanceira;
        private Dados.VSF_ConfiguracaoFinanceira _vsfConfiguracaoFinanceira;
        
        private Servicos.ServicoBoletoCobranca _servicoBoletoCobranca;
        private Dados.BoletoCobranca _boletoCobranca;

        private Servicos.ServicoMovDocFinan _servicoMovDocFinan;


        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                this.Label1.Text = HttpContext.Current.Request.Url.LocalPath.ToString();

                if (!IsPostBack)
                {
                    if(String.IsNullOrEmpty(Request.QueryString["autoIdDocFin"]))
                    {
                        Response.Redirect("Erro.aspx");
                    }
                    int AutoIdDocFin = Convert.ToInt32(Request.QueryString["autoIdDocFin"]); 

                    _servicoDadosBoletoCobranca = new ServicoDadosBoletoCobranca();
                    _dadosBoletoCobranca = _servicoDadosBoletoCobranca.ObterPorDocFinanceiro(AutoIdDocFin, "TOTEM", null);
                    
                    _servicoVsfConfiguracaoFinanceira = new ServicoVSF_ConfiguracaoFinanceira();
                    _vsfConfiguracaoFinanceira = _servicoVsfConfiguracaoFinanceira.ObterVSF_ConfiguracaoFinanceira(true, "TOTEM", null);

                    _servicoBoletoCobranca = new ServicoBoletoCobranca();
                    _boletoCobranca = _servicoBoletoCobranca.ObterBoletoCobrancaPorId(_dadosBoletoCobranca.AutoId, true, "TOTEM", null);
                    
                    Banco Nomebanco = new Banco(Convert.ToInt32(_dadosBoletoCobranca.Banco));
                    _dadosBoletoCobranca.Observacoes = ObterObservacaoBoleto(_servicoBoletoCobranca.VerificaBoletoVencido(_boletoCobranca), Nomebanco.Nome.ToUpper());

                    //DADOS DO BANCO
                    string banco = _dadosBoletoCobranca.Banco;
                    string vencimento = Request.QueryString["vencimento"];
                    if(String.IsNullOrEmpty(vencimento))
                    {
                        Response.Redirect("Erro.aspx");
                    }
                    string valor = _dadosBoletoCobranca.ValorLiquido.ToString("N2");
                    string moramulta = Request.QueryString["moramulta"];
                    if (string.IsNullOrEmpty(moramulta))
                    {
                        Response.Redirect("Erro.aspx"); 
                    }

                    string valorcobrado = Request.QueryString["valorcobrado"]; //ObterValorCobrado(_servicoBoletoCobranca.VerificaBoletoVencido(_boletoCobranca), Request.QueryString["valorcobrado"]);
                    if (string.IsNullOrEmpty(valorcobrado))
                    {
                        Response.Redirect("Erro.aspx");
                    }
                    
                    
                    string nossonumero = _dadosBoletoCobranca.NossoNumero;
                    string numerodocumento = _dadosBoletoCobranca.NumeroDocumento;
                    string carteira = _dadosBoletoCobranca.Carteira;

                    //DADOS DO CEDENTE
                    string cnpcedente = _dadosBoletoCobranca.CnpCedente;
                    string codigocedente = _dadosBoletoCobranca.CodigoCedente;
                    string nomecedente = _dadosBoletoCobranca.NomeCedente;
                    string agenciacedente = _dadosBoletoCobranca.Agencia;
                    string contacedente = _dadosBoletoCobranca.NumeroConta;
                    IList<string> instrucoes = new List<string>();
                    instrucoes.Add(_dadosBoletoCobranca.Observacoes);
                    instrucoes.Add("");//Quebra de Linha entre a Obersavaçoes do Boleto e a Instrução 
                    instrucoes.Add(_vsfConfiguracaoFinanceira.InstrucoesBoleto);
                    instrucoes.Add("");//Quebra de Linha entre a Obersavaçoes do Boleto e a Instrução 
                    instrucoes.Add("REFERÊNCIA: " + _boletoCobranca.CompFin);


                    //DADOS DO SACADO
                    string cnpsacado = _dadosBoletoCobranca.CnpSacado ?? "00000000000";
                    string nomesacado = _dadosBoletoCobranca.NomeSacado;
                    string enderecosacado = _dadosBoletoCobranca.EnderecoSacado ?? "";
                    string bairrosacado = _dadosBoletoCobranca.BairroSacado ?? "";
                    string cidadesacado = _dadosBoletoCobranca.CidadeSacado ?? "";
                    string cepsacado = _dadosBoletoCobranca.CepSacado ?? "";
                    string ufsacado = _dadosBoletoCobranca.UfSacado ?? "" ;


                    //Remove dígito da Agência.
                    int DigAgencia = 0;
                    int Agencia = 0;
                    if (agenciacedente.IndexOf("-") > -1)
                    {
                        int s = agenciacedente.IndexOf("-") + 1;
                        int tam = Strings.Len(agenciacedente);
                        DigAgencia = Convert.ToInt32(Strings.Right(agenciacedente, tam - s));
                        int dif = tam - (s - 1);
                        //incluindo o traço.
                        Agencia = Convert.ToInt32(Strings.Left(agenciacedente, tam - dif));
                    }
                    else
                    {
                        int tam = Strings.Len(agenciacedente);
                        DigAgencia = Convert.ToInt32(Strings.Right(agenciacedente, 1));
                        Agencia = Convert.ToInt32(Strings.Left(agenciacedente, tam - 1));
                    }
                    //txtAgenciaCedente.Text

                    //Remove dígito da Conta.
                    int DigConta = 0;
                    int Conta = 0;
                    if (contacedente.IndexOf("-") > -1)
                    {
                        int s2 = contacedente.IndexOf("-") + 1;
                        int tam2 = Strings.Len(contacedente);
                        DigConta = Convert.ToInt32(Strings.Right(contacedente, tam2 - s2));
                        int dif2 = tam2 - (s2 - 1);
                        //incluindo o traço.
                        Conta = Convert.ToInt32(Strings.Left(contacedente, tam2 - dif2));
                    }
                    else
                    {
                        int tam2 = Strings.Len(contacedente);
                        DigConta = Convert.ToInt32(Strings.Right(contacedente, 1));
                        Conta = Convert.ToInt32(Strings.Left(contacedente, tam2 - 1));

                    }
                    //txtContaCedente.Text

                    //Remove dígito do Cedente.
                    int DigCedente = 0;
                    if (codigocedente.IndexOf("-") > -1)
                    {
                        int s3 = codigocedente.IndexOf("-") + 1;
                        int tam3 = Strings.Len(codigocedente);
                        DigCedente = Convert.ToInt32(Strings.Right(codigocedente, tam3 - s3));
                        int dif3 = tam3 - (s3 - 1);
                        //incluindo o traço.
                        codigocedente = Strings.Left(codigocedente, tam3 - dif3);
                    }
                    else
                    {
                        int tam3 = Strings.Len(codigocedente);
                        DigCedente = Convert.ToInt32(Strings.Right(codigocedente, 1));
                        codigocedente = Strings.Left(codigocedente, tam3 - 1);
                    }

                    //Validação.
                    switch (banco)
                    {
                        case "001":
                            //Banco do Brasil.

                            //Agência com 4 caracteres.
                            if (Strings.Len(Agencia) > 4)
                            {
                                Response.Write("A Agência deve conter até 4 dígitos.");
                                return;
                            }


                            //Conta com 8 caracteres.
                            if (Strings.Len(Conta) > 8)
                            {
                                Response.Write("A Conta deve conter até 8 dígitos.");
                                return;
                            }


                            //Cedente com 8 caracteres.
                            if (Strings.Len(codigocedente) > 8)
                            {
                                Response.Write("O Código do Cedente deve conter até 8 dígitos.");
                                return;
                            }


                            //Nosso Número deve ser 11 ou 17 dígitos.
                            if (Strings.Len(nossonumero) != 11 & Strings.Len(nossonumero) != 17)
                            {
                                Response.Write("O Nosso Número deve ter 11 ou 17 dígitos dependendo da Carteira.");
                                return;
                            }


                            break;

                        case "033":
                            //Santander.
                            break;

                        case "070":
                            //Banco BRB.
                            break;

                        case "104":
                            //Caixa Econômica Federal.
                            break;

                        case "237":
                            //Banco Bradesco.
                            break;

                        case "275":
                            //Banco Real.

                            //Cedente 
                            if (!string.IsNullOrEmpty(Request["CodigoCedente"]))
                            {

                            }

                            //Cobrança registrada 7 dígitos.
                            //Cobrança sem registro até 13 dígitos.
                            if (Strings.Len(nossonumero) < 7 & Strings.Len(nossonumero) < 13)
                            {
                                Response.Write("O Nosso Número deve ser entre 7 e 13 caracteres.");
                                return;
                            }


                            //Carteira
                            if (carteira != "00" & carteira != "20" & carteira != "31" & carteira != "42" & carteira != "47" & carteira != "85" & carteira != "57")
                            {
                                Response.Write("A Carteira deve ser 00,20,31,42,47,57 ou 85.");
                                return;
                            }

                            //00'- Carteira do convênio
                            //20' - Cobrança Simples
                            //31' - Cobrança Câmbio
                            //42' - Cobrança Caucionada
                            //47' - Cobr. Caucionada Crédito Imobiliário
                            //85' - Cobrança Partilhada
                            //57 - última implementação ?

                            //Agência 4 dígitos.
                            if (Strings.Len(Agencia) > 4)
                            {
                                Response.Write("A Agência deve conter até 4 dígitos.");
                                return;
                            }

                            //Número da conta 6 dígitos.
                            if (Strings.Len(Conta) > 6)
                            {
                                Response.Write("A Conta Corrente deve conter até 6 dígitos.");
                                return;
                            }


                            break;
                        case "291":
                            //Banco BCN.
                            break;

                        case "341":
                            //Banco Itaú.
                            break;

                        case "347":
                            //Banco Sudameris.
                            break;

                        case "356":
                            //Banco Real.

                            //Cedente 
                            if (!string.IsNullOrEmpty(Request["CodigoCedente"]))
                            {
                            }
                            //?


                            //Cobrança registrada 7 dígitos.
                            //Cobrança sem registro até 13 dígitos.
                            if (Strings.Len(nossonumero) < 7 & Strings.Len(nossonumero) < 13)
                            {
                                Response.Write("O Nosso Número deve ser entre 7 e 13 caracteres.");
                                return;
                            }


                            //Carteira
                            if (carteira != "00" & carteira != "20" & carteira != "31" & carteira != "42" & carteira != "47" & carteira != "85" & carteira != "57")
                            {
                                Response.Write("A Carteira deve ser 00,20,31,42,47,57 ou 85.");
                                return;
                            }

                            //00'- Carteira do convênio
                            //20' - Cobrança Simples
                            //31' - Cobrança Câmbio
                            //42' - Cobrança Caucionada
                            //47' - Cobr. Caucionada Crédito Imobiliário
                            //85' - Cobrança Partilhada

                            //Agência 4 dígitos.
                            if (Strings.Len(Agencia) > 4)
                            {
                                Response.Write("A Agência deve conter até 4 dígitos.");
                                return;
                            }

                            //Número da conta 6 dígitos.
                            if (Strings.Len(Conta) > 6)
                            {
                                Response.Write("A Conta Corrente deve conter até 6 dígitos.");
                                return;
                            }


                            break;
                        case "409":
                            //Banco Unibanco.
                            break;

                        case "422":
                            //Banco Safra.
                            break;

                        case "748":
                            //Banco Sicredi.
                            break;

                        default:

                            break;
                    }

                    //Informa os dados do cedente
                    Cedente c = new Cedente(cnpcedente, nomecedente, Agencia.ToString(), DigAgencia.ToString(), Conta.ToString(), DigConta.ToString());

                    //Dependendo da carteira, é necessário informar o código do cedente (o banco que fornece)
                    c.Codigo = Convert.ToInt32(codigocedente);
                    c.DigitoCedente = Convert.ToInt32(DigCedente);

                    //Dados para preenchimento do boleto (data de vencimento, valor, carteira e nosso número)
                    BoletoNet.Boleto b = new BoletoNet.Boleto(Convert.ToDateTime(vencimento), Convert.ToDecimal(valor), carteira, nossonumero, c);

                    //Dependendo da carteira, é necessário o número do documento
                    b.NumeroDocumento = numerodocumento;
                    b.ValorCobrado = Convert.ToDecimal(valorcobrado);
                    b.ValorMulta = Convert.ToDecimal(moramulta);

                    //Informa os dados do sacado
                    b.Sacado = new Sacado(cnpsacado, nomesacado);
                    b.Sacado.Endereco.End = enderecosacado;
                    b.Sacado.Endereco.Bairro = bairrosacado;
                    b.Sacado.Endereco.Cidade = cidadesacado;
                    b.Sacado.Endereco.CEP = cepsacado;
                    b.Sacado.Endereco.UF = ufsacado;
                    
                    //Implementa Descrição do Boleto
                    switch (banco)
                    {
                        case "001"://Banco do Brasil.
                        case "033"://Santander.
                        case "070"://Banco BRB.
                        case "104"://Caixa Econômica Federal.
                        case "237"://Banco Bradesco.
                        case "275"://Banco Real.
                        case "291"://Banco BCN.
                        case "341"://Banco Itaú.
                        case "347"://Banco Sudameris.
                        case "356"://Banco Real.
                        case "409"://Banco Unibanco.
                        case "422"://Banco Safra.
                            {
                                IInstrucao i1;
                                foreach (string instru in instrucoes)
                                {
                                    i1 = new Instrucao(Convert.ToInt32(banco));
                                    i1.Descricao = instru;
                                    b.Instrucoes.Add(i1);
                                }
                                break;
                            }
                        default:
                            {
                                Instrucao_Santander i2;
                                foreach (string instrucao in instrucoes)
                                {
                                    i2 = new Instrucao_Santander();
                                    i2.Descricao = instrucao;
                                    b.Instrucoes.Add(i2);
                                }
                                break;
                            }
                    }
                    
                    
                    //Espécie do Documento - [R] Recibo
                    switch (banco)
                    {
                        case "001":
                            //Banco do Brasil.
                            b.EspecieDocumento = new EspecieDocumento_BancoBrasil(2);
                            break;
                        //Espécie.
                        //Cheque = 1, //CH – CHEQUE
                        //DuplicataMercantil = 2, //DM – DUPLICATA MERCANTIL
                        //DuplicataMercantilIndicacao = 3, //DMI – DUPLICATA MERCANTIL P/ INDICAÇÃO
                        //DuplicataServico = 4, //DS – DUPLICATA DE SERVIÇO
                        //DuplicataServicoIndicacao = 5, //DSI – DUPLICATA DE SERVIÇO P/ INDICAÇÃO
                        //DuplicataRural = 6, //DR – DUPLICATA RURAL
                        //LetraCambio = 7, //LC – LETRA DE CAMBIO
                        //NotaCreditoComercial = 8, //NCC – NOTA DE CRÉDITO COMERCIAL
                        //NotaCreditoExportacao = 9, //NCE – NOTA DE CRÉDITO A EXPORTAÇÃO
                        //NotaCreditoIndustrial = 10, //NCI – NOTA DE CRÉDITO INDUSTRIAL
                        //NotaCreditoRural = 11, //NCR – NOTA DE CRÉDITO RURAL
                        //NotaPromissoria = 12, //NP – NOTA PROMISSÓRIA
                        //NotaPromissoriaRural = 13, //NPR –NOTA PROMISSÓRIA RURAL
                        //TriplicataMercantil = 14, //TM – TRIPLICATA MERCANTIL
                        //TriplicataServico = 15, //TS – TRIPLICATA DE SERVIÇO
                        //NotaSeguro = 16, //NS – NOTA DE SEGURO
                        //Recibo = 17, //RC – RECIBO
                        //Fatura = 18, //FAT – FATURA
                        //NotaDebito = 19, //ND – NOTA DE DÉBITO
                        //ApoliceSeguro = 20, //AP – APÓLICE DE SEGURO
                        //MensalidadeEscolar = 21, //ME – MENSALIDADE ESCOLAR
                        //ParcelaConsorcio = 22, //PC – PARCELA DE CONSÓRCIO
                        //Outros = 23 //OUTROS

                        case "033":
                            //Santander.
                            b.EspecieDocumento = new EspecieDocumento_Santander(17);
                            break;
                        case "070":
                            //Banco BRB.
                            b.EspecieDocumento = new EspecieDocumento(17);
                            break;
                        case "104":
                            //Caixa Econômica Federal.
                            b.EspecieDocumento = new EspecieDocumento_Caixa(17);
                            break;
                        case "237":
                            //Banco Bradesco.
                            b.EspecieDocumento = new EspecieDocumento(17);
                            break;
                        case "275":
                            //Banco Real.
                            b.EspecieDocumento = new EspecieDocumento(17);
                            break;
                        case "291":
                            //Banco BCN.
                            b.EspecieDocumento = new EspecieDocumento(17);
                            break;
                        case "341":
                            //Banco Itaú.
                            b.EspecieDocumento = new EspecieDocumento_Itau(99);
                            break;
                        case "347":
                            //Banco Sudameris.
                            b.EspecieDocumento = new EspecieDocumento_Sudameris(17);
                            break;
                        case "356":
                            //Banco Real.
                            break;
                        //Não funciona com isso.
                        //b.EspecieDocumento = New EspecieDocumento_BancoBrasil(17)
                        //b.EspecieDocumento = New EspecieDocumento_Itau(99)
                        case "409":
                            //Banco Unibanco.
                            b.EspecieDocumento = new EspecieDocumento(17);
                            break;
                        case "422":
                            //Banco Safra.
                            b.EspecieDocumento = new EspecieDocumento(17);
                            break;
                        default:
                            //Banco de teste Santander.
                            b.EspecieDocumento = new EspecieDocumento_Santander(17);
                            break;
                    }


                    BoletoBancario bb = new BoletoBancario();
                    bb.CodigoBanco = Convert.ToInt16(banco);
                    //33 '-> Referente ao código do Santander
                    bb.Boleto = b;
                    //bb.MostrarCodigoCarteira = True
                    bb.Boleto.Valida();

                    //true -> Mostra o compravante de entrega
                    //false -> Oculta o comprovante de entrega
                    bb.MostrarComprovanteEntrega = false;

                    //Oculta Instrução de Impressao
                    bb.OcultarInstrucoes = true;

                    //Regra do valor cobrado (Vencido ou Não)
                    bb.Boleto.ValorCobrado = Convert.ToDecimal(ObterValorCobrado(_servicoBoletoCobranca.VerificaBoletoVencido(_boletoCobranca), Request.QueryString["valorcobrado"]));


                    panelBoleto.Controls.Clear();
                    if (panelBoleto.Controls.Count == 0)
                    {
                        panelBoleto.Controls.Add(bb);
                    }

                    /*string nomeArquivo =  AutoIdDocFin.ToString();
                    string path = HttpContext.Current.Server.MapPath(@"~/Boletos/");
                    Directory.CreateDirectory(path);

                    nomeArquivo = path + Path.GetFileName(nomeArquivo);
                    bb.MontaHtmlNoArquivoLocal(nomeArquivo);

                    CriarArquivo.CriarPdf(nomeArquivo);*/

                    return;
                }
            }
            catch (Exception ex)
            {
                PaginaErro(ex.Message);
            }
        }

        private void PaginaErro(string mensagem)
        {
            Response.Redirect("Erro.aspx?mensagem=" + mensagem);
        }

        //Obter mensagem de Observações do boleto especifica para o TOTEM
        private string ObterObservacaoBoleto(bool boletoVencido, string nomeBanco)
        {
            string mensagem;
            string multa = Math.Round((_vsfConfiguracaoFinanceira.PercentualMulta * 100), 0).ToString() + "%";
            string juros = Math.Round((_vsfConfiguracaoFinanceira.PercentualJuros*100)*30, 0).ToString() + "%";
            string limiteDias = _vsfConfiguracaoFinanceira.LimiteDiasVencido.ToString();

            if (boletoVencido)
            {   //mensagem para boletos vencidos(levando em consideração a escolha de um vencimento auternativo)
                mensagem = "PAG. QUALQUER AGENCIA BANCARIA. SR. CAIXA, NÃO RECEBER ESSE DOCUMENTO APÓS O VENCIMENTO";
            }
            else
            {   //mensagem para boletos NÃO vencidos(levando em consideração que NÃO foi feita escolha de um vencimento auternativo)
                mensagem = string.Format(@"PAG. QUALQUER AGENCIA BANCARIA ATE O SEU VENC. APOS VENC SOMENTE NO(A) {0}, MULTA " +
                   "{1} MAIS MORA DE {2} AM. SR. CAIXA, NÃO RECEBER APÓS {3} DIAS DO VENCIMENTO.", nomeBanco, multa, juros, limiteDias);
            }

            return mensagem;
        }

        //Obter valor cobrado para impressão no boleto
        private string ObterValorCobrado(bool boletoVencido, string valorCobrado)
        {
            string valor="0";
            if (string.IsNullOrEmpty(valorCobrado))
            {
                Response.Redirect("Erro.aspx");
            }
            else
            {
                if (boletoVencido)
                {   //Boleto vencido exibe o valor cobrado (impossibilitar alteração do valor) 
                    valor = valorCobrado;
                }
                else
                {   /*Boleto NÃO vencido não exibe valor cobrado (possibilita o operado do caixa 
                     * corrigir o valor caso o pagamento venha a acontecer após o vecimento)
                     */
                    valor = "0";

                }
            }

            return valor;
        }

        //Metodo de Impressão do lado do servidor
        protected void ImprimirBehind(object sender, EventArgs e)
        {
            //string path = HttpContext.Current.Server.MapPath(@"~/Boletos/");
            //Directory.CreateDirectory(path);

            //Excuta Metodo de registro de emissão na Tabela MovDocFinan
            GeraMovDocFinan(Convert.ToInt32(Request.QueryString["autoIdDocFin"]));
        }

        //Gerar Registro de Emissão na Tabela MovDocFinan
        private void GeraMovDocFinan(int autoIdDocFinan)
        {
            _servicoMovDocFinan = new ServicoMovDocFinan();

            _servicoMovDocFinan.InserirPorDocFinan(autoIdDocFinan);
        }

        //Retorna nome do computador que esta acessa
        private string NomeComputador()
        {
            string[] computer_name = System.Net.Dns.GetHostEntry(Request.ServerVariables["remote_addr"]).HostName.Split(new Char[] { '.' });
            String ecn = System.Environment.MachineName;
            return computer_name[0].ToString();
        }
    }
}