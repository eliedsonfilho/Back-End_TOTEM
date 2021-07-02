using System;

namespace Dados
{
    public class OpcaoVencimentoBoleto
    {
        private int _opcao;
        private DateTime _dataVencimento;
        private decimal _valorJuros;
        private decimal _valorTotal;

        public OpcaoVencimentoBoleto()
        {
        }

        public virtual int Opcao
        {
            get { return _opcao; }
            set { _opcao = value; }
        }

        public virtual DateTime DataVencimento
        {
            get { return _dataVencimento; }
            set { _dataVencimento = value; }
        }

        public virtual decimal ValorJuros
        {
            get { return _valorJuros; }
            set { _valorJuros = value; }
        }

        public virtual decimal ValorTotal
        {
            get { return _valorTotal; }
            set { _valorTotal = value; }
        }
    }
}