using System.Collections.Generic;
using Worflow.Dados.Interfaces;
using Worflow.Models;
using Worflow.Repository;

namespace Worflow.Services
{
    public class AdminService : IAdminService
    {
        IClienteDao _clienteDao;
        IEnderecoDao _enderecoDao;
        IUsuarioDao _usuarioDao;

        public AdminService(IClienteDao clienteDao, IEnderecoDao enderecoDao, IUsuarioDao usuarioDao)
        {
            _clienteDao = clienteDao;
            _enderecoDao = enderecoDao;
            _usuarioDao = usuarioDao;
        }

        public ICollection<Cliente> BuscarClientes()
        {
            return _clienteDao.BuscarTodos();
        }

        public ICollection<Endereco> BuscarEnderecos()
        {
            return _enderecoDao.BuscarTodos();
        }

        public ICollection<Usuario> BuscarUsuarios()
        {
            return _usuarioDao.BuscarTodos();
        }
    }
}
