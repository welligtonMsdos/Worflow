﻿using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Worflow.Models;
using Worflow.Repository;

namespace Worflow.Dados.EFCore
{
    public class CotacaoEF: ICotacaoRepository
    {
        AppDbContext _context;

        public CotacaoEF(AppDbContext context)
        {
            _context = context;
        }

        public void Alterar(Cotacao obj)
        {
            _context.Update(obj);
            _context.SaveChanges();
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
    }
}