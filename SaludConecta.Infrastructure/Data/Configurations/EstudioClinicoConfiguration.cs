using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaludConecta.Core.Entities;

namespace SaludConecta.Infrastructure.Data.Configurations;

public class EstudioClinicoConfiguration : IEntityTypeConfiguration<EstudioClinico>
{
    public void Configure(EntityTypeBuilder<EstudioClinico> builder)
    {
        builder.ToTable("EstudiosClinicos");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.TipoEstudio)
            .IsRequired()
            .HasConversion<string>()
            .HasMaxLength(30);

        builder.Property(e => e.NombreEstudio)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(e => e.Laboratorio)
            .HasMaxLength(200);

        builder.Property(e => e.MedicoSolicitante)
            .HasMaxLength(200);

        builder.Property(e => e.FechaRealizacion)
            .IsRequired();

        builder.Property(e => e.FechaCreacion)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.HasOne(e => e.PerfilPaciente)
            .WithMany(p => p.EstudiosClinicos)
            .HasForeignKey(e => e.PerfilPacienteId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(e => e.Consulta)
            .WithMany(c => c.EstudiosClinicos)
            .HasForeignKey(e => e.ConsultaId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasIndex(e => e.PerfilPacienteId);
        builder.HasIndex(e => new { e.PerfilPacienteId, e.TipoEstudio });
    }
}
