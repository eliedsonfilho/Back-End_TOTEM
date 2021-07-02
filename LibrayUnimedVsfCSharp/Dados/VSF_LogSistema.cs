using System;

namespace Dados
{
    public class VSF_LogSistema
    {
        private int _autoId;
        private VSF_Sistema _sistema;
        private string _mensagem;
        private DateTime? _dataLog;
        
        public VSF_LogSistema()
        {
        }

        public virtual int AutoId
        {
            get { return _autoId; }
            set { _autoId = value; }
        }

        public virtual VSF_Sistema Sistema
        {
            get { return _sistema; }
            set { _sistema = value; }
        }

        public virtual string Mensagem
        {
            get { return _mensagem; }
            set { _mensagem = value; }
        }

        public virtual DateTime? DataLog
        {
            get { return _dataLog; }
            set { _dataLog = value; }
        }
    }
}