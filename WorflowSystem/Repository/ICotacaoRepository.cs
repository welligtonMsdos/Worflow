using System.Collections.Generic;
using Worflow.Dados.Interfaces;
using Worflow.Models;

namespace Worflow.Repository
{
    public interface ICotacaoRepository: IQuery<Cotacao>, ICommand<Cotacao>
    {
        ICollection<Cotacao> BuscarCotacoesPorLeadId(int leadId);
    }
}
