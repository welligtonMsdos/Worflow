using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Worflow.Models;


namespace Worflow.Dados.Mappings
{
    public class AgendaMap : IEntityTypeConfiguration<Agenda>
    {
        public void Configure(EntityTypeBuilder<Agenda> builder)
        {
            builder.ToTable("Agenda");

            builder.Property(p => p.DataAgendada)
                    .HasColumnType("datetime")
                    .IsRequired();

            builder.HasOne(p => p.Lead)
             .WithMany(p => p.Agenda)
             .HasForeignKey(p => p.LeadId);

            builder.HasOne(p => p.Usuario)
            .WithMany(p => p.Agenda)
            .HasForeignKey(p => p.UsuarioId)
            .OnDelete(DeleteBehavior.NoAction);

            builder.Property(p => p.Comentario)
                .HasColumnType("varchar(150)")
                .IsRequired();

            builder.Property(p => p.Ativo)
                  .HasColumnType("bit")
                  .IsRequired();
        }
    }
}
