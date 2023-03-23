using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Worflow.Dados.Interfaces;
using Worflow.Enum;
using Worflow.Models;
using Worflow.Repository;

namespace Worflow.Services;

public class SeguradoraService: ISeguradoraService
{
    private readonly ISeguradoraRepository _repository;
    public SeguradoraService(ISeguradoraRepository seguradoraRepository) => (_repository) = (seguradoraRepository);
    
    public bool Alterar(Seguradora obj)
    {
        Validator.ValidateObject(obj, new ValidationContext(obj), true);

        _repository.Alterar(obj);

        return obj.Id > 0 ? true : false;
    }

    public Seguradora BuscarPorId(int id)
    {
        if (id == 0)
            throw new Exception(Mensagens.SEGURADORA_BUSCAR_ID_ZERADO);

        return _repository.BuscarPorId(id);
    }

    public ICollection<Seguradora> BuscarSeguradoras() => _repository.BuscarTodos();
    
    public bool Excluir(Seguradora obj)
    {
        if (obj.Id == 0)
            throw new Exception(Mensagens.SEGURADORA_EXCLUIR_ID_ZERADO);

        _repository.Excluir(obj);

        return obj.Id > 0 ? true : false;
    }

    public bool Incluir(Seguradora obj)
    {
        Validator.ValidateObject(obj, new ValidationContext(obj), true);

        _repository.Incluir(obj);

        return obj.Id > 0 ? true : false;
    }

    public ICollection<Seguradora> Pesquisar(string value) => _repository.Pesquisar(value);        
}
