using System.Collections.Generic;
using Dados;
using FluorineFx;

namespace Servicos
{
    [RemotingService]
    public class ServicoMedicamento
    {
        public IList<Medicamento> ObterTodosMedicamentos(Medicamento medicamento, bool lazy)
        {
            return Fachada.GetInstancia().ObterTodosMedicamentos(medicamento,lazy);
        }
    }
}