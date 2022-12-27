using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Worflow.Models;

namespace Worflow.Dados.Mappings
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Cliente");

            builder.Property(p => p.CNPJ)
                   .HasColumnType("varchar(14)")
                   .IsRequired();

            builder.Property(p => p.RazaoSocial)
                 .HasColumnType("varchar(150)")
                 .IsRequired();

            builder.HasIndex(p => p.RazaoSocial)
                .HasName("IX_CLIENTE_RAZAO_SOCIAL");

            builder.Property(p => p.Fantasia)
                 .HasColumnType("varchar(150)")
                 .IsRequired();

            builder.HasIndex(p => p.Fantasia)
                .HasName("IX_CLIENTE_FANTASIA");

            builder.Property(p => p.Agencia)
                 .HasColumnType("varchar(4)")
                 .IsRequired();

            builder.Property(p => p.Conta)
                 .HasColumnType("varchar(5)")
                 .IsRequired();

            builder.Property(p => p.Email)
                 .HasColumnType("varchar(50)");

            builder.Property(p => p.Telefone)
                 .HasColumnType("varchar(11)");

           
        }
    }
}
