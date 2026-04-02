using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaludConecta.Core.Entities;
using SaludConecta.Core.Enums;

namespace SaludConecta.Infrastructure.Data.Configurations;

public class AlergiaConfiguration : IEntityTypeConfiguration<Alergia>
{
    public void Configure(EntityTypeBuilder<Alergia> builder)
    {
        builder.ToTable("Alergias");

        builder.HasKey(a => a.Id);

        builder.Property(a => a.TipoAlergia)
            .IsRequired()
            .HasConversion<string>()
            .HasMaxLength(20);

        builder.Property(a => a.Descripcion)
            .IsRequired()
            .HasMaxLength(300);

        builder.Property(a => a.Severidad)
            .IsRequired()
            .HasConversion<string>()
            .HasMaxLength(20)
            .HasDefaultValue(SeveridadAlergia.Moderada);

        builder.Property(a => a.Activa)
            .HasDefaultValue(true);

        builder.Property(a => a.FechaCreacion)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.HasOne(a => a.PerfilPaciente)
            .WithMany(p => p.Alergias)
            .HasForeignKey(a => a.PerfilPacienteId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(a => a.PerfilPacienteId);
        builder.HasIndex(a => new { a.PerfilPacienteId, a.Activa });
    }
}
