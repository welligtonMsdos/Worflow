using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Worflow.Models;

namespace Worflow.Dados.Mappings
{
    public class CotacaoMap : IEntityTypeConfiguration<Cotacao>
    {
        public void Configure(EntityTypeBuilder<Cotacao> builder)
        {
            builder.ToTable("Cotacao");

            builder.Property(p => p.DataEmissao)
                   .HasColumnType("datetime")
                   .IsRequired();
            
            builder.Property(p => p.DataVencimento)
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(p => p.Valor)
                .HasColumnType("decimal(10,2)")
                .IsRequired();

            builder.HasOne(p => p.Seguradora)
                .WithMany(p => p.Cotacao)
                .HasForeignKey(p => p.SeguradoraId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.Lead)
            .WithMany(p => p.Cotacao)
            .HasForeignKey(p => p.LeadId);

            builder.Property(p => p.Ativo)
                 .HasColumnType("bit")
                 .IsRequired();
            
        }
    }
}
