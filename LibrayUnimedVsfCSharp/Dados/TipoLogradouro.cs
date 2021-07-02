namespace Dados
{
    public class TipoLogradouro
    {
        private string _codigo;
        private string _nome;

        public TipoLogradouro()
        {
        }

        public virtual string Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }

        public virtual string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }
    }
}