using Worflow.Dados.Interfaces;
using Worflow.Models;

namespace Worflow.Repository
{
    public interface ISeguradoraRepository: IQuery<Seguradora>, ICommand<Seguradora>, IQueryPesquisa<Seguradora>
    {
    }
}
