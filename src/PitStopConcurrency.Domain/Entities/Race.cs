namespace PitStopConcurrency.Domain.Entities;

public class Race
{
    public Guid Id { get; private set; }
    public string Circuit { get; private set; }
    public DateTime StartTime { get; private set; }
    public DateTime? EndTime { get; private set; }
    public List<Car> Cars { get; private set; }

    public Race(Guid id, string circuit, DateTime startTime)
    {
        Id = id;
        Circuit = circuit;
        StartTime = startTime;
        Cars = new List<Car>();
    }

    public void AddCar(Car car)
    {
        Cars.Add(car);
    }

    public void EndRace()
    {
        EndTime = DateTime.UtcNow;
    }
}
