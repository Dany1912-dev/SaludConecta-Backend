using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaludConecta.Core.Entities;

namespace SaludConecta.Infrastructure.Data.Configurations;

public class ArchivoAdjuntoConfiguration : IEntityTypeConfiguration<ArchivoAdjunto>
{
    public void Configure(EntityTypeBuilder<ArchivoAdjunto> builder)
    {
        builder.ToTable("ArchivosAdjuntos");

        builder.HasKey(a => a.Id);

        builder.Property(a => a.TipoArchivo)
            .IsRequired()
            .HasConversion<string>()
            .HasMaxLength(20);

        builder.Property(a => a.NombreOriginal)
            .IsRequired()
            .HasMaxLength(300);

        builder.Property(a => a.RutaArchivo)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(a => a.ExtensionArchivo)
            .IsRequired()
            .HasMaxLength(10);

        builder.Property(a => a.TamanoBytes)
            .IsRequired();

        builder.Property(a => a.ContentType)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(a => a.Descripcion)
            .HasMaxLength(500);

        builder.Property(a => a.FechaCreacion)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.HasOne(a => a.PerfilPaciente)
            .WithMany(p => p.ArchivosAdjuntos)
            .HasForeignKey(a => a.PerfilPacienteId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(a => a.Receta)
            .WithMany(r => r.ArchivosAdjuntos)
            .HasForeignKey(a => a.RecetaId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(a => a.Consulta)
            .WithMany(c => c.ArchivosAdjuntos)
            .HasForeignKey(a => a.ConsultaId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(a => a.EstudioClinico)
            .WithMany(e => e.ArchivosAdjuntos)
            .HasForeignKey(a => a.EstudioClinicoId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasIndex(a => a.PerfilPacienteId);
        builder.HasIndex(a => a.TipoArchivo);
    }
}
