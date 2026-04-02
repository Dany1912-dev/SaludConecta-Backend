using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaludConecta.Core.Entities;

namespace SaludConecta.Infrastructure.Data.Configurations;

public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.ToTable("Usuarios");

        builder.HasKey(u => u.Id);

        builder.Property(u => u.Nombre)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(u => u.Correo)
            .IsRequired()
            .HasMaxLength(255);

        builder.HasIndex(u => u.Correo)
            .IsUnique();

        builder.Property(u => u.Telefono)
            .HasMaxLength(20);

        builder.Property(u => u.TelefonoVerificado)
            .HasDefaultValue(false);

        builder.Property(u => u.Modo)
            .IsRequired()
            .HasConversion<string>()
            .HasMaxLength(20)
            .HasDefaultValue(Core.Enums.ModoUsuario.Personal);

        builder.Property(u => u.FechaCreacion)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.Property(u => u.FechaActualizacion)
            .HasDefaultValueSql("CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP");
    }
}
