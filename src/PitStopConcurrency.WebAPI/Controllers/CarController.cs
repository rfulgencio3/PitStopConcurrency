using Microsoft.AspNetCore.Mvc;
using PitStopConcurrency.Application.Commands;
using PitStopConcurrency.Application.Handlers;
using PitStopConcurrency.Application.Queries;

namespace PitStopConcurrency.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CarController : ControllerBase
{
    private readonly GetCarStatusQueryHandler _getCarStatusHandler;
    private readonly SchedulePitStopCommandHandler _schedulePitStopHandler;

    public CarController(
        GetCarStatusQueryHandler getCarStatusHandler,
        SchedulePitStopCommandHandler schedulePitStopHandler)
    {
        _getCarStatusHandler = getCarStatusHandler;
        _schedulePitStopHandler = schedulePitStopHandler;
    }

    /// <summary>
    /// Retorna o status de um carro específico (pneus, combustível, volta atual etc.).
    /// GET: /api/car/{carId}
    /// </summary>
    [HttpGet("{carId}")]
    public async Task<IActionResult> GetCarStatus(Guid carId)
    {
        var query = new GetCarStatusQuery(carId);
        var carDto = await _getCarStatusHandler.Handle(query);

        if (carDto == null)
        {
            return NotFound();
        }

        return Ok(carDto);
    }

    /// <summary>
    /// Agenda (ou força) um pitstop para o carro especificado.
    /// POST: /api/car/{carId}/pitstop?forcePitStop=true/false
    /// </summary>
    [HttpPost("{carId}/pitstop")]
    public async Task<IActionResult> SchedulePitStop(Guid carId, bool forcePitStop = false)
    {
        var command = new SchedulePitStopCommand(carId, forcePitStop);
        await _schedulePitStopHandler.Handle(command);
        return NoContent();
    }
}
