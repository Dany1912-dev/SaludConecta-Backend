using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SaludConecta.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CatalogoCondicionesMedicas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Categoria = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NombreCondicion = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Orden = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogoCondicionesMedicas", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Correo = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefono = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TelefonoVerificado = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: false),
                    Modo = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false, defaultValue: "Personal")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaCreacion = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    FechaActualizacion = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CodigosVerificacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    Codigo = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Tipo = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaExpiracion = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Usado = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: false),
                    IntentosFallidos = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    FechaCreacion = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CodigosVerificacion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CodigosVerificacion_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PerfilesPaciente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    NombreCompleto = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Genero = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TipoSangre = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false, defaultValue: "Desconocido")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Parentesco = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false, defaultValue: "Yo")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Ocupacion = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LugarNacimiento = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefono = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TelefonoEmergencia = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CorreoContacto = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Direccion = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ColorAvatar = table.Column<string>(type: "varchar(7)", maxLength: 7, nullable: false, defaultValue: "#6366F1")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Activo = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    FechaActualizacion = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerfilesPaciente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PerfilesPaciente_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ProveedoresAutenticacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    TipoProveedor = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    HashContrasena = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    GoogleId = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaCreacion = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProveedoresAutenticacion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProveedoresAutenticacion_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    Token = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaExpiracion = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Revocado = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: false),
                    DispositivoInfo = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DireccionIP = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaCreacion = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Alergias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PerfilPacienteId = table.Column<int>(type: "int", nullable: false),
                    TipoAlergia = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descripcion = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Severidad = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false, defaultValue: "Moderada")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Activa = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: true),
                    FechaDiagnostico = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alergias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alergias_PerfilesPaciente_PerfilPacienteId",
                        column: x => x.PerfilPacienteId,
                        principalTable: "PerfilesPaciente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AntecedentesHeredofamiliares",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PerfilPacienteId = table.Column<int>(type: "int", nullable: false),
                    ParentescoFamiliar = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CondicionMedicaId = table.Column<int>(type: "int", nullable: false),
                    Presente = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: false),
                    Notas = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaCreacion = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AntecedentesHeredofamiliares", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AntecedentesHeredofamiliares_CatalogoCondicionesMedicas_Cond~",
                        column: x => x.CondicionMedicaId,
                        principalTable: "CatalogoCondicionesMedicas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AntecedentesHeredofamiliares_PerfilesPaciente_PerfilPaciente~",
                        column: x => x.PerfilPacienteId,
                        principalTable: "PerfilesPaciente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AntecedentesPersonales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PerfilPacienteId = table.Column<int>(type: "int", nullable: false),
                    CondicionMedicaId = table.Column<int>(type: "int", nullable: false),
                    Presente = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: false),
                    FechaDiagnostico = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    FechaResolucion = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Notas = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaCreacion = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AntecedentesPersonales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AntecedentesPersonales_CatalogoCondicionesMedicas_CondicionM~",
                        column: x => x.CondicionMedicaId,
                        principalTable: "CatalogoCondicionesMedicas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AntecedentesPersonales_PerfilesPaciente_PerfilPacienteId",
                        column: x => x.PerfilPacienteId,
                        principalTable: "PerfilesPaciente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AntecedentesPsicologicos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PerfilPacienteId = table.Column<int>(type: "int", nullable: false),
                    NombreCondicion = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaDiagnostico = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    FechaResolucion = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Activo = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: true),
                    NotasTratamiento = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaCreacion = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AntecedentesPsicologicos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AntecedentesPsicologicos_PerfilesPaciente_PerfilPacienteId",
                        column: x => x.PerfilPacienteId,
                        principalTable: "PerfilesPaciente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Consultas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PerfilPacienteId = table.Column<int>(type: "int", nullable: false),
                    FechaConsulta = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    NombreEspecialista = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Especialidad = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MotivoConsulta = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Diagnostico = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Notas = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaSeguimiento = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consultas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Consultas_PerfilesPaciente_PerfilPacienteId",
                        column: x => x.PerfilPacienteId,
                        principalTable: "PerfilesPaciente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "EventosQuirurgicos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PerfilPacienteId = table.Column<int>(type: "int", nullable: false),
                    TipoEvento = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descripcion = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaEvento = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Hospital = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Medico = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Notas = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaCreacion = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventosQuirurgicos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventosQuirurgicos_PerfilesPaciente_PerfilPacienteId",
                        column: x => x.PerfilPacienteId,
                        principalTable: "PerfilesPaciente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PerfilEstiloVida",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PerfilPacienteId = table.Column<int>(type: "int", nullable: false),
                    CalidadVida = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    HorasSueno = table.Column<decimal>(type: "decimal(3,1)", precision: 3, scale: 1, nullable: true),
                    CalidadAlimentacion = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    VasosAguaDiarios = table.Column<int>(type: "int", nullable: true),
                    ActividadFisica = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConsumoAlcohol = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, defaultValue: "Ninguno")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConsumoDrogas = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, defaultValue: "Ninguno")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Tabaquismo = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, defaultValue: "Ninguno")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MedicamentosActuales = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false, defaultValue: "Ninguno")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Zoonosis = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, defaultValue: "No")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AntecedentesLaborales = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false, defaultValue: "Ninguno")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaActualizacion = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerfilEstiloVida", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PerfilEstiloVida_PerfilesPaciente_PerfilPacienteId",
                        column: x => x.PerfilPacienteId,
                        principalTable: "PerfilesPaciente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RegistrosBiometricos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PerfilPacienteId = table.Column<int>(type: "int", nullable: false),
                    PesoKg = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: true),
                    EstaturaCm = table.Column<decimal>(type: "decimal(5,1)", precision: 5, scale: 1, nullable: true),
                    Notas = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaRegistro = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistrosBiometricos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RegistrosBiometricos_PerfilesPaciente_PerfilPacienteId",
                        column: x => x.PerfilPacienteId,
                        principalTable: "PerfilesPaciente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "EstudiosClinicos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PerfilPacienteId = table.Column<int>(type: "int", nullable: false),
                    ConsultaId = table.Column<int>(type: "int", nullable: true),
                    TipoEstudio = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NombreEstudio = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Laboratorio = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MedicoSolicitante = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaRealizacion = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FechaResultados = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Observaciones = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaCreacion = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstudiosClinicos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EstudiosClinicos_Consultas_ConsultaId",
                        column: x => x.ConsultaId,
                        principalTable: "Consultas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_EstudiosClinicos_PerfilesPaciente_PerfilPacienteId",
                        column: x => x.PerfilPacienteId,
                        principalTable: "PerfilesPaciente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Recetas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PerfilPacienteId = table.Column<int>(type: "int", nullable: false),
                    ConsultaId = table.Column<int>(type: "int", nullable: true),
                    RecetadoPor = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaReceta = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FechaVencimiento = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Activa = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: true),
                    Notas = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaCreacion = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recetas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recetas_Consultas_ConsultaId",
                        column: x => x.ConsultaId,
                        principalTable: "Consultas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Recetas_PerfilesPaciente_PerfilPacienteId",
                        column: x => x.PerfilPacienteId,
                        principalTable: "PerfilesPaciente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ArchivosAdjuntos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PerfilPacienteId = table.Column<int>(type: "int", nullable: false),
                    RecetaId = table.Column<int>(type: "int", nullable: true),
                    ConsultaId = table.Column<int>(type: "int", nullable: true),
                    EstudioClinicoId = table.Column<int>(type: "int", nullable: true),
                    TipoArchivo = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NombreOriginal = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RutaArchivo = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ExtensionArchivo = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TamanoBytes = table.Column<long>(type: "bigint", nullable: false),
                    ContentType = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descripcion = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaCreacion = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArchivosAdjuntos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArchivosAdjuntos_Consultas_ConsultaId",
                        column: x => x.ConsultaId,
                        principalTable: "Consultas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_ArchivosAdjuntos_EstudiosClinicos_EstudioClinicoId",
                        column: x => x.EstudioClinicoId,
                        principalTable: "EstudiosClinicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_ArchivosAdjuntos_PerfilesPaciente_PerfilPacienteId",
                        column: x => x.PerfilPacienteId,
                        principalTable: "PerfilesPaciente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArchivosAdjuntos_Recetas_RecetaId",
                        column: x => x.RecetaId,
                        principalTable: "Recetas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MedicamentosReceta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RecetaId = table.Column<int>(type: "int", nullable: false),
                    NombreMedicamento = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Dosis = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Frecuencia = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FrecuenciaHoras = table.Column<int>(type: "int", nullable: true),
                    ViaAdministracion = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false, defaultValue: "Oral")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaInicio = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Instrucciones = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Activo = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicamentosReceta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicamentosReceta_Recetas_RecetaId",
                        column: x => x.RecetaId,
                        principalTable: "Recetas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Alergias_PerfilPacienteId",
                table: "Alergias",
                column: "PerfilPacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Alergias_PerfilPacienteId_Activa",
                table: "Alergias",
                columns: new[] { "PerfilPacienteId", "Activa" });

            migrationBuilder.CreateIndex(
                name: "IX_AntecedentesHeredofamiliares_CondicionMedicaId",
                table: "AntecedentesHeredofamiliares",
                column: "CondicionMedicaId");

            migrationBuilder.CreateIndex(
                name: "IX_AntecedentesHeredofamiliares_PerfilPacienteId",
                table: "AntecedentesHeredofamiliares",
                column: "PerfilPacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_AntecedentesHeredofamiliares_PerfilPacienteId_ParentescoFami~",
                table: "AntecedentesHeredofamiliares",
                columns: new[] { "PerfilPacienteId", "ParentescoFamiliar", "CondicionMedicaId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AntecedentesPersonales_CondicionMedicaId",
                table: "AntecedentesPersonales",
                column: "CondicionMedicaId");

            migrationBuilder.CreateIndex(
                name: "IX_AntecedentesPersonales_PerfilPacienteId",
                table: "AntecedentesPersonales",
                column: "PerfilPacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_AntecedentesPersonales_PerfilPacienteId_CondicionMedicaId",
                table: "AntecedentesPersonales",
                columns: new[] { "PerfilPacienteId", "CondicionMedicaId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AntecedentesPsicologicos_PerfilPacienteId",
                table: "AntecedentesPsicologicos",
                column: "PerfilPacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_ArchivosAdjuntos_ConsultaId",
                table: "ArchivosAdjuntos",
                column: "ConsultaId");

            migrationBuilder.CreateIndex(
                name: "IX_ArchivosAdjuntos_EstudioClinicoId",
                table: "ArchivosAdjuntos",
                column: "EstudioClinicoId");

            migrationBuilder.CreateIndex(
                name: "IX_ArchivosAdjuntos_PerfilPacienteId",
                table: "ArchivosAdjuntos",
                column: "PerfilPacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_ArchivosAdjuntos_RecetaId",
                table: "ArchivosAdjuntos",
                column: "RecetaId");

            migrationBuilder.CreateIndex(
                name: "IX_ArchivosAdjuntos_TipoArchivo",
                table: "ArchivosAdjuntos",
                column: "TipoArchivo");

            migrationBuilder.CreateIndex(
                name: "IX_CatalogoCondicionesMedicas_Categoria_NombreCondicion",
                table: "CatalogoCondicionesMedicas",
                columns: new[] { "Categoria", "NombreCondicion" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CodigosVerificacion_FechaExpiracion",
                table: "CodigosVerificacion",
                column: "FechaExpiracion");

            migrationBuilder.CreateIndex(
                name: "IX_CodigosVerificacion_UsuarioId",
                table: "CodigosVerificacion",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Consultas_Especialidad",
                table: "Consultas",
                column: "Especialidad");

            migrationBuilder.CreateIndex(
                name: "IX_Consultas_PerfilPacienteId_FechaConsulta",
                table: "Consultas",
                columns: new[] { "PerfilPacienteId", "FechaConsulta" },
                descending: new[] { false, true });

            migrationBuilder.CreateIndex(
                name: "IX_EstudiosClinicos_ConsultaId",
                table: "EstudiosClinicos",
                column: "ConsultaId");

            migrationBuilder.CreateIndex(
                name: "IX_EstudiosClinicos_PerfilPacienteId",
                table: "EstudiosClinicos",
                column: "PerfilPacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_EstudiosClinicos_PerfilPacienteId_TipoEstudio",
                table: "EstudiosClinicos",
                columns: new[] { "PerfilPacienteId", "TipoEstudio" });

            migrationBuilder.CreateIndex(
                name: "IX_EventosQuirurgicos_PerfilPacienteId",
                table: "EventosQuirurgicos",
                column: "PerfilPacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_EventosQuirurgicos_PerfilPacienteId_TipoEvento",
                table: "EventosQuirurgicos",
                columns: new[] { "PerfilPacienteId", "TipoEvento" });

            migrationBuilder.CreateIndex(
                name: "IX_MedicamentosReceta_Activo_FechaFin",
                table: "MedicamentosReceta",
                columns: new[] { "Activo", "FechaFin" });

            migrationBuilder.CreateIndex(
                name: "IX_MedicamentosReceta_RecetaId",
                table: "MedicamentosReceta",
                column: "RecetaId");

            migrationBuilder.CreateIndex(
                name: "IX_PerfilesPaciente_UsuarioId",
                table: "PerfilesPaciente",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_PerfilesPaciente_UsuarioId_Activo",
                table: "PerfilesPaciente",
                columns: new[] { "UsuarioId", "Activo" });

            migrationBuilder.CreateIndex(
                name: "IX_PerfilEstiloVida_PerfilPacienteId",
                table: "PerfilEstiloVida",
                column: "PerfilPacienteId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProveedoresAutenticacion_GoogleId",
                table: "ProveedoresAutenticacion",
                column: "GoogleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProveedoresAutenticacion_UsuarioId",
                table: "ProveedoresAutenticacion",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Recetas_ConsultaId",
                table: "Recetas",
                column: "ConsultaId");

            migrationBuilder.CreateIndex(
                name: "IX_Recetas_PerfilPacienteId",
                table: "Recetas",
                column: "PerfilPacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Recetas_PerfilPacienteId_Activa",
                table: "Recetas",
                columns: new[] { "PerfilPacienteId", "Activa" });

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_Token",
                table: "RefreshTokens",
                column: "Token");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_UsuarioId",
                table: "RefreshTokens",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistrosBiometricos_PerfilPacienteId_FechaRegistro",
                table: "RegistrosBiometricos",
                columns: new[] { "PerfilPacienteId", "FechaRegistro" },
                descending: new[] { false, true });

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Correo",
                table: "Usuarios",
                column: "Correo",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alergias");

            migrationBuilder.DropTable(
                name: "AntecedentesHeredofamiliares");

            migrationBuilder.DropTable(
                name: "AntecedentesPersonales");

            migrationBuilder.DropTable(
                name: "AntecedentesPsicologicos");

            migrationBuilder.DropTable(
                name: "ArchivosAdjuntos");

            migrationBuilder.DropTable(
                name: "CodigosVerificacion");

            migrationBuilder.DropTable(
                name: "EventosQuirurgicos");

            migrationBuilder.DropTable(
                name: "MedicamentosReceta");

            migrationBuilder.DropTable(
                name: "PerfilEstiloVida");

            migrationBuilder.DropTable(
                name: "ProveedoresAutenticacion");

            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DropTable(
                name: "RegistrosBiometricos");

            migrationBuilder.DropTable(
                name: "CatalogoCondicionesMedicas");

            migrationBuilder.DropTable(
                name: "EstudiosClinicos");

            migrationBuilder.DropTable(
                name: "Recetas");

            migrationBuilder.DropTable(
                name: "Consultas");

            migrationBuilder.DropTable(
                name: "PerfilesPaciente");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
