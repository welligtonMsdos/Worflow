using System.Collections.Generic;
using System.Linq;
using Worflow.Models;
using Worflow.Repository;

namespace Worflow.Dados.EFCore
{
    public class SeguradoraEF : ISeguradoraRepository
    {
        AppDbContext _context;
        public SeguradoraEF(AppDbContext context)
        {
            _context = context;
        }

        public Seguradora BuscarPorId(int id)
        {
           return _context.Seguradora.First(x => x.Id == id);
        }

        public ICollection<Seguradora> BuscarTodos()
        {
            return _context.Seguradora
                .Where(x => x.Ativo)
                .OrderBy(x => x.Nome)
                .ToList();
        }
    }
}
