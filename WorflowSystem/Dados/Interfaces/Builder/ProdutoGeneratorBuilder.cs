﻿using Worflow.Models;

namespace Worflow.Dados.Interfaces.Builder;

public class ProdutoGeneratorBuilder: IProdutoBuilder, IDadosBuilder<Produto>
{
    private Produto produto;
    public ProdutoGeneratorBuilder()
    {
        DadosProduto();
    }

    public int Id => 1;

    public void DadosProduto() => produto = new Produto(Id, "Garantia");

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
