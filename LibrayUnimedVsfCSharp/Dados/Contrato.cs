using System;

namespace Dados
{
    public class Contrato
    {
        private int _autoId;
        private long _codigo;
        private Pessoa _contratante;
        private DateTime? _dataProposta;
        private DateTime? _dataEnvio;
        private DateTime? _dataAssinatura;
        private DateTime? _dataParecer;
        private DateTime? _inicioVigencia;
        private ContratoFinanceiro _contratoFinanceiro;
            
        public Contrato()
        {
        }

        public virtual int AutoId
        {
            get { return _autoId; }
            set { _autoId = value; }
        }

        public virtual long Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }

        public virtual Pessoa Contratante
        {
            get { return _contratante; }
            set { _contratante = value; }
        }

        public virtual DateTime? DataProposta
        {
            get { return _dataProposta; }
            set { _dataProposta = value; }
        }

        public virtual DateTime? DataEnvio
        {
            get { return _dataEnvio; }
            set { _dataEnvio = value; }
        }

        public virtual DateTime? DataAssinatura
        {
            get { return _dataAssinatura; }
            set { _dataAssinatura = value; }
        }

        public virtual DateTime? DataParecer
        {
            get { return _dataParecer; }
            set { _dataParecer = value; }
        }

        public virtual DateTime? InicioVigencia
        {
            get { return _inicioVigencia; }
            set { _inicioVigencia = value; }
        }

        public virtual ContratoFinanceiro ContratoFinanceiro
        {
            get { return _contratoFinanceiro; }
            set { _contratoFinanceiro = value; }
        }
    }
}