using System.Collections.Generic;
using Worflow.Dados.Interfaces;
using Worflow.Models;
using Worflow.Repository;

namespace Worflow.Services
{
    public class ProdutoService : IProdutoService
    {
        IProdutoRepository _produtoRepository;
        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }
        public Produto BuscarPorId(int id)
        {
            return _produtoRepository.BuscarPorId(id);
        }

        public ICollection<Produto> BuscarProdutos()
        {
            return _produtoRepository.BuscarTodos();
        }

        public ICollection<ProdutoSegmento> BuscarProdutosPorSegmento(int segmentoId)
        {
            return _produtoRepository.BuscarProdutosPorSegmento(segmentoId);
        }
    }
}
