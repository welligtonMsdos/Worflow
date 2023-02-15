using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Worflow.Dados.Interfaces;
using X.PagedList;

namespace Worflow.ViewsComponents
{
    public class ListaTarefasViewComponent : ViewComponent
    {
        IAgendaService _agendaService;

        public ListaTarefasViewComponent(IAgendaService agendaService)
        {
            _agendaService = agendaService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string data)
        {
            return View(await _agendaService.BuscarHorarios(DateTime.Parse(data)).ToListAsync());
        }
    }
}
