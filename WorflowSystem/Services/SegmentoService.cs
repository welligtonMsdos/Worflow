using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Worflow.Dados.Interfaces;
using Worflow.Enum;
using Worflow.Models;
using Worflow.Repository;

namespace Worflow.Services;

public class SegmentoService : ISegmentoService
{
    private readonly ISegmentoRepository _repository;

    public SegmentoService(ISegmentoRepository repository) => (_repository) = (repository);
   
    public bool Alterar(Segmento obj)
    {
        Validator.ValidateObject(obj, new ValidationContext(obj), true);

        _repository.Alterar(obj);

        return obj.Id > 0 ? true : false;
    }

    public Segmento BuscarPorId(int id)
    {
        if (id == 0)
            throw new Exception(Mensagens.SEGMENTO_BUSCAR_ID_ZERADO);

        return _repository.BuscarPorId(id);
    }       

    public ICollection<Segmento> BuscarTodos() => _repository.BuscarTodos();    

    public bool Excluir(Segmento obj)
    {
        if (obj.Id == 0)
            throw new Exception(Mensagens.SEGMENTO_EXCLUIR_ID_ZERADO);

        _repository.Excluir(obj);

        return obj.Id > 0 ? true : false;
    }

    public bool Incluir(Segmento obj)
    {
        Validator.ValidateObject(obj, new ValidationContext(obj), true);

        _repository.Incluir(obj);

        return obj.Id > 0 ? true : false;
    }

    public ICollection<Segmento> Pesquisar(string value) => _repository.Pesquisar(value);    
}
