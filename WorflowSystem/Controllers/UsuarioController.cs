using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Worflow.Dados.Interfaces;
using Worflow.Models;

namespace Worflow.Controllers
{
    public class UsuarioController : Controller
    {
        IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }
        public IActionResult GetUsuario()
        {
            var usuarios = _usuarioService.BuscarUsuarios();
            return View(usuarios);
        }

        [Route("Detalhes/{id}")]
        public ActionResult Detalhes(int id)
        {
            var usuario = _usuarioService.BuscarPorId(id);
            return View(usuario);
        }

        [Route("Editar/{id}")]
        public ActionResult Editar(int id)
        {
            var usuario = _usuarioService.BuscarPorId(id);
            return View(usuario);
        }

        [Route("Create")]
        public ActionResult Create()
        {
            var usuario = new Usuario();
            return View(usuario);
        }
    }
}
