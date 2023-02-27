using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Worflow.Dto;
using Worflow.Models;
using Worflow.Repository;
using X.PagedList;

namespace Worflow.Dados.EFCore
{
    public class LeadEF : ILeadRepository
    {
        AppDbContext _context;

        public LeadEF(AppDbContext context)
        {
            _context = context;
        }

        public void Alterar(Lead obj)
        {
            _context.Update(obj);
            _context.SaveChanges();
        }

        public IPagedList<Lead> PesquisarByPageList(string value, int pagina)
        {
            if (value == null)
                return BuscarLeadsByPageList(pagina);

            return _context.Lead
                  .Include(x => x.Usuario)
                  .Include(x => x.Cliente)
                  .Include(x => x.Produto)
                  .Include(x => x.Segmento)
                  .Include(x => x.Status)
                  .Where(x => x.Cliente.RazaoSocial.Contains(value) ||
                              x.Cliente.Fantasia.Contains(value) ||
                              x.Produto.Descricao.Contains(value) ||
                              x.Status.Descricao.Contains(value) ||
                              x.Segmento.Descricao.Contains(value)
                        )
                  .OrderByDescending(x => x.Id)
                  .ToPagedList(pagina, 10);
        }

        public IPagedList<Lead> BuscarLeadsByPageList(int pagina)
        {
            return _context.Lead
               .Include(x => x.Usuario)
               .Include(x => x.Cliente)
               .Include(x => x.Produto)
               .Include(x => x.Segmento)
               .Include(x => x.Status)
               .OrderByDescending(x => x.Id)
               .ToPagedList(pagina, 10);
        }

        public Lead BuscarPorId(int id)
        {
            return _context.Lead
                .Include(x => x.Usuario)
                .Include(x => x.Cliente)
                .Include(x => x.Cliente.Endereco)
                .Include(x => x.Produto)
                .Include(x => x.Segmento)
                .Include(x => x.Produto.ProdutoSegmento)
                .Include(x => x.Status)
                .Include(x => x.Cotacao)
                
                .First(x => x.Id == id);
        }

        public ICollection<Lead> BuscarTodos()
        {
            return _context.Lead
                .Include(x => x.Usuario)
                .Include(x => x.Cliente)
                .Include(x => x.Produto)
                .Include(x => x.Segmento)
                .Include(x => x.Status)
                .Skip(0)
                .Take(20)
                .OrderByDescending(x => x.Id)
                .ToList();
        }

        public void Excluir(Lead obj)
        {
            _context.Remove(obj);
            _context.SaveChanges();
        }

        public void Incluir(Lead obj)
        {
            _context.Entry(obj.Cliente).State = EntityState.Modified;

            _context.Add(obj);

            _context.SaveChanges();
        }

        public void Incluir(List<Lead> obj)
        {
            _context.Lead.AddRange(obj);
            _context.SaveChanges();
        }

        public ICollection<Lead> Pesquisar(string value)
        {
            if (value == null)
                return BuscarTodos();

            return _context.Lead
                  .Include(x => x.Usuario)
                  .Include(x => x.Cliente)
                  .Include(x => x.Produto)
                  .Include(x => x.Segmento)
                  .Include(x => x.Status)
                  .Where(x => x.Cliente.RazaoSocial.Contains(value) ||
                              x.Cliente.Fantasia.Contains(value) ||
                              x.Produto.Descricao.Contains(value) ||
                              x.Status.Descricao.Contains(value) ||
                              x.Segmento.Descricao.Contains(value)
                        )
                  .OrderByDescending(x => x.Id)
                  .ToList();
        }

        public ICollection<Lead> PesquisarPorId(int value)
        {
            return _context.Lead
                  .Include(x => x.Usuario)
                  .Include(x => x.Cliente)
                  .Include(x => x.Produto)
                  .Include(x => x.Segmento)
                  .Include(x => x.Status)
                  .Where(x => x.Id.Equals(value))
                  .OrderByDescending(x => x.Id)
                  .ToList();
        }       
    }
}
