using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using Worflow.Models;
using Worflow.Repository;

namespace Worflow.Dados.EFCore
{
    public class PerfilDao : IPerfilDao
    {
        AppDbContext _context;

        public PerfilDao(AppDbContext context)
        {
            _context = context;
        }

        public List<Perfil> BuscarPerfilList()
        {
            return _context.Perfis
                .Where(x => x.Ativo)
                .ToList();
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
    }
}
