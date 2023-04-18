using Worflow.Dados.Builder.Interfaces;
using Worflow.Models;

namespace Worflow.Dados.Builder;

public class ProdutoGeneratorBuilder : IDadosBuilder<Produto>
{
    private Produto produto;
    public ProdutoGeneratorBuilder() => Dados();
    public int Id => 1;

    public void Dados() => produto = new Produto(Id, "Garantia");
    public Produto DeleteNotValid()
    {
        produto.Id = 0;
        return produto;
    }

    public Produto DeleteValid() => Get();

    public Produto Get()
    {
        produto.Id = Id;
        return produto;
    }

    public Produto Post() => produto;

    public Produto Put() => Get();
}
