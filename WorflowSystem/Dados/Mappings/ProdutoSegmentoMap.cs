using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Worflow.Models;

namespace Worflow.Dados.Mappings
{
    public class ProdutoSegmentoMap : IEntityTypeConfiguration<ProdutoSegmento>
    {
        public void Configure(EntityTypeBuilder<ProdutoSegmento> builder)
        {
            builder.ToTable("ProdutoSegmento");

            builder.HasData(
                new ProdutoSegmento(1,1,1),
                new ProdutoSegmento(2,2, 1),
                new ProdutoSegmento(3,3, 1),
                new ProdutoSegmento(4,1,2),
                new ProdutoSegmento(5,4, 2),
                new ProdutoSegmento(6,1, 3),
                new ProdutoSegmento(7,1, 4),
                new ProdutoSegmento(8,2, 4)
            );
        }
    }
}
