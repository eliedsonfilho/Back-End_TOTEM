using System;
using System.Collections.Generic;
using Dados;
using Repositorios;

namespace Negocios
{
    public class NegocioVSF_LogSistema
    {
        private RepositorioVSF_LogSistema _repositorioVsfLogSistema;

        public NegocioVSF_LogSistema()
        {
            _repositorioVsfLogSistema = new RepositorioVSF_LogSistema();
        }

        public VSF_LogSistema ObterPorId(int autoId, bool lazy)
        {
            return _repositorioVsfLogSistema.ObterPorId(autoId, lazy);
        }

        public IList<VSF_LogSistema> ObterTodos(bool lazy)
        {
            return _repositorioVsfLogSistema.ObterTodos(lazy);
        }

        public IList<VSF_LogSistema> ObterTodos(VSF_LogSistema objetoPesquisado, bool lazy)
        {
            return _repositorioVsfLogSistema.ObterTodos(objetoPesquisado, lazy);
        }

        public VSF_LogSistema Inserir(VSF_LogSistema logSistema)
        {
            //Data e hora do Servidor
            logSistema.DataLog = DateTime.Now;

            return _repositorioVsfLogSistema.Inserir(logSistema);
        }

        public VSF_LogSistema Atualizar(VSF_LogSistema logSistema)
        {
            return _repositorioVsfLogSistema.Atualizar(logSistema);
        }
    }
}