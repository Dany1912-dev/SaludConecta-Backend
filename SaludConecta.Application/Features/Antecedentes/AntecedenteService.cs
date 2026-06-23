using SaludConecta.Application.DTOs;
using SaludConecta.Application.Interfaces.Services;
using SaludConecta.Core.Entities;
using SaludConecta.Core.Enums;
using SaludConecta.Core.Exceptions;
using SaludConecta.Core.Interfaces.Repositories;

namespace SaludConecta.Application.Features.Antecedentes;

public class AntecedenteService : IAntecedenteService
{
    private readonly IPerfilPacienteRepository _perfilRepo;
    private readonly ICatalogoCondicionMedicaRepository _catalogoRepo;
    private readonly IAntecedentePersonalRepository _personalRepo;
    private readonly IAntecedenteHeredofamiliarRepository _heredoRepo;
    private readonly IAntecedentePsicologicoRepository _psicRepo;

    public AntecedenteService(
        IPerfilPacienteRepository perfilRepo,
        ICatalogoCondicionMedicaRepository catalogoRepo,
        IAntecedentePersonalRepository personalRepo,
        IAntecedenteHeredofamiliarRepository heredoRepo,
        IAntecedentePsicologicoRepository psicRepo)
    {
        _perfilRepo = perfilRepo;
        _catalogoRepo = catalogoRepo;
        _personalRepo = personalRepo;
        _heredoRepo = heredoRepo;
        _psicRepo = psicRepo;
    }

    // ── Catálogo ──────────────────────────────────────────────

    public async Task<IEnumerable<CondicionMedicaResult>> ObtenerCatalogoAsync()
    {
        var condiciones = await _catalogoRepo.ObtenerTodosOrdenadosAsync();
        return condiciones.Select(MapCondicion);
    }

    public async Task<IEnumerable<CondicionMedicaResult>> ObtenerCatalogoPorCategoriaAsync(CategoriaCondicionMedica categoria)
    {
        var condiciones = await _catalogoRepo.ObtenerPorCategoriaAsync(categoria);
        return condiciones.Select(MapCondicion);
    }

    // ── Antecedentes personales ───────────────────────────────

    public async Task<IEnumerable<AntecedentePersonalResult>> ObtenerPersonalesAsync(int perfilId, int usuarioId)
    {
        await ValidarPropietario(perfilId, usuarioId);
        var lista = await _personalRepo.ObtenerPorPerfilAsync(perfilId);
        return lista.Select(MapPersonal);
    }

    public async Task<AntecedentePersonalResult> GuardarPersonalAsync(int perfilId, int usuarioId, int condicionMedicaId,
        bool presente, DateTime? fechaDiagnostico, DateTime? fechaResolucion, string? notas)
    {
        await ValidarPropietario(perfilId, usuarioId);

        var condicion = await _catalogoRepo.ObtenerPorIdAsync(condicionMedicaId)
            ?? throw new NotFoundException("Condición médica no encontrada en el catálogo");

        // Upsert: si ya existe para este perfil+condición, actualizar
        var existente = await _personalRepo.ExisteAsync(perfilId, condicionMedicaId);
        if (existente)
        {
            var lista = await _personalRepo.ObtenerPorPerfilAsync(perfilId);
            var registro = lista.First(a => a.CondicionMedicaId == condicionMedicaId);
            registro.Presente = presente;
            registro.FechaDiagnostico = fechaDiagnostico;
            registro.FechaResolucion = fechaResolucion;
            registro.Notas = notas?.Trim();
            await _personalRepo.ActualizarAsync(registro);
            registro.CondicionMedica = condicion;
            return MapPersonal(registro);
        }

        var antecedente = new AntecedentePersonal
        {
            PerfilPacienteId = perfilId,
            CondicionMedicaId = condicionMedicaId,
            Presente = presente,
            FechaDiagnostico = fechaDiagnostico,
            FechaResolucion = fechaResolucion,
            Notas = notas?.Trim(),
            FechaCreacion = DateTime.UtcNow,
        };

        await _personalRepo.CrearAsync(antecedente);
        antecedente.CondicionMedica = condicion;
        return MapPersonal(antecedente);
    }

    public async Task EliminarPersonalAsync(int antecedenteId, int usuarioId)
    {
        var antecedente = await _personalRepo.ObtenerConPerfilAsync(antecedenteId)
            ?? throw new NotFoundException("Antecedente no encontrado");

        if (antecedente.PerfilPaciente.UsuarioId != usuarioId)
            throw new UnauthorizedException("No tienes acceso a este antecedente");

        await _personalRepo.EliminarAsync(antecedente);
    }

    // ── Antecedentes heredo-familiares ────────────────────────

    public async Task<IEnumerable<AntecedenteHeredofamiliarResult>> ObtenerHeredofamiliaresAsync(int perfilId, int usuarioId)
    {
        await ValidarPropietario(perfilId, usuarioId);
        var lista = await _heredoRepo.ObtenerPorPerfilAsync(perfilId);
        return lista.Select(MapHeredo);
    }

    public async Task<AntecedenteHeredofamiliarResult> CrearHeredofamiliarAsync(int perfilId, int usuarioId,
        int condicionMedicaId, ParentescoFamiliar parentesco, bool presente, string? notas)
    {
        await ValidarPropietario(perfilId, usuarioId);

        var condicion = await _catalogoRepo.ObtenerPorIdAsync(condicionMedicaId)
            ?? throw new NotFoundException("Condición médica no encontrada en el catálogo");

        var antecedente = new AntecedenteHeredofamiliar
        {
            PerfilPacienteId = perfilId,
            CondicionMedicaId = condicionMedicaId,
            ParentescoFamiliar = parentesco,
            Presente = presente,
            Notas = notas?.Trim(),
            FechaCreacion = DateTime.UtcNow,
        };

        await _heredoRepo.CrearAsync(antecedente);
        antecedente.CondicionMedica = condicion;
        return MapHeredo(antecedente);
    }

    public async Task EliminarHeredofamiliarAsync(int antecedenteId, int usuarioId)
    {
        var antecedente = await _heredoRepo.ObtenerConPerfilAsync(antecedenteId)
            ?? throw new NotFoundException("Antecedente heredo-familiar no encontrado");

        if (antecedente.PerfilPaciente.UsuarioId != usuarioId)
            throw new UnauthorizedException("No tienes acceso a este antecedente");

        await _heredoRepo.EliminarAsync(antecedente);
    }

    // ── Antecedentes psicológicos ─────────────────────────────

    public async Task<IEnumerable<AntecedentePsicologicoResult>> ObtenerPsicologicosAsync(int perfilId, int usuarioId)
    {
        await ValidarPropietario(perfilId, usuarioId);
        var lista = await _psicRepo.ObtenerPorPerfilAsync(perfilId);
        return lista.Select(MapPsic);
    }

    public async Task<AntecedentePsicologicoResult> CrearPsicologicoAsync(int perfilId, int usuarioId,
        string nombreCondicion, DateTime? fechaDiagnostico, string? notasTratamiento)
    {
        await ValidarPropietario(perfilId, usuarioId);

        var antecedente = new AntecedentePsicologico
        {
            PerfilPacienteId = perfilId,
            NombreCondicion = nombreCondicion.Trim(),
            FechaDiagnostico = fechaDiagnostico,
            Activo = true,
            NotasTratamiento = notasTratamiento?.Trim(),
            FechaCreacion = DateTime.UtcNow,
        };

        await _psicRepo.CrearAsync(antecedente);
        return MapPsic(antecedente);
    }

    public async Task DesactivarPsicologicoAsync(int antecedenteId, int usuarioId)
    {
        var antecedente = await _psicRepo.ObtenerConPerfilAsync(antecedenteId)
            ?? throw new NotFoundException("Antecedente psicológico no encontrado");

        if (antecedente.PerfilPaciente.UsuarioId != usuarioId)
            throw new UnauthorizedException("No tienes acceso a este antecedente");

        antecedente.Activo = false;
        await _psicRepo.ActualizarAsync(antecedente);
    }

    // ── Helpers ───────────────────────────────────────────────

    private async Task ValidarPropietario(int perfilId, int usuarioId)
    {
        var perfil = await _perfilRepo.ObtenerPorIdAsync(perfilId)
            ?? throw new NotFoundException("Perfil no encontrado");

        if (perfil.UsuarioId != usuarioId)
            throw new UnauthorizedException("No tienes acceso a este perfil");
    }

    private static CondicionMedicaResult MapCondicion(CatalogoCondicionMedica c) => new()
    {
        Id = c.Id,
        Categoria = c.Categoria.ToString(),
        NombreCondicion = c.NombreCondicion,
        Orden = c.Orden,
    };

    private static AntecedentePersonalResult MapPersonal(AntecedentePersonal a) => new()
    {
        Id = a.Id,
        PerfilPacienteId = a.PerfilPacienteId,
        CondicionMedica = MapCondicion(a.CondicionMedica),
        Presente = a.Presente,
        FechaDiagnostico = a.FechaDiagnostico,
        FechaResolucion = a.FechaResolucion,
        Notas = a.Notas,
        FechaCreacion = a.FechaCreacion,
    };

    private static AntecedenteHeredofamiliarResult MapHeredo(AntecedenteHeredofamiliar a) => new()
    {
        Id = a.Id,
        PerfilPacienteId = a.PerfilPacienteId,
        ParentescoFamiliar = a.ParentescoFamiliar.ToString(),
        CondicionMedica = MapCondicion(a.CondicionMedica),
        Presente = a.Presente,
        Notas = a.Notas,
        FechaCreacion = a.FechaCreacion,
    };

    private static AntecedentePsicologicoResult MapPsic(AntecedentePsicologico a) => new()
    {
        Id = a.Id,
        PerfilPacienteId = a.PerfilPacienteId,
        NombreCondicion = a.NombreCondicion,
        FechaDiagnostico = a.FechaDiagnostico,
        FechaResolucion = a.FechaResolucion,
        Activo = a.Activo,
        NotasTratamiento = a.NotasTratamiento,
        FechaCreacion = a.FechaCreacion,
    };
}
