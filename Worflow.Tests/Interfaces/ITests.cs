namespace Worflow.Tests.Interfaces;

public interface ITests
{
    int GetTodos();
    string BuscarIdZerado();
    bool BuscarIdValido();
    string ExcluirIdZerado();
    bool ExcluirIdValido();
    bool Incluir();
    bool Alterar();   
}
