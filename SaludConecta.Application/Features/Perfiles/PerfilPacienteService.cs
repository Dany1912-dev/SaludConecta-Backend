using SaludConecta.Application.DTOs;
using SaludConecta.Application.Interfaces.Services;
using SaludConecta.Core.Entities;
using SaludConecta.Core.Exceptions;
using SaludConecta.Core.Interfaces.Repositories;

namespace SaludConecta.Application.Features.Perfiles;

public class PerfilPacienteService : IPerfilPacienteService
{
    private readonly IPerfilPacienteRepository _perfilRepository;

    public PerfilPacienteService(IPerfilPacienteRepository perfilRepository)
    {
        _perfilRepository = perfilRepository;
    }

    public async Task<IEnumerable<PerfilPacienteResult>> ObtenerPerfilesAsync(int usuarioId)
    {
        var perfiles = await _perfilRepository.ObtenerPorUsuarioIdAsync(usuarioId);
        return perfiles.Where(p => p.Activo).Select(MapToResult);
    }

    public async Task<PerfilPacienteResult> ObtenerPerfilAsync(int perfilId, int usuarioId)
    {
        var perfil = await _perfilRepository.ObtenerPorIdAsync(perfilId)
            ?? throw new NotFoundException("Perfil no encontrado");

        if (perfil.UsuarioId != usuarioId)
            throw new UnauthorizedException("No tienes permiso para acceder a este perfil");

        return MapToResult(perfil);
    }

    public async Task<PerfilPacienteResult> CrearPerfilAsync(int usuarioId, CrearPerfilPacienteDto datos)
    {
        if (await _perfilRepository.ExistePerfilPacienteAsync(usuarioId, datos.NombreCompleto))
            throw new ConflictException($"Ya existe un perfil con el nombre '{datos.NombreCompleto}' en esta cuenta");

        var perfil = new PerfilPaciente
        {
            UsuarioId = usuarioId,
            NombreCompleto = datos.NombreCompleto.Trim(),
            FechaNacimiento = datos.FechaNacimiento,
            Genero = datos.Genero,
            TipoSangre = datos.TipoSangre,
            Parentesco = datos.Parentesco,
            Ocupacion = datos.Ocupacion,
            LugarNacimiento = datos.LugarNacimiento,
            Telefono = datos.Telefono,
            TelefonoEmergencia = datos.TelefonoEmergencia,
            CorreoContacto = datos.CorreoContacto,
            Direccion = datos.Direccion,
            ColorAvatar = datos.ColorAvatar,
            Activo = true,
            FechaCreacion = DateTime.UtcNow,
            FechaActualizacion = DateTime.UtcNow
        };

        await _perfilRepository.CrearAsync(perfil);
        return MapToResult(perfil);
    }

    public async Task<PerfilPacienteResult> ActualizarPerfilAsync(int perfilId, int usuarioId, ActualizarPerfilPacienteDto datos)
    {
        var perfil = await _perfilRepository.ObtenerPorIdAsync(perfilId)
            ?? throw new NotFoundException("Perfil no encontrado");

        if (perfil.UsuarioId != usuarioId)
            throw new UnauthorizedException("No tienes permiso para modificar este perfil");

        if (datos.NombreCompleto is not null && datos.NombreCompleto != perfil.NombreCompleto)
        {
            if (await _perfilRepository.ExistePerfilPacienteAsync(usuarioId, datos.NombreCompleto))
                throw new ConflictException($"Ya existe un perfil con el nombre '{datos.NombreCompleto}' en esta cuenta");

            perfil.NombreCompleto = datos.NombreCompleto.Trim();
        }

        if (datos.FechaNacimiento is not null) perfil.FechaNacimiento = datos.FechaNacimiento.Value;
        if (datos.Genero is not null) perfil.Genero = datos.Genero.Value;
        if (datos.TipoSangre is not null) perfil.TipoSangre = datos.TipoSangre.Value;
        if (datos.Parentesco is not null) perfil.Parentesco = datos.Parentesco.Value;
        if (datos.Ocupacion is not null) perfil.Ocupacion = datos.Ocupacion;
        if (datos.LugarNacimiento is not null) perfil.LugarNacimiento = datos.LugarNacimiento;
        if (datos.Telefono is not null) perfil.Telefono = datos.Telefono;
        if (datos.TelefonoEmergencia is not null) perfil.TelefonoEmergencia = datos.TelefonoEmergencia;
        if (datos.CorreoContacto is not null) perfil.CorreoContacto = datos.CorreoContacto;
        if (datos.Direccion is not null) perfil.Direccion = datos.Direccion;
        if (datos.ColorAvatar is not null) perfil.ColorAvatar = datos.ColorAvatar;

        perfil.FechaActualizacion = DateTime.UtcNow;

        await _perfilRepository.ActualizarAsync(perfil);
        return MapToResult(perfil);
    }

    public async Task DesactivarPerfilAsync(int perfilId, int usuarioId)
    {
        var perfil = await _perfilRepository.ObtenerPorIdAsync(perfilId)
            ?? throw new NotFoundException("Perfil no encontrado");

        if (perfil.UsuarioId != usuarioId)
            throw new UnauthorizedException("No tienes permiso para desactivar este perfil");

        perfil.Activo = false;
        perfil.FechaActualizacion = DateTime.UtcNow;

        await _perfilRepository.ActualizarAsync(perfil);
    }

    private static PerfilPacienteResult MapToResult(PerfilPaciente perfil) => new()
    {
        Id = perfil.Id,
        UsuarioId = perfil.UsuarioId,
        NombreCompleto = perfil.NombreCompleto,
        FechaNacimiento = perfil.FechaNacimiento,
        Genero = perfil.Genero,
        TipoSangre = perfil.TipoSangre,
        Parentesco = perfil.Parentesco,
        Ocupacion = perfil.Ocupacion,
        Telefono = perfil.Telefono,
        CorreoContacto = perfil.CorreoContacto,
        ColorAvatar = perfil.ColorAvatar,
        Activo = perfil.Activo,
        FechaCreacion = perfil.FechaCreacion
    };
}
