using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Worflow.Models;
using Worflow.Repository;

namespace Worflow.Dados.EFCore;

public class AgendaEF : IAgendaRepository
{
    private readonly AppDbContext _context;

    public AgendaEF(AppDbContext context) => (_context) = (context);
    
    public void Alterar(Agenda obj)
    {          
        _context.Update(obj);
        _context.SaveChanges();
    }

    public IQueryable<IGrouping<DateTime, Agenda>> BuscarDatas()
    {
        return _context.Agenda
            .Where(x => x.DataAgendada >= DateTime.Now.Date &&
                       x.DataAgendada <= DateTime.Now.AddDays(7).Date &&
                       x.Ativo)
            .GroupBy(x => x.DataAgendada);
    }

    public ICollection<Agenda> BuscarHorarios(DateTime data)
    {
        return _context.Agenda
             .OrderBy(x => x.Horario)
             .Where(x => x.DataAgendada == data &&
                         x.Ativo)
             .ToList();
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

    public void Excluir(Agenda obj)
    {
        _context.Remove(obj);
        _context.SaveChanges();
    }

    public void Incluir(Agenda obj)
    {
        _context.Add(obj);
        _context.SaveChanges();
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
