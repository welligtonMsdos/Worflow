using System.Collections.Generic;
using Worflow.Models;

namespace Worflow.Dados.Interfaces
{
    public interface ISegmentoService
    {
        ICollection<Segmento> BuscarSegmentos();
        Segmento BuscarPorId(int id);       
    }
}
