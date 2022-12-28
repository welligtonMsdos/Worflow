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

        public ICollection<Produto> BuscarTodos()
        {
            return _context.Produtos
                .OrderBy(x => x.Descricao)
                .ToList();
        }
    }
}
