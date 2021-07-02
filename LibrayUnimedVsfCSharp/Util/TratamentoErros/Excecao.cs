using System;

namespace Util.TratamentoErros
{
    public class Excecao : Exception
    {
        private int _tipo;
        private string _mensagem;
        private string _codigo;

        public Excecao()
        {
        }

        public virtual int Tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }

        public virtual string Mensagem
        {
            get { return _mensagem; }
            set { _mensagem = value; }
        }

        public virtual string Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }
    }
}