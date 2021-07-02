using System;
using Dados;
using FluorineFx;
using Util.TratamentoErros;

namespace Servicos
{
    [RemotingService]
    public class ServicoDadosCarteiraProvisoria
    {
        public DadosCarteiraProvisoria ObterDadosCarteiraProvisoriaPorCodigo(long autoId, bool lazy, string codigoSistema, TelosUser usuario)
        {
            return Fachada.GetInstancia().ObterDadosCarteiraProvisoriaPorCodigo(autoId, lazy, codigoSistema, usuario);
        }
    }
}