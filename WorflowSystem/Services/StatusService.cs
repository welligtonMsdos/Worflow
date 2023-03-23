using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Worflow.Core.StatusState;
using Worflow.Dados.Interfaces;
using Worflow.Enum;
using Worflow.Models;
using Worflow.Repository;

namespace Worflow.Services;

public class StatusService : IStatusService
{
    private readonly IStatusRepository _repository;
    private IStatusLead statusLeadRepository;

    public StatusService(IStatusRepository statusRepository) => (_repository) = (statusRepository);        

    public bool Alterar(Status obj)
    {
        Validator.ValidateObject(obj, new ValidationContext(obj), true);

        _repository.Alterar(obj);

        return obj.Id > 0 ? true : false;
    }

    public Status BuscarPorId(int id)
    {
        if (id == 0)
            throw new Exception(Mensagens.STATUS_BUSCAR_ID_ZERADO);

        return _repository.BuscarPorId(id);
    }

    public ICollection<Status> BuscarStatus(Lead lead)
    {
        RecuperaStatusAtual(lead.StatusId);
    
        return _repository.BuscarProximoStatus(statusLeadRepository.ProximoStatus()); 
    }

    public ICollection<Status> BuscarTodos() => _repository.BuscarTodos();       

    public bool Excluir(Status obj)
    {
        if (obj.Id == 0)
            throw new Exception(Mensagens.STATUS_EXCLUIR_ID_ZERADO);

        _repository.Excluir(obj);

        return obj.Id > 0 ? true : false;
    }

    public bool Incluir(Status obj)
    {
        Validator.ValidateObject(obj, new ValidationContext(obj), true);

        _repository.Incluir(obj);

        return obj.Id > 0 ? true : false;
    }

    public ICollection<Status> Pesquisar(string value) => _repository.Pesquisar(value);        

    private void RecuperaStatusAtual(int statusId)
    {
        switch (statusId)
        {
            case 1: statusLeadRepository = new StatusAtivo(); break;
            case 2: statusLeadRepository = new StatusEmAndamento(); break;
            case 3: statusLeadRepository = new StatusFinalizao(); break;
            case 4: statusLeadRepository = new StatusCotacao(); break;
            case 5: statusLeadRepository = new StatusImplantacao(); break;
        }
    }
}
