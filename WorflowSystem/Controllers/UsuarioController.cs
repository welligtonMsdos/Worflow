using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Worflow.Dados.Interfaces;
using Worflow.Models;
using WorflowSystem.Models;

namespace Worflow.Controllers
{
    public class UsuarioController : Controller
    {
        IUsuarioService _usuarioService;
        IPerfilService _perfilService;

        public UsuarioController(IUsuarioService usuarioService, IPerfilService perfilService)
        {
            _usuarioService = usuarioService;
            _perfilService = perfilService;
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

            ViewBag.Perfil = _perfilService.BuscarPerfilList();

            return View(usuario);
        }

        [Route("Create")]
        public ActionResult Create()
        {
            var usuario = new Usuario();

            ViewBag.Perfil = _perfilService.BuscarPerfilList();

            return View(usuario);
        }

        [Route("Salvar")]
        public ActionResult Salvar(Usuario usuario)
        {           
            if (ModelState.IsValid)
            {
                _usuarioService.Incluir(usuario);

                return RedirectToAction("GetUsuario", "Usuario");
            }

            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
        [Route("SalvarEditar")]
        public ActionResult SalvarEditar(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _usuarioService.Alterar(usuario);

                return RedirectToAction("GetUsuario", "Usuario");
            }

            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Route("Excluir")]
        public ActionResult Excluir(int id)
        {
            if(id > 0) {
                var usuario = _usuarioService.BuscarPorId(id);

                _usuarioService.Excluir(usuario);

                return RedirectToAction("GetUsuario", "Usuario");
            }

            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Route("Pesquisar")]
        public ActionResult Pesquisar(string pesquisar)
        {
            var usuarios = _usuarioService.Pesquisar(pesquisar);

            return View("GetUsuario", usuarios);
        }
    }
}

