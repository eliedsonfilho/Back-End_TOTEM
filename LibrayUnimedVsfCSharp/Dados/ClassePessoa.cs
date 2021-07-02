namespace Dados
{
    public class ClassePessoa
    {
        private int _codigo;
        private string _nome;

        public ClassePessoa()
        {
        }

        public virtual int Codigo
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