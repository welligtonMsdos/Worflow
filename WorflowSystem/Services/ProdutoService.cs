using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Worflow.Dados.Interfaces;
using Worflow.Models;
using Worflow.Repository;

namespace Worflow.Services;

public class ProdutoService : IProdutoService
{
    IProdutoRepository _repository;
    public ProdutoService(IProdutoRepository produtoRepository)
    {
        _repository = produtoRepository;
    }

    public bool Alterar(Produto obj)
    {
        Validator.ValidateObject(obj, new ValidationContext(obj), true);

        _repository.Alterar(obj);

        return obj.Id > 0 ? true : false;
    }

    public Produto BuscarPorId(int id)
    {
        if (id == 0)
            throw new Exception("Erro ao buscar produto por id: Detalhes: Id não pode ser zerado");

        return _repository.BuscarPorId(id);
    }

    public ICollection<Produto> BuscarProdutos()
    {
        return _repository.BuscarTodos();
    }

    public ICollection<ProdutoSegmento> BuscarProdutosPorSegmento(int segmentoId)
    {
        return _repository.BuscarProdutosPorSegmento(segmentoId);
    }

    public bool Excluir(Produto obj)
    {
        if (obj.Id == 0)
            throw new Exception("Erro ao excluir produto: Detalhes: Id não pode ser zerado");

        _repository.Excluir(obj);

        return obj.Id > 0 ? true : false;
    }

    public bool Incluir(Produto obj)
    {
        Validator.ValidateObject(obj, new ValidationContext(obj), true);

        _repository.Incluir(obj);

        return obj.Id > 0 ? true : false;
    }

    public ICollection<Produto> Pesquisar(string value)
    {
        return _repository.Pesquisar(value);
    }
}
