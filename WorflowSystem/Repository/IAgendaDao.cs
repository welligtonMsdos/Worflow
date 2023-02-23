using System;
using System.Collections.Generic;
using System.Linq;
using Worflow.Dados.Interfaces;
using Worflow.Models;
namespace Worflow.Repository
{
    public interface IAgendaDao : IQuery<Agenda>, IQueryPesquisa<Agenda>,ICommand<Agenda>
    {
        ICollection<Agenda> BuscarPorUsuarioId(int usuarioId);        
        ICollection<Agenda> BuscarHorarios(DateTime data);
        IQueryable<IGrouping<DateTime, Agenda>> BuscarDatas();
    }
}
