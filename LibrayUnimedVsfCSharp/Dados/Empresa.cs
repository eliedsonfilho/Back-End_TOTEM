using System;

namespace Dados
{
    public class Empresa
    {
        private int _codigo;
        private Pessoa _pessoa;
        private decimal _taxaAdm;
        private bool _usaDV;
        private bool _identaConta;
        private bool _temCCusto;
        
        public Empresa()
        {
        }

        public virtual int Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }

        public virtual Pessoa Pessoa
        {
            get { return _pessoa; }
            set { _pessoa = value; }
        }

        public virtual decimal TaxaAdm
        {
            get { return _taxaAdm; }
            set { _taxaAdm = value; }
        }

        public virtual bool UsaDv
        {
            get { return _usaDV; }
            set { _usaDV = value; }
        }

        public virtual bool IdentaConta
        {
            get { return _identaConta; }
            set { _identaConta = value; }
        }

        public virtual bool TemCCusto
        {
            get { return _temCCusto; }
            set { _temCCusto = value; }
        }
    }
}