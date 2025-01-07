namespace PitStopConcurrency.Domain.ValueObjects;

public struct WeatherCondition
{
    public double Temperature { get; private set; }
    public bool IsRaining { get; private set; }

    public WeatherCondition(double temperature, bool isRaining)
    {
        Temperature = temperature;
        IsRaining = isRaining;
    }

    // Poderíamos ter métodos ou propriedades extras para dizer se é “chuva forte”, “muito calor”, etc.
}
