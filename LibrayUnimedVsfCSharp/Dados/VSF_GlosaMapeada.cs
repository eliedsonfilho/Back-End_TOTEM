namespace Dados
{
    public class VSF_MensagemMapeada
    {
        private int _autoId;
        private string _codigo;
        private string _descricao;
        private string _mensagemMapeada;

        public VSF_MensagemMapeada()
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

        public virtual string Descricao
        {
            get { return _descricao; }
            set { _descricao = value; }
        }

        public virtual string MensagemMapeada
        {
            get { return _mensagemMapeada; }
            set { _mensagemMapeada = value; }
        }
    }
}