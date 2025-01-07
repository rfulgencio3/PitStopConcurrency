namespace PitStopConcurrency.Domain.ValueObjects;

public struct FuelLevel
{
    // Nível de combustível em litros (exemplo) de 0 a 100
    public int Liters { get; private set; }

    private FuelLevel(int liters)
    {
        Liters = liters < 0 ? 0 : (liters > 100 ? 100 : liters);
    }

    public static FuelLevel Full() => new FuelLevel(100);

    public FuelLevel Consume(int amount)
    {
        return new FuelLevel(Liters - amount);
    }

    public FuelLevel Add(int amount)
    {
        return new FuelLevel(Liters + amount);
    }

    public bool IsEmpty => Liters <= 0;
}
