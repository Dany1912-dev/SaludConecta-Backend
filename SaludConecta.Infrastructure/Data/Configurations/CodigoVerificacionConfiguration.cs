using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaludConecta.Core.Entities;

namespace SaludConecta.Infrastructure.Data.Configurations;

public class CodigoVerificacionConfiguration : IEntityTypeConfiguration<CodigoVerificacion>
{
    public void Configure(EntityTypeBuilder<CodigoVerificacion> builder)
    {
        builder.ToTable("CodigosVerificacion");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Codigo)
            .IsRequired()
            .HasMaxLength(10);

        builder.Property(c => c.Tipo)
            .IsRequired()
            .HasConversion<string>()
            .HasMaxLength(30);

        builder.Property(c => c.FechaExpiracion)
            .IsRequired();

        builder.Property(c => c.Usado)
            .HasDefaultValue(false);

        builder.Property(c => c.IntentosFallidos)
            .HasDefaultValue(0);

        builder.Property(c => c.FechaCreacion)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.HasOne(c => c.Usuario)
            .WithMany(u => u.CodigosVerificacion)
            .HasForeignKey(c => c.UsuarioId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(c => c.UsuarioId);
        builder.HasIndex(c => c.FechaExpiracion);
    }
}
