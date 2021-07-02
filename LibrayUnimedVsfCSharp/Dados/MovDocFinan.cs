using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dados
{
    public class MovDocFinan
    {
        //Movimentacao Documento Financeiro
        private int _autoId;
        private int _docFinanceiro;
        private DateTime _dataMov;
        private int _tipo;
        private int _motivo;
        private string _complemento;
        private DateTime _dataCont;
        private string _telosRgUs;
        private DateTime _telosRgDt;
        private string _telosUpUs;
        private DateTime _telosUpDt;
        private string _telosCtrler;
        private int _tipoCompl;

        public MovDocFinan()
        {
        }

        public virtual int AutoId
        {
            get { return _autoId; }
            set { _autoId = value; }
        }

        public virtual int DocFinanceiro
        {
            get { return _docFinanceiro; }
            set { _docFinanceiro = value; }
        }

        public virtual DateTime DataMov
        {
            get { return _dataMov; }
            set { _dataMov = value; }
        }

        public virtual int Tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }

        public virtual int Motivo
        {
            get { return _motivo; }
            set { _motivo = value; }
        }

        public virtual DateTime DataCont
        {
            get { return _dataCont; }
            set { _dataCont = value; }
        }

        public virtual string Complemento
        {
            get { return _complemento; }
            set { _complemento = value; }
        }

        public virtual string TelosRgUs
        {
            get { return _telosRgUs; }
            set { _telosRgUs = value; }
        }

        public virtual DateTime TelosRgDt
        {
            get { return _telosRgDt; }
            set { _telosRgDt = value; }
        }

        public virtual string TelosUpUs
        {
            get { return _telosUpUs; }
            set { _telosUpUs = value; }
        }

        public virtual DateTime TelosUpDt
        {
            get { return _telosUpDt; }
            set { _telosUpDt = value; }
        }

        public virtual string TelosCtrler
        {
            get { return _telosCtrler; }
            set { _telosCtrler = value; }
        }

        public virtual int TipoCompl
        {
            get { return _tipoCompl; }
            set { _tipoCompl = value; }
        }
    
    }
}
