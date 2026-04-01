using SaludConecta.Core.Enums;

namespace SaludConecta.Core.Entities;

public class MedicamentoReceta
{
    public int Id { get; set; }
    public int RecetaId { get; set; }
    public string NombreMedicamento { get; set; } = string.Empty;
    public string Dosis { get; set; } = string.Empty;
    public string Frecuencia { get; set; } = string.Empty;
    public int? FrecuenciaHoras { get; set; }
    public ViaAdministracion ViaAdministracion { get; set; } = ViaAdministracion.Oral;
    public DateTime FechaInicio { get; set; }
    public DateTime? FechaFin { get; set; }
    public string? Instrucciones { get; set; }
    public bool Activo { get; set; } = true;
    public DateTime FechaCreacion { get; set; }

    // Navegación
    public Receta Receta { get; set; } = null!;
}