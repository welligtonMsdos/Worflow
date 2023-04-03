namespace Worflow.Dados.Builder.Interfaces;

public interface IDadosBuilder<T>
{
    T Post();

    T Put();

    T Get();

    T DeleteValid();

    T DeleteNotValid();

    public int Id { get; }
}
