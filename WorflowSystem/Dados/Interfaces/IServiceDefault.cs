using System.Collections.Generic;

namespace Worflow.Dados.Interfaces;

public interface IServiceDefault<T>
{
    ICollection<T> BuscarTodos();
    ICollection<T> Pesquisar(string value);
    T BuscarPorId(int id);
    bool Incluir(T obj);
    bool Alterar(T obj);
    bool Excluir(T obj);
}
