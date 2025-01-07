namespace PitStopConcurrency.Application.Models;

public class CarDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int TireWearPercentage { get; set; }
    public int FuelLevelLiters { get; set; }
    public bool IsInPit { get; set; }
    public int CurrentLap { get; set; }
    public int TotalLaps { get; set; }
}
