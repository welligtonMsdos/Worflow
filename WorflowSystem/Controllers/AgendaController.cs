using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using Worflow.Core;
using Worflow.Dados.EFCore;
using Worflow.Dados.Interfaces;
using Worflow.Models;
using Worflow.Services;
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
        
        public IActionResult InserirTarefa(string data, string horario, string comentario)
        {
            string result = _agendaService.AgendaPost(data, horario, comentario);

            if (!result.Equals("OK")) return Json(new { IsCreated = false, ErrorMessage = result });

            return RedirectToAction(nameof(ListarAgendas));
        }

        public IActionResult AtualizarAgenda(string data, string horario, string comentario, int agendaId)
        {
            string result = _agendaService.AgendaPut(data, horario, comentario, agendaId);

            if (!result.Equals("OK")) return Json(new { IsCreated = false, ErrorMessage = result });

            return RedirectToAction(nameof(ListarAgendas));
        }

        public IActionResult ExcluirAgenda(int agendaId)
        {
            if (agendaId > 0)
            {
                var agenda = _agendaService.BuscarPorId(agendaId);

                _agendaService.Excluir(agenda);

                return RedirectToAction(nameof(ListarAgendas));
            }

            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult BuscarEditarAgenda(int agendaId)
        {
            var agenda = _agendaService.BuscarPorId(agendaId);
            
            return PartialView("~/Views/Agenda/PartialViews/_EditarAgenda.cshtml", agenda);
        }

        public IActionResult BuscarExcluirAgenda(int agendaId)
        {
            var agenda = _agendaService.BuscarPorId(agendaId);           

            return PartialView("~/Views/Agenda/PartialViews/_ExcluirAgenda.cshtml", agenda);
        }

        public ActionResult EditarAgenda(int agendaID)
        {
            var agenda = _agendaService.BuscarPorId(agendaID);

            return View(agenda);
        }
    }
}
