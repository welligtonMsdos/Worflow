using System.Collections.Generic;
using Worflow.Models;

namespace Worflow.Dados.Interfaces
{
    public interface ISeguradoraService
    {
        ICollection<Seguradora> BuscarSeguradoras();
        Seguradora BuscarPorId(int id);
        ICollection<Seguradora> Pesquisar(string value);        
        bool Incluir(Seguradora obj);
        bool Alterar(Seguradora obj);
        bool Excluir(Seguradora obj);
    }
}
