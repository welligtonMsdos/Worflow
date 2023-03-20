using System.Collections.Generic;
using Worflow.Dados.Interfaces;
using Worflow.Models;
namespace Worflow.Repository
{
    public interface IStatusRepository : IQuery<Status>, IQueryDescription<Status>, ICommand<Status>, IQueryPesquisa<Status>
    {
        ICollection<Status> BuscarProximoStatus(List<int> statusId);
    }
}
