using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Worflow.Dados.Interfaces;
using Worflow.Models;

namespace Worflow.Controllers
{
    public class AgendaController : Controller
    {
        IAgendaService _agendaService;

        public AgendaController(IAgendaService agendaService)
        {
            _agendaService = agendaService;
        }

        public IActionResult Index()
        {
            var datas = _agendaService.BuscarAgendaList();
            return View(datas);
        }
    }
}
