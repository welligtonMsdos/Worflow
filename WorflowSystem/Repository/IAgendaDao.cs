using System;
using System.Collections.Generic;
using Worflow.Dados.Interfaces;
using Worflow.Models;
namespace Worflow.Repository
{
    public interface IAgendaDao : IQuery<Agenda>, IQueryPesquisa<Agenda>
    {
        ICollection<Agenda> BuscarPorUsuarioId(int usuarioId);
        ICollection<Agenda> BuscarAgendaList();
        ICollection<Agenda> BuscarHorarios(DateTime data);
    }
}
