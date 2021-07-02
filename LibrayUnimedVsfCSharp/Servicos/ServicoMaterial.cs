using System.Collections.Generic;
using Dados;
using FluorineFx;

namespace Servicos
{
    [RemotingService]
    public class ServicoMaterial
    {
        public IList<Material> ObterTodosMateriais(Material material, bool lazy)
        {
            return Fachada.GetInstancia().ObterTodosMateriais(material,lazy);
        }
    }
}