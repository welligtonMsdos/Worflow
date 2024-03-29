﻿using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Worflow.Models;
using Worflow.Repository;

namespace Worflow.Dados.EFCore;

public class AnexoEF : IAnexoRepository
{
    private readonly AppDbContext _context;

    public AnexoEF(AppDbContext context) => (_context) = (context);
    
    public void Alterar(Anexo obj)
    {
        _context.Update(obj);
        _context.SaveChanges();
    }

    public Anexo BuscarPorId(int id) 
    { 
        return _context.Anexo
            .Include(x => x.Usuario)
            .Include(x => x.Lead)
            .Where(x => x.Id == id)
            .First(); 
    }

    public ICollection<Anexo> BuscarPorLeadId(int leadId)
    {
        return _context.Anexo
           .Include(x => x.Usuario)     
           .Include(x => x.Lead)
           .Where(x => x.LeadId == leadId)
           .OrderBy(x => x.DataCriacao)
           .ToList();
    }

    public ICollection<Anexo> BuscarTodos() 
    { 
        return _context.Anexo
            .Include(x => x.Usuario)
            .Include(x => x.Lead)
            .OrderBy(x => x.DataCriacao)
            .ToList(); 
    }    

    public void Excluir(Anexo obj)
    {
        _context.Remove(obj);
        _context.SaveChanges();
    }

    public void Incluir(Anexo obj)
    {
        _context.Add(obj);
        _context.SaveChanges();
    }

    public ICollection<Anexo> Pesquisar(string value) 
    { 
        return _context.Anexo
            .Include(x => x.Usuario)
            .Include(x => x.Lead)
            .Where(x => x.Nome.Contains(value))
            .ToList(); 
    }
}
