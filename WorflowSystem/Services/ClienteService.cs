using System.Collections.Generic;
using Worflow.Dados.Interfaces;
using Worflow.Models;
using Worflow.Repository;

namespace Worflow.Services
{
    public class ClienteService : IClienteService
    {
        IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }
        public ICollection<Cliente> BuscarClientes()
        {
            return _clienteRepository.BuscarTodos();
        }

        public Cliente BuscarPorId(int id)
        {
            return _clienteRepository.BuscarPorId(id);
        }

        public ICollection<Cliente> Pesquisar(string value)
        {
            return _clienteRepository.Pesquisar(value);
        }
    }
}
