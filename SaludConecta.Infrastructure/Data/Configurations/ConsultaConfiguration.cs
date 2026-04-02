using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaludConecta.Core.Entities;

namespace SaludConecta.Infrastructure.Data.Configurations;

public class ConsultaConfiguration : IEntityTypeConfiguration<Consulta>
{
    public void Configure(EntityTypeBuilder<Consulta> builder)
    {
        builder.ToTable("Consultas");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.FechaConsulta)
            .IsRequired();

        builder.Property(c => c.NombreEspecialista)
            .HasMaxLength(200);

        builder.Property(c => c.Especialidad)
            .HasMaxLength(150);

        builder.Property(c => c.MotivoConsulta)
            .IsRequired();

        builder.Property(c => c.FechaCreacion)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.HasOne(c => c.PerfilPaciente)
            .WithMany(p => p.Consultas)
            .HasForeignKey(c => c.PerfilPacienteId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(c => new { c.PerfilPacienteId, c.FechaConsulta })
            .IsDescending(false, true);

        builder.HasIndex(c => c.Especialidad);
    }
}
