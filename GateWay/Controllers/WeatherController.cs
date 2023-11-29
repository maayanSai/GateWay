using Microsoft.AspNetCore.Mvc;
using GateWay.Models;
using Newtonsoft.Json;

namespace GateWay.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly WeatherModel _weatherModel;

        public WeatherController()
        {
            _weatherModel = new WeatherModel();
        }

        [HttpGet("{cityName}")]
        public async Task<IActionResult> GetWeather(string cityName)
        {
            try
            {
                Root weatherResponse = _weatherModel.Checkweather(cityName);

                if (weatherResponse != null)
                {
                    return Ok(weatherResponse);
                }
                else
                {
                    return StatusCode(500, "Failed to retrieve weather data.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}