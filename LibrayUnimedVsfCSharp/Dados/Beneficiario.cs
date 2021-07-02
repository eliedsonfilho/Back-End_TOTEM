using System;

namespace Dados
{
    public class Beneficiario
    {
        private int _autoId;
        private Pessoa _pessoa;
        private Contrato _contrato;
        private EnumRDP _rDP;
        private int _familia;
        private long _codigo;
        private TipoBeneficiario _tipo;
        private Beneficiario _titular;
        private DateTime? _inicioVigencia;
        private DateTime? _dataBaseCalc;
        private DateTime? _dataInicioContribuicao;
        private DateTime? _dataAposentadoDemitido;
        private SituacaoBeneficiario _situacaoBeneficiario;
        private string _matricula;
        private DateTime? _dataAdmissao;
        private GrauDepPessoa _grauDependencia;
        private bool _benefTemporario;

        public Beneficiario()
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

        public virtual Contrato Contrato
        {
            get { return _contrato; }
            set { _contrato = value; }
        }

        public virtual EnumRDP RDP
        {
            get { return _rDP; }
            set { _rDP = value; }
        }

        public virtual int Familia
        {
            get { return _familia; }
            set { _familia = value; }
        }

        public virtual long Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }

        public virtual TipoBeneficiario Tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }

        public virtual Beneficiario Titular
        {
            get { return _titular; }
            set { _titular = value; }
        }

        public virtual DateTime? InicioVigencia
        {
            get { return _inicioVigencia; }
            set { _inicioVigencia = value; }
        }

        public virtual DateTime? DataBaseCalc
        {
            get { return _dataBaseCalc; }
            set { _dataBaseCalc = value; }
        }

        public virtual DateTime? DataInicioContribuicao
        {
            get { return _dataInicioContribuicao; }
            set { _dataInicioContribuicao = value; }
        }

        public virtual DateTime? DataAposentadoDemitido
        {
            get { return _dataAposentadoDemitido; }
            set { _dataAposentadoDemitido = value; }
        }

        public virtual SituacaoBeneficiario SituacaoBeneficiario
        {
            get { return _situacaoBeneficiario; }
            set { _situacaoBeneficiario = value; }
        }

        public virtual string Matricula
        {
            get { return _matricula; }
            set { _matricula = value; }
        }

        public virtual DateTime? DataAdmissao
        {
            get { return _dataAdmissao; }
            set { _dataAdmissao = value; }
        }

        public virtual GrauDepPessoa GrauDependencia
        {
            get { return _grauDependencia; }
            set { _grauDependencia = value; }
        }

        public virtual bool BenefTemporario
        {
            get { return _benefTemporario; }
            set { _benefTemporario = value; }
        }
    }
}