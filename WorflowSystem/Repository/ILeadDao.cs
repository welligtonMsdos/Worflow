using System.Collections.Generic;
using Worflow.Dados.Interfaces;
using Worflow.Models;
using X.PagedList;

namespace Worflow.Repository
{
    public interface ILeadDao : IQuery<Lead>, ICommand<Lead>, IQueryPesquisa<Lead>
    {
        void Incluir(List<Lead> obj);
        ICollection<Lead> PesquisarPorId(int value);
        IPagedList<Lead> BuscarLeadsByPageList(int pagina);
        IPagedList<Lead> PesquisarByPageList(string value, int pagina);
    }
}
