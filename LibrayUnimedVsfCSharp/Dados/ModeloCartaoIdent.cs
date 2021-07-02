namespace Dados
{
    public class ModeloCartaoIdent
    {
        private int _codigo;
        private string _nome;
        private TipoCartaoIdentificacao _tipo;

        public ModeloCartaoIdent()
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
        
        public virtual TipoCartaoIdentificacao Tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }
    }
}