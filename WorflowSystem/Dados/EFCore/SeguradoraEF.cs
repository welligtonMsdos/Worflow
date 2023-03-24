using System.Collections.Generic;
using System.Linq;
using Worflow.Models;
using Worflow.Repository;

namespace Worflow.Dados.EFCore;

public class SeguradoraEF : ISeguradoraRepository
{
    private readonly AppDbContext _context;
    public SeguradoraEF(AppDbContext context) => (_context) = (context);
    
    public void Alterar(Seguradora obj)
    {
        _context.Update(obj);
        _context.SaveChanges();
    }

    public Seguradora BuscarPorId(int id)
    {
        return _context.Seguradoras.First(x => x.Id == id);
    }

    public ICollection<Seguradora> BuscarTodos()
    {
        return _context.Seguradoras
            .Where(x => x.Ativo)
            .OrderBy(x => x.Nome)
            .ToList();
    }

    public void Excluir(Seguradora obj)
    {
        _context.Remove(obj);
        _context.SaveChanges();
    }

    public void Incluir(Seguradora obj)
    {
        _context.Add(obj);
        _context.SaveChanges();
    }

    public ICollection<Seguradora> Pesquisar(string value)
    {
        return _context.Seguradoras
              .Where(x => x.Ativo && x.Nome.Contains(value))
              .ToList();
    }
}
