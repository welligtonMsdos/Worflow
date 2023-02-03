using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Worflow.Models;
using Worflow.Repository;

namespace Worflow.Dados.EFCore
{
    public class AgendaDao : IAgendaDao
    {
        AppDbContext _context;

        public AgendaDao(AppDbContext context)
        {
            _context = context;
        }
        public Agenda BuscarPorId(int id)
        {
            return _context.Agenda
                .Include(x => x.Lead)
                .Include(x => x.Usuario)
                .First(x => x.Id == id);
        }

        public ICollection<Agenda> BuscarPorUsuarioId(int usuarioId)
        {
            return _context.Agenda
              .Include(x => x.Lead)
              .Include(x => x.Usuario)
              .Where(x => x.Ativo && x.Usuario.Id.Equals(usuarioId))
              .OrderBy(x => x.Id)
              .ToList();
        }

        public ICollection<Agenda> BuscarTodos()
        {
            return _context.Agenda
              .Include(x => x.Lead)
              .Include(x => x.Usuario)
              .Where(x => x.Ativo)
              .OrderBy(x => x.Id)
              .ToList();
        }

        public ICollection<Agenda> Pesquisar(string value)
        {
            if (value == null)
                return BuscarTodos();

            return _context.Agenda
                 .Include(x => x.Lead)
                 .Include(x => x.Usuario)
                 .Where(x => x.Ativo && (x.Comentario.Contains(value) || x.Lead.Id.Equals(value)))
                 .OrderBy(x => x.Id)
                 .ToList();
        }
    }
}
