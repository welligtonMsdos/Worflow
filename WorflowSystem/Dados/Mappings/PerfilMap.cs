using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Worflow.Models;

namespace Worflow.Dados.Mappings
{
    public class PerfilMap : IEntityTypeConfiguration<Perfil>
    {
        public void Configure(EntityTypeBuilder<Perfil> builder)
        {
            builder.ToTable("Perfil");

            builder.Property(p => p.Descricao)
                   .HasColumnType("varchar(50)")
                   .IsRequired();

            builder.HasIndex(p => p.Descricao)
                  .HasName("IX_PERFIL_DESCRICAO");

            builder.Property(p => p.Ativo)
                  .HasColumnType("bit")
                  .IsRequired();

            builder.HasData(
                new Perfil(1, "Consultor"),
                new Perfil(2, "Cotação"),
                new Perfil(3, "Implantação"),
                new Perfil(4, "Subscrição")
            );
        }
    }
}
