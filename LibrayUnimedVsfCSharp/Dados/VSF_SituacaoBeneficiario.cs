using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dados
{
    public class VSF_SituacaoBeneficiario
    {

        private int _autoId;
        private string _situacao;
        private bool _ativo;

        public VSF_SituacaoBeneficiario()
        {
        }

        public virtual int AutoId
        {
            get { return _autoId; }
            set { _autoId = value; }
        }

        public virtual string Situacao
        {
            get { return _situacao; }
            set { _situacao = value; }
        }

        public virtual bool Ativo
        {
            get { return _ativo; }
            set { _ativo = value; }
        }
    }
}
