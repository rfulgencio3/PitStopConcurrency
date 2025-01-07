using PitStopConcurrency.Domain.Interfaces;
using PitStopConcurrency.Domain.Services;
using PitStopConcurrency.Application.Models;
using PitStopConcurrency.Domain.Entities;
using PitStopConcurrency.Domain.ValueObjects;

namespace PitStopConcurrency.Application.Services;

public class RaceApplicationService
{
    private readonly IRaceRepository _raceRepository;
    private readonly ICarRepository _carRepository;
    private readonly IWeatherApi _weatherApi;

    public RaceApplicationService(
        IRaceRepository raceRepository,
        ICarRepository carRepository,
        IWeatherApi weatherApi)
    {
        _raceRepository = raceRepository;
        _carRepository = carRepository;
        _weatherApi = weatherApi;
    }

    /// <summary>
    /// Exemplo de método para processar a situação de todos os carros em uma corrida,
    /// calculando se precisam de pitstop com base no clima (assíncrono + paralelo).
    /// </summary>
    public async Task ProcessRaceStatusAsync(Guid raceId)
    {
        var race = await _raceRepository.GetByIdAsync(raceId);
        if (race == null)
            throw new InvalidOperationException("Race not found");

        // Obter clima atual (chamada assíncrona a API externa)
        var weatherDto = await _weatherApi.GetCurrentWeatherAsync(race.Circuit);
        var weatherCondition = new WeatherCondition(weatherDto.Temperature, weatherDto.IsRaining);

        // Poderíamos processar todos os carros em paralelo, usando PLINQ ou Parallel.ForEach
        // (Exemplo usando Parallel.ForEach)
        Parallel.ForEach(race.Cars, car =>
        {
            var shouldPitStop = PitStopCalculationService.ShouldPitStop(car, weatherCondition);
            if (shouldPitStop)
            {
                car.EnterPit();
                car.ChangeTires();
                car.Refuel(50);
            }
        });

        // Salvar as mudanças dos carros
        // (idealmente cada carro seria atualizado no repositório, mas
        // aqui é um exemplo simples)
        foreach (var car in race.Cars)
        {
            await _carRepository.UpdateAsync(car);
        }
    }

    /// <summary>
    /// Retorna dados básicos da corrida e dos carros (RaceDto).
    /// </summary>
    public async Task<RaceDto> GetRaceAsync(Guid raceId)
    {
        var race = await _raceRepository.GetByIdAsync(raceId);
        if (race == null)
            throw new InvalidOperationException($"Race with Id {raceId} not found.");

        // TODO: Criar Builder ToDomain/FromDomain
        var raceDto = new RaceDto
        {
            Id = race.Id,
            Circuit = race.Circuit,
            StartTime = race.StartTime,
            EndTime = race.EndTime,
            Cars = race.Cars.Select(car => new CarDto
            {
                Id = car.Id,
                Name = car.Name,
                TireWearPercentage = car.TireWear.Percentage,
                FuelLevelLiters = car.FuelLevel.Liters,
                IsInPit = car.IsInPit,
                CurrentLap = car.CurrentLap,
                TotalLaps = car.TotalLaps
            }).ToList()
        };

        return raceDto;
    }
}
