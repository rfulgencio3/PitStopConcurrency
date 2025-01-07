using PitStopConcurrency.Domain.Entities;
using PitStopConcurrency.Domain.ValueObjects;

namespace PitStopConcurrency.Domain.Services;

public static class PitStopCalculationService
{
    /// <summary>
    /// Determina se o carro deve parar no pitstop, baseado em condições de pneus, combustível e clima.
    /// </summary>
    /// <param name="car">Carro atual</param>
    /// <param name="weather">Condições climáticas</param>
    /// <returns>Retorna verdadeiro se o pitstop for recomendado</returns>
    public static bool ShouldPitStop(Car car, WeatherCondition weather)
    {
        // Lógica simplificada:
        // - Se desgaste de pneus for alto ou combustível baixo, recomendamos parar
        // - Se estiver chovendo e os pneus não são adequados para chuva, recomendamos parar

        if (car.TireWear.IsWornOut)
        {
            return true;
        }

        if (car.FuelLevel.IsEmpty || car.FuelLevel.Liters < 10)
        {
            return true;
        }

        if (weather.IsRaining && car.TireWear.Percentage > 50)
        {
            // Se está chovendo e o desgaste já está em 50%, pitstop pode ser boa ideia
            return true;
        }

        return false;
    }

    /// <summary>
    /// Calcula a estratégia recomendada de pitstop (quantos litros abastecer, trocar pneu, etc.).
    /// </summary>
    public static (bool changeTires, int refuelAmount) CalculatePitStopActions(Car car, WeatherCondition weather)
    {
        bool changeTires = false;
        int refuelAmount = 0;

        // Exemplo de lógica simples
        if (car.TireWear.Percentage > 70 || weather.IsRaining)
            changeTires = true;

        if (car.FuelLevel.Liters < 30)
            refuelAmount = 50; // abastece 50 litros

        return (changeTires, refuelAmount);
    }
}
