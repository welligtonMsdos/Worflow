using System.Collections.Generic;
using Worflow.Dados.Interfaces;
using Worflow.Models;
using Worflow.Repository;
namespace Worflow.Services
{
    public class UsuarioService : IUsuarioService
    {
        IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public void Alterar(Usuario obj)
        {
            _usuarioRepository.Alterar(obj);
        }

        public Usuario BuscarPorId(int id)
        {
            return _usuarioRepository.BuscarPorId(id);
        }

        public ICollection<Usuario> BuscarUsuarios()
        {
            return _usuarioRepository.BuscarTodos();
        }

        public void Excluir(Usuario obj)
        {
            _usuarioRepository.Excluir(obj);
        }

        public void Incluir(Usuario obj)
        {
            _usuarioRepository.Incluir(obj);
        }

        public ICollection<Usuario> Pesquisar(string value)
        {
            return _usuarioRepository.Pesquisar(value);
        }

        public bool UsuarioExiste(Usuario obj)
        {
            return _usuarioRepository.UsuarioExiste(obj);
        }
    }
}
