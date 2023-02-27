using Worflow.Dados.Interfaces;
using Worflow.Models;

namespace Worflow.Repository
{
    public interface IUsuarioRepository : IQuery<Usuario>, ICommand<Usuario>, IQueryPesquisa<Usuario>
    {
        bool UsuarioExiste(Usuario obj);
    }
}
