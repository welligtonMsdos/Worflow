using System;
using System.Collections.Generic;
using Worflow.Models;

namespace Worflow.Dados.Interfaces;

public interface IAgendaService: IServiceDefault<Agenda>
{
    ICollection<Agenda> BuscarHorarios(DateTime data);
    List<DatasAgenda> BuscarDatas();
}
