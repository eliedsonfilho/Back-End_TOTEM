using System.Collections.Generic;
using Dados;
using FluorineFx;

namespace Servicos
{
    [RemotingService]
    public class ServicoVSF_ConfiguracaoSistema
    {
        public VSF_ConfiguracaoSistema ObterVSF_ConfiguracaoSistemaPorId(int autoId, bool lazy, string codigoSistema, TelosUser usuario)
        {
            return Fachada.GetInstancia().ObterVSF_ConfiguracaoSistemaPorId(autoId,lazy,codigoSistema,usuario);
        }

        public IList<VSF_ConfiguracaoSistema> ObterTodosVSF_ConfiguracaoSistemas(bool lazy, string codigoSistema, TelosUser usuario)
        {
            return Fachada.GetInstancia().ObterTodosVSF_ConfiguracaoSistemas(lazy,codigoSistema,usuario);
        }

        public IList<VSF_ConfiguracaoSistema> ObterTodosVSF_ConfiguracaoSistemas(VSF_ConfiguracaoSistema configuracaoSistema, bool lazy, string codigoSistema, TelosUser usuario)
        {
            return Fachada.GetInstancia().ObterTodosVSF_ConfiguracaoSistemas(configuracaoSistema,lazy,codigoSistema,usuario);
        }

        public VSF_ConfiguracaoSistema InserirVSF_ConfiguracaoSistema(VSF_ConfiguracaoSistema configuracaoSistema, string codigoSistema, TelosUser usuario)
        {
            return Fachada.GetInstancia().InserirVSF_ConfiguracaoSistema(configuracaoSistema,codigoSistema,usuario);
        }

        public VSF_ConfiguracaoSistema AtualizarVSF_ConfiguracaoSistema(VSF_ConfiguracaoSistema configuracaoSistema, string codigoSistema, TelosUser usuario)
        {
            return Fachada.GetInstancia().AtualizarVSF_ConfiguracaoSistema(configuracaoSistema, codigoSistema, usuario);
        }
      
    }
}