using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using Worflow.Dados.Interfaces;
using Worflow.Models;
using Worflow.Services;
using WorflowSystem.Models;

namespace Worflow.Controllers
{
    public class CotacaoController : Controller
    {
        ICotacaoService _cotacaoService;

        public CotacaoController(ICotacaoService cotacaoService)
        {
            _cotacaoService = cotacaoService;
        }

        [Route("CreateCotacao")]
        public ActionResult CreateCotacao()
        {
            var cotacao = new Cotacao();            

            return View(cotacao);
        }

        [Route("InserirCotacao")]
        public ActionResult InserirCotacao(Cotacao cotacao)
        {
            if (ModelState.IsValid)
            {
                _cotacaoService.Incluir(cotacao);

                return RedirectToAction("");
            }

            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
