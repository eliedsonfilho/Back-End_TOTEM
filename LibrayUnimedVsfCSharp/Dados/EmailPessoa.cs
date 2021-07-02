using System;

namespace Dados
{
    public class EmailPessoa
    {
        private int _autoId;
        private Pessoa _pessoa;
        private short _seq;
        private string _email;
        private DateTime? _inicioVigencia;
        private DateTime? _fimVigencia;

        public EmailPessoa()
        {
        }

        public virtual int AutoId
        {
            get { return _autoId; }
            set { _autoId = value; }
        }

        public virtual Pessoa Pessoa
        {
            get { return _pessoa; }
            set { _pessoa = value; }
        }

        public virtual short Seq
        {
            get { return _seq; }
            set { _seq = value; }
        }

        public virtual string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public virtual DateTime? InicioVigencia
        {
            get { return _inicioVigencia; }
            set { _inicioVigencia = value; }
        }

        public virtual DateTime? FimVigencia
        {
            get { return _fimVigencia; }
            set { _fimVigencia = value; }
        }
    }
}