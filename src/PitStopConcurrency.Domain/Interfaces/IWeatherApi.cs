using System.Threading.Tasks;

namespace PitStopConcurrency.Domain.Interfaces
{
    /// <summary>
    /// Define métodos para obter informações de clima de uma fonte externa (API, serviço, etc.).
    /// </summary>
    public interface IWeatherApi
    {
        /// <summary>
        /// Retorna as informações do clima (temperatura, se está chovendo, etc.) para um determinado circuito.
        /// </summary>
        /// <param name="circuit">Nome ou identificador do circuito (ex.: "Interlagos", "Monza")</param>
        /// <returns>Objeto com dados de clima (temperatura, chuva, etc.).</returns>
        Task<WeatherInfo> GetCurrentWeatherAsync(string circuit);
    }

    /// <summary>
    /// DTO (ou objeto de modelo) representando as informações de clima.
    /// Pode ser mapeado depois para ValueObjects, se você preferir.
    /// </summary>
    public class WeatherInfo
    {
        public double Temperature { get; set; }
        public bool IsRaining { get; set; }
        public double WindSpeed { get; set; }
        public double Humidity { get; set; }
    }
}
