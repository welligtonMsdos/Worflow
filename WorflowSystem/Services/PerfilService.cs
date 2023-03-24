using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Worflow.Dados.Interfaces;
using Worflow.Enum;
using Worflow.Models;
using Worflow.Repository;

namespace Worflow.Services;

public class PerfilService : IPerfilService
{
    private readonly IPerfilRepository _repository;
    public PerfilService(IPerfilRepository perfilRepository) => (_repository) = (perfilRepository);    

    public bool Alterar(Perfil obj)
    {
        Validator.ValidateObject(obj, new ValidationContext(obj), true);

        _repository.Alterar(obj);

        return obj.Id > 0 ? true : false;
    }

    public ICollection<Perfil> BuscarTodos() => _repository.BuscarTodos();

    public Perfil BuscarPorId(int id)
    {
        if (id == 0)
            throw new Exception(Mensagens.PERFIL_BUSCAR_ID_ZERADO);

        return _repository.BuscarPorId(id);
    }

    public bool Excluir(Perfil obj)
    {
        if (obj.Id == 0)
            throw new Exception(Mensagens.PERFIL_EXCLUIR_ID_ZERADO);

        _repository.Excluir(obj);

        return obj.Id > 0 ? true : false;
    }

    public bool Incluir(Perfil obj)
    {
        Validator.ValidateObject(obj, new ValidationContext(obj), true);

        _repository.Incluir(obj);

        return obj.Id > 0 ? true : false;
    }

    public ICollection<Perfil> Pesquisar(string value) => _repository.Pesquisar(value);    
}
