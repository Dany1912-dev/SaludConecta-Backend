using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaludConecta.Core.Entities;
using SaludConecta.Core.Enums;

namespace SaludConecta.Infrastructure.Data.Configurations;

public class PerfilPacienteConfiguration : IEntityTypeConfiguration<PerfilPaciente>
{
    public void Configure(EntityTypeBuilder<PerfilPaciente> builder)
    {
        builder.ToTable("PerfilesPaciente");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.NombreCompleto)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(p => p.FechaNacimiento)
            .IsRequired();

        builder.Property(p => p.Genero)
            .IsRequired()
            .HasConversion<string>()
            .HasMaxLength(20);

        builder.Property(p => p.TipoSangre)
            .IsRequired()
            .HasConversion<string>()
            .HasMaxLength(20)
            .HasDefaultValue(TipoSangre.Desconocido);

        builder.Property(p => p.Parentesco)
            .IsRequired()
            .HasConversion<string>()
            .HasMaxLength(20)
            .HasDefaultValue(Parentesco.Yo);

        builder.Property(p => p.Ocupacion)
            .HasMaxLength(100);

        builder.Property(p => p.LugarNacimiento)
            .HasMaxLength(200);

        builder.Property(p => p.Telefono)
            .HasMaxLength(20);

        builder.Property(p => p.TelefonoEmergencia)
            .HasMaxLength(20);

        builder.Property(p => p.CorreoContacto)
            .HasMaxLength(255);

        builder.Property(p => p.Direccion)
            .HasMaxLength(300);

        builder.Property(p => p.ColorAvatar)
            .IsRequired()
            .HasMaxLength(7)
            .HasDefaultValue("#6366F1");

        builder.Property(p => p.Activo)
            .HasDefaultValue(true);

        builder.Property(p => p.FechaCreacion)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.Property(p => p.FechaActualizacion)
            .HasDefaultValueSql("CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP");

        builder.HasOne(p => p.Usuario)
            .WithMany(u => u.PerfilesPaciente)
            .HasForeignKey(p => p.UsuarioId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(p => p.UsuarioId);
        builder.HasIndex(p => new { p.UsuarioId, p.Activo });
    }
}
