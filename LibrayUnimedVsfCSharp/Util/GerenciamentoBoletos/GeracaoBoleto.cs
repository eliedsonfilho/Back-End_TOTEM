using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using Util.TratamentoErros;

namespace Util.GerenciamentoBoletos
{
    public class GeracaoBoleto
    {/*
        private Dados.Titulo _titulo;
        private Dados.Pessoa _sacado;
        private Dados.ContaBanco _contaBanco;
        private Dados.MovimentoFinanceiro _movimentoFinanceiro;
        private BoletoNet.Boleto _boleto;
        
        public GeracaoBoleto()
        {

        }

        public GeracaoBoleto(Dados.Titulo titulo, Dados.Pessoa sacado, Dados.ContaBanco contaBanco)
        {
            _titulo = titulo;
            _sacado = sacado;
            _contaBanco = contaBanco;
        }

        public GeracaoBoleto(Dados.MovimentoFinanceiro movimentoFinanceiro, Dados.Pessoa sacado, Dados.ContaBanco contaBanco)
        {
            _movimentoFinanceiro = movimentoFinanceiro;
            _sacado = sacado;
            _contaBanco = contaBanco;
        }
        

        public Dados.Titulo Titulo
        {
            private get { return _titulo; }
            set { _titulo = value; }
        }

        public Dados.Pessoa Sacado
        {
            private get { return _sacado; }
            set { _sacado = value; }
        }

        public Dados.ContaBanco ContaBanco
        {
            private get { return _contaBanco; }
            set { _contaBanco = value; }
        }

        public virtual Dados.MovimentoFinanceiro MovimentoFinanceiro
        {
            private get { return _movimentoFinanceiro; }
            set { _movimentoFinanceiro = value; }
        }


        //TODO: Verificar qual ContaBanco irá gerar o boleto
        //TODO: Falta dados
        public string GerarBoleto()
        {
            string caminhoArquivo = string.Empty;

            List<BoletoNet.BoletoBancario> listaBoletosBancario = new List<BoletoNet.BoletoBancario>();
            listaBoletosBancario.Add(CriarBoleto());
            caminhoArquivo = GeraLayout(listaBoletosBancario);

            //GeraBoletoCaixa(1);

            return caminhoArquivo;
        }

        public string GerarBoletos()
        {
            string caminhoArquivo = string.Empty;
            List<BoletoNet.BoletoBancario> listaBoletosBancario = new List<BoletoNet.BoletoBancario>();
            foreach (Dados.Titulo titulo in MovimentoFinanceiro.ListaTitulos)
            {
                _titulo = titulo;
                listaBoletosBancario.Add(CriarBoleto());
            }

            caminhoArquivo = GeraLayout(listaBoletosBancario);

            return caminhoArquivo;
        }

        private BoletoNet.BoletoBancario CriarBoleto()
        {
            BoletoNet.BoletoBancario boletoBancario;
            try
            {
                if (_titulo == null)
                {
                    throw new Exception("Não há um Título para o Boleto!");
                }

                if (ContaBanco == null)
                {
                    throw new Exception("Não há uma Conta Banco para o Boleto!");
                }

                if (ContaBanco.Titular == null)
                {
                    throw new Exception("Não há um Cedente para o Boleto!");
                }

                if (_sacado == null)
                {
                    throw new Exception("Não há um Sacado para o Boleto!");
                }

                _boleto = new BoletoNet.Boleto();

                Dados.Pagamento pagamento = _titulo.ListaPagamentos[0] as Dados.Pagamento;
                if (pagamento != null && pagamento.FormaPagamento != null)
                {
                    _boleto.Aceite = pagamento.FormaPagamento.Aceite == Dados.EnumAceiteFormaPagamento.Sim ? "S" : "N";
                    _boleto.Carteira = pagamento.FormaPagamento.Carteira;
                    _boleto.LocalPagamento = pagamento.FormaPagamento.LocalPagamento;
                }
                
                _boleto.Abatimento = _titulo.Desconto.GetValueOrDefault();
                _boleto.Cedente = CriarCedente(ContaBanco.Titular);
                _boleto.ContaBancaria = _boleto.Cedente.ContaBancaria;
                BoletoNet.IInstrucao instrucao = CriarInstrucao(ContaBanco);
                instrucao.Descricao = _titulo.Historico;
                _boleto.Instrucoes.Add(instrucao);
                _boleto.Banco = instrucao.Banco;
                _boleto.DataDocumento = _titulo.DataEmissao;
                _boleto.DataProcessamento = _titulo.DataEmissao;
                _boleto.DataVencimento = _titulo.DataVencimento;
                _boleto.JurosMora = _titulo.JurosTaxas.GetValueOrDefault();
                _boleto.NossoNumero = _titulo.NossoNumero;
                _boleto.NumeroDocumento = _titulo.Documento;
                _boleto.PercMulta = _titulo.Multa.GetValueOrDefault();
                _boleto.Sacado = CriarSacado(_sacado);
                _boleto.ValorBoleto = _titulo.Valor;

                //_boleto.FormataCampos();
                _boleto.Valida();

                boletoBancario = new BoletoNet.BoletoBancario();
                boletoBancario.CodigoBanco = Convert.ToInt16(ContaBanco.Agencia.Banco.CodigoCompensacao);
                boletoBancario.Boleto = _boleto;
            }
            catch (Exception exception)
            {
                string erro = TratamentoExcecoes.TratarRecursaoExcecao(exception);
                throw new Exception(erro);
            }

            return boletoBancario;
        }

        public void GeraBoletoBradesco(int qtde)
        {
            List<BoletoNet.BoletoBancario> boletos = new List<BoletoNet.BoletoBancario>();
            for (int i = 0; i < qtde; i++)
            {
                BoletoNet.BoletoBancario bb = new BoletoNet.BoletoBancario();
                bb.CodigoBanco = 237;

                DateTime vencimento = new DateTime(2007, 9, 10);
                BoletoNet.Instrucao_Bradesco item = new BoletoNet.Instrucao_Bradesco(9, 5);

                BoletoNet.Cedente c = new BoletoNet.Cedente("00.000.000/0000-00", "Empresa de Atacado", "1234", "5", "123456", "7");
                c.Codigo = 13000;

                BoletoNet.Endereco end = new BoletoNet.Endereco();
                end.Bairro = "Lago Sul";
                end.CEP = "71666660";
                end.Cidade = "Brasília- DF";
                end.Complemento = "Quadra XX Conjunto XX Casa XX";
                end.End = "Condominio de Brasilia - Quadra XX Conjunto XX Casa XX";
                end.Logradouro = "Cond. Brasilia";
                end.Numero = "55";
                end.UF = "DF";

                BoletoNet.Boleto b = new BoletoNet.Boleto(vencimento, 1.01m, "02", "01000000001", c);
                b.NumeroDocumento = "01000000001";

                b.Sacado = new BoletoNet.Sacado("000.000.000-00", "Eduardo Frare");
                b.Sacado.Endereco = end;

                item.Descricao += " após " + item.QuantidadeDias.ToString() + " dias corridos do vencimento.";
                b.Instrucoes.Add(item); //"Não Receber após o vencimento");

                bb.Boleto = b;
                bb.Boleto.Valida();

                boletos.Add(bb);
            }

            GeraLayout(boletos);
        }

        private string GeraLayout(List<BoletoNet.BoletoBancario> boletos)
        {
            StringBuilder html = new StringBuilder();
            foreach (BoletoNet.BoletoBancario boletoBancario in boletos)
            {
                html.Append(boletoBancario. MontaHtml());
                html.Append("</br></br></br></br></br>");
            }
            
            string arquivo = Path.GetTempFileName();
            arquivo = Path.ChangeExtension(arquivo, "html");
            using (FileStream f = new FileStream(arquivo, FileMode.Create))
            {
                StreamWriter w = new StreamWriter(f, Encoding.Default);
                w.Write(html.ToString());
                w.Close();
                f.Close();
            }

            string path = HttpContext.Current.Server.MapPath(@"~/Boletos/");
            Directory.CreateDirectory(path);
            File.Copy(arquivo, path + Path.GetFileName(arquivo));

            File.Delete(arquivo);
            arquivo = path + Path.GetFileName(arquivo);

            CriarArquivo.CriarPdf(arquivo);

            CriarArquivo.ExluirArquivo(Path.ChangeExtension(arquivo, "tmp"));
            CriarArquivo.ExluirArquivo(Path.ChangeExtension(arquivo, "html"));
            CriarArquivo.ExluirArquivo(Path.ChangeExtension(arquivo, "bmp"));
            
            arquivo = Path.ChangeExtension(arquivo, "pdf");

            return arquivo;
        }

        //TODO: Falta dados
        private BoletoNet.Cedente CriarCedente(Dados.Pessoa pessoa)
        {
            BoletoNet.Cedente cedente = new BoletoNet.Cedente();
            cedente.CPFCNPJ = pessoa.CpfCnpj;
            cedente.Codigo = pessoa.PessoaId;
            cedente.Nome = pessoa.NomeRazaoSocial;

            if(_contaBanco != null)
            {
                cedente.ContaBancaria = CriarContaBancaria(_contaBanco);
            }

            //cedente.Carteira = 
            //cedente.Convenio
            //cedente.DigitoCedente
            //cedente.NumeroBordero
            //cedente.NumeroSequencial
            
            return cedente;
        }

        //TODO: Falta dados
        private BoletoNet.Sacado CriarSacado(Dados.Pessoa pessoa)
        {
            BoletoNet.Sacado sacado = new BoletoNet.Sacado();
            sacado.CPFCNPJ = pessoa.CpfCnpj;
            sacado.Nome = pessoa.NomeRazaoSocial;

            if(pessoa.ListaEnderecos.Count > 0)
            {
                sacado.Endereco = CriarEndereco(pessoa.ListaEnderecos[0] as Dados.Endereco);
                
                if(pessoa.ListaEmails.Count > 0)
                {
                    sacado.Endereco.Email = (pessoa.ListaEmails[0] as Dados.Email).Descricao;
                }
            }

            //sacado.InformacoesSacado = 

            return sacado;
        }

        //TODO: Falta dados
        private BoletoNet.ContaBancaria CriarContaBancaria(Dados.ContaBanco contaBanco)
        {
            BoletoNet.ContaBancaria contaBancaria = new BoletoNet.ContaBancaria();

            if (contaBanco.Agencia != null)
            {
                contaBancaria.Agencia = contaBanco.Agencia.NumeroAgencia.Substring(0, contaBanco.Agencia.NumeroAgencia.Length -1);
                contaBancaria.DigitoAgencia = contaBanco.Agencia.NumeroAgencia.Substring(contaBanco.Agencia.NumeroAgencia.Length - 1);
            }

            contaBancaria.Conta = contaBanco.NumeroConta.Substring(0, contaBanco.NumeroConta.Length - 1);
            contaBancaria.DigitoConta = contaBanco.NumeroConta.Substring(contaBanco.NumeroConta.Length - 1);
            //contaBancaria.OperacaConta

            return contaBancaria;
        }

        //TODO: Falta dados
        private BoletoNet.Endereco CriarEndereco(Dados.Endereco endereco)
        {
            BoletoNet.Endereco enderecoBoleto = new BoletoNet.Endereco();
            
            if(endereco.Logradouro != null)
            {
                enderecoBoleto.CEP = endereco.Logradouro.Cep;
                enderecoBoleto.End = endereco.Logradouro.Descricao;

                if (endereco.Logradouro.Bairro != null)
                {
                    enderecoBoleto.Bairro = endereco.Logradouro.Bairro.Descricao;

                    if (endereco.Logradouro.Bairro.Cidade != null)
                    {
                        enderecoBoleto.Cidade = endereco.Logradouro.Bairro.Cidade.Descricao;

                        if (endereco.Logradouro.Bairro.Cidade.UnidadeFederativa != null)
                        {
                            enderecoBoleto.UF = endereco.Logradouro.Bairro.Cidade.UnidadeFederativa.Sigla;
                        }
                    }    
                }
            }
            
            enderecoBoleto.Complemento = endereco.Complemento;
            //enderecoBoleto.Email = 
            enderecoBoleto.Numero = endereco.Numero;
            
            return enderecoBoleto;
        }

        private BoletoNet.IInstrucao CriarInstrucao(Dados.ContaBanco contaBanco)
        {
            BoletoNet.IInstrucao instrucao;
            switch (Convert.ToInt32(contaBanco.Agencia.Banco.CodigoCompensacao))
            {
                    //104 - Caixa
                case 104:
                    instrucao = new BoletoNet.Instrucao_Caixa();
                    break;
                    //341 - Itaú
                case 341:
                    instrucao = new BoletoNet.Instrucao_Itau();
                    break;
                    //356 - Real
                case 275:
                case 356:
                    instrucao = new BoletoNet.Instrucao_Real();
                    break;
                    //422 - Safra
                case 422:
                    instrucao = new BoletoNet.Instrucao_Safra();
                    break;
                    //237 - Bradesco
                case 237:
                    instrucao = new BoletoNet.Instrucao_Bradesco();
                    break;
                    //347 - Sudameris
                case 347:
                    instrucao = new BoletoNet.Instrucao_Sudameris();
                    break;
                    //353 - Santander
                case 353:
                    instrucao = new BoletoNet.Instrucao_Santander();
                    break;
                    //070 - BRB
                case 70:
                    instrucao = new BoletoNet.Instrucao_BRB();
                    break;
                    //479 - BankBoston
                case 479:
                    instrucao = new BoletoNet.Instrucao_BankBoston();
                    break;
                    //001 - Banco do Brasil
                case 1:
                    instrucao = new BoletoNet.Instrucao_BancoBrasil();
                    break;
                    //399 - HSBC
                case 399:
                    instrucao = new BoletoNet.Instrucao(399);
                    break;
                    //003 - HSBC
                case 3:
                    instrucao = new BoletoNet.Instrucao(3);
                    break;
                    //409 - Unibanco
                case 409:
                    instrucao = new BoletoNet.Instrucao(409);
                    break;
                    //33 - Unibanco
                case 33:
                    instrucao = new BoletoNet.Instrucao_Santander();
                    break;
                    //41 - Banrisul
                case 41:
                    instrucao = new BoletoNet.Instrucao_Banrisul();
                    break;
                    //756 - Sicoob (Bancoob)
                case 756:
                    instrucao = new BoletoNet.Instrucao(756);
                    break;
                default:
                    throw new Exception("Código do banco não implementando: " + contaBanco.Agencia.Banco.CodigoCompensacao);
            }

            return instrucao;
        }
      */
    }
}