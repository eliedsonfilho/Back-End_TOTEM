using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dados;
using FluorineFx;

namespace Servicos
{
    [RemotingService]
    public class ServicoMovDocFinan
    {
        public MovDocFinan InserirPorDocFinan(int autoIdDocFinan)
        {
            return Fachada.GetInstancia().InserirPorDocFinan(autoIdDocFinan);
        }
    }
}
