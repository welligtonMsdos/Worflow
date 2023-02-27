using System.Collections.Generic;
using Worflow.Dados.Interfaces;
using Worflow.Models;
using Worflow.Repository;

namespace Worflow.Services
{
    public class ClienteService : IClienteService
    {
        IClienteRepository _clienteDao;

        public ClienteService(IClienteRepository clienteDao)
        {
            _clienteDao = clienteDao;
        }
        public ICollection<Cliente> BuscarClientes()
        {
            return _clienteDao.BuscarTodos();
        }

        public Cliente BuscarPorId(int id)
        {
            return _clienteDao.BuscarPorId(id);
        }

        public ICollection<Cliente> Pesquisar(string value)
        {
            return _clienteDao.Pesquisar(value);
        }
    }
}
