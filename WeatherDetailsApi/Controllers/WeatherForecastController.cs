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
        
        /// <summary>
        /// display current weather details of specific city
        /// </summary>
        /// <param name="cityName"></param>
        /// <returns></returns>

        [HttpGet("getweatherforecastbycity/{cityName}")]
        public async Task<CityWeatherDetails> GetWeatherForecastByCity(string cityName)
        {
            var res = await _weatherApi.GetCurrentWeatherDetails(cityName);
            return _mapper.Map<CityWeatherDetails>(res);
        }
    }
}