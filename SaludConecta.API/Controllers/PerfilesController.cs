using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SaludConecta.API.Contracts.Perfiles;
using SaludConecta.Application.DTOs;
using SaludConecta.Application.Interfaces.Services;

namespace SaludConecta.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class PerfilesController : ControllerBase
{
    private readonly IPerfilPacienteService _perfilService;

    public PerfilesController(IPerfilPacienteService perfilService)
    {
        _perfilService = perfilService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PerfilPacienteResponse>>> ObtenerPerfiles()
    {
        var usuarioId = ObtenerUsuarioId();
        var perfiles = await _perfilService.ObtenerPerfilesAsync(usuarioId);
        return Ok(perfiles.Select(MapToResponse));
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<PerfilPacienteResponse>> ObtenerPerfil(int id)
    {
        var usuarioId = ObtenerUsuarioId();
        var perfil = await _perfilService.ObtenerPerfilAsync(id, usuarioId);
        return Ok(MapToResponse(perfil));
    }

    [HttpPost]
    public async Task<ActionResult<PerfilPacienteResponse>> CrearPerfil([FromBody] CrearPerfilRequest request)
    {
        var usuarioId = ObtenerUsuarioId();

        var datos = new CrearPerfilPacienteDto
        {
            NombreCompleto = request.NombreCompleto,
            FechaNacimiento = request.FechaNacimiento,
            Genero = request.Genero,
            TipoSangre = request.TipoSangre,
            Parentesco = request.Parentesco,
            Ocupacion = request.Ocupacion,
            LugarNacimiento = request.LugarNacimiento,
            Telefono = request.Telefono,
            TelefonoEmergencia = request.TelefonoEmergencia,
            CorreoContacto = request.CorreoContacto,
            Direccion = request.Direccion,
            ColorAvatar = request.ColorAvatar
        };

        var perfil = await _perfilService.CrearPerfilAsync(usuarioId, datos);
        return CreatedAtAction(nameof(ObtenerPerfil), new { id = perfil.Id }, MapToResponse(perfil));
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<PerfilPacienteResponse>> ActualizarPerfil(int id, [FromBody] ActualizarPerfilRequest request)
    {
        var usuarioId = ObtenerUsuarioId();

        var datos = new ActualizarPerfilPacienteDto
        {
            NombreCompleto = request.NombreCompleto,
            FechaNacimiento = request.FechaNacimiento,
            Genero = request.Genero,
            TipoSangre = request.TipoSangre,
            Parentesco = request.Parentesco,
            Ocupacion = request.Ocupacion,
            LugarNacimiento = request.LugarNacimiento,
            Telefono = request.Telefono,
            TelefonoEmergencia = request.TelefonoEmergencia,
            CorreoContacto = request.CorreoContacto,
            Direccion = request.Direccion,
            ColorAvatar = request.ColorAvatar
        };

        var perfil = await _perfilService.ActualizarPerfilAsync(id, usuarioId, datos);
        return Ok(MapToResponse(perfil));
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DesactivarPerfil(int id)
    {
        var usuarioId = ObtenerUsuarioId();
        await _perfilService.DesactivarPerfilAsync(id, usuarioId);
        return NoContent();
    }

    private int ObtenerUsuarioId() =>
        int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

    private static PerfilPacienteResponse MapToResponse(PerfilPacienteResult result) => new()
    {
        Id = result.Id,
        NombreCompleto = result.NombreCompleto,
        FechaNacimiento = result.FechaNacimiento,
        Genero = result.Genero.ToString(),
        TipoSangre = result.TipoSangre.ToString(),
        Parentesco = result.Parentesco.ToString(),
        Ocupacion = result.Ocupacion,
        Telefono = result.Telefono,
        CorreoContacto = result.CorreoContacto,
        ColorAvatar = result.ColorAvatar,
        FechaCreacion = result.FechaCreacion
    };
}
