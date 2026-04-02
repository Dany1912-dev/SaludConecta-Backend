using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaludConecta.Core.Entities;

namespace SaludConecta.Infrastructure.Data.Configurations;

public class CatalogoCondicionMedicaConfiguration : IEntityTypeConfiguration<CatalogoCondicionMedica>
{
    public void Configure(EntityTypeBuilder<CatalogoCondicionMedica> builder)
    {
        builder.ToTable("CatalogoCondicionesMedicas");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Categoria)
            .IsRequired()
            .HasConversion<string>()
            .HasMaxLength(20);

        builder.Property(c => c.NombreCondicion)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(c => c.Orden)
            .HasDefaultValue(0);

        builder.HasIndex(c => new { c.Categoria, c.NombreCondicion })
            .IsUnique();
    }
}
