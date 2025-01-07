namespace PitStopConcurrency.Application.Models;

public class RaceDto
{
    public Guid Id { get; set; }
    public string Circuit { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime? EndTime { get; set; }

    public List<CarDto> Cars { get; set; } = new List<CarDto>();
}
