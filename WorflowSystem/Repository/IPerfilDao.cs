using Worflow.Dados.Interfaces;
using Worflow.Models;

namespace Worflow.Repository
{
    public interface IPerfilDao : IQuery<Perfil>, IQueryDescription<Perfil>
    {
    }
}
