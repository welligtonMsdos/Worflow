using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Worflow.Models;

namespace Worflow.Dados.Mappings
{
    public class HistoricoMap : IEntityTypeConfiguration<Historico>
    {
        public void Configure(EntityTypeBuilder<Historico> builder)
        {
            builder.ToTable("Historico");

            builder.Property(p => p.Data)
                   .HasColumnType("varchar(50)")
                   .IsRequired();

            builder.Property(p => p.Mensagem)
                  .HasColumnType("varchar(50)")
                  .IsRequired();

            builder.HasOne(p => p.Status)
              .WithMany(p => p.Historico)
              .HasForeignKey(p => p.StatusId)
              .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.Lead)
              .WithMany(p => p.Historico)
              .HasForeignKey(p => p.LeadId)
              .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
