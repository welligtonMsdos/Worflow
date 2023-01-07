using System.Collections.Generic;
using System.Linq;
using Worflow.Models;
using Worflow.Repository;

namespace Worflow.Dados.EFCore
{
    public class EnderecoDao : IEnderecoDao
    {
        AppDbContext _context;

        public EnderecoDao(AppDbContext context)
        {
            _context = context;
        }
        public void Alterar(Endereco obj)
        {
            _context.Update(obj);
            _context.SaveChanges();
        }

        public Endereco BuscarPorId(int id)
        {
            return _context.Enderecos.First(e => e.Id == id);
        }

        public ICollection<Endereco> BuscarTodos()
        {
            return _context.Enderecos
                .OrderBy(x => x.Logadouro)
                .ToList();
        }

        public void Excluir(Endereco obj)
        {
            _context.Remove(obj);
            _context.SaveChanges();
        }

        public void Incluir(Endereco obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }

        public ICollection<Endereco> Pesquisar(string value)
        {
            if (value == null)
                return BuscarTodos();

            return _context.Enderecos
               .Where(x => x.Logadouro.Contains(value) || 
                           x.Bairro.Contains(value) || 
                           x.Cidade.Contains(value))
               .OrderBy(x => x.Logadouro)
               .ToList();
        }
    }
}
