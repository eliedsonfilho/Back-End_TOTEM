using System.Collections.Generic;
using Dados;
using Repositorios;

namespace Negocios
{
    public class NegocioArquivo
    {
        private RepositorioArquivo _repositorioArquivo;

        public NegocioArquivo()
        {
            _repositorioArquivo = new RepositorioArquivo();
        }

        public Arquivo ObterPorId(int autoId, bool lazy)
        {
            return _repositorioArquivo.ObterPorId(autoId, lazy);
        }

        public IList<Arquivo> ObterTodos(bool lazy)
        {
            return _repositorioArquivo.ObterTodos(lazy);
        }

        public IList<Arquivo> ObterTodos(Arquivo objetoPesquisado, bool lazy)
        {
            return _repositorioArquivo.ObterTodos(objetoPesquisado, lazy);
        }

        public Arquivo Inserir(Arquivo ObjetoInserido)
        {
            return _repositorioArquivo.Inserir(ObjetoInserido);
        }

        public Arquivo Atualizar(Arquivo ObjetoInserido)
        {
            return _repositorioArquivo.Atualizar(ObjetoInserido);
        }
    }
}