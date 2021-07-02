using System;

namespace Dados
{
    public class BoletoCobranca
    {
        private int _autoId;
        private string _contrato;
        private string _contratante;
        private int _autoIdDocFinan;
        private string _numeroDocumento;
        private string _compFin;
        private DateTime _dataVencimento;
        private decimal _valorDocumento;
        private decimal _valorPago;
        private DateTime _dataPagamento;
        private string _situacaoContrato;
        private int _diasAtraso;
        private string _historico;
        private string _situacaoDocFinan;
        private string _nossoNumero;

        public BoletoCobranca()
        {
        }


        public virtual int AutoId
        {
            get { return _autoId; }
            set { _autoId = value; }
        }

        public virtual string Contrato
        {
            get { return _contrato; }
            set { _contrato = value; }
        }

        public virtual string Contratante
        {
            get { return _contratante; }
            set { _contratante = value; }
        }

        public virtual int AutoIdDocFinan
        {
            get { return _autoIdDocFinan; }
            set { _autoIdDocFinan = value; }
        }

        public virtual string NumeroDocumento
        {
            get { return _numeroDocumento; }
            set { _numeroDocumento = value; }
        }

        public virtual string CompFin
        {
            get { return _compFin; }
            set { _compFin = value; }
        }

        public virtual DateTime DataVencimento
        {
            get { return _dataVencimento; }
            set { _dataVencimento = value; }
        }

        public virtual decimal ValorDocumento
        {
            get { return _valorDocumento; }
            set { _valorDocumento = value; }
        }

        public virtual int DiasAtraso
        {
            get { return _diasAtraso; }
            set { _diasAtraso = value; }
        }

        public virtual decimal ValorPago
        {
            get { return _valorPago; }
            set { _valorPago = value; }
        }

        public virtual DateTime DataPagamento
        {
            get { return _dataPagamento; }
            set { _dataPagamento = value; }
        }

        public virtual string SituacaoContrato
        {
            get { return _situacaoContrato; }
            set { _situacaoContrato = value; }
        }

        public virtual string Historico
        {
            get { return _historico; }
            set { _historico = value; }
        }

        public virtual string SituacaoDocFinan
        {
            get { return _situacaoDocFinan; }
            set { _situacaoDocFinan = value; }
        }

        public virtual string NossoNumero
        {
            get { return _nossoNumero; }
            set { _nossoNumero = value; }
        }
    }
}