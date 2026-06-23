using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaludConecta.Core.Entities;
using SaludConecta.Core.Enums;

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

        // Catálogo inicial de condiciones médicas
        builder.HasData(
            // General (1–8)
            new CatalogoCondicionMedica { Id = 1,  Categoria = CategoriaCondicionMedica.General,     NombreCondicion = "Hipertensión arterial",             Orden = 1 },
            new CatalogoCondicionMedica { Id = 2,  Categoria = CategoriaCondicionMedica.General,     NombreCondicion = "Obesidad",                           Orden = 2 },
            new CatalogoCondicionMedica { Id = 3,  Categoria = CategoriaCondicionMedica.General,     NombreCondicion = "Anemia",                             Orden = 3 },
            new CatalogoCondicionMedica { Id = 4,  Categoria = CategoriaCondicionMedica.General,     NombreCondicion = "Artritis",                           Orden = 4 },
            new CatalogoCondicionMedica { Id = 5,  Categoria = CategoriaCondicionMedica.General,     NombreCondicion = "Insuficiencia renal",                Orden = 5 },
            // Cardiaca (6–10)
            new CatalogoCondicionMedica { Id = 6,  Categoria = CategoriaCondicionMedica.Cardiaca,   NombreCondicion = "Cardiopatía isquémica",              Orden = 1 },
            new CatalogoCondicionMedica { Id = 7,  Categoria = CategoriaCondicionMedica.Cardiaca,   NombreCondicion = "Insuficiencia cardíaca",             Orden = 2 },
            new CatalogoCondicionMedica { Id = 8,  Categoria = CategoriaCondicionMedica.Cardiaca,   NombreCondicion = "Arritmia cardíaca",                  Orden = 3 },
            new CatalogoCondicionMedica { Id = 9,  Categoria = CategoriaCondicionMedica.Cardiaca,   NombreCondicion = "Angina de pecho",                    Orden = 4 },
            new CatalogoCondicionMedica { Id = 10, Categoria = CategoriaCondicionMedica.Cardiaca,   NombreCondicion = "Valvulopatía cardíaca",              Orden = 5 },
            // Pulmonar (11–15)
            new CatalogoCondicionMedica { Id = 11, Categoria = CategoriaCondicionMedica.Pulmonar,   NombreCondicion = "Asma",                               Orden = 1 },
            new CatalogoCondicionMedica { Id = 12, Categoria = CategoriaCondicionMedica.Pulmonar,   NombreCondicion = "EPOC",                               Orden = 2 },
            new CatalogoCondicionMedica { Id = 13, Categoria = CategoriaCondicionMedica.Pulmonar,   NombreCondicion = "Bronquitis crónica",                 Orden = 3 },
            new CatalogoCondicionMedica { Id = 14, Categoria = CategoriaCondicionMedica.Pulmonar,   NombreCondicion = "Neumonía recurrente",                Orden = 4 },
            new CatalogoCondicionMedica { Id = 15, Categoria = CategoriaCondicionMedica.Pulmonar,   NombreCondicion = "Tuberculosis",                       Orden = 5 },
            // Metabólica (16–20)
            new CatalogoCondicionMedica { Id = 16, Categoria = CategoriaCondicionMedica.Metabolica, NombreCondicion = "Diabetes mellitus tipo 1",           Orden = 1 },
            new CatalogoCondicionMedica { Id = 17, Categoria = CategoriaCondicionMedica.Metabolica, NombreCondicion = "Diabetes mellitus tipo 2",           Orden = 2 },
            new CatalogoCondicionMedica { Id = 18, Categoria = CategoriaCondicionMedica.Metabolica, NombreCondicion = "Dislipidemia",                       Orden = 3 },
            new CatalogoCondicionMedica { Id = 19, Categoria = CategoriaCondicionMedica.Metabolica, NombreCondicion = "Síndrome metabólico",                Orden = 4 },
            new CatalogoCondicionMedica { Id = 20, Categoria = CategoriaCondicionMedica.Metabolica, NombreCondicion = "Gota",                               Orden = 5 },
            // Endocrina (21–24)
            new CatalogoCondicionMedica { Id = 21, Categoria = CategoriaCondicionMedica.Endocrina,  NombreCondicion = "Hipotiroidismo",                     Orden = 1 },
            new CatalogoCondicionMedica { Id = 22, Categoria = CategoriaCondicionMedica.Endocrina,  NombreCondicion = "Hipertiroidismo",                    Orden = 2 },
            new CatalogoCondicionMedica { Id = 23, Categoria = CategoriaCondicionMedica.Endocrina,  NombreCondicion = "Síndrome de Cushing",                Orden = 3 },
            new CatalogoCondicionMedica { Id = 24, Categoria = CategoriaCondicionMedica.Endocrina,  NombreCondicion = "Hiperparatiroidismo",                Orden = 4 },
            // Neurológica (25–29)
            new CatalogoCondicionMedica { Id = 25, Categoria = CategoriaCondicionMedica.Neurologica, NombreCondicion = "Epilepsia",                         Orden = 1 },
            new CatalogoCondicionMedica { Id = 26, Categoria = CategoriaCondicionMedica.Neurologica, NombreCondicion = "Migraña crónica",                   Orden = 2 },
            new CatalogoCondicionMedica { Id = 27, Categoria = CategoriaCondicionMedica.Neurologica, NombreCondicion = "Enfermedad de Parkinson",           Orden = 3 },
            new CatalogoCondicionMedica { Id = 28, Categoria = CategoriaCondicionMedica.Neurologica, NombreCondicion = "Enfermedad de Alzheimer",           Orden = 4 },
            new CatalogoCondicionMedica { Id = 29, Categoria = CategoriaCondicionMedica.Neurologica, NombreCondicion = "Esclerosis múltiple",               Orden = 5 },
            // Cáncer (30–35)
            new CatalogoCondicionMedica { Id = 30, Categoria = CategoriaCondicionMedica.Cancer,     NombreCondicion = "Cáncer de mama",                     Orden = 1 },
            new CatalogoCondicionMedica { Id = 31, Categoria = CategoriaCondicionMedica.Cancer,     NombreCondicion = "Cáncer colorrectal",                 Orden = 2 },
            new CatalogoCondicionMedica { Id = 32, Categoria = CategoriaCondicionMedica.Cancer,     NombreCondicion = "Cáncer cervicouterino",              Orden = 3 },
            new CatalogoCondicionMedica { Id = 33, Categoria = CategoriaCondicionMedica.Cancer,     NombreCondicion = "Cáncer de próstata",                 Orden = 4 },
            new CatalogoCondicionMedica { Id = 34, Categoria = CategoriaCondicionMedica.Cancer,     NombreCondicion = "Leucemia",                           Orden = 5 },
            new CatalogoCondicionMedica { Id = 35, Categoria = CategoriaCondicionMedica.Cancer,     NombreCondicion = "Linfoma",                            Orden = 6 }
        );
    }
}
