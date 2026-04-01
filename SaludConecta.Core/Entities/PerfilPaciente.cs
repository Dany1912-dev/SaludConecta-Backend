using SaludConecta.Core.Enums;

namespace SaludConecta.Core.Entities;

public class PerfilPaciente
{
    public int Id { get; set; }
    public int UsuarioId { get; set; }
    public string NombreCompleto { get; set; } = string.Empty;
    public DateTime FechaNacimiento { get; set; }
    public Genero Genero { get; set; }
    public TipoSangre TipoSangre { get; set; } = TipoSangre.Desconocido;
    public Parentesco Parentesco { get; set; } = Parentesco.Yo;
    public string? Ocupacion { get; set; }
    public string? LugarNacimiento { get; set; }
    public string? Telefono { get; set; }
    public string? TelefonoEmergencia { get; set; }
    public string? CorreoContacto { get; set; }
    public string? Direccion { get; set; }
    public string ColorAvatar { get; set; } = "#6366F1";
    public bool Activo { get; set; } = true;
    public DateTime FechaCreacion { get; set; }
    public DateTime FechaActualizacion { get; set; }

    // Navegación
    public Usuario Usuario { get; set; } = null!;
    public ICollection<RegistroBiometrico> RegistrosBiometricos { get; set; } = new List<RegistroBiometrico>();
    public ICollection<AntecedentePersonal> AntecedentesPersonales { get; set; } = new List<AntecedentePersonal>();
    public ICollection<AntecedenteHeredofamiliar> AntecedentesHeredofamiliares { get; set; } = new List<AntecedenteHeredofamiliar>();
    public ICollection<AntecedentePsicologico> AntecedentesPsicologicos { get; set; } = new List<AntecedentePsicologico>();
    public PerfilEstiloVida? PerfilEstiloVida { get; set; }
    public ICollection<Alergia> Alergias { get; set; } = new List<Alergia>();
    public ICollection<EventoQuirurgico> EventosQuirurgicos { get; set; } = new List<EventoQuirurgico>();
    public ICollection<Consulta> Consultas { get; set; } = new List<Consulta>();
    public ICollection<Receta> Recetas { get; set; } = new List<Receta>();
    public ICollection<EstudioClinico> EstudiosClinicos { get; set; } = new List<EstudioClinico>();
    public ICollection<ArchivoAdjunto> ArchivosAdjuntos { get; set; } = new List<ArchivoAdjunto>();
}