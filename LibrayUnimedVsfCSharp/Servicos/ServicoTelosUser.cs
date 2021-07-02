using System.Collections.Generic;
using Dados;
using FluorineFx;

namespace Servicos
{
    [RemotingService]
    public class ServicoTelosUser
    {
        public TelosUser ObterTelosUserPorId(string code, bool lazy, string codigoSistema, TelosUser usuario)
        {
            return Fachada.GetInstancia().ObterTelosUserPorId(code, lazy, codigoSistema, usuario);
        }

        public TelosUser ValidarLoginUsuario(string code, string senha, bool lazy, string codigoSistema, TelosUser usuario)
        {
            return Fachada.GetInstancia().ValidarLoginUsuario(code, senha, lazy, codigoSistema, usuario);
        }

        public IList<TelosUser> ObterTodosTelosUsers(bool lazy, string codigoSistema, TelosUser usuario)
        {
            return Fachada.GetInstancia().ObterTodosTelosUsers(lazy, codigoSistema, usuario);
        }

        public IList<TelosUser> ObterTodosTelosUsers(TelosUser usuarioPesquisado, bool lazy, string codigoSistema, TelosUser usuario)
        {
            return Fachada.GetInstancia().ObterTodosTelosUsers(usuarioPesquisado,lazy, codigoSistema, usuario);
        }
    }
}