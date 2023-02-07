using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Worflow.Models;

namespace Worflow.Dados.Mappings
{
    public class EnderecoMap : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.ToTable("Endereco");

            builder.Property(p => p.CEP)
                   .HasColumnType("varchar(8)")
                   .IsRequired();

            builder.Property(p => p.Logadouro)
                   .HasColumnType("varchar(150)")
                   .IsRequired();           

            builder.Property(p => p.Numero)
                  .HasColumnType("varchar(15)")
                  .IsRequired();

            builder.Property(p => p.Bairro)
                  .HasColumnType("varchar(50)")
                  .IsRequired();

            builder.Property(p => p.Cidade)
                  .HasColumnType("varchar(150)")
                  .IsRequired();

            builder.Property(p => p.UF)
                  .HasColumnType("varchar(2)")
                  .IsRequired();

            
        }
    }
}
