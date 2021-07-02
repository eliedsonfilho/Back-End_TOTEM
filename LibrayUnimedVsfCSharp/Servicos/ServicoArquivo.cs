using System.Collections.Generic;
using Dados;
using FluorineFx;

namespace Servicos
{
    [RemotingService]
    public class ServicoArquivo
    {
        public Arquivo ObterArquivoPorId(int autoId, bool lazy, string codigoSistema, TelosUser usuario)
        {
            return Fachada.GetInstancia().ObterArquivoPorId(autoId, lazy, codigoSistema, usuario);
        }

        public IList<Arquivo> ObterTodosArquivos(bool lazy, string codigoSistema, TelosUser usuario)
        {
            return Fachada.GetInstancia().ObterTodosArquivos(lazy, codigoSistema, usuario);
        }

        public IList<Arquivo> ObterTodosArquivos(Arquivo objeto, bool lazy, string codigoSistema, TelosUser usuario)
        {
            return Fachada.GetInstancia().ObterTodosArquivos(objeto, lazy, codigoSistema, usuario);
        }

        public Arquivo InserirArquivo(Arquivo objeto, string codigoSistema, TelosUser usuario)
        {
            return Fachada.GetInstancia().InserirArquivo(objeto, codigoSistema, usuario);
        }

        public Arquivo AtualizarArquivo(Arquivo objeto, string codigoSistema, TelosUser usuario)
        {
           return Fachada.GetInstancia().AtualizarArquivo(objeto, codigoSistema, usuario);
        } 
    }
}