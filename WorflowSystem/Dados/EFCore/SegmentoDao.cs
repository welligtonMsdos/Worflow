﻿using System.Collections.Generic;
using System.Linq;
using Worflow.Models;
using Worflow.Repository;

namespace Worflow.Dados.EFCore
{
    public class SegmentoDao : ISegmentoDao
    {
        AppDbContext _context;

        public SegmentoDao(AppDbContext context)
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
                .OrderBy(x => x.Descricao)
                .ToList();
        }
    }
}