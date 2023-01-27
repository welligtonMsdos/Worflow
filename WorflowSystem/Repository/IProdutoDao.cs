using System.Collections.Generic;
using Worflow.Dados.Interfaces;
using Worflow.Models;

namespace Worflow.Repository
{
    public interface IProdutoDao : IQuery<Produto>
    {
        ICollection<Produto> BuscarProdutosPorSegmento(int segmentoId);
    }
}
