using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WeatherDashboard.Services;

namespace WeatherDashboard.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherController : ControllerBase
    {
        private readonly IWeatherService _weatherService;
        private readonly ILogger<WeatherController> _logger;

        public WeatherController(IWeatherService weatherService, ILogger<WeatherController> logger)
        {
            _weatherService = weatherService;
            _logger = logger;
        }

        [HttpGet("{city}")]
        public async Task<IActionResult> GetCurrentWeather(string city)
        {
            try
            {
                _logger.LogInformation($"Fetching weather data for {city}");
                var weatherData = await _weatherService.GetCurrentWeatherAsync(city);
                return Ok(weatherData);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error fetching weather for {city}");
                return StatusCode(500, "An error occurred while fetching weather data");
            }
        }
    }
}