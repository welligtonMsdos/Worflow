﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;
using Worflow.Core;
using Worflow.Dados.Interfaces;
using Worflow.Models;
using WorflowSystem.Models;

namespace Worflow.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
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
                _leadService.Incluir(lead, Request.Form["caixaSelecao"]);

                return RedirectToAction("ListarLead", "Lead");
            }

            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult ListarLead(int pagina = 1)
        {       
            var leads = _leadService.BuscarLeads();

            return View(leads);
        }

        [Route("PesquisarLeads")]
        public ActionResult PesquisarLeads(string pesquisar, int pagina = 1)
        {          
            var leads = _leadService.Pesquisar(pesquisar);

            return View("ListarLead", leads);
        }

        [Route("EditarLead/{id}")]
        public ActionResult EditarLead(int id)
        {
            if (id == 0) return View(new LeadCotacao(new Lead(), new Cotacao()));

            var leadCotacao = _leadService.BuscarLeadCotacaoPorId(id);

            ViewBag.Status = _statusService.BuscarStatus(leadCotacao.Lead);

            ViewBag.Seguradoras = _seguradoraService.BuscarSeguradoras();           

            ViewBag.StatusSeguradora = _cotacaoService.BuscarDadosSeguradora(id);

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

        #region Cotação

        public IActionResult InserirCotacao(string dataEmissao, string dataVencimento, decimal valor, int leadId, int seguradoraId)
        {
            if (ModelState.IsValid)
            {
                var cotacao = new Cotacao(dataEmissao, dataVencimento, valor, leadId, seguradoraId);

                _cotacaoService.Incluir(cotacao);

                var cotacoes = _cotacaoService.BuscarCotacoesPorLeadId(cotacao.LeadId);

                return PartialView("~/Views/Lead/PartialViews/_TabelaCotacoes.cshtml", cotacoes);
            }

            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult AtualizarCotacao(string dataEmissao, string dataVencimento, decimal valor, int leadId, int seguradoraId, int cotacaoId, string statusCotacao)
        {
            string result = _cotacaoService.IsCotacaoValid(dataEmissao, dataVencimento, valor, leadId, seguradoraId, cotacaoId, statusCotacao);
            
            if (!result.Equals("OK")) return Json(new { IsCreated = false, ErrorMessage = result });
            
            var cotacoes = _cotacaoService.BuscarCotacoesPorLeadId(leadId);

            return PartialView("~/Views/Lead/PartialViews/_TabelaCotacoes.cshtml", cotacoes);            
        }

        public IActionResult ExcluirCotacao(int cotacaoId, int leadId)
        {
            if (cotacaoId > 0)
            {
                var cotacao = _cotacaoService.BuscarPorId(cotacaoId);

                _cotacaoService.Excluir(cotacao);

                var cotacoes = _cotacaoService.BuscarCotacoesPorLeadId(leadId);

                return PartialView("~/Views/Lead/PartialViews/_TabelaCotacoes.cshtml", cotacoes);
            }

            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult BuscarCotacao(int leadId)
        {
            var cotacoes = _cotacaoService.BuscarCotacoesPorLeadId(leadId);

            return PartialView("~/Views/Lead/PartialViews/_TabelaCotacoes.cshtml", cotacoes);
        }

        public IActionResult BuscarDetalheCotacao(int cotacaoId)
        {
            var cotacao = _cotacaoService.BuscarPorId(cotacaoId);

            return PartialView("~/Views/Lead/PartialViews/_DetalhesCotacao.cshtml", cotacao);
        }

        public IActionResult BuscarEditarCotacao(int cotacaoId)
        {
            var cotacao = _cotacaoService.BuscarPorId(cotacaoId);

            ViewBag.Seguradoras = _seguradoraService.BuscarSeguradoras();

            ViewBag.Opcoes = Util.GetOpcoesAprovadaNegada();            

            return PartialView("~/Views/Lead/PartialViews/_EditarCotacao.cshtml", cotacao);
        }

        public IActionResult BuscarExcluirCotacao(int cotacaoId)
        {
            var cotacao = _cotacaoService.BuscarPorId(cotacaoId);

            ViewBag.Seguradoras = _seguradoraService.BuscarSeguradoras();

            return PartialView("~/Views/Lead/PartialViews/_ExcluirCotacao.cshtml", cotacao);
        }

        #endregion
    }
}
