using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Worflow.Models;

namespace Worflow.Dados.Mappings
{
    public class SeguradoraMap : IEntityTypeConfiguration<Seguradora>
    {
        public void Configure(EntityTypeBuilder<Seguradora> builder)
        {
            builder.ToTable("Seguradora");

            builder.Property(p => p.Nome)
                   .HasColumnType("varchar(20)")
                   .IsRequired();

            builder.Property(p => p.Ativo)
                  .HasColumnType("bit")
                  .IsRequired();          

            builder.HasData(
                new Seguradora(1, "Catu"),
                new Seguradora(2, "Itaú"),
                new Seguradora(3, "Porto Seguro"),
                new Seguradora(4, "MetLife")
            );
        }
    }
}
