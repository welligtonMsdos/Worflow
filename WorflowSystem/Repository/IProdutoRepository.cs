using System.Collections.Generic;
using Worflow.Dados.Interfaces;
using Worflow.Models;

namespace Worflow.Repository
{
    public interface IProdutoRepository : IQuery<Produto>
    {
        ICollection<ProdutoSegmento> BuscarProdutosPorSegmento(int segmentoId);
    }
}
