using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dados
{
    public class DadosBoletoCobranca
    {   
        //Boleto
        private int _autoId;
        private string _dataVencimento;
        private decimal _valorLiquido;
        private decimal _jurosMulta;
        private decimal _valorCobrado;
        private string _nossoNumero;
        private string _carteira;
        private string _banco;
        private string _agencia;
        private string _numeroConta;
        private string _numeroDocumento;
        private string _observacoes;
        //Cedente
        private string _codigoCedente;
        private string _nomeCedente;
        private string _cnpCedente;
        //Sacado
        private string _cnpSacado;
        private string _nomeSacado;
        private string _enderecoSacado;
        private string _bairroSacado;
        private string _cidadeSacado;
        private string _ufSacado;
        private string _cepSacado;


        public DadosBoletoCobranca()
        {
        }

        public virtual int AutoId
        {
            get { return _autoId; }
            set { _autoId = value; }
        }

        public virtual string DataVencimento
        {
            get { return _dataVencimento; }
            set { _dataVencimento = value; }
        }

        public virtual decimal ValorLiquido
        {
            get { return _valorLiquido; }
            set { _valorLiquido = value; }
        }

        public virtual decimal JurosMulta
        {
            get { return _jurosMulta; }
            set { _jurosMulta = value; }
        }

        public virtual decimal ValorCobrado
        {
            get { return _valorCobrado; }
            set { _valorCobrado = value; }
        }

        public virtual string NossoNumero
        {
            get { return _nossoNumero; }
            set { _nossoNumero = value; }
        }

        public virtual string Carteira
        {
            get { return _carteira; }
            set { _carteira = value; }
        }

        public virtual string Banco
        {
            get { return _banco; }
            set { _banco = value; }
        }

        public virtual string Agencia
        {
            get { return _agencia; }
            set { _agencia = value; }
        }

        public virtual string NumeroConta
        {
            get { return _numeroConta; }
            set { _numeroConta = value; }
        }

        public virtual string NumeroDocumento
        {
            get { return _numeroDocumento; }
            set { _numeroDocumento = value; }
        }

        public virtual string Observacoes
        {
            get { return _observacoes; }
            set { _observacoes = value; }
        }

        public virtual string CodigoCedente
        {
            get { return _codigoCedente; }
            set { _codigoCedente = value; }
        }

        public virtual string NomeCedente
        {
            get { return _nomeCedente; }
            set { _nomeCedente = value; }
        }

        public virtual string CnpCedente
        {
            get { return _cnpCedente; }
            set { _cnpCedente = value; }
        }

        public virtual string CnpSacado
        {
            get { return _cnpSacado; }
            set { _cnpSacado = value; }
        }

        public virtual string NomeSacado
        {
            get { return _nomeSacado; }
            set { _nomeSacado = value; }
        }

        public virtual string EnderecoSacado
        {
            get { return _enderecoSacado; }
            set { _enderecoSacado = value; }
        }

        public virtual string BairroSacado
        {
            get { return _bairroSacado; }
            set { _bairroSacado = value; }
        }

        public virtual string CidadeSacado
        {
            get { return _cidadeSacado; }
            set { _cidadeSacado = value; }
        }

        public virtual string UfSacado
        {
            get { return _ufSacado; }
            set { _ufSacado = value; }
        }

        public virtual string CepSacado
        {
            get { return _cepSacado; }
            set { _cepSacado = value; }
        }
    }
}
