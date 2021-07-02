using System.Collections.Generic;
using Dados;
using FluorineFx;

namespace Servicos
{
    [RemotingService]
    public class ServicoVSF_FaleConosco
    {
        public VSF_FaleConosco ObterVSF_FaleConoscoPorId(int autoId, bool lazy, string codigoSistema, TelosUser usuario)
        {
            return Fachada.GetInstancia().ObterVSF_FaleConoscoPorId(autoId, lazy, codigoSistema, usuario);
        }

        public IList<VSF_FaleConosco> ObterTodosVSF_FaleConoscos(bool lazy, string codigoSistema, TelosUser usuario)
        {
            return Fachada.GetInstancia().ObterTodosVSF_FaleConoscos(lazy, codigoSistema, usuario);
        }

        public IList<VSF_FaleConosco> ObterTodosVSF_FaleConoscos(VSF_FaleConosco VSF_FaleConosco, bool lazy, string codigoSistema, TelosUser usuario)
        {
            return Fachada.GetInstancia().ObterTodosVSF_FaleConoscos(VSF_FaleConosco, lazy, codigoSistema, usuario);
        }

        public VSF_FaleConosco InserirVSF_FaleConosco(VSF_FaleConosco VSF_FaleConosco, string codigoSistema, TelosUser usuario)
        {
            return Fachada.GetInstancia().InserirVSF_FaleConosco(VSF_FaleConosco, codigoSistema, usuario);
        }

        public VSF_FaleConosco AtualizarVSF_FaleConosco(VSF_FaleConosco VSF_FaleConosco, string codigoSistema, TelosUser usuario)
        {
            return Fachada.GetInstancia().AtualizarVSF_FaleConosco(VSF_FaleConosco, codigoSistema, usuario);
        } 
    }
}