using System.Collections.Generic;
using System.Data;

namespace Repositorios
{
    public interface IConexao<TParametro, TRetorno>
    {
        IList<TObject> ExecutarConsultaList<TObject>(TParametro comando, TObject objeto, bool lazy) where TObject : class;
        TObject ExecutarConsultaObject<TObject>(ref TParametro comando, TObject objeto, bool lazy) where TObject : class;
        TObject ExecutarConsultaObject<TObject>(TParametro comando, TObject objeto, bool lazy) where TObject : class;
        TRetorno ExecutarConsulta(TParametro comando);
        int ExecutarNaoConsulta(TParametro comando);
    }
}