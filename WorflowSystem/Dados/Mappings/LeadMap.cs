using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Worflow.Models;

namespace Worflow.Dados.Mappings
{
    public class LeadMap : IEntityTypeConfiguration<Lead>
    {
        public void Configure(EntityTypeBuilder<Lead> builder)
        {
            builder.ToTable("Lead");

            builder.Property(p => p.DataAgendada)
                   .HasColumnType("datetime")
                   .IsRequired();                      

            builder.Property(p => p.Observacao)
                   .HasColumnType("varchar(300)")
                   .IsRequired();           
        }
    }
}
