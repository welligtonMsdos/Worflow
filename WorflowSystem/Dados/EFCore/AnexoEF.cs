using Microsoft.EntityFrameworkCore;
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

    public Anexo BuscarPorId(int id) => _context.Anexo.Include(x => x.Usuario).Where(x => x.Id == id).First();

    public ICollection<Anexo> BuscarTodos() => _context.Anexo.Include(x => x.Usuario).OrderBy(x=>x.DataCriacao).ToList();
    

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

    public ICollection<Anexo> Pesquisar(string value) => _context.Anexo.Include(x => x.Usuario).Where(x => x.Nome.Contains(value)).ToList();   
}
