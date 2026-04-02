using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaludConecta.Core.Entities;

namespace SaludConecta.Infrastructure.Data.Configurations;

public class PerfilEstiloVidaConfiguration : IEntityTypeConfiguration<PerfilEstiloVida>
{
    public void Configure(EntityTypeBuilder<PerfilEstiloVida> builder)
    {
        builder.ToTable("PerfilEstiloVida");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.CalidadVida)
            .HasConversion<string>()
            .HasMaxLength(20);

        builder.Property(p => p.HorasSueno)
            .HasPrecision(3, 1);

        builder.Property(p => p.CalidadAlimentacion)
            .HasConversion<string>()
            .HasMaxLength(20);

        builder.Property(p => p.ActividadFisica)
            .HasMaxLength(100);

        builder.Property(p => p.ConsumoAlcohol)
            .IsRequired()
            .HasMaxLength(100)
            .HasDefaultValue("Ninguno");

        builder.Property(p => p.ConsumoDrogas)
            .IsRequired()
            .HasMaxLength(100)
            .HasDefaultValue("Ninguno");

        builder.Property(p => p.Tabaquismo)
            .IsRequired()
            .HasMaxLength(100)
            .HasDefaultValue("Ninguno");

        builder.Property(p => p.MedicamentosActuales)
            .IsRequired()
            .HasMaxLength(500)
            .HasDefaultValue("Ninguno");

        builder.Property(p => p.Zoonosis)
            .IsRequired()
            .HasMaxLength(100)
            .HasDefaultValue("No");

        builder.Property(p => p.AntecedentesLaborales)
            .IsRequired()
            .HasMaxLength(300)
            .HasDefaultValue("Ninguno");

        builder.Property(p => p.FechaActualizacion)
            .HasDefaultValueSql("CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP");

        builder.HasOne(p => p.PerfilPaciente)
            .WithOne(pp => pp.PerfilEstiloVida)
            .HasForeignKey<PerfilEstiloVida>(p => p.PerfilPacienteId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(p => p.PerfilPacienteId)
            .IsUnique();
    }
}
