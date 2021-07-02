namespace Dados
{
    public class MotivoBloqueioCartao
    {
        private int _codigo;
        private string _nome;

        public MotivoBloqueioCartao()
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