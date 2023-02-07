using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Worflow.Models;
namespace Worflow.Dados.Mappings
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produto");

            builder.Property(p => p.Descricao)
                   .HasColumnType("varchar(50)")
                   .IsRequired();           

            builder.Property(p => p.Ativo)
                  .HasColumnType("bit")
                  .IsRequired();

            builder.HasData(
                new Produto(1, "Garantia"),
                new Produto(2, "Vida em Grupo"),
                new Produto(3, "Patrimonial"),
                new Produto(4, "Odonto")
            );      
        }
    }
}
