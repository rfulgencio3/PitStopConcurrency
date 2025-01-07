using PitStopConcurrency.Domain.Interfaces;
using PitStopConcurrency.Domain.Services;
using PitStopConcurrency.Application.Commands;
using PitStopConcurrency.Domain.Events;

namespace PitStopConcurrency.Application.Handlers;

public class SchedulePitStopCommandHandler
{
    private readonly ICarRepository _carRepository;

    public SchedulePitStopCommandHandler(ICarRepository carRepository)
    {
        _carRepository = carRepository;
    }

    public async Task Handle(SchedulePitStopCommand command)
    {
        // 1. Obter o carro do repositório
        var car = await _carRepository.GetByIdAsync(command.CarId);
        if (car == null)
        {
            throw new InvalidOperationException($"Car with Id {command.CarId} not found.");
        }

        // 2. Verificar se deve forçar o pitstop ou se a lógica de domínio recomenda
        var recommended = PitStopCalculationService.ShouldPitStop(car, /* weather unknown here */ default);

        // Se "ForcePitStop" for true ou se o recommended for true, agendamos
        if (command.ForcePitStop || recommended)
        {
            // Exemplo simples: o carro entra no pit
            car.EnterPit();

            // Reabastecer e trocar pneus no pit
            // (Isso poderia ser feito em outro local, mas servindo de ilustração)
            car.ChangeTires();
            car.Refuel(50);

            // Se quisermos disparar um evento de domínio
            var pitStopEvent = new PitStopScheduledEvent(car.Id, DateTime.UtcNow);
            // Poderíamos colocar esse evento em uma lista interna ou enviar para um "EventBus"

            // 3. Atualizar o carro
            await _carRepository.UpdateAsync(car);
        }
    }
}
