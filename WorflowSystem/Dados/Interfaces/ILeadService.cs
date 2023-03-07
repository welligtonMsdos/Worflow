using System.Collections.Generic;
using Worflow.Models;
using X.PagedList;

namespace Worflow.Dados.Interfaces
{
    public interface ILeadService
    {
        ICollection<Lead> BuscarLeads();
        IPagedList<Lead> BuscarLeadsByPageList(int pagina = 1);
        ICollection<Lead> Pesquisar(string value);
        IPagedList<Lead> PesquisarByPageList(string value, int pagina = 1);
        LeadCotacao BuscarLeadCotacaoPorId(int id);
        Lead BuscarPorId(int id);
        bool Incluir(Lead obj, string[] produtos);      
        bool Alterar(Lead obj);       
        bool Excluir(Lead obj);       
    }
}
