namespace Dados
{
    public class Logradouro
    {
        private int _codigo;
        private string _cEP;
        private string _nome;
        private TipoLogradouro _tipo;
        private Bairro _bairro;
        private CidadePais _cidade;

        public Logradouro()
        {
        }

        public virtual int Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }

        public virtual string CEp
        {
            get { return _cEP; }
            set { _cEP = value; }
        }

        public virtual string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }

        public virtual TipoLogradouro Tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }

        public virtual Bairro Bairro
        {
            get { return _bairro; }
            set { _bairro = value; }
        }

        public virtual CidadePais Cidade
        {
            get { return _cidade; }
            set { _cidade = value; }
        }
    }
}