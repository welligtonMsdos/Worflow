using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Worflow.Models;
using Worflow.Repository;

namespace Worflow.Dados.EFCore;

public class ProdutoEF : IProdutoRepository
{
    AppDbContext _context;

    public ProdutoEF(AppDbContext context)
    {
        _context = context;
    }

    public void Alterar(Produto obj)
    {
        _context.Update(obj);
        _context.SaveChanges();
    }

    public Produto BuscarPorId(int id)
    {
        return _context.Produtos
            .Include(x => x.ProdutoSegmento)
            .First(x => x.Id == id);
    }

    public ICollection<ProdutoSegmento> BuscarProdutosPorSegmento(int segmentoId)
    {
        return _context.ProdutoSegmento
            .Include(x => x.produto)
            .Include(x => x.Segmento)
            .Where(x => x.Segmento.Ativo && x.produto.Ativo && x.SegmentoId == segmentoId)
            .OrderBy(x => x.produto.Descricao)
            .ToList();
    }

    public ICollection<Produto> BuscarTodos()
    {
        return _context.Produtos
            .Where(x => x.Ativo)
            .Include(x => x.ProdutoSegmento)
            .OrderBy(x => x.Descricao)
            .ToList();
    }

    public void Excluir(Produto obj)
    {
        _context.Remove(obj);
        _context.SaveChanges();
    }

    public void Incluir(Produto obj)
    {
        _context.Add(obj);
        _context.SaveChanges();
    }

    public ICollection<Produto> Pesquisar(string value)
    {
        return _context.Produtos
            .Where(x => x.Descricao.Contains(value))
            .ToList();
    }
}
