using System;

namespace Dados
{
    public class ObjetoPesquisa
    {
        private int _autoId;
        private string _codigo;
        private int _autoIdBeneficiario;
        private string _nomeBeneficiario;
        private string _codigoBeneficiario;
        private int _situacao;
        private DateTime? _dataInicial;
        private DateTime? _dataFinal;
        private DateTime? _dataSolicitacaoInicial;
        private DateTime? _dataSolicitacaoFinal;
        private DateTime? _dataEmissaoInicial;
        private DateTime? _dataEmissaoFinal;
        private DateTime? _dataCancelamentoInicial;
        private DateTime? _dataCancelamentoFinal;
        private string _usuarioEmissaoCodigo;

        public ObjetoPesquisa()
        {
        }

        public virtual int AutoId
        {
            get { return _autoId; }
            set { _autoId = value; }
        }

        public virtual int AutoIdBeneficiario
        {
            get { return _autoIdBeneficiario; }
            set { _autoIdBeneficiario = value; }
        }

        public virtual string NomeBeneficiario
        {
            get { return _nomeBeneficiario; }
            set { _nomeBeneficiario = value; }
        }

        public virtual string Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }

        public virtual string CodigoBeneficiario
        {
            get { return _codigoBeneficiario; }
            set { _codigoBeneficiario = value; }
        }

        public virtual int Situacao
        {
            get { return _situacao; }
            set { _situacao = value; }
        }

        public virtual DateTime? DataInicial
        {
            get { return _dataInicial; }
            set { _dataInicial = value; }
        }

        public virtual DateTime? DataFinal
        {
            get { return _dataFinal; }
            set { _dataFinal = value; }
        }

        public virtual DateTime? DataSolicitacaoInicial
        {
            get { return _dataSolicitacaoInicial; }
            set { _dataSolicitacaoInicial = value; }
        }

        public virtual DateTime? DataSolicitacaoFinal
        {
            get { return _dataSolicitacaoFinal; }
            set { _dataSolicitacaoFinal = value; }
        }

        public virtual DateTime? DataEmissaoInicial
        {
            get { return _dataEmissaoInicial; }
            set { _dataEmissaoInicial = value; }
        }

        public virtual DateTime? DataEmissaoFinal
        {
            get { return _dataEmissaoFinal; }
            set { _dataEmissaoFinal = value; }
        }

        public virtual DateTime? DataCancelamentoInicial
        {
            get { return _dataCancelamentoInicial; }
            set { _dataCancelamentoInicial = value; }
        }

        public virtual DateTime? DataCancelamentoFinal
        {
            get { return _dataCancelamentoFinal; }
            set { _dataCancelamentoFinal = value; }
        }

        public virtual string UsuarioEmissaoCodigo
        {
            get { return _usuarioEmissaoCodigo; }
            set { _usuarioEmissaoCodigo = value; }
        }
    }
}