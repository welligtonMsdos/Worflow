using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Worflow.Dados.Mappings;
using Worflow.Models;

namespace Worflow.Dados.EFCore
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions options) : base(options){}


        public DbSet<Perfil> Perfis { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Segmento> Segmentos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Lead> Lead { get; set; }
        public DbSet<ProdutoSegmento> ProdutoSegmento { get; set; }
        public DbSet<Agenda> Agenda { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {            
           optionsBuilder.UseSqlServer("Data Source=DESKTOP-TK7GSO1\\SQLEXPRESS;Initial Catalog=BDWorflow;Integrated Security=True;Trust Server Certificate=true");
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PerfilMap());
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new StatusMap());
            modelBuilder.ApplyConfiguration(new SegmentoMap());
            modelBuilder.ApplyConfiguration(new ProdutoMap());
            modelBuilder.ApplyConfiguration(new EnderecoMap());
            modelBuilder.ApplyConfiguration(new ClienteMap());
            modelBuilder.ApplyConfiguration(new LeadMap());
            modelBuilder.ApplyConfiguration(new ProdutoSegmentoMap());
            modelBuilder.ApplyConfiguration(new AgendaMap());

            
        }
    }
}
