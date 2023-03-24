namespace Worflow.Dados.Interfaces;

public interface ICommand<T> 
{
    void Incluir(T obj);
    void Alterar(T obj);
    void Excluir(T obj);
}
