# SaludConecta-Backend
Lugar donde vivira la API y sus dependencias de Salud Conecta

# Salud Conecta - Backend API

API REST para la gestión centralizada de historiales clínicos familiares. Permite a un usuario administrar perfiles de salud propios y de su círculo familiar, incluyendo antecedentes médicos, consultas, recetas, estudios clínicos y evolución biométrica.

## Stack Tecnológico

- **.NET 9.0** - Framework principal
- **Entity Framework Core** - ORM para acceso a datos
- **MariaDB** - Base de datos relacional
- **JWT** - Autenticación basada en tokens
- **Google OAuth** - Inicio de sesión con Google

## Arquitectura

El proyecto sigue el patrón de **Clean Architecture** dividido en tres capas:

```
SaludConecta-Backend/
├── SaludConecta.Core/             # Entidades, enums, interfaces
├── SaludConecta.Infrastructure/   # DbContext, repositorios, servicios externos
└── SaludConecta.API/              # Controllers, DTOs, middlewares
```

**SaludConecta.Core** → El corazón del negocio. No depende de ningún otro proyecto. Contiene las entidades, enums, interfaces de repositorios y servicios, y excepciones personalizadas.

**SaludConecta.Infrastructure** → La capa de acceso a datos y servicios externos. Depende únicamente de Core. Contiene el DbContext, las configuraciones de Fluent API, las migraciones y las implementaciones de repositorios.

**SaludConecta.API** → El punto de entrada HTTP. Depende de Core e Infrastructure. Organizado por **features** (módulos funcionales), donde cada módulo agrupa su controller, DTOs y servicio.

## Módulos

| Módulo | Descripción |
|--------|-------------|
| **Auth** | Registro, login (local y Google), refresh tokens, recuperación de contraseña, verificación de teléfono |
| **Perfiles** | Gestión de perfiles de pacientes (modo personal y familiar) |
| **Biométricos** | Registro histórico de peso y estatura |
| **Antecedentes** | Antecedentes personales, heredofamiliares y psicológicos |
| **Estilo de Vida** | Hábitos de sueño, alimentación, actividad física, consumo de sustancias |
| **Alergias** | Alergias alimentarias, medicamentosas, de contacto y ambientales |
| **Eventos Quirúrgicos** | Cirugías, traumatismos, hospitalizaciones, transfusiones, inmunizaciones |
| **Consultas** | Historial cronológico de citas médicas y diagnósticos |
| **Recetas** | Recetas médicas con detalle de medicamentos, dosis y frecuencias |
| **Estudios** | Estudios clínicos (sangre, orina, radiografías, etc.) |
| **Archivos** | Archivos adjuntos vinculados a recetas, consultas y estudios |

## Base de Datos

MariaDB con 18 tablas organizadas por módulo. El esquema completo se encuentra en el archivo `database/salud_conecta_schema.sql`.

## Configuración

### Prerrequisitos

- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- [MariaDB 10.6+](https://mariadb.org/download/)

### Instalación

1. Clonar el repositorio:
```bash
git clone https://github.com/tu-usuario/SaludConecta-Backend.git
cd SaludConecta-Backend
```

2. Crear el archivo de configuración local:
```bash
cp SaludConecta.API/appsettings.json SaludConecta.API/appsettings.Development.json
```

3. Editar `appsettings.Development.json` con tus datos:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=salud_conecta;User=tu_usuario;Password=tu_contraseña;"
  },
  "JwtSettings": {
    "SecretKey": "tu_secret_key_minimo_32_caracteres",
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

4. Crear la base de datos ejecutando el script SQL en MariaDB:
```bash
mysql -u tu_usuario -p < database/salud_conecta_schema.sql
```

5. Compilar y ejecutar:
```bash
dotnet build
dotnet run --project SaludConecta.API
```

## 📁 Estructura de Features

Cada módulo sigue la misma organización interna:

```
Features/
└── Consultas/
    ├── ConsultasController.cs      # Endpoints HTTP
    ├── CrearConsultaRequest.cs      # DTO de entrada
    ├── ConsultaResponse.cs          # DTO de salida
    └── ConsultasService.cs          # Lógica de negocio
```

## Proyecto Relacionado

- [SaludConecta-Frontend](https://github.com/Dany1912-dev/SaludConecta-Frontend) - Interfaz web con React + Vite

## Licencia

Este proyecto es de uso personal y educativo.