using System.Collections.Generic;
using Worflow.Models;

namespace Worflow.Dados.Interfaces
{
    public interface ILeadService
    {
        ICollection<Lead> BuscarLeads();       
        ICollection<Lead> Pesquisar(string value);       
        LeadCotacao BuscarLeadCotacaoPorId(int id);
        Lead BuscarPorId(int id);
        bool Incluir(Lead obj, string[] produtos);      
        bool Alterar(Lead obj);       
        bool Excluir(Lead obj);       
    }
}
