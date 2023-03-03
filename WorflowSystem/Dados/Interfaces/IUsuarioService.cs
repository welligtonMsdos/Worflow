using System.Collections.Generic;
using Worflow.Models;

namespace Worflow.Dados.Interfaces
{
    public interface IUsuarioService
    {
        ICollection<Usuario> BuscarUsuarios();
        ICollection<Usuario> Pesquisar(string value);
        Usuario BuscarPorId(int id);
        bool Incluir(Usuario obj);
        bool Alterar(Usuario obj);
        bool Excluir(Usuario obj);       
    }
}
