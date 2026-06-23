namespace SaludConecta.Application.DTOs;

public class CondicionMedicaResult
{
    public int Id { get; set; }
    public string Categoria { get; set; } = string.Empty;
    public string NombreCondicion { get; set; } = string.Empty;
    public int Orden { get; set; }
}
