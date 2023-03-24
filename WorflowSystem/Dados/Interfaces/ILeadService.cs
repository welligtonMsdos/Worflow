using System.Collections.Generic;
using Worflow.Models;

namespace Worflow.Dados.Interfaces
{
    public interface ILeadService: IServiceDefault<Lead>
    {
        LeadCotacao BuscarLeadCotacaoPorId(int id);
        bool Incluir(Lead obj, string[] produtos);      
    }
}
