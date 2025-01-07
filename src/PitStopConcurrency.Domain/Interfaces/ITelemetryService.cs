using System;
using System.Threading.Tasks;

namespace PitStopConcurrency.Domain.Interfaces
{
    /// <summary>
    /// Define métodos para obter dados de telemetria de um carro, provenientes de sensores ou APIs externas.
    /// </summary>
    public interface ITelemetryService
    {
        /// <summary>
        /// Retorna os dados de telemetria de um determinado carro (ex.: desgaste de pneus em tempo real, temperatura, etc.).
        /// </summary>
        Task<TelemetryData> GetCarTelemetryAsync(Guid carId);
    }

    /// <summary>
    /// DTO que representa as informações de telemetria obtidas do carro.
    /// </summary>
    public class TelemetryData
    {
        public Guid CarId { get; set; }
        public int TireWearPercentage { get; set; }
        public int FuelLevelLiters { get; set; }
        public double EngineTemperature { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
