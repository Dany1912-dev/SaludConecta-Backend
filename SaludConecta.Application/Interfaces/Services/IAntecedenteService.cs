using SaludConecta.Application.DTOs;
using SaludConecta.Core.Enums;

namespace SaludConecta.Application.Interfaces.Services;

public interface IAntecedenteService
{
    // Catálogo
    Task<IEnumerable<CondicionMedicaResult>> ObtenerCatalogoAsync();
    Task<IEnumerable<CondicionMedicaResult>> ObtenerCatalogoPorCategoriaAsync(CategoriaCondicionMedica categoria);

    // Antecedentes personales
    Task<IEnumerable<AntecedentePersonalResult>> ObtenerPersonalesAsync(int perfilId, int usuarioId);
    Task<AntecedentePersonalResult> GuardarPersonalAsync(int perfilId, int usuarioId, int condicionMedicaId, bool presente, DateTime? fechaDiagnostico, DateTime? fechaResolucion, string? notas);
    Task EliminarPersonalAsync(int antecedenteId, int usuarioId);

    // Antecedentes heredo-familiares
    Task<IEnumerable<AntecedenteHeredofamiliarResult>> ObtenerHeredofamiliaresAsync(int perfilId, int usuarioId);
    Task<AntecedenteHeredofamiliarResult> CrearHeredofamiliarAsync(int perfilId, int usuarioId, int condicionMedicaId, ParentescoFamiliar parentesco, bool presente, string? notas);
    Task EliminarHeredofamiliarAsync(int antecedenteId, int usuarioId);

    // Antecedentes psicológicos
    Task<IEnumerable<AntecedentePsicologicoResult>> ObtenerPsicologicosAsync(int perfilId, int usuarioId);
    Task<AntecedentePsicologicoResult> CrearPsicologicoAsync(int perfilId, int usuarioId, string nombreCondicion, DateTime? fechaDiagnostico, string? notasTratamiento);
    Task DesactivarPsicologicoAsync(int antecedenteId, int usuarioId);
}
