using System.Collections.Generic;
using System.Linq;
using Worflow.Models;
using Worflow.Repository;

namespace Worflow.Dados.EFCore;

public class PerfilEF : IPerfilRepository
{
    private readonly AppDbContext _context;

    public PerfilEF(AppDbContext context) => (_context) = (context);    

    public void Alterar(Perfil obj)
    {
        _context.Update(obj);
        _context.SaveChanges();
    }

    public ICollection<Perfil> BuscarPorDescricao(string descricao)
    {
        return _context.Perfis
            .Where(x => x.Ativo && x.Descricao.StartsWith(descricao))
            .OrderBy(x => x.Descricao)
            .ToList();
    }

    public Perfil BuscarPorId(int id)
    {
        return _context.Perfis.First(x => x.Id == id);
    }

    public ICollection<Perfil> BuscarTodos()
    {
        return _context.Perfis
            .Where(x => x.Ativo)
            .OrderBy(x => x.Descricao)
            .ToList();
    }

    public void Excluir(Perfil obj)
    {
        _context.Remove(obj);
        _context.SaveChanges();
    }

    public void Incluir(Perfil obj)
    {
        _context.Add(obj);
        _context.SaveChanges();
    }

    public ICollection<Perfil> Pesquisar(string value)
    {
        if (value == null)
            return BuscarTodos();

        return _context.Perfis
            .Where(x => x.Descricao.Contains(value))
            .ToList();
    }
}
