using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using Worflow.Dados.Interfaces;
using Worflow.Models;
using WorflowSystem.Models;

namespace Worflow.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
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

                return RedirectToAction(nameof(ListarAgendas));
            }

            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
     
        public ActionResult EditarAgenda(int agendaID)
        {
            var agenda = _agendaService.BuscarPorId(agendaID);

            return View(agenda);
        }
      
        [Route("AtualizarAgenda")]      
        public ActionResult AtualizarAgenda(Agenda agenda)
        {
            if (ModelState.IsValid)
            {
                _agendaService.Alterar(agenda);

                return RedirectToAction(nameof(ListarAgendas));
            }

            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
       
        [Route("ExcluirAgenda")]
        public ActionResult ExcluirAgenda(int id)
        {
            if (id > 0)
            {
                var agenda = _agendaService.BuscarPorId(id);

                _agendaService.Excluir(agenda);

                return RedirectToAction(nameof(ListarAgendas));
            }

            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
