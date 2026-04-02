using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaludConecta.Core.Entities;

namespace SaludConecta.Infrastructure.Data.Configurations;

public class RegistroBiometricoConfiguration : IEntityTypeConfiguration<RegistroBiometrico>
{
    public void Configure(EntityTypeBuilder<RegistroBiometrico> builder)
    {
        builder.ToTable("RegistrosBiometricos");

        builder.HasKey(r => r.Id);

        builder.Property(r => r.PesoKg)
            .HasPrecision(5, 2);

        builder.Property(r => r.EstaturaCm)
            .HasPrecision(5, 1);

        builder.Property(r => r.Notas)
            .HasMaxLength(300);

        builder.Property(r => r.FechaRegistro)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.HasOne(r => r.PerfilPaciente)
            .WithMany(p => p.RegistrosBiometricos)
            .HasForeignKey(r => r.PerfilPacienteId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(r => new { r.PerfilPacienteId, r.FechaRegistro })
            .IsDescending(false, true);
    }
}
