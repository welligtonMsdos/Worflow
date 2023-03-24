using System.Collections.Generic;
using System.Linq;
using Worflow.Models;
using Worflow.Repository;


namespace Worflow.Dados.EFCore;

public class SegmentoEF : ISegmentoRepository
{
    AppDbContext _context;

    public SegmentoEF(AppDbContext context) => (_context) = (context);    

    public void Alterar(Segmento obj)
    {
        _context.Update(obj);
        _context.SaveChanges();
    }

    public ICollection<Segmento> BuscarPorDescricao(string descricao)
    {
        return _context.Segmentos
            .Where(x=> x.Ativo && x.Descricao.StartsWith(descricao))
            .ToList();
    }

    public Segmento BuscarPorId(int id)
    {
        return _context.Segmentos.First(x => x.Id == id);
    }

    public ICollection<Segmento> BuscarTodos()
    {
        return _context.Segmentos
            .Where(x => x.Ativo)
            .OrderBy(x => x.Descricao)
            .ToList();
    }

    public void Excluir(Segmento obj)
    {
        _context.Remove(obj);
        _context.SaveChanges();
    }

    public void Incluir(Segmento obj)
    {
        _context.Add(obj);
        _context.SaveChanges();
    }

    public ICollection<Segmento> Pesquisar(string value)
    {
        return _context.Segmentos
            .Where(x => x.Ativo && x.Descricao.Contains(value))
            .ToList();
    }
}
