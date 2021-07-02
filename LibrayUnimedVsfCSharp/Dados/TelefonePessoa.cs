using System;

namespace Dados
{
    public class TelefonePessoa
    {
        private int _autoId;
        private Pessoa _pessoa;
        private short _seq;
        private TipoTelefone _tipo;
        private TipoEndereco _tipoEndereco;
        private EnderecoPessoa _endereco;
        private short _dDI;
        private short _dDD;
        private string _numero;
        private string _ramal;
        private DateTime? _inicioVigencia;
        private DateTime? _fimVigencia;

        public TelefonePessoa()
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

        public virtual TipoTelefone Tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }

        public virtual TipoEndereco TipoEndereco
        {
            get { return _tipoEndereco; }
            set { _tipoEndereco = value; }
        }

        public virtual EnderecoPessoa Endereco
        {
            get { return _endereco; }
            set { _endereco = value; }
        }

        public virtual short DDi
        {
            get { return _dDI; }
            set { _dDI = value; }
        }

        public virtual short DDd
        {
            get { return _dDD; }
            set { _dDD = value; }
        }

        public virtual string Numero
        {
            get { return _numero; }
            set { _numero = value; }
        }

        public virtual string Ramal
        {
            get { return _ramal; }
            set { _ramal = value; }
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