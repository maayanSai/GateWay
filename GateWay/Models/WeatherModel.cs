
using GateWay.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;


namespace GateWay.Models
{
    public class WeatherResponse
    {
        public Main Main { get; set; }
        public string Name { get; set; }
    }

    public class Main
    {
        public double Temp { get; set; }
        public int Pressure { get; set; }
        public int Humidity { get; set;}
    }

    public class WeatherModel
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey = "a88ab57cba89c967eba5e3d1ed13142c"; // Replace with your OpenWeatherMap API key
        private readonly string _weatherApiUrl = "https://api.openweathermap.org/data/2.5/weather";

        public WeatherModel()
        {
            _httpClient = new HttpClient();
        }

        public async Task<WeatherResponse> GetWeatherForCity(string cityName)
        {
            try
            {
                string apiUrl = $"{_weatherApiUrl}?q={cityName}&appid={_apiKey}";

                var response = await _httpClient.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var weatherResponse = JsonConvert.DeserializeObject<WeatherResponse>(content);
                    return weatherResponse;
                }

                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

