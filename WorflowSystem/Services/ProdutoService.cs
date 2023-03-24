using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Worflow.Dados.Interfaces;
using Worflow.Enum;
using Worflow.Models;
using Worflow.Repository;

namespace Worflow.Services;

public class ProdutoService : IProdutoService
{
    private readonly IProdutoRepository _repository;
    public ProdutoService(IProdutoRepository produtoRepository) => (_repository) = (produtoRepository);    

    public bool Alterar(Produto obj)
    {
        Validator.ValidateObject(obj, new ValidationContext(obj), true);

        _repository.Alterar(obj);

        return obj.Id > 0 ? true : false;
    }

    public Produto BuscarPorId(int id)
    {
        if (id == 0)
            throw new Exception(Mensagens.PRODUTO_BUSCAR_ID_ZERADO);

        return _repository.BuscarPorId(id);
    }

    public ICollection<Produto> BuscarTodos() => _repository.BuscarTodos();    

    public ICollection<ProdutoSegmento> BuscarProdutosPorSegmento(int segmentoId) => _repository.BuscarProdutosPorSegmento(segmentoId);    

    public bool Excluir(Produto obj)
    {
        if (obj.Id == 0)
            throw new Exception(Mensagens.PRODUTO_EXCLUIR_ID_ZERADO);

        _repository.Excluir(obj);

        return obj.Id > 0 ? true : false;
    }

    public bool Incluir(Produto obj)
    {
        Validator.ValidateObject(obj, new ValidationContext(obj), true);

        _repository.Incluir(obj);

        return obj.Id > 0 ? true : false;
    }

    public ICollection<Produto> Pesquisar(string value) => _repository.Pesquisar(value);    
}
