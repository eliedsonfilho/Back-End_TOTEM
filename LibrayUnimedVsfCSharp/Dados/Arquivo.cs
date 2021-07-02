namespace Dados
{
    public class Arquivo
    {
        private int _autoId;
        private string _nomeArquivoServidor;
        private string _descricao;
        private int _chavePai;
        private string _nomePai;

        public Arquivo()
        {
        }

        public virtual int AutoId
        {
            get { return _autoId; }
            set { _autoId = value; }
        }

        public virtual string NomeArquivoServidor
        {
            get { return _nomeArquivoServidor; }
            set { _nomeArquivoServidor = value; }
        }

        public virtual string Descricao
        {
            get { return _descricao; }
            set { _descricao = value; }
        }

        public virtual int ChavePai
        {
            get { return _chavePai; }
            set { _chavePai = value; }
        }

        public virtual string NomePai
        {
            get { return _nomePai; }
            set { _nomePai = value; }
        }
    }
}