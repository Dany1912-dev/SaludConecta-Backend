namespace SaludConecta.API.Contracts.EstiloVida;

public class EstiloVidaResponse
{
    public int Id { get; set; }
    public int PerfilPacienteId { get; set; }
    public string? CalidadVida { get; set; }
    public decimal? HorasSueno { get; set; }
    public string? CalidadAlimentacion { get; set; }
    public int? VasosAguaDiarios { get; set; }
    public string? ActividadFisica { get; set; }
    public string ConsumoAlcohol { get; set; } = "Ninguno";
    public string ConsumoDrogas { get; set; } = "Ninguno";
    public string Tabaquismo { get; set; } = "Ninguno";
    public string MedicamentosActuales { get; set; } = "Ninguno";
    public string Zoonosis { get; set; } = "No";
    public string AntecedentesLaborales { get; set; } = "Ninguno";
    public DateTime FechaActualizacion { get; set; }
}
