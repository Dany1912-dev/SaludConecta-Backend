using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SaludConecta.API.Contracts.EstiloVida;
using SaludConecta.Application.DTOs;
using SaludConecta.Application.Interfaces.Services;

namespace SaludConecta.API.Controllers;

[ApiController]
[Authorize]
[Route("api/perfiles/{perfilId:int}/estilo-vida")]
public class EstiloVidaController : ControllerBase
{
    private readonly IEstiloVidaService _service;

    public EstiloVidaController(IEstiloVidaService service)
    {
        _service = service;
    }

    private int ObtenerUsuarioId()
        => int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

    // GET api/perfiles/{perfilId}/estilo-vida
    [HttpGet]
    public async Task<IActionResult> Obtener(int perfilId)
    {
        var result = await _service.ObtenerAsync(perfilId, ObtenerUsuarioId());
        if (result is null) return NoContent();
        return Ok(MapToResponse(result));
    }

    // PUT api/perfiles/{perfilId}/estilo-vida
    [HttpPut]
    public async Task<IActionResult> Guardar(int perfilId, [FromBody] EstiloVidaRequest request)
    {
        var dto = new GuardarEstiloVidaDto
        {
            CalidadVida = request.CalidadVida,
            HorasSueno = request.HorasSueno,
            CalidadAlimentacion = request.CalidadAlimentacion,
            VasosAguaDiarios = request.VasosAguaDiarios,
            ActividadFisica = request.ActividadFisica,
            ConsumoAlcohol = request.ConsumoAlcohol,
            ConsumoDrogas = request.ConsumoDrogas,
            Tabaquismo = request.Tabaquismo,
            MedicamentosActuales = request.MedicamentosActuales,
            Zoonosis = request.Zoonosis,
            AntecedentesLaborales = request.AntecedentesLaborales,
        };

        var result = await _service.GuardarAsync(perfilId, ObtenerUsuarioId(), dto);
        return Ok(MapToResponse(result));
    }

    private static EstiloVidaResponse MapToResponse(EstiloVidaResult r) => new()
    {
        Id = r.Id,
        PerfilPacienteId = r.PerfilPacienteId,
        CalidadVida = r.CalidadVida,
        HorasSueno = r.HorasSueno,
        CalidadAlimentacion = r.CalidadAlimentacion,
        VasosAguaDiarios = r.VasosAguaDiarios,
        ActividadFisica = r.ActividadFisica,
        ConsumoAlcohol = r.ConsumoAlcohol,
        ConsumoDrogas = r.ConsumoDrogas,
        Tabaquismo = r.Tabaquismo,
        MedicamentosActuales = r.MedicamentosActuales,
        Zoonosis = r.Zoonosis,
        AntecedentesLaborales = r.AntecedentesLaborales,
        FechaActualizacion = r.FechaActualizacion,
    };
}
