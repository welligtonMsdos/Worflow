using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Worflow.Dados.Interfaces;
using Worflow.Models;
using WorflowSystem.Models;

namespace Worflow.Controllers
{
    public class LeadController : Controller
    {
        ILeadService _leadService;
        ISegmentoService _segmentoService;

        public LeadController(ILeadService leadService, ISegmentoService segmentoService)
        {
            _leadService = leadService;
            _segmentoService = segmentoService;
        }

        [Route("CreateLead")]      

        public ActionResult CreateLead()
        {
            var lead = new Lead();

            ViewBag.Segmentos = _segmentoService.BuscarSegmentos();

            return View(lead);
        }
    }
}
