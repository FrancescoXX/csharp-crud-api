using Data;
using LocationService.Data;
using LocationService.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var configuration = builder.Configuration;

// Add configuration for UserContext
builder.Services.AddDbContext<UserContext>(options =>
    options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

// Add configuration for Entity Framework Core and PostgreSQL
builder.Services.AddDbContext<LocationDbContext>(options =>
    options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ILocationRepository, DbLocationRepository>();

// Build the application
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Only use HTTPS redirection if the configuration setting is true
if (configuration.GetValue<bool>("UseHttpsRedirection", false))
{
    app.UseHttpsRedirection();
}

// If you're using authentication, add it before authorization:
// app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
