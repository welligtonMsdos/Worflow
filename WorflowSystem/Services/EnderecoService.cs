using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Worflow.Dados.Interfaces;
using Worflow.Enum;
using Worflow.Models;
using Worflow.Repository;

namespace Worflow.Services;

public class EnderecoService : IEnderecoService
{
    private readonly IEnderecoRepository _repository;

    public EnderecoService(IEnderecoRepository repository) => (_repository) = (repository);

    public bool Alterar(Endereco obj)
    {
        Validator.ValidateObject(obj, new ValidationContext(obj), true);

        _repository.Alterar(obj);

        return obj.Id > 0 ? true : false;
    }

    public Endereco BuscarPorId(int id)
    {
        if (id == 0)
            throw new Exception(Mensagens.ENDERECO_BUSCAR_ID_ZERADO);

        return _repository.BuscarPorId(id);
    }

    public ICollection<Endereco> BuscarTodos() => _repository.BuscarTodos();     

    public bool Excluir(Endereco obj)
    {
        if (obj.Id == 0)
            throw new Exception(Mensagens.ENDERECO_EXCLUIR_ID_ZERADO);

        _repository.Excluir(obj);

        return obj.Id > 0 ? true : false;
    }

    public bool Incluir(Endereco obj)
    {
        Validator.ValidateObject(obj, new ValidationContext(obj), true);

        _repository.Incluir(obj);

        return true;
    }

    public ICollection<Endereco> Pesquisar(string value) => _repository.Pesquisar(value);   
}
