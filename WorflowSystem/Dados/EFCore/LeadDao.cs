using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Worflow.Models;
using Worflow.Repository;

namespace Worflow.Dados.EFCore
{
    public class LeadDao : ILeadDao
    {
        AppDbContext _context;

        public LeadDao(AppDbContext context)
        {
            _context = context;
        }
        public Lead BuscarPorId(int id)
        {
            return _context.Lead
                .Include(x => x.Usuario)
                .Include(x => x.Cliente)               
                .Include(x => x.Produto)
                .Include(x => x.Status)
                .First(x => x.Id == id);
        }

        public ICollection<Lead> BuscarTodos()
        {
            return _context.Lead
                .Include(x => x.Usuario)
                .Include(x => x.Cliente)               
                .Include(x => x.Produto)
                .Include(x => x.Status)
                .OrderByDescending(x => x.Id)
                .ToList();
        }
    }
}
