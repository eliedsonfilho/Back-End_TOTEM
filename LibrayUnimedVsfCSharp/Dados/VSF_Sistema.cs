namespace Dados
{
    public class VSF_Sistema
    {
        private int _autoId;
        private string _codigo;
        private string _nome;

        public VSF_Sistema()
        {
        }

        public virtual int AutoId
        {
            get { return _autoId; }
            set { _autoId = value; }
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