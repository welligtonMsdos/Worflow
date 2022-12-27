using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Worflow.Models;

namespace Worflow.Dados.Mappings
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");

            builder.Property(p => p.Nome)
                   .HasColumnType("varchar(150)")
                   .IsRequired();

            builder.HasIndex(p => p.Nome)
                  .HasName("IX_USUARIO_NOME");

            builder.Property(p => p.Ativo)
                   .HasColumnType("bit")
                   .IsRequired();

            builder.HasOne(p => p.Perfil)
                .WithMany(p => p.Usuario)
                .HasForeignKey(p => p.PerfilId)
                .OnDelete(DeleteBehavior.NoAction);          

            builder.HasData(
               new Usuario(1,"Lionel Messi", 1),
               new Usuario(2, "Cristiano Ronaldo", 1),
               new Usuario(3, "Neymar Junior", 1)
           );
        }
    }
}
