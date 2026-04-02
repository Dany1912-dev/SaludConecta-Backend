using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaludConecta.Core.Entities;

namespace SaludConecta.Infrastructure.Data.Configurations;

public class AntecedentePsicologicoConfiguration : IEntityTypeConfiguration<AntecedentePsicologico>
{
    public void Configure(EntityTypeBuilder<AntecedentePsicologico> builder)
    {
        builder.ToTable("AntecedentesPsicologicos");

        builder.HasKey(a => a.Id);

        builder.Property(a => a.NombreCondicion)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(a => a.Activo)
            .HasDefaultValue(true);

        builder.Property(a => a.FechaCreacion)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.HasOne(a => a.PerfilPaciente)
            .WithMany(p => p.AntecedentesPsicologicos)
            .HasForeignKey(a => a.PerfilPacienteId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(a => a.PerfilPacienteId);
    }
}
