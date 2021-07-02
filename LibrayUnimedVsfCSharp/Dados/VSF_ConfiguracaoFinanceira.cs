using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dados
{
    public class VSF_ConfiguracaoFinanceira
    {

        private decimal _percentualJuros;
        private decimal _percentualMulta;
        private int _limiteDiasVencido;
        private int _qtdOpcoesVencimento;
        private string _instrucoesBoleto;

        public VSF_ConfiguracaoFinanceira()
        {
        }


        public virtual decimal PercentualJuros
        {
            get { return _percentualJuros; }
            set { _percentualJuros = value; }
        }

        public virtual decimal PercentualMulta
        {
            get { return _percentualMulta; }
            set { _percentualMulta = value; }
        }

        public virtual int LimiteDiasVencido
        {
            get { return _limiteDiasVencido; }
            set { _limiteDiasVencido = value; }
        }

        public virtual int QtdOpcoesVencimento
        {
            get { return _qtdOpcoesVencimento; }
            set { _qtdOpcoesVencimento = value; }
        }

        public virtual string InstrucoesBoleto
        {
            get { return _instrucoesBoleto; }
            set { _instrucoesBoleto = value; }
        }

    }
}
