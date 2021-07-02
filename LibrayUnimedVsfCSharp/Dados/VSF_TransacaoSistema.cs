using System;

namespace Dados
{
    public class VSF_TransacaoSistema
    {
        private int _autoId;
        private string _acao;
        private DateTime? _dataTransacao;
        private Beneficiario _beneficiario;
        private TelosUser _usuario;
        private VSF_Sistema _sistema;

        public VSF_TransacaoSistema()
        {
        }

        public virtual int AutoId
        {
            get { return _autoId; }
            set { _autoId = value; }
        }

        public virtual string Acao
        {
            get { return _acao; }
            set { _acao = value; }
        }

        public virtual DateTime? DataTransacao
        {
            get { return _dataTransacao; }
            set { _dataTransacao = value; }
        }

        public virtual Beneficiario Beneficiario
        {
            get { return _beneficiario; }
            set { _beneficiario = value; }
        }

        public virtual TelosUser Usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }

        public virtual VSF_Sistema Sistema
        {
            get { return _sistema; }
            set { _sistema = value; }
        }
    }
}