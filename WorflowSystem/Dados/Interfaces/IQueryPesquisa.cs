using System.Collections.Generic;

namespace Worflow.Dados.Interfaces
{
    public interface IQueryPesquisa<T>
    {
        ICollection<T> Pesquisar(string value);
    }
}
