using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dados;
using MySql.Data.MySqlClient;
using Repositorios;

namespace Negocios
{
    public class NegocioMedicamento
    {
        private RepositorioMedicamento _repositorioMedicamento;

        public NegocioMedicamento()
        {
            _repositorioMedicamento = new RepositorioMedicamento();
        }

        public IList<Medicamento> ObterTodosMedicamentos(Medicamento medicamentoPesquisado, bool lazy)
        {
           return _repositorioMedicamento.ObterTodos(medicamentoPesquisado,lazy);
        }
    }
}
