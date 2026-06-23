using SaludConecta.Application.DTOs;
using SaludConecta.Application.Interfaces.Services;
using SaludConecta.Core.Entities;
using SaludConecta.Core.Exceptions;
using SaludConecta.Core.Interfaces.Repositories;

namespace SaludConecta.Application.Features.EstiloVida;

public class EstiloVidaService : IEstiloVidaService
{
    private readonly IPerfilEstiloVidaRepository _estiloRepo;
    private readonly IPerfilPacienteRepository _perfilRepo;

    public EstiloVidaService(IPerfilEstiloVidaRepository estiloRepo, IPerfilPacienteRepository perfilRepo)
    {
        _estiloRepo = estiloRepo;
        _perfilRepo = perfilRepo;
    }

    public async Task<EstiloVidaResult?> ObtenerAsync(int perfilId, int usuarioId)
    {
        var perfil = await _perfilRepo.ObtenerPorIdAsync(perfilId)
            ?? throw new NotFoundException("Perfil no encontrado");

        if (perfil.UsuarioId != usuarioId)
            throw new UnauthorizedException("No tienes acceso a este perfil");

        var estilo = await _estiloRepo.ObtenerPorPerfilAsync(perfilId);
        return estilo is null ? null : MapToResult(estilo);
    }

    public async Task<EstiloVidaResult> GuardarAsync(int perfilId, int usuarioId, GuardarEstiloVidaDto datos)
    {
        var perfil = await _perfilRepo.ObtenerPorIdAsync(perfilId)
            ?? throw new NotFoundException("Perfil no encontrado");

        if (perfil.UsuarioId != usuarioId)
            throw new UnauthorizedException("No tienes acceso a este perfil");

        var estilo = await _estiloRepo.ObtenerPorPerfilAsync(perfilId);

        if (estilo is null)
        {
            // Primera vez: crear
            estilo = new PerfilEstiloVida
            {
                PerfilPacienteId = perfilId,
                FechaActualizacion = DateTime.UtcNow,
            };
            AplicarCambios(estilo, datos);
            await _estiloRepo.CrearAsync(estilo);
        }
        else
        {
            // Ya existe: actualizar (upsert)
            AplicarCambios(estilo, datos);
            estilo.FechaActualizacion = DateTime.UtcNow;
            await _estiloRepo.ActualizarAsync(estilo);
        }

        return MapToResult(estilo);
    }

    private static void AplicarCambios(PerfilEstiloVida estilo, GuardarEstiloVidaDto datos)
    {
        if (datos.CalidadVida.HasValue) estilo.CalidadVida = datos.CalidadVida;
        if (datos.HorasSueno.HasValue) estilo.HorasSueno = datos.HorasSueno;
        if (datos.CalidadAlimentacion.HasValue) estilo.CalidadAlimentacion = datos.CalidadAlimentacion;
        if (datos.VasosAguaDiarios.HasValue) estilo.VasosAguaDiarios = datos.VasosAguaDiarios;
        if (datos.ActividadFisica != null) estilo.ActividadFisica = datos.ActividadFisica.Trim();
        if (datos.ConsumoAlcohol != null) estilo.ConsumoAlcohol = datos.ConsumoAlcohol.Trim();
        if (datos.ConsumoDrogas != null) estilo.ConsumoDrogas = datos.ConsumoDrogas.Trim();
        if (datos.Tabaquismo != null) estilo.Tabaquismo = datos.Tabaquismo.Trim();
        if (datos.MedicamentosActuales != null) estilo.MedicamentosActuales = datos.MedicamentosActuales.Trim();
        if (datos.Zoonosis != null) estilo.Zoonosis = datos.Zoonosis.Trim();
        if (datos.AntecedentesLaborales != null) estilo.AntecedentesLaborales = datos.AntecedentesLaborales.Trim();
    }

    private static EstiloVidaResult MapToResult(PerfilEstiloVida e) => new()
    {
        Id = e.Id,
        PerfilPacienteId = e.PerfilPacienteId,
        CalidadVida = e.CalidadVida?.ToString(),
        HorasSueno = e.HorasSueno,
        CalidadAlimentacion = e.CalidadAlimentacion?.ToString(),
        VasosAguaDiarios = e.VasosAguaDiarios,
        ActividadFisica = e.ActividadFisica,
        ConsumoAlcohol = e.ConsumoAlcohol,
        ConsumoDrogas = e.ConsumoDrogas,
        Tabaquismo = e.Tabaquismo,
        MedicamentosActuales = e.MedicamentosActuales,
        Zoonosis = e.Zoonosis,
        AntecedentesLaborales = e.AntecedentesLaborales,
        FechaActualizacion = e.FechaActualizacion,
    };
}
