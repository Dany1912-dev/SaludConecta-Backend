using SaludConecta.Core.Enums;

namespace SaludConecta.Core.Entities;

public class PerfilEstiloVida
{
    public int Id { get; set; }
    public int PerfilPacienteId { get; set; }
    public CalidadVida? CalidadVida { get; set; }
    public decimal? HorasSueno { get; set; }
    public CalidadAlimentacion? CalidadAlimentacion { get; set; }
    public int? VasosAguaDiarios { get; set; }
    public string? ActividadFisica { get; set; }
    public string ConsumoAlcohol { get; set; } = "Ninguno";
    public string ConsumoDrogas { get; set; } = "Ninguno";
    public string Tabaquismo { get; set; } = "Ninguno";
    public string MedicamentosActuales { get; set; } = "Ninguno";
    public string Zoonosis { get; set; } = "No";
    public string AntecedentesLaborales { get; set; } = "Ninguno";
    public DateTime FechaActualizacion { get; set; }

    // Navegación
    public PerfilPaciente PerfilPaciente { get; set; } = null!;
}