using System;
using System.Collections.Generic;
using System.Text;
using Dados;
using MySql.Data.MySqlClient;
using Repositorios;

namespace Negocios
{
    public class NegocioMaterial
    {
        private RepositorioMaterial _repositorioMaterial;

        public NegocioMaterial()
        {
            _repositorioMaterial = new RepositorioMaterial();
        }

        public IList<Material> ObterTodosMateriais(Material materialPesquisado, bool lazy)
        {
            return _repositorioMaterial.ObterTodos(materialPesquisado,lazy);
        }
    }
}
