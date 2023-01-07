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

        [Route("InserirUsuarios")]
        public ActionResult InserirUsuarios(Usuario usuario)
        {           
            if (ModelState.IsValid)
            {
                if (!_usuarioService.UsuarioExiste(usuario))
                    _usuarioService.Incluir(usuario);

                return RedirectToAction("GetUsuario", "Usuario");
            }

            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
        [Route("AtualizarUsuarios")]
        public ActionResult AtualizarUsuarios(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _usuarioService.Alterar(usuario);

                return RedirectToAction("GetUsuario", "Usuario");
            }

            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Route("ExcluirUsuarios")]
        public ActionResult ExcluirUsuarios(int id)
        {
            if(id > 0) {
                var usuario = _usuarioService.BuscarPorId(id);

                _usuarioService.Excluir(usuario);

                return RedirectToAction("GetUsuario", "Usuario");
            }

            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Route("PesquisarUsuarios")]
        public ActionResult PesquisarUsuarios(string pesquisar)
        {
            var usuarios = _usuarioService.Pesquisar(pesquisar);

            return View("GetUsuario", usuarios);
        }
    }
}

