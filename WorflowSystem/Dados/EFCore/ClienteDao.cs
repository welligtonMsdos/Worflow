using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Worflow.Models;
using Worflow.Repository;

namespace Worflow.Dados.EFCore
{
    public class ClienteDao : IClienteDao
    {
        AppDbContext _context;

        public ClienteDao(AppDbContext context)
        {
            _context = context;
        }

        public void Alterar(Cliente obj)
        {
            _context.Clientes.Update(obj);
            _context.SaveChanges();
        }

        public Cliente BuscarPorId(int id)
        {
            return _context.Clientes.Include(e => e.Endereco).First(c => c.Id == id);
        }

        public ICollection<Cliente> BuscarTodos()
        {
            return _context.Clientes.Include(e => e.Endereco)
                .OrderBy(x => x.Fantasia)
                .ToList();
        }

        public void Excluir(Cliente obj)
        {
            _context.Clientes.Remove(obj);
            _context.SaveChanges();
        }

        public void Incluir(Cliente obj)
        {
            _context.Clientes.Add(obj);
            _context.SaveChanges();
        }
    }
}
