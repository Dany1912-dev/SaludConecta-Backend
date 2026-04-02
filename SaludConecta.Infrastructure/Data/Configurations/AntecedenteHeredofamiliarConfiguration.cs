using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaludConecta.Core.Entities;

namespace SaludConecta.Infrastructure.Data.Configurations;

public class AntecedenteHeredofamiliarConfiguration : IEntityTypeConfiguration<AntecedenteHeredofamiliar>
{
    public void Configure(EntityTypeBuilder<AntecedenteHeredofamiliar> builder)
    {
        builder.ToTable("AntecedentesHeredofamiliares");

        builder.HasKey(a => a.Id);

        builder.Property(a => a.ParentescoFamiliar)
            .IsRequired()
            .HasConversion<string>()
            .HasMaxLength(30);

        builder.Property(a => a.Presente)
            .HasDefaultValue(false);

        builder.Property(a => a.Notas)
            .HasMaxLength(500);

        builder.Property(a => a.FechaCreacion)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.HasOne(a => a.PerfilPaciente)
            .WithMany(p => p.AntecedentesHeredofamiliares)
            .HasForeignKey(a => a.PerfilPacienteId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(a => a.CondicionMedica)
            .WithMany(c => c.AntecedentesHeredofamiliares)
            .HasForeignKey(a => a.CondicionMedicaId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(a => a.PerfilPacienteId);

        builder.HasIndex(a => new { a.PerfilPacienteId, a.ParentescoFamiliar, a.CondicionMedicaId })
            .IsUnique();
    }
}
