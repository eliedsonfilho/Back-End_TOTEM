using System.Collections.Generic;
using Dados;
using Repositorios;

namespace Negocios
{
    public class NegocioBeneficiario
    {
        private RepositorioBeneficiario _repositorioBeneficiario;

        public NegocioBeneficiario()
        {
            _repositorioBeneficiario=new RepositorioBeneficiario();
        }

        public Beneficiario ObterPorId(int autoId, bool lazy)
        {
            return _repositorioBeneficiario.ObterPorId(autoId, lazy);
        }

        public IList<Beneficiario> ObterTodos(bool lazy)
        {
            return _repositorioBeneficiario.ObterTodos(lazy);
        }

        public IList<Beneficiario> ObterTodos(Beneficiario objectPesquisado, bool lazy)
        {
            return _repositorioBeneficiario.ObterTodos(objectPesquisado,lazy);
        }
    }
}