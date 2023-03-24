using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Worflow.Models;
using Worflow.Repository;
using X.PagedList;

namespace Worflow.Dados.EFCore;

public class CotacaoEF: ICotacaoRepository
{
    private readonly AppDbContext _context;

    public CotacaoEF(AppDbContext context) => (_context) = (context);
    
    public void Alterar(Cotacao obj)
    {
        _context.Update(obj);
        _context.SaveChanges();
    }
         
    public ICollection<Cotacao> BuscarCotacoesPorLeadId(int leadId)
    {
        return _context.Cotacoes                
            .Include(x => x.Lead)
            .Include(x => x.Seguradora)
            .Where(x => x.Ativo && x.LeadId == leadId)
            .OrderByDescending(x => x.DataEmissao)
            .ToList();
    }

    public Cotacao BuscarPorId(int id)
    {
        return _context.Cotacoes               
            .Include(x => x.Seguradora)
            .Include(x => x.Lead)
            .First(x=>x.Id == id);
    }

    public ICollection<Cotacao> BuscarTodos()
    {
        return _context.Cotacoes                
            .Include(x => x.Seguradora)
            .Include(x => x.Lead)
            .Where(x => x.Ativo)
            .OrderBy(x => x.DataEmissao)
            .ToList();
    }

    public void Excluir(Cotacao obj)
    {
        _context.Remove(obj);
        _context.SaveChanges();
    }

    public void Incluir(Cotacao obj)
    {
        _context.Add(obj);
        _context.SaveChanges();
    }

    public ICollection<Cotacao> Pesquisar(string value)
    {
        return _context.Cotacoes
             .Include(x => x.Seguradora)
             .Include(x => x.Lead)
             .Where(x => x.Ativo && x.Lead.Id == int.Parse(value))
             .OrderBy(x => x.DataEmissao)
             .ToList();
    }
}
