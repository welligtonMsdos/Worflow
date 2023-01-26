using System.Collections.Generic;
using Worflow.Models;

namespace Worflow.Dados.Interfaces
{
    public interface ILeadService
    {
        ICollection<Lead> BuscarLeads();
        ICollection<Lead> Pesquisar(string value);
        Lead BuscarPorId(int id);
        void Incluir(Lead obj);
        void Alterar(Lead obj);
        void Excluir(Lead obj);        
    }
}
