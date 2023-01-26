using Worflow.Dados.Interfaces;
using Worflow.Models;

namespace Worflow.Repository
{
    public interface ILeadDao : IQuery<Lead>, ICommand<Lead>, IQueryPesquisa<Lead>
    {
    }
}
