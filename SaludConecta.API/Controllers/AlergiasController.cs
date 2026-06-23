using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SaludConecta.API.Contracts.Alergias;
using SaludConecta.Application.DTOs;
using SaludConecta.Application.Interfaces.Services;

namespace SaludConecta.API.Controllers;

[ApiController]
[Authorize]
[Route("api/perfiles/{perfilId:int}/alergias")]
public class AlergiasController : ControllerBase
{
    private readonly IAlergiaService _service;

    public AlergiasController(IAlergiaService service)
    {
        _service = service;
    }

    private int ObtenerUsuarioId()
        => int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

    // GET api/perfiles/{perfilId}/alergias
    [HttpGet]
    public async Task<IActionResult> ObtenerTodas(int perfilId)
    {
        var alergias = await _service.ObtenerAlergiasAsync(perfilId, ObtenerUsuarioId());
        return Ok(alergias.Select(MapToResponse));
    }

    // POST api/perfiles/{perfilId}/alergias
    [HttpPost]
    public async Task<IActionResult> Crear(int perfilId, [FromBody] CrearAlergiaRequest request)
    {
        var dto = new CrearAlergiaDto
        {
            TipoAlergia = request.TipoAlergia,
            Descripcion = request.Descripcion,
            Severidad = request.Severidad,
            FechaDiagnostico = request.FechaDiagnostico,
        };

        var result = await _service.CrearAlergiaAsync(perfilId, ObtenerUsuarioId(), dto);
        return CreatedAtAction(nameof(ObtenerTodas), new { perfilId }, MapToResponse(result));
    }

    // PUT api/perfiles/{perfilId}/alergias/{id}
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Actualizar(int perfilId, int id, [FromBody] ActualizarAlergiaRequest request)
    {
        var dto = new ActualizarAlergiaDto
        {
            TipoAlergia = request.TipoAlergia,
            Descripcion = request.Descripcion,
            Severidad = request.Severidad,
            FechaDiagnostico = request.FechaDiagnostico,
        };

        var result = await _service.ActualizarAlergiaAsync(id, ObtenerUsuarioId(), dto);
        return Ok(MapToResponse(result));
    }

    // DELETE api/perfiles/{perfilId}/alergias/{id}
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Desactivar(int perfilId, int id)
    {
        await _service.DesactivarAlergiaAsync(id, ObtenerUsuarioId());
        return NoContent();
    }

    private static AlergiaResponse MapToResponse(AlergiaResult r) => new()
    {
        Id = r.Id,
        PerfilPacienteId = r.PerfilPacienteId,
        TipoAlergia = r.TipoAlergia,
        Descripcion = r.Descripcion,
        Severidad = r.Severidad,
        Activa = r.Activa,
        FechaDiagnostico = r.FechaDiagnostico,
        FechaCreacion = r.FechaCreacion,
    };
}
