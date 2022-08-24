using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WeatherDetailsApi.DataModel;
using WeatherDetailsApi.Interfaces;

namespace WeatherDetailsApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IWeatherAPI _weatherApi;
        private readonly IMapper _mapper;

        public WeatherForecastController(IMapper mapper, ILogger<WeatherForecastController> logger, IWeatherAPI weatherApi)
        {
            _logger = logger;
            _weatherApi = weatherApi;
            _mapper = mapper;
        }
        /*
         * we can create custom response class which can be returned by all APIs
         * the same response then can be hared by exception handler middlewear
         * 
         */

        [HttpGet("getweatherforecastbycity/{cityName}")]
        public async Task<CityWeatherDetails> GetWeatherForecastByCity(string cityName)
        {
            var res = await _weatherApi.GetCurrentWeatherDetails(cityName);
            return _mapper.Map<CityWeatherDetails>(res);
        }
    }
}