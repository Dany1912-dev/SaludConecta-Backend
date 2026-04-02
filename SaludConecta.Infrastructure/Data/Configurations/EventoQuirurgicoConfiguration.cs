using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaludConecta.Core.Entities;

namespace SaludConecta.Infrastructure.Data.Configurations;

public class EventoQuirurgicoConfiguration : IEntityTypeConfiguration<EventoQuirurgico>
{
    public void Configure(EntityTypeBuilder<EventoQuirurgico> builder)
    {
        builder.ToTable("EventosQuirurgicos");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.TipoEvento)
            .IsRequired()
            .HasConversion<string>()
            .HasMaxLength(20);

        builder.Property(e => e.Descripcion)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(e => e.Hospital)
            .HasMaxLength(200);

        builder.Property(e => e.Medico)
            .HasMaxLength(200);

        builder.Property(e => e.FechaCreacion)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.HasOne(e => e.PerfilPaciente)
            .WithMany(p => p.EventosQuirurgicos)
            .HasForeignKey(e => e.PerfilPacienteId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(e => e.PerfilPacienteId);
        builder.HasIndex(e => new { e.PerfilPacienteId, e.TipoEvento });
    }
}
