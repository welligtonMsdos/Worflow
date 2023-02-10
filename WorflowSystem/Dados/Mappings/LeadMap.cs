using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Worflow.Models;

namespace Worflow.Dados.Mappings
{
    public class LeadMap : IEntityTypeConfiguration<Lead>
    {
        public void Configure(EntityTypeBuilder<Lead> builder)
        {
            builder.ToTable("Lead");   

            builder.Property(p => p.DataAgendada)
                   .HasColumnType("datetime")
                   .IsRequired();                      

            builder.Property(p => p.Observacao)
                   .HasColumnType("varchar(300)")
                   .IsRequired();

            builder.HasOne(p => p.Cliente)
              .WithMany(p => p.Lead)
              .HasForeignKey(p => p.ClienteId)
              .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.Usuario)
              .WithMany(p => p.Lead)
              .HasForeignKey(p => p.UsuarioId)
              .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.Produto)
              .WithMany(p => p.Lead)
              .HasForeignKey(p => p.ProdutoId)
              .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.Segmento)
             .WithMany(p => p.Lead)
             .HasForeignKey(p => p.SegmentoId)
             .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.Status)
              .WithMany(p => p.Lead)
              .HasForeignKey(p => p.StatusId)
              .OnDelete(DeleteBehavior.NoAction);

            builder.ToTable(x => x.HasTrigger("addNaAgenda"));
        }
    }
}
