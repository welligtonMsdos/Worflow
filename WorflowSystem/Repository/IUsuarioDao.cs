using Worflow.Dados.Interfaces;
using Worflow.Models;

namespace Worflow.Repository
{
    public interface IUsuarioDao : IQuery<Usuario>, ICommand<Usuario>, IQueryPesquisa<Usuario>
    {
        bool UsuarioExiste(Usuario obj);
    }
}
