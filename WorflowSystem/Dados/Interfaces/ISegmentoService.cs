using System.Collections.Generic;
using Worflow.Models;

namespace Worflow.Dados.Interfaces
{
    public interface ISegmentoService
    {
        ICollection<Segmento> BuscarSegmentos();
        Segmento BuscarPorId(int id);
        ICollection<Segmento> Pesquisar(string value);      
        bool Incluir(Segmento obj);
        bool Alterar(Segmento obj);
        bool Excluir(Segmento obj);
    }
}
