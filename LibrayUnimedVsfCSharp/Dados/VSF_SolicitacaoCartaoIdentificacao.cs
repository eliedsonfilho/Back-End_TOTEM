using System;

namespace Dados
{
    public class VSF_SolicitacaoCartaoIdentificacao
    {
        private int _autoId;
        private string _codigo;
        private Beneficiario _beneficiario;
        private EnumSituacaoSolicitacaoCartaoIdentificacao _situacaoSolicitacaoCartaoIdentificacao;
        private EnderecoPessoa _enderecoPessoa;
        private bool _registrarEnderecoPessoa;
        private EmailPessoa _emailPessoa;
        private bool _registrarEmailPessoa;
        private DateTime? _dataSolicitacao;
        private DateTime? _dataEmissao;
        private DateTime? _dataCancelamento;
        private TelosUser _usuarioEmissao;

        public VSF_SolicitacaoCartaoIdentificacao()
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

        public virtual Beneficiario Beneficiario
        {
            get { return _beneficiario; }
            set { _beneficiario = value; }
        }

        public virtual EnumSituacaoSolicitacaoCartaoIdentificacao SituacaoSolicitacaoCartaoIdentificacao
        {
            get { return _situacaoSolicitacaoCartaoIdentificacao; }
            set { _situacaoSolicitacaoCartaoIdentificacao = value; }
        }

        public virtual EnderecoPessoa EnderecoPessoa
        {
            get { return _enderecoPessoa; }
            set { _enderecoPessoa = value; }
        }

        public virtual bool RegistrarEnderecoPessoa
        {
            get { return _registrarEnderecoPessoa; }
            set { _registrarEnderecoPessoa = value; }
        }

        public virtual EmailPessoa EmailPessoa
        {
            get { return _emailPessoa; }
            set { _emailPessoa = value; }
        }

        public virtual bool RegistrarEmailPessoa
        {
            get { return _registrarEmailPessoa; }
            set { _registrarEmailPessoa = value; }
        }

        public virtual DateTime? DataSolicitacao
        {
            get { return _dataSolicitacao; }
            set { _dataSolicitacao = value; }
        }

        public virtual DateTime? DataEmissao
        {
            get { return _dataEmissao; }
            set { _dataEmissao = value; }
        }

        public virtual DateTime? DataCancelamento
        {
            get { return _dataCancelamento; }
            set { _dataCancelamento = value; }
        }

        public virtual TelosUser UsuarioEmissao
        {
            get { return _usuarioEmissao; }
            set { _usuarioEmissao = value; }
        }
    }
}