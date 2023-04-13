using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Worflow.Dados.Interfaces;
using Worflow.Enum;
using Worflow.Models;
using Worflow.Repository;
using Worflow.ValidatorFluent;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace Worflow.Services;

public class AgendaService : IAgendaService
{
    private readonly IAgendaRepository _repository;

    public AgendaService(IAgendaRepository repository) => (_repository) = (repository);
    
    public bool Alterar(Agenda obj)
    {
        AgendaDefault(ref obj);

        Validator.ValidateObject(obj, new ValidationContext(obj), true);

        _repository.Alterar(obj);

        return obj.Id > 0 ? true : false;
    }

    public ICollection<Agenda> BuscarTodos() => _repository.BuscarTodos();

    public List<DatasAgenda> BuscarDatas() => SetarDatasAgenda(ListarDatas());        

    public ICollection<Agenda> BuscarHorarios(DateTime data) => _repository.BuscarHorarios(data);        

    public Agenda BuscarPorId(int id)
    {
        if (id == 0)
            throw new Exception(Mensagens.AGENDA_BUSCAR_ID_ZERADO);

        return _repository.BuscarPorId(id);
    }

    public bool Excluir(Agenda obj)
    {
        if (obj.Id == 0)
            throw new Exception(Mensagens.AGENDA_EXCLUIR_ID_ZERADO);

        _repository.Excluir(obj);

        return obj.Id > 0 ? true : false;
    }

    public bool Incluir(Agenda obj)
    {
        AgendaDefault(ref obj);

        System.ComponentModel.DataAnnotations.Validator.ValidateObject(obj, new System.ComponentModel.DataAnnotations.ValidationContext(obj), true);

        _repository.Incluir(obj);

        return obj.Id > 0 ? true : false;
    }

    private void AgendaDefault(ref Agenda agenda)
    {
        agenda.Ativo = true;
        agenda.LeadId = 1;
        agenda.UsuarioId = 1;
    }

    private List<Agenda> ListarDatas()
    {
        var query = _repository.BuscarDatas();

        List<Agenda> listaAgenda = new List<Agenda>();

        foreach (IGrouping<DateTime, Agenda> group in query)
        {
            foreach (Agenda agenda in group)
            {
                listaAgenda.Add(new Agenda(agenda.DataAgendada));
                break;
            }
        }

        return listaAgenda;
    }

    private List<DatasAgenda> SetarDatasAgenda(List<Agenda> listaAgenda)
    {
        List<DatasAgenda> listaDatasAgenda = new List<DatasAgenda>();

        listaAgenda.ForEach(delegate (Agenda agenda)
        {
            listaDatasAgenda.Add(new DatasAgenda(agenda.DataAgendada.ToShortDateString(), 
                                                 "collapse" + agenda.DataAgendada.ToShortDateString().Replace("/", "")));
        });

        return listaDatasAgenda;
    }

    public ICollection<Agenda> Pesquisar(string value) => _repository.Pesquisar(value);
   
    public string AgendaPut(string data, string horario, string comentario, int agendaId)
    {
        Agenda agenda = new Agenda(agendaId, data, horario, comentario);

        AgendaValidator validator = new AgendaValidator();

        ValidationResult results = validator.Validate(agenda);

        if (!results.IsValid) return results.ToString("~");

        Alterar(agenda);

        return "OK";
    }

    public string AgendaPost(string data, string horario, string comentario)
    {
        Agenda agenda = new Agenda(data, horario, comentario);

        AgendaValidator validator = new AgendaValidator();

        ValidationResult results = validator.Validate(agenda);

        if (!results.IsValid) return results.ToString("~");

        Incluir(agenda);

        return "OK";
    }
}
