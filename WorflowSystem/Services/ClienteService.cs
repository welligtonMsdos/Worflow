using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Worflow.Dados.Interfaces;
using Worflow.Enum;
using Worflow.Models;
using Worflow.Repository;

namespace Worflow.Services;

public class ClienteService : IClienteService
{
    private readonly IClienteRepository _repository;

    public ClienteService(IClienteRepository repository) => (_repository) = (repository);

    public bool Alterar(Cliente obj)
    {
        Validator.ValidateObject(obj, new ValidationContext(obj), true);

        _repository.Alterar(obj);

        return obj.Id > 0 ? true : false;
    }

    public Cliente BuscarPorId(int id)
    {
        if (id == 0)
            throw new Exception(Mensagens.CLIENTE_BUSCAR_ID_ZERADO);

        return _repository.BuscarPorId(id);
    }

    public ICollection<Cliente> BuscarTodos() => _repository.BuscarTodos();         

    public bool Excluir(Cliente obj)
    {
        if (obj.Id == 0)
            throw new Exception(Mensagens.CLIENTE_EXCLUIR_ID_ZERADO);

        _repository.Excluir(obj);

        return obj.Id > 0 ? true : false;
    }

    public bool Incluir(Cliente obj)
    {
        Validator.ValidateObject(obj, new ValidationContext(obj), true);

        _repository.Incluir(obj);

        return obj.Id > 0 ? true : false;
    }

    public ICollection<Cliente> Pesquisar(string value) => _repository.Pesquisar(value);        
}
