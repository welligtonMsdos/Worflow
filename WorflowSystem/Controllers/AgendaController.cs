using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Worflow.Dados.Interfaces;
using Worflow.Models;
using Worflow.Services;
using WorflowSystem.Models;

namespace Worflow.Controllers
{
    public class AgendaController : Controller
    {
        IAgendaService _agendaService;

        public AgendaController(IAgendaService agendaService)
        {
            _agendaService = agendaService;
        }

        public IActionResult ListarAgendas()
        {
            var datas = _agendaService.BuscarDatas();

            return View(datas);
        }

        [HttpGet]
        public IActionResult CreateAgenda(string dataTarefa)
        {
            Agenda agenda = new Agenda(DateTime.Parse(dataTarefa));

            return View(agenda);
        }

        [Route("InserirAgenda")]
        public ActionResult InserirAgenda(Agenda agenda)
        {
            if (ModelState.IsValid)
            {
                _agendaService.Incluir(agenda);

                return RedirectToAction("ListarAgendas", "Agenda");
            }

            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
