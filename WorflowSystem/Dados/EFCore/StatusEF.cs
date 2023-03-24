using System.Collections.Generic;
using System.Linq;
using Worflow.Models;
using Worflow.Repository;

namespace Worflow.Dados.EFCore;

public class StatusEF : IStatusRepository
{
    private readonly AppDbContext _context;

    public StatusEF(AppDbContext context) => (_context) = (context);
    
    public void Alterar(Status obj)
    {
        _context.Update(obj);
        _context.SaveChanges();
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

    public void Excluir(Status obj)
    {
        _context.Remove(obj);
        _context.SaveChanges();
    }

    public void Incluir(Status obj)
    {
        _context.Add(obj);
        _context.SaveChanges();
    }

    public ICollection<Status> Pesquisar(string value)
    {
        return _context.Status
            .Where(x=>x.Ativo && x.Descricao.Contains(value))
            .ToList();
    }
}
