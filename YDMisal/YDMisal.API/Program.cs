using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using YDMisal.API.Data;
using YDMisal.API.Repository;

// Entry point of the application — sets up all services and the request pipeline
var builder = WebApplication.CreateBuilder(args);

// Register the MVC controllers so the app can handle HTTP requests
builder.Services.AddControllers();

// Register FluentValidation — automatically validates request bodies before they reach controllers
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<Program>();

// Enable Swagger for API documentation and testing (available at /swagger in development)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    // Use full type names to avoid Swagger schema conflicts between DTOs and domain models
    options.CustomSchemaIds(type => type.FullName);
});

// Register the database context with the SQL Server connection string from appsettings.json
builder.Services.AddDbContext<NZWalksDbContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("NZWalks"));
});

// Register repositories — allows controllers to receive them via dependency injection
builder.Services.AddScoped<IRegionRepository, RegionRepository>();
builder.Services.AddScoped<IWalkRepository, WalkRepository>();
builder.Services.AddScoped<IWalkDifficultyRepository, WalkDifficultyRepository>();

// Register AutoMapper — scans all profiles in this assembly to set up object mappings
builder.Services.AddAutoMapper(typeof(Program).Assembly);

var app = builder.Build();

// Only enable Swagger in the development environment
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Redirect all HTTP requests to HTTPS for security
app.UseHttpsRedirection();

// Enable authorization middleware (no auth scheme configured yet)
app.UseAuthorization();

// Map incoming HTTP requests to the correct controller actions
app.MapControllers();

// Start the web server
app.Run();