using Microsoft.EntityFrameworkCore;
using GameCollectionPlayApi.Data;

var builder = WebApplication.CreateBuilder(args);

// Pegar a connection string do appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Adiciona CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost", policy =>
    {
        policy.WithOrigins("http://localhost:8080") // frontend
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Adicionar serviços
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.WriteIndented = true; // opcional, para JSON bonito
    });


// Adicionar DbContext para integração com banco de dados MySQL
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
);

// Adiciona Swagger 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Usa CORS
app.UseCors("AllowLocalhost");

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
