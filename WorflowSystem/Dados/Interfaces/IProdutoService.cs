using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Worflow.Models;

namespace Worflow.Dados.Interfaces
{
    public interface IProdutoService
    {
        ICollection<Produto> BuscarProdutos();
        ICollection<ProdutoSegmento> BuscarProdutosPorSegmento(int segmentoId);
        Produto BuscarPorId(int id);
    }
}
