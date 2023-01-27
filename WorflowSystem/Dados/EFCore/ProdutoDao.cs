using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Worflow.Models;
using Worflow.Repository;

namespace Worflow.Dados.EFCore
{
    public class ProdutoDao : IProdutoDao
    {
        AppDbContext _context;

        public ProdutoDao(AppDbContext context)
        {
            _context = context;
        }

        public Produto BuscarPorId(int id)
        {
            return _context.Produtos
                .Include(x => x.Segmento)
                .First(x => x.Id == id);
        }

        public ICollection<Produto> BuscarProdutosPorSegmento(int segmentoId)
        {
            return _context.Produtos
                .Include(x=>x.Segmento)
                .Where(x => x.SegmentoId == segmentoId)
                .OrderBy(x => x.Descricao)
                .ToList();
        }

        public ICollection<Produto> BuscarTodos()
        {
            return _context.Produtos
                .Include(x => x.Segmento)
                .OrderBy(x => x.Descricao)
                .ToList();
        }
    }
}
