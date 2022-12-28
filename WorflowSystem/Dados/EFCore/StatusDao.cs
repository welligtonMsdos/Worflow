using System.Collections.Generic;
using System.Linq;
using Worflow.Models;
using Worflow.Repository;

namespace Worflow.Dados.EFCore
{
    public class StatusDao : IStatusDao
    {
        AppDbContext _context;

        public StatusDao(AppDbContext context)
        {
            _context = context;
        }

        public ICollection<Status> BuscarPorDescricao(string descricao)
        {
            return _context.Status
                .Where(x => x.Descricao.StartsWith(descricao))
                .OrderBy(x => x.Descricao)
                .ToList();
        }

        public Status BuscarPorId(int id)
        {
            return _context.Status.First(x => x.Id == id);
        }

        public ICollection<Status> BuscarTodos()
        {
            return _context.Status
                .OrderBy(x => x.Descricao)
                .ToList();
        }
    }
}
