using SaludConecta.Core.Enums;

namespace SaludConecta.API.Contracts.EstiloVida;

public class EstiloVidaRequest
{
    public CalidadVida? CalidadVida { get; set; }
    public decimal? HorasSueno { get; set; }
    public CalidadAlimentacion? CalidadAlimentacion { get; set; }
    public int? VasosAguaDiarios { get; set; }
    public string? ActividadFisica { get; set; }
    public string? ConsumoAlcohol { get; set; }
    public string? ConsumoDrogas { get; set; }
    public string? Tabaquismo { get; set; }
    public string? MedicamentosActuales { get; set; }
    public string? Zoonosis { get; set; }
    public string? AntecedentesLaborales { get; set; }
}
