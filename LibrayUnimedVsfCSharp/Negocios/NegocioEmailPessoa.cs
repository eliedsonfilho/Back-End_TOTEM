using System.Collections.Generic;
using Dados;
using Repositorios;

namespace Negocios
{
    public class NegocioEmailPessoa
    {
        private RepositorioEmailPessoa _repositorioEmailPessoa;

        public NegocioEmailPessoa()
        {
            _repositorioEmailPessoa = new RepositorioEmailPessoa();
        }

        public IList<EmailPessoa> ObterTodos(bool lazy)
        {
            return _repositorioEmailPessoa.ObterTodos(lazy);
        }

        public EmailPessoa ObterPorId(int autoId, bool lazy)
        {
            return _repositorioEmailPessoa.ObterPorId(autoId, lazy);
        }

        public IList<EmailPessoa> ObterTodos(EmailPessoa objetoPesquisado, bool lazy)
        {
            return _repositorioEmailPessoa.ObterTodos(objetoPesquisado, lazy);
        }

        public EmailPessoa ObterPorPessoa(Pessoa pessoa, bool lazy)
        {
            return _repositorioEmailPessoa.ObterPorPessoa(pessoa, lazy);
        }
    }
}