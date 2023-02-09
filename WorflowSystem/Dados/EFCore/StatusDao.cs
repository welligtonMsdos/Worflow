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
                .Where(x => x.Ativo && x.Descricao.StartsWith(descricao))
                .OrderBy(x => x.Descricao)
                .ToList();
        }

        public Status BuscarPorId(int id)
        {
            return _context.Status.First(x => x.Id == id);
        }

        public ICollection<Status> BuscarProximoStatus(List<int> statusId)
        {
            return _context.Status
                .Where(x => statusId.Contains(x.Id))
                .OrderBy(x => x.Descricao)
                .ToList();
        }

        public ICollection<Status> BuscarTodos()
        {
            return _context.Status
                .Where(x => x.Ativo)
                .OrderBy(x => x.Descricao)
                .ToList();
        }
    }
}
