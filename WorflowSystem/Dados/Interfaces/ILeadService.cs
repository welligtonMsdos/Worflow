using System.Collections.Generic;
using Worflow.Models;
using X.PagedList;

namespace Worflow.Dados.Interfaces
{
    public interface ILeadService
    {
        ICollection<Lead> BuscarLeads();
        IPagedList<Lead> BuscarLeadsByPageList(int pagina);
        ICollection<Lead> Pesquisar(string value);
        IPagedList<Lead> PesquisarByPageList(string value, int pagina);
        Lead BuscarPorId(int id);
        void Incluir(Lead obj, string[] produtos);      
        void Alterar(Lead obj);       
        void Excluir(Lead obj);        
    }
}
