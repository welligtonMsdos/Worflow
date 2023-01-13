using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
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
        public IActionResult ListarUsuarios()
        {
            var usuarios = _usuarioService.BuscarUsuarios();
            return View(usuarios);
        }

        [Route("PesquisarUsuarios")]
        public ActionResult PesquisarUsuarios(string pesquisar)
        {
            var usuarios = _usuarioService.Pesquisar(pesquisar);

            return View("ListarUsuarios", usuarios);
        }

        [Route("DetalhesUsuario/{id}")]
        public ActionResult DetalhesUsuario(int id)
        {
            var usuario = _usuarioService.BuscarPorId(id);
            return View(usuario);
        }

        [Route("EditarUsuario/{id}")]
        public ActionResult EditarUsuario(int id)
        {
            var usuario = _usuarioService.BuscarPorId(id);

            ViewBag.Perfil = _perfilService.BuscarPerfilList();

            return View(usuario);
        }

        [Route("AtualizarUsuario")]
        public ActionResult AtualizarUsuario(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _usuarioService.Alterar(usuario);

                return RedirectToAction("ListarUsuarios", "Usuario");
            }

            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Route("CreateUsuario")]
        public ActionResult CreateUsuario()
        {
            var usuario = new Usuario();

            ViewBag.Perfil = _perfilService.BuscarPerfilList();

            return View(usuario);
        }

        [Route("InserirUsuario")]
        public ActionResult InserirUsuario(Usuario usuario)
        {           
            if (ModelState.IsValid)
            {
                if (!_usuarioService.UsuarioExiste(usuario))
                    _usuarioService.Incluir(usuario);

                return RedirectToAction("ListarUsuarios", "Usuario");
            }

            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }  

        [Route("ExcluirUsuario")]
        public ActionResult ExcluirUsuario(int id)
        {
            if(id > 0) {
                var usuario = _usuarioService.BuscarPorId(id);

                _usuarioService.Excluir(usuario);

                return RedirectToAction("ListarUsuarios", "Usuario");
            }

            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        
    }
}

