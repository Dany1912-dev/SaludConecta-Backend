using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaludConecta.Core.Entities;

namespace SaludConecta.Infrastructure.Data.Configurations;

public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
{
    public void Configure(EntityTypeBuilder<RefreshToken> builder)
    {
        builder.ToTable("RefreshTokens");

        builder.HasKey(r => r.Id);

        builder.Property(r => r.Token)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(r => r.FechaExpiracion)
            .IsRequired();

        builder.Property(r => r.Revocado)
            .HasDefaultValue(false);

        builder.Property(r => r.DispositivoInfo)
            .HasMaxLength(300);

        builder.Property(r => r.DireccionIP)
            .HasMaxLength(45);

        builder.Property(r => r.FechaCreacion)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.HasOne(r => r.Usuario)
            .WithMany(u => u.RefreshTokens)
            .HasForeignKey(r => r.UsuarioId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(r => r.UsuarioId);
        builder.HasIndex(r => r.Token);
    }
}
