using System;

namespace Dados
{
    public class VSF_FaleConosco
    {
        private int _autoId;
        private string _codigoMensagem;
        private string _nome;
        private string _codigoBeneficiario;
        private string _email;
        private bool _respostaEmail;
        private bool _noticiaEmail;
        private string _telefone;
        private bool _respostaTelefone;
        private bool _noticiaTelefone;
        private string _motivo;
        private string _assunto;
        private string _mensagem;
        private DateTime _dataMensagem;
        private DateTime? _dataEmissao;
        private string _usuarioEmissao;

        public VSF_FaleConosco()
        {
        }

        public virtual int AutoId
        {
            get { return _autoId; }
            set { _autoId = value; }
        }

        public virtual string CodigoMensagem
        {
            get { return _codigoMensagem; }
            set { _codigoMensagem = value; }
        }

        public virtual string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }

        public virtual string CodigoBeneficiario
        {
            get { return _codigoBeneficiario; }
            set { _codigoBeneficiario = value; }
        }

        public virtual string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public virtual bool RespostaEmail
        {
            get { return _respostaEmail; }
            set { _respostaEmail = value; }
        }

        public virtual bool NoticiaEmail
        {
            get { return _noticiaEmail; }
            set { _noticiaEmail = value; }
        }

        public virtual string Telefone
        {
            get { return _telefone; }
            set { _telefone = value; }
        }

        public virtual bool RespostaTelefone
        {
            get { return _respostaTelefone; }
            set { _respostaTelefone = value; }
        }

        public virtual bool NoticiaTelefone
        {
            get { return _noticiaTelefone; }
            set { _noticiaTelefone = value; }
        }

        public virtual string Motivo
        {
            get { return _motivo; }
            set { _motivo = value; }
        }

        public virtual string Assunto
        {
            get { return _assunto; }
            set { _assunto = value; }
        }

        public virtual string Mensagem
        {
            get { return _mensagem; }
            set { _mensagem = value; }
        }

        public virtual DateTime DataMensagem
        {
            get { return _dataMensagem; }
            set { _dataMensagem = value; }
        }

        public virtual DateTime? DataEmissao
        {
            get { return _dataEmissao; }
            set { _dataEmissao = value; }
        }

        public virtual string UsuarioEmissao
        {
            get { return _usuarioEmissao; }
            set { _usuarioEmissao = value; }
        }
    }
}