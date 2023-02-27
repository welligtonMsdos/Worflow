using System.Collections.Generic;
using Worflow.Dados.Interfaces;
using Worflow.Models;
using Worflow.Repository;

namespace Worflow.Services
{
    public class AdminService : IAdminService
    {
        IClienteRepository _clienteDao;
        IEnderecoRepository _enderecoDao;
        IUsuarioRepository _usuarioDao;

        public AdminService(IClienteRepository clienteDao, IEnderecoRepository enderecoDao, IUsuarioRepository usuarioDao)
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
