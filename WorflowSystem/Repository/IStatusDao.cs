using Worflow.Dados.Interfaces;
using Worflow.Models;
namespace Worflow.Repository
{
    public interface IStatusDao : IQuery<Status>, IQueryDescription<Status>
    {
    }
}
