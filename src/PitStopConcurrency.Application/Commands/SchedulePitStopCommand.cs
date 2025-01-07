namespace PitStopConcurrency.Application.Commands;

public class SchedulePitStopCommand
{
    public Guid CarId { get; }
    public bool ForcePitStop { get; }

    public SchedulePitStopCommand(Guid carId, bool forcePitStop)
    {
        CarId = carId;
        ForcePitStop = forcePitStop;
    }
}
