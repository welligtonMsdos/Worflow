using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Worflow.Models;

namespace Worflow.Dados.Mappings
{
    public class StatusMap : IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> builder)
        {
            builder.ToTable("Status");

            builder.Property(p => p.Descricao)
                   .HasColumnType("varchar(50)")
                   .IsRequired();

            builder.HasIndex(p => p.Descricao)
                  .HasName("IX_STATUS_DESCRICAO");

            builder.Property(p => p.Ativo)
                  .HasColumnType("bit")
                  .IsRequired();

            builder.HasData(
                new Status(1, "Ativo"),
                new Status(2, "Em andamento"),
                new Status(3, "Finalizado")
            );
        }
    }
}
