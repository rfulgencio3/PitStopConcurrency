using Microsoft.EntityFrameworkCore;
using PitStopConcurrency.Application.Handlers;
using PitStopConcurrency.Domain.Interfaces;
using PitStopConcurrency.Infrastructure.Persistence;
using PitStopConcurrency.Infrastructure.Repositories;
using PitStopConcurrency.WebAPI.Middlewares;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

// DbContext InMemory Database
builder.Services.AddDbContext<PitStopDbContext>(options =>
    options.UseInMemoryDatabase("PitStopDatabase"));

// Repositories
builder.Services.AddScoped<ICarRepository, CarRepository>();
builder.Services.AddScoped<IRaceRepository, RaceRepository>();

// Services
builder.Services.AddScoped<GetCarStatusQueryHandler>();
builder.Services.AddScoped<SchedulePitStopCommandHandler>();

// Externals
// builder.Services.AddHttpClient<IWeatherApi, WeatherApiService>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseMiddleware<ErrorHandlingMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.Run();
