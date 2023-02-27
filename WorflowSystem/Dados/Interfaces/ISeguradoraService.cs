using System.Collections.Generic;
using Worflow.Models;

namespace Worflow.Dados.Interfaces
{
    public interface ISeguradoraService
    {
        ICollection<Seguradora> BuscarSeguradoras();
        Seguradora BuscarPorId(int id);
    }
}
