using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Worflow.Dados.EFCore;
using Worflow.Models;

namespace Worflow.Seeding
{
    public static class DataBaseGenerator
    {
        public static void Seed()
        {          
            var options = new DbContextOptions<AppDbContext>();

            using (var ctx = new AppDbContext(options))
            {
                if (!ctx.Database.EnsureCreated())
                {
                    AddEnderecos(ctx);

                    AddCliente(ctx);

                    AddLead(ctx);
                }
            }
        }

        private static void AddEnderecos(AppDbContext ctx)
        {
            if (ctx.Enderecos.ToList().Count() == 0)
            {
                List<Endereco> lstEndereco = new List<Endereco>();
                lstEndereco.Add(new Endereco("01310200", "Av.Paulista", "1578", "Bela Vista", "São Paulo", "SP"));
                lstEndereco.Add(new Endereco("04094050", "Av.Pedro Álvares Cabral", "s/n", "Vila Mariana", "São Paulo", "SP"));

                lstEndereco.ForEach(delegate (Endereco endereco) {
                    ctx.Add(endereco);
                    ctx.SaveChanges();
                });
            }
        }

        private static void AddCliente(AppDbContext ctx)
        {
            if(ctx.Clientes.ToList().Count() == 0)
            {
                List<Cliente> ltsCliente = new List<Cliente>();
                ltsCliente.Add(new Cliente(
                    GetEndereco(ctx),
                    "60664745000187",
                    "Museu de arte moderna de São Paulo Assis Chateubriand",
                    "MASP",
                    "0102",
                    "45678",
                    "contabil_fiscal@masp.org.br",
                    "1131495959"
                ));

                ltsCliente.ForEach(delegate (Cliente cliente)
                {
                    ctx.Add(cliente);
                    ctx.SaveChanges();
                });
            }          
        }

        private static void AddLead(AppDbContext ctx)
        {
            if(ctx.Lead.ToList().Count() == 0)
            {
                List<Lead> ltsLead = new List<Lead>();
                ltsLead.Add(new Lead(GetUsuario(ctx), GetCliente(ctx), GetProduto(ctx),  GetSegmento(ctx), GetStatus(ctx)));

                ltsLead.ForEach(delegate (Lead lead)
                {
                    ctx.Add(lead);
                    ctx.SaveChanges();
                });
            }
        }

        private static Endereco GetEndereco(AppDbContext ctx)
        {
            return ctx.Enderecos.First(x => x.Id == 1);
        }

        private static Segmento GetSegmentoAgro(AppDbContext ctx)
        {
            return ctx.Segmentos.First(x => x.Id == 1);
        }
        private static Segmento GetSegmentoCib(AppDbContext ctx)
        {
            return ctx.Segmentos.First(x => x.Id == 2);
        }

        private static Usuario GetUsuario(AppDbContext ctx)
        {
            return ctx.Usuarios.First(x => x.Id == 1);
        }

        private static Cliente GetCliente(AppDbContext ctx)
        {
            return ctx.Clientes.First(x => x.Id == 1);
        }

        private static Produto GetProduto(AppDbContext ctx)
        {
            return ctx.Produtos.First(x => x.Id == 1);
        }

        private static Segmento GetSegmento(AppDbContext ctx)
        {
            return ctx.Segmentos.First(x => x.Id == 1);
        }

        private static Status GetStatus(AppDbContext ctx)
        {
            return ctx.Status.First(x => x.Id == 1);
        }
    }
}
