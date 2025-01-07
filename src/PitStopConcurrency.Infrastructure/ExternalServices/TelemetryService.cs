using PitStopConcurrency.Domain.Interfaces;
using System.Text.Json;

namespace PitStopConcurrency.Infrastructure.ExternalServices;

public class TelemetryService : ITelemetryService
{
    private readonly HttpClient _httpClient;

    public TelemetryService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    /// <summary>
    /// Exemplo de implementação que chama uma API externa (ex.: "http://telemetry.api/cars/{carId}/telemetry")
    /// para obter dados em tempo real de telemetria.
    /// OBS: Essa API não existe, é utilizado apenas para simular uma chamada
    /// </summary>
    public async Task<TelemetryData> GetCarTelemetryAsync(Guid carId)
    {
        // Retorno de dado 'simulado' de API externa
        await Task.Delay(500);

        var random = new Random();
        var telemetry = new TelemetryData
        {
            CarId = carId,
            TireWearPercentage = random.Next(0, 100),
            FuelLevelLiters = random.Next(0, 100),
            EngineTemperature = 90 + random.NextDouble() * 10, 
            Timestamp = DateTime.UtcNow
        };
        #region Exemplo de Chamada de api Externa
        //var url = $"http://telemetry.api/cars/{carId}/telemetry";
        //var response = await _httpClient.GetAsync(url);
        //response.EnsureSuccessStatusCode();

        //var json = await response.Content.ReadAsStringAsync();

        //var telemetry = JsonSerializer.Deserialize<TelemetryData>(json,
        //    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        //if (telemetry == null)
        //{
        //    throw new InvalidOperationException("Failed to get telemetry data from external API.");
        //}
        #endregion
        
        return telemetry;
    }
}
