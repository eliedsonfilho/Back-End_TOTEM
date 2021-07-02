using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dados
{
    public class Feriado
    {
        private DateTime _dataFeriado;
        private String _descricao;

        public Feriado()
        {
        }

        public virtual DateTime DataFeriado
        {
            get { return _dataFeriado; }
            set { _dataFeriado = value; }
        }

        public virtual string Descricao
        {
            get { return _descricao; }
            set { _descricao = value; }
        }
    }
}
