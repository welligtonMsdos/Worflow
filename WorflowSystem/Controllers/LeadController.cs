using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;
using Worflow.Dados.Interfaces;
using Worflow.Models;
using Worflow.Services;
using WorflowSystem.Models;

namespace Worflow.Controllers
{
    public class LeadController : Controller
    {
        ILeadService _leadService;
        ISegmentoService _segmentoService;
        IProdutoService _produtoService;
        IClienteService _clienteService;

        public LeadController(ILeadService leadService, ISegmentoService segmentoService, 
                              IProdutoService produtoService, IClienteService clienteService)
        {
            _leadService = leadService;
            _segmentoService = segmentoService;
            _produtoService = produtoService;
            _clienteService = clienteService;
        }

        [Route("CreateLead")]      

        public ActionResult CreateLead()
        {
            var lead = new Lead();

            lead.StatusId = 1;
            lead.UsuarioId = 1;
            lead.SegmentoId = 1;

            ViewBag.Segmentos = _segmentoService.BuscarSegmentos();

            return View(lead);
        }

        public ActionResult _CarregaProdutos(int id)
        {
            ICollection<ProdutoSegmento> produtoSegmento = _produtoService.BuscarProdutosPorSegmento(id);

            return PartialView(produtoSegmento);
        }

        public ActionResult BuscarCliente(string cnpj)
        {
            var cliente = _clienteService.Pesquisar(cnpj);

            return Json(cliente);
        }

        [Route("InserirLead")]
        public ActionResult InserirLead(Lead lead)
        {
            if (ModelState.IsValid)
            {      
                _leadService.Incluir(lead, Request.Form["produtos"]);

                return RedirectToAction("ListarLead", "Lead");
            }

            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult ListarLead()
        {
            var leads = _leadService.BuscarLeads();
            return View(leads);
        }

        [Route("PesquisarLeads")]
        public ActionResult PesquisarLeads(string pesquisar)
        {
            var leads = _leadService.Pesquisar(pesquisar);

            return View("ListarLead", leads);
        }

        [Route("EditarLead/{id}")]
        public ActionResult EditarLead(int id)
        {
            var lead = _leadService.BuscarPorId(id);          

            return View(lead);
        }

        [Route("ExcluirLead")]
        public ActionResult ExcluirLead(int id)
        {
            if (id > 0)
            {
                var lead = _leadService.BuscarPorId(id);

                _leadService.Excluir(lead);

                return RedirectToAction("ListarLead", "Lead");
            }

            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Route("DetalhesLead/{id}")]
        public ActionResult DetalhesLead(int id)
        {
            var lead = _leadService.BuscarPorId(id);
            return View(lead);
        }

    }
}
