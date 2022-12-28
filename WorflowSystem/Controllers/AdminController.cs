using Microsoft.AspNetCore.Mvc;
using Worflow.Dados.Interfaces;

namespace Worflow.Controllers
{
    public class AdminController : Controller
    {
        IAdminService _service;

        public AdminController(IAdminService service)
        {
            _service = service;
        }
      
        public IActionResult GetUsuario()
        {
            var usuarios = _service.BuscarUsuarios();
            return View(usuarios);
        }

        public IActionResult GetEndereco()
        {
            var endereco = _service.BuscarEnderecos();
            return View(endereco);
        }

        public IActionResult GetCliente()
        {
            var cliente = _service.BuscarClientes();
            return View(cliente);
        }
    }
}
