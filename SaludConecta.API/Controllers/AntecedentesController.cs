using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SaludConecta.API.Contracts.Antecedentes;
using SaludConecta.Application.Interfaces.Services;
using SaludConecta.Core.Enums;

namespace SaludConecta.API.Controllers;

[ApiController]
[Authorize]
[Route("api/perfiles/{perfilId:int}/antecedentes")]
public class AntecedentesController : ControllerBase
{
    private readonly IAntecedenteService _service;

    public AntecedentesController(IAntecedenteService service)
    {
        _service = service;
    }

    private int ObtenerUsuarioId()
        => int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

    // ── Antecedentes personales ───────────────────────────────

    [HttpGet("personales")]
    public async Task<IActionResult> ObtenerPersonales(int perfilId)
    {
        var lista = await _service.ObtenerPersonalesAsync(perfilId, ObtenerUsuarioId());
        return Ok(lista);
    }

    [HttpPost("personales")]
    public async Task<IActionResult> GuardarPersonal(int perfilId, [FromBody] GuardarAntecedentePersonalRequest req)
    {
        var result = await _service.GuardarPersonalAsync(
            perfilId, ObtenerUsuarioId(),
            req.CondicionMedicaId, req.Presente,
            req.FechaDiagnostico, req.FechaResolucion, req.Notas);

        return Ok(result);
    }

    [HttpDelete("personales/{id:int}")]
    public async Task<IActionResult> EliminarPersonal(int perfilId, int id)
    {
        await _service.EliminarPersonalAsync(id, ObtenerUsuarioId());
        return NoContent();
    }

    // ── Antecedentes heredo-familiares ────────────────────────

    [HttpGet("heredofamiliares")]
    public async Task<IActionResult> ObtenerHeredofamiliares(int perfilId)
    {
        var lista = await _service.ObtenerHeredofamiliaresAsync(perfilId, ObtenerUsuarioId());
        return Ok(lista);
    }

    [HttpPost("heredofamiliares")]
    public async Task<IActionResult> CrearHeredofamiliar(int perfilId, [FromBody] CrearAntecedenteHeredofamiliarRequest req)
    {
        var result = await _service.CrearHeredofamiliarAsync(
            perfilId, ObtenerUsuarioId(),
            req.CondicionMedicaId, req.ParentescoFamiliar, req.Presente, req.Notas);

        return Ok(result);
    }

    [HttpDelete("heredofamiliares/{id:int}")]
    public async Task<IActionResult> EliminarHeredofamiliar(int perfilId, int id)
    {
        await _service.EliminarHeredofamiliarAsync(id, ObtenerUsuarioId());
        return NoContent();
    }

    // ── Antecedentes psicológicos ─────────────────────────────

    [HttpGet("psicologicos")]
    public async Task<IActionResult> ObtenerPsicologicos(int perfilId)
    {
        var lista = await _service.ObtenerPsicologicosAsync(perfilId, ObtenerUsuarioId());
        return Ok(lista);
    }

    [HttpPost("psicologicos")]
    public async Task<IActionResult> CrearPsicologico(int perfilId, [FromBody] CrearAntecedentePsicologicoRequest req)
    {
        var result = await _service.CrearPsicologicoAsync(
            perfilId, ObtenerUsuarioId(),
            req.NombreCondicion, req.FechaDiagnostico, req.NotasTratamiento);

        return Ok(result);
    }

    [HttpDelete("psicologicos/{id:int}")]
    public async Task<IActionResult> DesactivarPsicologico(int perfilId, int id)
    {
        await _service.DesactivarPsicologicoAsync(id, ObtenerUsuarioId());
        return NoContent();
    }
}
