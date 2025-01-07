namespace PitStopConcurrency.Domain.Events;

public class PitStopScheduledEvent
{
    public Guid CarId { get; }
    public DateTime ScheduledTime { get; }

    public PitStopScheduledEvent(Guid carId, DateTime scheduledTime)
    {
        CarId = carId;
        ScheduledTime = scheduledTime;
    }
}
