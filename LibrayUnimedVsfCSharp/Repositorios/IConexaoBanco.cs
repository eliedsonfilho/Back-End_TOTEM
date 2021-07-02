using System.Collections.Generic;
using System.Data;

namespace Repositorios
{
    public interface IConexaoBanco : IConexao<IDbCommand, IDataReader>
    {
    }
}