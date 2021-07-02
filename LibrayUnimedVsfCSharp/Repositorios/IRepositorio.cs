using System.Collections.Generic;
using System.Data;

namespace Repositorios
{
    public interface IRepositorio <TObject, TId>
    {
        TObject ObterPorId(TId autoIdBoleto, bool lazy);
        IList<TObject> ObterTodos(bool lazy);
        IList<TObject> ObterTodos(TObject objectPesquisado, bool lazy);
    }
}