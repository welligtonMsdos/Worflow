using System;
using Worflow.Dados.Builder.Interfaces;
using Worflow.Models;

namespace Worflow.Dados.Builder;

public class AgendaGeneratorBuilder : IDadosBuilder<Agenda>
{
    private Agenda agenda;
    public AgendaGeneratorBuilder() => Dados();

    public void Dados()
    {
        agenda = new Agenda(Id, DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), "comentário");
    }

    public int Id => 1;    

    public Agenda DeleteNotValid()
    {
        agenda.Id = 0;
        return agenda;
    }

    public Agenda DeleteValid() => Get();

    public Agenda Get()
    {
        agenda.Id = Id;
        return agenda;
    }

    public Agenda Post() => agenda;

    public Agenda Put() => Get();
}
