﻿using Microsoft.EntityFrameworkCore;
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
           
            builder.Property(p => p.Ativo)
                   .HasColumnType("bit")
                   .IsRequired();

            builder.HasOne(p => p.Perfil)
                .WithMany(p => p.Usuario)
                .HasForeignKey(p => p.PerfilId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasData(
               new Usuario(1,"Lionel Messi","LIOMES", 1),
               new Usuario(2, "Cristiano Ronaldo","CRISRO", 1),
               new Usuario(3, "Neymar Junior", "NEYJU", 1)
           );
        }
    }
}
