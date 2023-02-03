using System.Collections.Generic;
using Worflow.Dados.Interfaces;
using Worflow.Models;

namespace Worflow.Repository
{
    public interface ILeadDao : IQuery<Lead>, ICommand<Lead>, IQueryPesquisa<Lead>
    {
        void Incluir(List<Lead> obj);
    }
}
