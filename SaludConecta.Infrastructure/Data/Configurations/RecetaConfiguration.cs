using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaludConecta.Core.Entities;

namespace SaludConecta.Infrastructure.Data.Configurations;

public class RecetaConfiguration : IEntityTypeConfiguration<Receta>
{
    public void Configure(EntityTypeBuilder<Receta> builder)
    {
        builder.ToTable("Recetas");

        builder.HasKey(r => r.Id);

        builder.Property(r => r.RecetadoPor)
            .HasMaxLength(200);

        builder.Property(r => r.FechaReceta)
            .IsRequired();

        builder.Property(r => r.Activa)
            .HasDefaultValue(true);

        builder.Property(r => r.FechaCreacion)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.HasOne(r => r.PerfilPaciente)
            .WithMany(p => p.Recetas)
            .HasForeignKey(r => r.PerfilPacienteId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(r => r.Consulta)
            .WithMany(c => c.Recetas)
            .HasForeignKey(r => r.ConsultaId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasIndex(r => r.PerfilPacienteId);
        builder.HasIndex(r => new { r.PerfilPacienteId, r.Activa });
    }
}
