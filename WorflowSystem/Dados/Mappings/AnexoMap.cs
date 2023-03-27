using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Worflow.Models;

namespace Worflow.Dados.Mappings;

public class AnexoMap : IEntityTypeConfiguration<Anexo>
{
    public void Configure(EntityTypeBuilder<Anexo> builder)
    {
        builder.ToTable("Anexo");

        builder.Property(p => p.Documento)
            .HasColumnType("varbinary(max)")
            .IsRequired();

        builder.Property(p => p.Nome)
               .HasColumnType("varchar(30)")
               .IsRequired();

        builder.Property(p => p.Extensao)
               .HasColumnType("varchar(30)")
               .IsRequired();

        builder.Property(p => p.DataCriacao)
                .HasColumnType("datetime")
               .IsRequired();

        builder.HasOne(p => p.Usuario)
              .WithMany(p => p.Anexo)
              .HasForeignKey(p => p.UsuarioId)
              .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(p => p.Lead)
              .WithMany(p => p.Anexo)
              .HasForeignKey(p => p.LeadId)
              .OnDelete(DeleteBehavior.NoAction);
    }
}
