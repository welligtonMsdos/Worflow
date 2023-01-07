using System.Collections.Generic;
using Worflow.Models;

namespace Worflow.Dados.Interfaces
{
    public interface IAdminService
    {
        ICollection<Usuario> BuscarUsuarios();
        ICollection<Endereco> BuscarEnderecos();
        ICollection<Cliente> BuscarClientes();
    }
}
