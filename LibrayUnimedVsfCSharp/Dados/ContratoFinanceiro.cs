using System;

namespace Dados
{
    public class ContratoFinanceiro
    {
        private int _autoId;
        private long _codigo;
        
        public ContratoFinanceiro()
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
    }
}