using System.Collections.Generic;
using Worflow.Dados.Interfaces;
using Worflow.Models;
using Worflow.Repository;
namespace Worflow.Services
{
    public class UsuarioService : IUsuarioService
    {
        IUsuarioDao _usuarioDao;

        public UsuarioService(IUsuarioDao usuarioDao)
        {
            _usuarioDao = usuarioDao;
        }

        public void Alterar(Usuario obj)
        {
            _usuarioDao.Alterar(obj);
        }

        public Usuario BuscarPorId(int id)
        {
            return _usuarioDao.BuscarPorId(id);
        }

        public ICollection<Usuario> BuscarUsuarios()
        {
            return _usuarioDao.BuscarTodos();
        }

        public void Excluir(Usuario obj)
        {
            _usuarioDao.Excluir(obj);
        }

        public void Incluir(Usuario obj)
        {
            _usuarioDao.Incluir(obj);
        }

        public bool UsuarioExiste(Usuario obj)
        {
            return _usuarioDao.UsuarioExiste(obj);
        }
    }
}
