namespace Dados
{
    public class CidadePais
    {
        private int _codigo;
        private string _nome;
        private string _uF;
        private string _codigoExterno;

        public CidadePais()
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

        public virtual string UF
        {
            get { return _uF; }
            set { _uF = value; }
        }

        public virtual string CodigoExterno
        {
            get { return _codigoExterno; }
            set { _codigoExterno = value; }
        }
    }
}