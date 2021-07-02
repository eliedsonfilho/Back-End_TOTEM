using System;

namespace Dados
{
    public class Pessoa
    {
        private int _autoId;
        private string _nome;
        private string _nomeReduzido;
        private TipoPessoa _tipo;
        private string _cnp;
        private ClassePessoa _classe;
        private DateTime? _dataNascimento;
        private SexoPessoa _sexo;
        private EstadoCivil _estadoCivil;
        private GrauEscolaridade _escolaridade;
        private string _nomePai;
        private string _nomeMae;
        private string _nomeConjuge;
        private Nacionalidade _nacionalidade;
        private CidadePais _naturalidade;
        private DateTime? _dataFalecimento;
        private DateTime? _dataFundacao;

        public Pessoa()
        {
        }


        public virtual int AutoId
        {
            get { return _autoId; }
            set { _autoId = value; }
        }

        public virtual string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }

        public virtual string NomeReduzido
        {
            get { return _nomeReduzido; }
            set { _nomeReduzido = value; }
        }

        public virtual TipoPessoa Tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }

        public virtual string Cnp
        {
            get { return _cnp; }
            set { _cnp = value; }
        }

        public virtual ClassePessoa Classe
        {
            get { return _classe; }
            set { _classe = value; }
        }

        public virtual DateTime? DataNascimento
        {
            get { return _dataNascimento; }
            set { _dataNascimento = value; }
        }

        public virtual SexoPessoa Sexo
        {
            get { return _sexo; }
            set { _sexo = value; }
        }

        public virtual EstadoCivil EstadoCivil
        {
            get { return _estadoCivil; }
            set { _estadoCivil = value; }
        }

        public virtual GrauEscolaridade Escolaridade
        {
            get { return _escolaridade; }
            set { _escolaridade = value; }
        }

        public virtual string NomePai
        {
            get { return _nomePai; }
            set { _nomePai = value; }
        }

        public virtual string NomeMae
        {
            get { return _nomeMae; }
            set { _nomeMae = value; }
        }

        public virtual string NomeConjuge
        {
            get { return _nomeConjuge; }
            set { _nomeConjuge = value; }
        }

        public virtual Nacionalidade Nacionalidade
        {
            get { return _nacionalidade; }
            set { _nacionalidade = value; }
        }

        public virtual CidadePais Naturalidade
        {
            get { return _naturalidade; }
            set { _naturalidade = value; }
        }

        public virtual DateTime? DataFalecimento
        {
            get { return _dataFalecimento; }
            set { _dataFalecimento = value; }
        }

        public virtual DateTime? DataFundacao
        {
            get { return _dataFundacao; }
            set { _dataFundacao = value; }
        }
    }
}