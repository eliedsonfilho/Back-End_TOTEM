namespace Dados
{
    public class EstadoCivil
    {
        private string _codigo;
        private string _nome;

        public EstadoCivil()
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