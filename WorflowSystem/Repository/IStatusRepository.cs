using System.Collections.Generic;
using Worflow.Dados.Interfaces;
using Worflow.Models;
namespace Worflow.Repository
{
    public interface IStatusRepository : IQuery<Status>, IQueryDescription<Status>
    {
        ICollection<Status> BuscarProximoStatus(List<int> statusId);
    }
}
