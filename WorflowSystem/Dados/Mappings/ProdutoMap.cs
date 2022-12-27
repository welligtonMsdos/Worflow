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

            builder.HasIndex(p => p.Descricao)
                  .HasName("IX_PRODUTO_DESCRICAO");

            builder.Property(p => p.Ativo)
                  .HasColumnType("bit")
                  .IsRequired();

            builder.HasOne(p => p.Segmento)
                .WithMany(p => p.Produtos)
                .HasForeignKey(p => p.SegmentoId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
