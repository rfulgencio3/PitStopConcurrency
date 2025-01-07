using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PitStopConcurrency.Infrastructure.ExternalServices;

public class WeatherApiService : IWeatherApi
{
	private readonly HttpClient _httpClient;

	public WeatherApiService(HttpClient httpClient)
	{
		_httpClient = httpClient;
	}

	public async Task<WeatherDto> GetCurrentWeatherAsync(string circuit)
	{
		// Monta URL, faz request
		var response = await _httpClient.GetAsync($"https://api.weather.com/{circuit}");
		response.EnsureSuccessStatusCode();

		var content = await response.Content.ReadAsStringAsync();
		// Desserializar JSON para WeatherDto (por ex., com Newtonsoft ou System.Text.Json)

		return /* objeto WeatherDto desserializado */;
	}
}