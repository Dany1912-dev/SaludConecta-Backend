using Microsoft.EntityFrameworkCore;
using SaludConecta.Core.Entities;

namespace SaludConecta.Infrastructure.Data.Context;

public class SaludConectaDbContext : DbContext
{
    public SaludConectaDbContext(DbContextOptions<SaludConectaDbContext> options) : base(options)
    {
    }

    // Autenticación
    public DbSet<Usuario> Usuarios => Set<Usuario>();
    public DbSet<ProveedorAutenticacion> ProveedoresAutenticacion => Set<ProveedorAutenticacion>();
    public DbSet<RefreshToken> RefreshTokens => Set<RefreshToken>();
    public DbSet<CodigoVerificacion> CodigosVerificacion => Set<CodigoVerificacion>();

    // Perfiles
    public DbSet<PerfilPaciente> PerfilesPaciente => Set<PerfilPaciente>();

    // Biométricos
    public DbSet<RegistroBiometrico> RegistrosBiometricos => Set<RegistroBiometrico>();

    // Antecedentes
    public DbSet<CatalogoCondicionMedica> CatalogoCondicionesMedicas => Set<CatalogoCondicionMedica>();
    public DbSet<AntecedentePersonal> AntecedentesPersonales => Set<AntecedentePersonal>();
    public DbSet<AntecedenteHeredofamiliar> AntecedentesHeredofamiliares => Set<AntecedenteHeredofamiliar>();
    public DbSet<AntecedentePsicologico> AntecedentesPsicologicos => Set<AntecedentePsicologico>();

    // Estilo de vida
    public DbSet<PerfilEstiloVida> PerfilesEstiloVida => Set<PerfilEstiloVida>();

    // Alergias
    public DbSet<Alergia> Alergias => Set<Alergia>();

    // Eventos quirúrgicos
    public DbSet<EventoQuirurgico> EventosQuirurgicos => Set<EventoQuirurgico>();

    // Consultas
    public DbSet<Consulta> Consultas => Set<Consulta>();

    // Recetas y medicamentos
    public DbSet<Receta> Recetas => Set<Receta>();
    public DbSet<MedicamentoReceta> MedicamentosReceta => Set<MedicamentoReceta>();

    // Estudios clínicos
    public DbSet<EstudioClinico> EstudiosClinicos => Set<EstudioClinico>();

    // Archivos
    public DbSet<ArchivoAdjunto> ArchivosAdjuntos => Set<ArchivoAdjunto>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Aplica todas las configuraciones de Fluent API que estén en este ensamblado
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SaludConectaDbContext).Assembly);
    }
}