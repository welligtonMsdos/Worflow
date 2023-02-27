using System.Collections.Generic;
using System.Linq;
using Worflow.Models;
using Worflow.Repository;
using Microsoft.EntityFrameworkCore;


namespace Worflow.Dados.EFCore
{
    public class SegmentoEF : ISegmentoRepository
    {
        AppDbContext _context;

        public SegmentoEF(AppDbContext context)
        {
            _context = context;
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
    }
}
