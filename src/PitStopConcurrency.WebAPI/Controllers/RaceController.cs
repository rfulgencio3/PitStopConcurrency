using Microsoft.AspNetCore.Mvc;
using PitStopConcurrency.Application.Services;

namespace PitStopConcurrency.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RaceController : ControllerBase
{
    private readonly RaceApplicationService _raceAppService;

    public RaceController(RaceApplicationService raceAppService)
    {
        _raceAppService = raceAppService;
    }

    /// <summary>
    /// Retorna dados de uma corrida (carros, status, etc.).
    /// GET: /api/race/{raceId}
    /// </summary>
    [HttpGet("{raceId}")]
    public async Task<IActionResult> GetRace(Guid raceId)
    {
        try
        {
            var raceDto = await _raceAppService.GetRaceAsync(raceId);
            return Ok(raceDto);
        }
        catch (InvalidOperationException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Processa o status atual da corrida, por ex. checando clima e decidindo pitstops.
    /// POST: /api/race/{raceId}/process-status
    /// </summary>
    [HttpPost("{raceId}/process-status")]
    public async Task<IActionResult> ProcessRaceStatus(Guid raceId)
    {
        await _raceAppService.ProcessRaceStatusAsync(raceId);
        return NoContent();
    }
}
