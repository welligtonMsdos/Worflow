using System.Collections.Generic;
using System.Linq;
using Worflow.Models;
using Worflow.Repository;

namespace Worflow.Dados.EFCore;

public class EventEF : IEventRepository
{
    private readonly AppDbContext _context;

    public EventEF(AppDbContext context) => (_context) = (context);
    
    public Event BuscarPorId(int id)
    {
        return _context.Event
            .First(x=>x.Id == id);
    }

    public ICollection<Event> BuscarTodos()
    {
        return _context.Event
            .ToList();
    }
}
