using SaludConecta.Core.Enums;

namespace SaludConecta.Core.Entities;

public class CatalogoCondicionMedica
{
    public int Id { get; set; }
    public CategoriaCondicionMedica Categoria { get; set; }
    public string NombreCondicion { get; set; } = string.Empty;
    public int Orden { get; set; }

    // Navegación
    public ICollection<AntecedentePersonal> AntecedentesPersonales { get; set; } = new List<AntecedentePersonal>();
    public ICollection<AntecedenteHeredofamiliar> AntecedentesHeredofamiliares { get; set; } = new List<AntecedenteHeredofamiliar>();
}