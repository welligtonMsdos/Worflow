using System.Collections.Generic;
using Worflow.Dados.Interfaces;
using Worflow.Models;
using Worflow.Repository;

namespace Worflow.Services
{
    public class ProdutoService : IProdutoService
    {
        IProdutoDao _produtoDao;
        public ProdutoService(IProdutoDao produtoDao)
        {
            _produtoDao = produtoDao;
        }
        public Produto BuscarPorId(int id)
        {
            return _produtoDao.BuscarPorId(id);
        }

        public ICollection<Produto> BuscarProdutos()
        {
            return _produtoDao.BuscarTodos();
        }

        public ICollection<Produto> BuscarProdutosPorSegmento(int segmentoId)
        {
            return _produtoDao.BuscarProdutosPorSegmento(segmentoId);
        }
    }
}
