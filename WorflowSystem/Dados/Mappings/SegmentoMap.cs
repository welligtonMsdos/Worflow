using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Worflow.Models;

namespace Worflow.Dados.Mappings
{
    public class SegmentoMap : IEntityTypeConfiguration<Segmento>
    {
        public void Configure(EntityTypeBuilder<Segmento> builder)
        {
            builder.ToTable("Segmento");

            builder.Property(p => p.Descricao)
                   .HasColumnType("varchar(50)")
                   .IsRequired();

            builder.HasIndex(p => p.Descricao)
                  .HasName("IX_SEGMENTO_DESCRICAO");

            builder.Property(p => p.Ativo)
                  .HasColumnType("bit")
                  .IsRequired();           

            builder.HasData(
                new Segmento(1, "Agro"),
                new Segmento(2, "Cib"),
                new Segmento(3, "Middle"),
                new Segmento(4, "Large")
            );
        }
    }
}
