using System.Collections.Generic;
using Worflow.Dados.Interfaces;
using Worflow.Models;

namespace Worflow.Repository;

public interface IAnexoRepository : IQuery<Anexo>, ICommand<Anexo>, IQueryPesquisa<Anexo>
{
    ICollection<Anexo> BuscarPorLeadId(int leadId);
}
