using System.Collections.Generic;
using Worflow.Models;

namespace Worflow.Dados.Interfaces
{
    public interface IClienteService
    {
        ICollection<Cliente> BuscarClientes();
        ICollection<Cliente> Pesquisar(string value);
        Cliente BuscarPorId(int id);
    }
}
