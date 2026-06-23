using SaludConecta.Application.DTOs;
using SaludConecta.Application.Interfaces.Services;
using SaludConecta.Core.Entities;
using SaludConecta.Core.Exceptions;
using SaludConecta.Core.Interfaces.Repositories;

namespace SaludConecta.Application.Features.Alergias;

public class AlergiaService : IAlergiaService
{
    private readonly IAlergiaRepository _alergiaRepo;
    private readonly IPerfilPacienteRepository _perfilRepo;

    public AlergiaService(IAlergiaRepository alergiaRepo, IPerfilPacienteRepository perfilRepo)
    {
        _alergiaRepo = alergiaRepo;
        _perfilRepo = perfilRepo;
    }

    public async Task<IEnumerable<AlergiaResult>> ObtenerAlergiasAsync(int perfilId, int usuarioId)
    {
        var perfil = await _perfilRepo.ObtenerPorIdAsync(perfilId)
            ?? throw new NotFoundException("Perfil no encontrado");

        if (perfil.UsuarioId != usuarioId)
            throw new UnauthorizedException("No tienes acceso a este perfil");

        var alergias = await _alergiaRepo.ObtenerPorPerfilAsync(perfilId);
        return alergias.Select(MapToResult);
    }

    public async Task<AlergiaResult> CrearAlergiaAsync(int perfilId, int usuarioId, CrearAlergiaDto datos)
    {
        var perfil = await _perfilRepo.ObtenerPorIdAsync(perfilId)
            ?? throw new NotFoundException("Perfil no encontrado");

        if (perfil.UsuarioId != usuarioId)
            throw new UnauthorizedException("No tienes acceso a este perfil");

        var alergia = new Alergia
        {
            PerfilPacienteId = perfilId,
            TipoAlergia = datos.TipoAlergia,
            Descripcion = datos.Descripcion.Trim(),
            Severidad = datos.Severidad,
            FechaDiagnostico = datos.FechaDiagnostico,
            FechaCreacion = DateTime.UtcNow,
        };

        await _alergiaRepo.CrearAsync(alergia);
        return MapToResult(alergia);
    }

    public async Task<AlergiaResult> ActualizarAlergiaAsync(int alergiaId, int usuarioId, ActualizarAlergiaDto datos)
    {
        var alergia = await _alergiaRepo.ObtenerConPerfilAsync(alergiaId)
            ?? throw new NotFoundException("Alergia no encontrada");

        if (alergia.PerfilPaciente.UsuarioId != usuarioId)
            throw new UnauthorizedException("No tienes acceso a esta alergia");

        if (datos.TipoAlergia.HasValue) alergia.TipoAlergia = datos.TipoAlergia.Value;
        if (datos.Descripcion != null) alergia.Descripcion = datos.Descripcion.Trim();
        if (datos.Severidad.HasValue) alergia.Severidad = datos.Severidad.Value;
        if (datos.FechaDiagnostico.HasValue) alergia.FechaDiagnostico = datos.FechaDiagnostico;

        await _alergiaRepo.ActualizarAsync(alergia);
        return MapToResult(alergia);
    }

    public async Task DesactivarAlergiaAsync(int alergiaId, int usuarioId)
    {
        var alergia = await _alergiaRepo.ObtenerConPerfilAsync(alergiaId)
            ?? throw new NotFoundException("Alergia no encontrada");

        if (alergia.PerfilPaciente.UsuarioId != usuarioId)
            throw new UnauthorizedException("No tienes acceso a esta alergia");

        alergia.Activa = false;
        await _alergiaRepo.ActualizarAsync(alergia);
    }

    private static AlergiaResult MapToResult(Alergia a) => new()
    {
        Id = a.Id,
        PerfilPacienteId = a.PerfilPacienteId,
        TipoAlergia = a.TipoAlergia.ToString(),
        Descripcion = a.Descripcion,
        Severidad = a.Severidad.ToString(),
        Activa = a.Activa,
        FechaDiagnostico = a.FechaDiagnostico,
        FechaCreacion = a.FechaCreacion,
    };
}
