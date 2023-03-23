using System.Collections.Generic;
using Worflow.Dados.Interfaces;
using Worflow.Models;

namespace Worflow.Repository;

public interface IProdutoRepository : IQuery<Produto>, ICommand<Produto>, IQueryPesquisa<Produto>
{
    ICollection<ProdutoSegmento> BuscarProdutosPorSegmento(int segmentoId);
}
