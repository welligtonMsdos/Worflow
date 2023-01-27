using Microsoft.AspNetCore.Mvc;
using Worflow.Dados.Interfaces;
using Worflow.Models;

namespace Worflow.Controllers
{
    public class LeadController : Controller
    {
        ILeadService _leadService;
        ISegmentoService _segmentoService;
        IProdutoService _produtoService;
        

        public LeadController(ILeadService leadService, ISegmentoService segmentoService, IProdutoService produtoService)
        {
            _leadService = leadService;
            _segmentoService = segmentoService;
            _produtoService = produtoService;
        }

        [Route("CreateLead")]      

        public ActionResult CreateLead()
        {
            var lead = new Lead();

            lead.StatusId = 1;

            ViewBag.Segmentos = _segmentoService.BuscarSegmentos();

            return View(lead);
        }

        public ActionResult _CarregaProdutos(int id)
        {
            var produtos = _produtoService.BuscarProdutosPorSegmento(id);

            return PartialView(produtos);
        }
    }
}
