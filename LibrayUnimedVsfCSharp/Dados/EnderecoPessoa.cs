using System;

namespace Dados
{
    public class EnderecoPessoa
    {
        private int _autoId;
        private Pessoa _pessoa;
        private short _seq;
        private string _logradouro;
        private string _numLogradouro;
        private string _complLogradouro;
        private string _bairro;
        private CidadePais _cidade;
        private string _cEP;
        private string _pontoReferencia;
        private int _caixaPostal;
        private TipoEndereco _tipo;
        private bool _paraCorrespondencia;
        private bool _paraCobranca;
        private bool _paraFaturamento;
        private bool _paraPublicacao;
        private DateTime? _inicioVigencia;
        private DateTime? _fimVigencia;
        private string _inicioHorario;
        private string _fimHorario;
        private string _codigoExterno;
        private string _latitude;
        private string _longitude;

        public EnderecoPessoa()
        {
        }

        public virtual int AutoId
        {
            get { return _autoId; }
            set { _autoId = value; }
        }

        public virtual Pessoa Pessoa
        {
            get { return _pessoa; }
            set { _pessoa = value; }
        }

        public virtual short Seq
        {
            get { return _seq; }
            set { _seq = value; }
        }

        public virtual string Logradouro
        {
            get { return _logradouro; }
            set { _logradouro = value; }
        }

        public virtual string NumLogradouro
        {
            get { return _numLogradouro; }
            set { _numLogradouro = value; }
        }

        public virtual string ComplLogradouro
        {
            get { return _complLogradouro; }
            set { _complLogradouro = value; }
        }

        public virtual string Bairro
        {
            get { return _bairro; }
            set { _bairro = value; }
        }

        public virtual CidadePais Cidade
        {
            get { return _cidade; }
            set { _cidade = value; }
        }

        public virtual string CEp
        {
            get { return _cEP; }
            set { _cEP = value; }
        }

        public virtual string PontoReferencia
        {
            get { return _pontoReferencia; }
            set { _pontoReferencia = value; }
        }

        public virtual int CaixaPostal
        {
            get { return _caixaPostal; }
            set { _caixaPostal = value; }
        }

        public virtual TipoEndereco Tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }

        public virtual bool ParaCorrespondencia
        {
            get { return _paraCorrespondencia; }
            set { _paraCorrespondencia = value; }
        }

        public virtual bool ParaCobranca
        {
            get { return _paraCobranca; }
            set { _paraCobranca = value; }
        }

        public virtual bool ParaFaturamento
        {
            get { return _paraFaturamento; }
            set { _paraFaturamento = value; }
        }

        public virtual bool ParaPublicacao
        {
            get { return _paraPublicacao; }
            set { _paraPublicacao = value; }
        }

        public virtual DateTime? InicioVigencia
        {
            get { return _inicioVigencia; }
            set { _inicioVigencia = value; }
        }

        public virtual DateTime? FimVigencia
        {
            get { return _fimVigencia; }
            set { _fimVigencia = value; }
        }

        public virtual string InicioHorario
        {
            get { return _inicioHorario; }
            set { _inicioHorario = value; }
        }

        public virtual string FimHorario
        {
            get { return _fimHorario; }
            set { _fimHorario = value; }
        }

        public virtual string CodigoExterno
        {
            get { return _codigoExterno; }
            set { _codigoExterno = value; }
        }

        public virtual string Latitude
        {
            get { return _latitude; }
            set { _latitude = value; }
        }

        public virtual string Longitude
        {
            get { return _longitude; }
            set { _longitude = value; }
        }
    }
}