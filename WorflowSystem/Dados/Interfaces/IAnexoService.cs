using System.Collections.Generic;
using Worflow.Models;

namespace Worflow.Dados.Interfaces;

public interface IAnexoService: IServiceDefault<Anexo>
{
    bool IncluirArquivo(Arquivo arquivo, int leadId);
    ICollection<Anexo> BuscarPorLeadId(int leadId);
}
