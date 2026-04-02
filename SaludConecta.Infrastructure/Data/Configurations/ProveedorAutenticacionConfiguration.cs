using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaludConecta.Core.Entities;

namespace SaludConecta.Infrastructure.Data.Configurations;

public class ProveedorAutenticacionConfiguration : IEntityTypeConfiguration<ProveedorAutenticacion>
{
    public void Configure(EntityTypeBuilder<ProveedorAutenticacion> builder)
    {
        builder.ToTable("ProveedoresAutenticacion");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.TipoProveedor)
            .IsRequired()
            .HasConversion<string>()
            .HasMaxLength(20);

        builder.Property(p => p.HashContrasena)
            .HasMaxLength(255);

        builder.Property(p => p.GoogleId)
            .HasMaxLength(128);

        builder.HasIndex(p => p.GoogleId)
            .IsUnique();

        builder.Property(p => p.FechaCreacion)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.HasOne(p => p.Usuario)
            .WithMany(u => u.ProveedoresAutenticacion)
            .HasForeignKey(p => p.UsuarioId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(p => p.UsuarioId);
    }
}
