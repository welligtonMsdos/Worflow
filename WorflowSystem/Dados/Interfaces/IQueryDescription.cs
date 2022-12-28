using System.Collections.Generic;

namespace Worflow.Dados.Interfaces
{
    public interface IQueryDescription<T>
    {
        ICollection<T> BuscarPorDescricao(string descricao);
    }
}
