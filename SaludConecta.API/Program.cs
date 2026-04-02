using Microsoft.EntityFrameworkCore;
using SaludConecta.API.Extensions;
using SaludConecta.API.Middlewares;
using SaludConecta.Infrastructure.Data.Context;

var builder = WebApplication.CreateBuilder(args);

// DbContext con MariaDB
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<SaludConectaDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// Repositorios y servicios
builder.Services.AddRepositorios();
builder.Services.AddServicios();

// JWT con cookies
builder.Services.AddAutenticacionJwt(builder.Configuration);

// CORS para que el frontend pueda enviar/recibir cookies
builder.Services.AddCors(options =>
{
    options.AddPolicy("FrontendLocal", policy =>
    {
        policy.WithOrigins("http://localhost:5173")
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();
    });
});

// Controllers
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Middleware de excepciones (debe ir primero)
app.UseMiddleware<ExceptionMiddleware>();

// Swagger solo en desarrollo
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("FrontendLocal");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();