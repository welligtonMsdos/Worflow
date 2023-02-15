using System.Collections.Generic;
using Worflow.Models;

namespace Worflow.Dados.Interfaces
{
    public interface IAgendaService
    {
        ICollection<Agenda> BuscarAgenda();

        List<DatasAgenda> BuscarAgendaList();
    }
}
