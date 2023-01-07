using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Worflow.Dados.Interfaces;
using Worflow.Models;
using WorflowSystem.Models;

namespace Worflow.Controllers
{
    public class EnderecoController : Controller
    {
        IEnderecoService _enderecoService;

        public EnderecoController(IEnderecoService enderecoService)
        {
            _enderecoService = enderecoService;
        }

        public IActionResult GetEndereco()
        {
            var enderecos = _enderecoService.BuscarEnderecos();
            return View(enderecos);
        }

        [Route("PesquisarEnderecos")]
        public ActionResult PesquisarEnderecos(string pesquisar)
        {
            var enderecos = _enderecoService.Pesquisar(pesquisar);

            return View("GetEndereco", enderecos);
        }
    }
}
