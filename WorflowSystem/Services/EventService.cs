using System;
using System.Collections.Generic;
using Worflow.Dados.Interfaces;
using Worflow.Enum;
using Worflow.Models;
using Worflow.Repository;

namespace Worflow.Services;

public class EventService : IEventService
{
    private readonly IEventRepository _repository;

    public EventService(IEventRepository repository) => (_repository) = (repository);

    public bool Alterar(Event obj)
    {
        throw new System.NotImplementedException();
    }

    public Event BuscarPorId(int id)
    {
        if (id == 0)
            throw new Exception(Mensagens.USUARIO_BUSCAR_ID_ZERADO);

        return _repository.BuscarPorId(id);
    }

    public ICollection<Event> BuscarTodos()
    {
        return _repository.BuscarTodos();
    }

    public bool Excluir(Event obj)
    {
        throw new System.NotImplementedException();
    }

    public bool Incluir(Event obj)
    {
        throw new System.NotImplementedException();
    }

    public ICollection<Event> Pesquisar(string value)
    {
        throw new System.NotImplementedException();
    }
}
