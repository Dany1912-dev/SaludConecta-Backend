using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaludConecta.Core.Entities;
using SaludConecta.Core.Enums;

namespace SaludConecta.Infrastructure.Data.Configurations;

public class MedicamentoRecetaConfiguration : IEntityTypeConfiguration<MedicamentoReceta>
{
    public void Configure(EntityTypeBuilder<MedicamentoReceta> builder)
    {
        builder.ToTable("MedicamentosReceta");

        builder.HasKey(m => m.Id);

        builder.Property(m => m.NombreMedicamento)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(m => m.Dosis)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(m => m.Frecuencia)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(m => m.ViaAdministracion)
            .IsRequired()
            .HasConversion<string>()
            .HasMaxLength(20)
            .HasDefaultValue(ViaAdministracion.Oral);

        builder.Property(m => m.FechaInicio)
            .IsRequired();

        builder.Property(m => m.Instrucciones)
            .HasMaxLength(500);

        builder.Property(m => m.Activo)
            .HasDefaultValue(true);

        builder.Property(m => m.FechaCreacion)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.HasOne(m => m.Receta)
            .WithMany(r => r.Medicamentos)
            .HasForeignKey(m => m.RecetaId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(m => m.RecetaId);
        builder.HasIndex(m => new { m.Activo, m.FechaFin });
    }
}
