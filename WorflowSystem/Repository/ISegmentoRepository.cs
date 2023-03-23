using Worflow.Dados.Interfaces;
using Worflow.Models;

namespace Worflow.Repository
{
    public interface ISegmentoRepository : IQuery<Segmento>, IQueryDescription<Segmento>, ICommand<Segmento>, IQueryPesquisa<Segmento>
    {      
    }
}
