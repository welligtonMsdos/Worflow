using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Worflow.Dados.Interfaces
{
    public interface IQueryPesquisa<T>
    {
        ICollection<T> Pesquisar(string value);
    }
}
