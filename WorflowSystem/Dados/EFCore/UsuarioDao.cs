using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Worflow.Models;
using Worflow.Repository;

namespace Worflow.Dados.EFCore
{
    public class UsuarioDao : IUsuarioDao
    {
        AppDbContext _context;

        public UsuarioDao(AppDbContext context)
        {
            _context = context;
        }

        public void Alterar(Usuario obj)
        {
            _context.Update(obj);
            _context.SaveChanges();
        }

        public Usuario BuscarPorId(int id)
        {
            return _context.Usuarios
                .Include(x => x.Perfil)
                .First(x => x.Id == id);
        }

        public ICollection<Usuario> BuscarTodos()
        {
            return _context.Usuarios
                .Include(x => x.Perfil)
                .Where(x => x.Ativo)
                .OrderBy(x => x.Nome)
                .ToList();
        }

        public void Excluir(Usuario obj)
        {
            _context.Remove(obj);
            _context.SaveChanges();
        }

        public void Incluir(Usuario obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }

        public ICollection<Usuario> Pesquisar(string value)
        {
            if (value == null)
                return BuscarTodos();

            return _context.Usuarios
                 .Include(x => x.Perfil)
                 .Where(x => x.Ativo && (
                                x.Nome.Contains(value) ||
                                x.RACF.Contains(value) ||
                                x.Perfil.Descricao.Contains(value)
                             )
                        )
                 .OrderBy(x => x.Nome)
                 .ToList();
        }

        public bool UsuarioExiste(Usuario obj)
        {
            return _context.Usuarios.Where(x => x.RACF.Contains(obj.RACF)).Count() > 0 ? true : false;
        }
    }
}
