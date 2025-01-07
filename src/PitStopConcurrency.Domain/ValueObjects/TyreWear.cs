namespace PitStopConcurrency.Domain.ValueObjects;

public struct TireWear
{
    // Desgaste entre 0 e 100 (0 = novo, 100 = completamente desgastado)
    public int Percentage { get; private set; }

    private TireWear(int percentage)
    {
        Percentage = percentage < 0 ? 0 : (percentage > 100 ? 100 : percentage);
    }

    public static TireWear Initial() => new TireWear(0);

    public TireWear IncreaseWear(int amount)
    {
        return new TireWear(Percentage + amount);
    }

    public TireWear Reset()
    {
        return new TireWear(0);
    }

    public bool IsWornOut => Percentage >= 90;
}
