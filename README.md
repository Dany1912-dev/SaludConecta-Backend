# SaludConecta — Backend

[![.NET](https://img.shields.io/badge/.NET-9.0-512BD4?logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![MariaDB](https://img.shields.io/badge/MariaDB-10.6+-003545?logo=mariadb&logoColor=white)](https://mariadb.org/)
[![EF Core](https://img.shields.io/badge/EF_Core-9-512BD4?logo=dotnet&logoColor=white)](https://learn.microsoft.com/ef/)
[![Estado](https://img.shields.io/badge/estado-en_desarrollo-yellow)]()

> Repositorio del frontend: [SaludConecta-Frontend](https://github.com/Dany1912-dev/SaludConecta-Frontend)

---

## La idea

La información médica personal vive fragmentada: recetas en cajones, resultados de laboratorio en fotos del celular, el nombre del especialista anotado en alguna hoja perdida. En una emergencia, nadie recuerda qué medicamentos toma, qué alergias tiene ni cuándo fue la última consulta.

**SaludConecta** es una cartilla médica digital personal. Permite registrar y centralizar todo el historial clínico propio y el de la familia en un solo lugar, accesible desde cualquier dispositivo. En caso de urgencia, se puede generar un resumen o descarga del historial completo en segundos.

**Lo que se quiere lograr (visión completa):**
- Registrar consultas médicas, diagnósticos y médicos tratantes
- Guardar resultados de estudios clínicos (sangre, orina, radiografías, etc.)
- Llevar un historial de recetas y medicamentos con dosis y frecuencias
- Registrar antecedentes personales, heredofamiliares y alergias
- Seguimiento biométrico (peso, estatura, signos vitales)
- Calendario de citas y recordatorios
- Gestión de perfiles familiares desde una sola cuenta
- Exportar un resumen clínico del último año o del historial completo

---

## Estado actual

El proyecto está en sus primeras fases. El dominio está modelado y la autenticación está implementada. Los módulos del historial clínico están definidos en entidades y configuraciones, pero sus endpoints aún no existen.

| Capa | Estado |
|------|--------|
| Modelo de dominio (entidades + enums) | ✅ Completo |
| Esquema de base de datos | ✅ Completo |
| Autenticación (JWT + cookies + refresh) | ✅ Completo |
| Verificación de correo / teléfono | 🔧 Parcial |
| Google OAuth | ⏳ Pendiente |
| Módulos del historial clínico | ⏳ Pendiente |
| Exportación de historial | ⏳ Pendiente |

---

## Arquitectura

Clean Architecture en tres capas. Las dependencias apuntan siempre hacia el centro:

```
SaludConecta-Backend/
├── SaludConecta.Core/              # Entidades, enums, interfaces, excepciones
├── SaludConecta.Infrastructure/    # DbContext, repositorios, configuraciones EF
└── SaludConecta.API/               # Controllers, servicios, middlewares (por features)
```

**Core** — el corazón del negocio. Sin dependencias externas. Contiene todas las entidades del dominio, los enums, las interfaces de repositorios y los contratos de servicios.

**Infrastructure** — la capa de datos. Solo depende de Core. Contiene el DbContext, las configuraciones Fluent API por entidad, y las implementaciones de repositorios.

**API** — el punto de entrada HTTP. Organizado por **features**: cada módulo funcional agrupa su controller, DTOs y servicio en una sola carpeta.

```
Features/
└── NombreModulo/
    ├── NombreController.cs      # Endpoints
    ├── CrearRequest.cs          # DTO de entrada
    ├── NombreResponse.cs        # DTO de salida
    └── NombreService.cs         # Lógica de negocio
```

---

## Dominio

Las entidades del sistema cubren el historial clínico completo de un paciente:

| Entidad | Qué representa |
|---------|----------------|
| `Usuario` | Cuenta de acceso con soporte para login local y OAuth |
| `PerfilPaciente` | Datos clínicos base: tipo de sangre, sexo, fecha de nacimiento |
| `RegistroBiometrico` | Evolución de peso y estatura a lo largo del tiempo |
| `PerfilEstiloVida` | Hábitos de sueño, alimentación, actividad física, consumo de sustancias |
| `Alergia` | Alergias con tipo, severidad y sustancia causante |
| `AntecedentePersonal` | Condiciones médicas previas del paciente |
| `AntecedenteHeredofamiliar` | Historial médico de familiares directos |
| `AntecedentePsicologico` | Antecedentes de salud mental |
| `EventoQuirurgico` | Cirugías, hospitalizaciones, traumatismos, transfusiones, vacunas |
| `Consulta` | Citas médicas con diagnóstico, médico tratante y especialidad |
| `Receta` | Recetas médicas vinculadas a una consulta |
| `MedicamentoReceta` | Detalle de cada medicamento: dosis, frecuencia, vía de administración |
| `EstudioClinico` | Estudios de laboratorio e imagen vinculados a consultas |
| `ArchivoAdjunto` | Archivos PDF o imagen vinculados a recetas, consultas o estudios |
| `CatalogoCondicionMedica` | Catálogo de condiciones médicas para estandarizar diagnósticos |
| `RefreshToken` | Tokens de refresco para rotación de sesión |
| `CodigoVerificacion` | Códigos temporales para verificación de correo y teléfono |
| `ProveedorAutenticacion` | Proveedores OAuth vinculados al usuario (Google, etc.) |

---

## Autenticación

JWT almacenado en **cookies HttpOnly** — el token nunca es accesible desde JavaScript:

```
Access token   → 30 minutos  → cookie HttpOnly, Secure, SameSite=Lax
Refresh token  → 7 días      → cookie HttpOnly
```

Cuando el access token expira, el frontend intercepta el `401` y llama a `/api/auth/refresh` de forma transparente. Si el refresh también falla, se despacha el evento `sc:sesion-expirada` para limpiar la sesión en el cliente.

---

## Configuración

**Prerrequisitos:**
- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- MariaDB 10.6+

**Instalación:**

```bash
git clone https://github.com/Dany1912-dev/SaludConecta-Backend.git
cd SaludConecta-Backend
```

Crea `SaludConecta.API/appsettings.Development.json` con tus datos:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=salud_conecta;User=tu_usuario;Password=tu_contraseña;"
  },
  "JwtSettings": {
    "SecretKey": "clave-secreta-minimo-32-caracteres",
    "Issuer": "SaludConecta",
    "Audience": "SaludConecta",
    "AccessTokenExpirationMinutes": 30,
    "RefreshTokenExpirationDays": 7
  },
  "GoogleAuth": {
    "ClientId": "tu_client_id",
    "ClientSecret": "tu_client_secret"
  }
}
```

```bash
dotnet build
dotnet run --project SaludConecta.API
```

---

## Tecnologías

| | |
|--|--|
| Framework | .NET 9, ASP.NET Core Web API |
| ORM | Entity Framework Core 9 |
| Base de datos | MariaDB 10.6+ |
| Autenticación | JWT (cookies HttpOnly) + Google OAuth |
| Arquitectura | Clean Architecture (Core / Infrastructure / API) |
