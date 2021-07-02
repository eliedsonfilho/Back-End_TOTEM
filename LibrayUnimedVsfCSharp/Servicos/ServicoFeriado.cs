using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dados;
using FluorineFx;

namespace Servicos
{
    [RemotingService]
    public class ServicoFeriado
    {
        public Feriado ObterFeriadoPorData(DateTime Data, string codigoSistema, TelosUser usuario)
        {
            return Fachada.GetInstancia().ObterFeriadoPorData(Data, codigoSistema, usuario);
        }


    }
}
