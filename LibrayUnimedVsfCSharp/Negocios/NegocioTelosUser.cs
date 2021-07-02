using System.Collections.Generic;
using Dados;
using Repositorios;

namespace Negocios
{
    public class NegocioTelosUser
    {
        private RepositorioTelosUser _repositorioTelosUser;

        public NegocioTelosUser()
        {
            _repositorioTelosUser=new RepositorioTelosUser();
        }

        public TelosUser ValidarLogin(string code, string senha, bool lazy)
        {
            //Obtem Usuario Pelo Codigo
            TelosUser telosUserTmp=_repositorioTelosUser.ObterPorId(code,lazy);
            //Valida Senha
            /*if((telosUserTmp!= null)&&(telosUserTmp.UPwd != senha))
            {
                telosUserTmp = null;
            }*/
            return telosUserTmp;
        }

        public TelosUser ObterPorId(string code, bool lazy)
        {
            return _repositorioTelosUser.ObterPorId(code, lazy);
        }

        public IList<TelosUser> ObterTodos(bool lazy)
        {
            return _repositorioTelosUser.ObterTodos(lazy);
        }

        public IList<TelosUser> ObterTodos(TelosUser objetoPesquisado, bool lazy)
        {
            return _repositorioTelosUser.ObterTodos(objetoPesquisado, lazy);
        }
    }
}