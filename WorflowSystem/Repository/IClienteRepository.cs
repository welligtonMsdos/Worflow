using Worflow.Dados.Interfaces;
using Worflow.Models;

namespace Worflow.Repository
{
    public interface IClienteRepository : IQuery<Cliente>, IQueryPesquisa<Cliente>, ICommand<Cliente>
    {
    }
}
