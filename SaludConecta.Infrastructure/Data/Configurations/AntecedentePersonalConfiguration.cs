using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaludConecta.Core.Entities;

namespace SaludConecta.Infrastructure.Data.Configurations;

public class AntecedentePersonalConfiguration : IEntityTypeConfiguration<AntecedentePersonal>
{
    public void Configure(EntityTypeBuilder<AntecedentePersonal> builder)
    {
        builder.ToTable("AntecedentesPersonales");

        builder.HasKey(a => a.Id);

        builder.Property(a => a.Presente)
            .HasDefaultValue(false);

        builder.Property(a => a.FechaCreacion)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.HasOne(a => a.PerfilPaciente)
            .WithMany(p => p.AntecedentesPersonales)
            .HasForeignKey(a => a.PerfilPacienteId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(a => a.CondicionMedica)
            .WithMany(c => c.AntecedentesPersonales)
            .HasForeignKey(a => a.CondicionMedicaId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(a => a.PerfilPacienteId);

        builder.HasIndex(a => new { a.PerfilPacienteId, a.CondicionMedicaId })
            .IsUnique();
    }
}
