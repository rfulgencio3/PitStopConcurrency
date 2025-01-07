using PitStopConcurrency.Domain.Interfaces;
using PitStopConcurrency.Application.Queries;
using PitStopConcurrency.Application.Models;

namespace PitStopConcurrency.Application.Handlers;

public class GetCarStatusQueryHandler
{
    private readonly ICarRepository _carRepository;

    public GetCarStatusQueryHandler(ICarRepository carRepository)
    {
        _carRepository = carRepository;
    }

    public async Task<CarDto> Handle(GetCarStatusQuery query)
    {
        // 1. Obter o carro do repositório
        var car = await _carRepository.GetByIdAsync(query.CarId);

        if (car == null)
        {
            throw new InvalidOperationException($"Car with Id {query.CarId} not found.");
        }

        // 2. Mapear entidade Car -> CarDto
        var dto = new CarDto
        {
            Id = car.Id,
            Name = car.Name,
            TireWearPercentage = car.TireWear.Percentage,
            FuelLevelLiters = car.FuelLevel.Liters,
            IsInPit = car.IsInPit,
            CurrentLap = car.CurrentLap,
            TotalLaps = car.TotalLaps
        };

        return dto;
    }
}
