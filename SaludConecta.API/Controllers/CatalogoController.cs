using Microsoft.AspNetCore.Mvc;
using SaludConecta.Application.Interfaces.Services;
using SaludConecta.Core.Enums;

namespace SaludConecta.API.Controllers;

[ApiController]
[Route("api/catalogo")]
public class CatalogoController : ControllerBase
{
    private readonly IAntecedenteService _service;

    public CatalogoController(IAntecedenteService service)
    {
        _service = service;
    }

    // GET api/catalogo/condiciones
    [HttpGet("condiciones")]
    public async Task<IActionResult> ObtenerCondiciones([FromQuery] CategoriaCondicionMedica? categoria)
    {
        if (categoria.HasValue)
        {
            var porCategoria = await _service.ObtenerCatalogoPorCategoriaAsync(categoria.Value);
            return Ok(porCategoria);
        }

        var todas = await _service.ObtenerCatalogoAsync();
        return Ok(todas);
    }
}
