using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Worflow.Dados.Interfaces;
using Worflow.Models;
using WorflowSystem.Models;

namespace Worflow.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class EnderecoController : Controller
    {
        IEnderecoService _enderecoService;

        public EnderecoController(IEnderecoService enderecoService)
        {
            _enderecoService = enderecoService;
        }

        public IActionResult ListarEnderecos()
        {
            var enderecos = _enderecoService.BuscarTodos();
            return View(enderecos);
        }

        [Route("PesquisarEnderecos")]
        public ActionResult PesquisarEnderecos(string pesquisar)
        {
            var enderecos = _enderecoService.Pesquisar(pesquisar);

            return View(nameof(ListarEnderecos), enderecos);            
        }

        [Route("DetalhesEndereco/{id}")]
        public ActionResult DetalhesEndereco(int id)
        {
            var endereco = _enderecoService.BuscarPorId(id);

            return View(endereco);
        }

        [Route("EditarEndereco/{id}")]
        public ActionResult EditarEndereco(int id)
        {
            var endereco = _enderecoService.BuscarPorId(id);

            return View(endereco);
        }

        [Route("AtualizarEndereco")]
        public ActionResult AtualizarEndereco(Endereco endereco)
        {
            if (ModelState.IsValid)
            {
                _enderecoService.Alterar(endereco);
               
                return RedirectToAction(nameof(ListarEnderecos));
            }

            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Route("CreateEndereco")]
        public ActionResult CreateEndereco()
        {
            var endereco = new Endereco();

            return View(endereco);
        }

        [Route("InserirEndereco")]
        public ActionResult InserirEndereco(Endereco endereco)
        {
            if (ModelState.IsValid)
            {
               _enderecoService.Incluir(endereco);
              
                return RedirectToAction(nameof(ListarEnderecos));
            }

            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Route("ExcluirEndereco")]
        public ActionResult ExcluirEndereco(int id)
        {
            if (id > 0)
            {
                var endereco = _enderecoService.BuscarPorId(id);

                _enderecoService.Excluir(endereco);
               
                return RedirectToAction(nameof(ListarEnderecos));
            }

            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
