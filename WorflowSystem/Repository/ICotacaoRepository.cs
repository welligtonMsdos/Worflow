using System.Collections.Generic;
using Worflow.Dados.Interfaces;
using Worflow.Models;
using X.PagedList;

namespace Worflow.Repository
{
    public interface ICotacaoRepository: IQuery<Cotacao>, ICommand<Cotacao>
    {
        ICollection<Cotacao> BuscarCotacoesPorLeadId(int leadId);
        IPagedList<Cotacao> BuscarCotacoesByPageList(int leadId, int pagina);
    }
}
