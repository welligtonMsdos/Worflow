using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Worflow.Dados.EFCore;
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
        IStatusService _statusService;
        ICotacaoService _cotacaoService;
        ISeguradoraService _seguradoraService;       

        public LeadController(ILeadService leadService, ISegmentoService segmentoService,
                              IProdutoService produtoService, IClienteService clienteService,
                              IStatusService statusService, ICotacaoService cotacaoService, 
                              ISeguradoraService seguradoraService)
        {
            _leadService = leadService;
            _segmentoService = segmentoService;
            _produtoService = produtoService;
            _clienteService = clienteService;
            _statusService = statusService;
            _cotacaoService = cotacaoService;
            _seguradoraService = seguradoraService;           
        }

        [Route("CreateLead")]

        public ActionResult CreateLead()
        {
            var lead = new Lead();

            lead.StatusId = 1;
            lead.UsuarioId = 1;            

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

        public IActionResult ListarLead(int pagina = 1)
        {
            //var leads = _leadService.BuscarLeads();

            var leads = _leadService.BuscarLeadsByPageList(pagina);

            return View(leads);
        }       

        [Route("PesquisarLeads")]
        public ActionResult PesquisarLeads(string pesquisar, int pagina = 1)
        {
            //var leads = _leadService.Pesquisar(pesquisar);

            var leads = _leadService.PesquisarByPageList(pesquisar, pagina);

            return View("ListarLead", leads);
        }

        [Route("EditarLead/{id}")]
        public ActionResult EditarLead(int id)
        {
            var leadCotacao = _leadService.BuscarLeadCotacaoPorId(id);           

            ViewBag.Status = _statusService.BuscarStatus(leadCotacao.Lead);

            ViewBag.Seguradoras = _seguradoraService.BuscarSeguradoras();

            return View(leadCotacao);
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

        [Route("AtualizarLead")]
        public ActionResult AtualizarLead(Lead lead)
        {
            if (ModelState.IsValid)
            {
                _leadService.Alterar(lead);

                return RedirectToAction("ListarLead", "Lead");
            }

            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult InserirCotacao(DateTime dataEmissao,DateTime dataVencimento, decimal valor,int leadId, int seguradoraId)
        {
            Cotacao cotacao = new Cotacao(dataEmissao, dataVencimento,valor,leadId, seguradoraId);

            _cotacaoService.Incluir(cotacao);

            var cotacoes = _cotacaoService.BuscarCotacoesPorLeadId(leadId);            

            return PartialView("~/Views/Lead/PartialViews/_TabelaCotacoes.cshtml", cotacoes);
        }

        public IActionResult BuscarCotacao(int leadId)
        {
            var cotacoes = _cotacaoService.BuscarCotacoesPorLeadId(leadId);

            return PartialView("~/Views/Lead/PartialViews/_TabelaCotacoes.cshtml", cotacoes);
        }
    }
}
