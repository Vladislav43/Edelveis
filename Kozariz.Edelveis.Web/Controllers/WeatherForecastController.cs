using Kozariz.Edelveis.
using Microsoft.AspNetCore.Mvc;
using Kozariz.Edelveis.Models.Weather;

namespace Kozariz.Edelveis.Web.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IWeatherForecastService _forecastService;

        public WeatherForecastController(IWeatherForecastService forecastService)
        {
            _forecastService = forecastService;
        }

        [HttpGet]
        [Route("Get")]
        public IEnumerable<WeatherForecast> Get()
        {
            return _forecastService.GetRandomForecast();
        }
    }
}