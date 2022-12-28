using System.Collections.Generic;

namespace Worflow.Dados.Interfaces
{
    public interface IQuery<T>
    {
        ICollection<T> BuscarTodos();
        T BuscarPorId(int id);
    }
}
