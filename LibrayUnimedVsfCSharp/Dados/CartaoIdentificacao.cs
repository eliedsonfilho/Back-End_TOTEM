using System;

namespace Dados
{
    public class CartaoIdentificacao
    {
        private int _autoId;
        private Beneficiario _beneficiario;
        private short _via;
        private ModeloCartaoIdent _modelo;
        private long _codigo;
        private DateTime? _dataSolicitacao;
        private string _operadorSolicitacao;
        private DateTime? _dataValidadeInicial;
        private DateTime? _dataValidadeFinal;
        private DateTime? _dataEmissao;
        private string _operadorEmissao;
        private bool _faturado;
        private bool _bloqueado;
        private DateTime? _dataRegistro;
        private bool _listaNegra;
        private DateTime? _dataBloqueio;
        private MotivoBloqueioCartao _motivoBloqueio;
        private string _operadorBloqueio;
        private DateTime? _dataDevolucao;
        private string _operadorDevolucao;
        private DateTime? _dataGeracao;
        private DateTime? _dataDesbloqueio;
        private MotivoDesbloqueioCartao _motivoDesbloqueio;
        private string _operadorDesbloqueio;
        private DateTime? _dataUltBloqueio;

        public CartaoIdentificacao()
        {
        }

        public virtual int AutoId
        {
            get { return _autoId; }
            set { _autoId = value; }
        }

        public virtual Beneficiario Beneficiario
        {
            get { return _beneficiario; }
            set { _beneficiario = value; }
        }

        public virtual short Via
        {
            get { return _via; }
            set { _via = value; }
        }

        public virtual ModeloCartaoIdent Modelo
        {
            get { return _modelo; }
            set { _modelo = value; }
        }

        public virtual long Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }

        public virtual DateTime? DataSolicitacao
        {
            get { return _dataSolicitacao; }
            set { _dataSolicitacao = value; }
        }

        public virtual string OperadorSolicitacao
        {
            get { return _operadorSolicitacao; }
            set { _operadorSolicitacao = value; }
        }

        public virtual DateTime? DataValidadeInicial
        {
            get { return _dataValidadeInicial; }
            set { _dataValidadeInicial = value; }
        }

        public virtual DateTime? DataValidadeFinal
        {
            get { return _dataValidadeFinal; }
            set { _dataValidadeFinal = value; }
        }

        public virtual DateTime? DataEmissao
        {
            get { return _dataEmissao; }
            set { _dataEmissao = value; }
        }

        public virtual string OperadorEmissao
        {
            get { return _operadorEmissao; }
            set { _operadorEmissao = value; }
        }

        public virtual bool Faturado
        {
            get { return _faturado; }
            set { _faturado = value; }
        }

        public virtual bool Bloqueado
        {
            get { return _bloqueado; }
            set { _bloqueado = value; }
        }

        public virtual DateTime? DataRegistro
        {
            get { return _dataRegistro; }
            set { _dataRegistro = value; }
        }

        public virtual bool ListaNegra
        {
            get { return _listaNegra; }
            set { _listaNegra = value; }
        }

        public virtual DateTime? DataBloqueio
        {
            get { return _dataBloqueio; }
            set { _dataBloqueio = value; }
        }

        public virtual MotivoBloqueioCartao MotivoBloqueio
        {
            get { return _motivoBloqueio; }
            set { _motivoBloqueio = value; }
        }

        public virtual string OperadorBloqueio
        {
            get { return _operadorBloqueio; }
            set { _operadorBloqueio = value; }
        }

        public virtual DateTime? DataDevolucao
        {
            get { return _dataDevolucao; }
            set { _dataDevolucao = value; }
        }

        public virtual string OperadorDevolucao
        {
            get { return _operadorDevolucao; }
            set { _operadorDevolucao = value; }
        }

        public virtual DateTime? DataGeracao
        {
            get { return _dataGeracao; }
            set { _dataGeracao = value; }
        }

        public virtual DateTime? DataDesbloqueio
        {
            get { return _dataDesbloqueio; }
            set { _dataDesbloqueio = value; }
        }

        public virtual MotivoDesbloqueioCartao MotivoDesbloqueio
        {
            get { return _motivoDesbloqueio; }
            set { _motivoDesbloqueio = value; }
        }

        public virtual string OperadorDesbloqueio
        {
            get { return _operadorDesbloqueio; }
            set { _operadorDesbloqueio = value; }
        }

        public virtual DateTime? DataUltBloqueio
        {
            get { return _dataUltBloqueio; }
            set { _dataUltBloqueio = value; }
        }
    }
}