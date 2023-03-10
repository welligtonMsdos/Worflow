using System.Collections.Generic;
using Worflow.Models;
using X.PagedList;

namespace Worflow.Dados.Interfaces
{
    public interface ICotacaoService
    {
        ICollection<Cotacao> BuscarCotacoes();
        Cotacao BuscarPorId(int id);
        ICollection<Cotacao> BuscarCotacoesPorLeadId(int leadId);
        IPagedList<Cotacao> BuscarCotacoesByPageList(int leadId, int pagina = 1);
        bool Incluir(Cotacao obj);
        bool Alterar(Cotacao obj);
        bool Excluir(Cotacao obj);       
    }
}
