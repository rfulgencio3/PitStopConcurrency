namespace PitStopConcurrency.Application.Queries;

public class GetCarStatusQuery
{
    public Guid CarId { get; }

    public GetCarStatusQuery(Guid carId)
    {
        CarId = carId;
    }
}
