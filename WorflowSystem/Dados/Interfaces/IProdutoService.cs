using System.Collections.Generic;
using Worflow.Models;

namespace Worflow.Dados.Interfaces;

public interface IProdutoService
{
    ICollection<Produto> BuscarProdutos();
    ICollection<ProdutoSegmento> BuscarProdutosPorSegmento(int segmentoId);
    Produto BuscarPorId(int id);
    ICollection<Produto> Pesquisar(string value);
    bool Incluir(Produto obj);
    bool Alterar(Produto obj);
    bool Excluir(Produto obj);
}
