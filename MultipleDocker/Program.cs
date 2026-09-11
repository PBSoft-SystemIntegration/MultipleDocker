using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();

// Dokumentation er tilgængelig i dette undervisningseksempel, også i Docker.
app.MapOpenApi();
app.MapScalarApiReference();
app.MapControllers();
app.Run();
