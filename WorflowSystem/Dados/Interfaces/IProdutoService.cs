using System.Collections.Generic;
using Worflow.Models;

namespace Worflow.Dados.Interfaces;

public interface IProdutoService: IServiceDefault<Produto>
{   
    ICollection<ProdutoSegmento> BuscarProdutosPorSegmento(int segmentoId);  
}
