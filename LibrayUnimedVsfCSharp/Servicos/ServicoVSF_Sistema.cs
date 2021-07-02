using System.Collections.Generic;
using Dados;
using FluorineFx;

namespace Servicos
{

    [RemotingService]
    public class ServicoVSF_Sistema
    {
        public VSF_Sistema ObterVSF_SistemaPorId(int autoId, bool lazy, string codigoSistema, TelosUser usuario)
        {
            return Fachada.GetInstancia().ObterVSF_SistemaPorId(autoId,lazy,codigoSistema,usuario);
        }

        public VSF_Sistema ObterVSF_SistemaPoCodigo(string codigo, bool lazy, string codigoSistema, TelosUser usuario)
        {
            return Fachada.GetInstancia().ObterVSF_SistemaPoCodigo(codigo,lazy,codigoSistema,usuario);
        }

        public IList<VSF_Sistema> ObterTodosVSF_Sistemas(bool lazy, string codigoSistema, TelosUser usuario)
        {
            return Fachada.GetInstancia().ObterTodosVSF_Sistemas(lazy,codigoSistema,usuario);
        }

        public IList<VSF_Sistema> ObterTodosVSF_Sistemas(VSF_Sistema sistema, bool lazy, string codigoSistema, TelosUser usuario)
        {
            return Fachada.GetInstancia().ObterTodosVSF_Sistemas(sistema,lazy,codigoSistema,usuario);
        }
    }
}