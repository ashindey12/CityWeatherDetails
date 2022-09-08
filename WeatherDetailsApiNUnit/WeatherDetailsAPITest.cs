
using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using WeatherDetailsApi.Controllers;
using WeatherDetailsApi.DataModel;
using WeatherDetailsApi.Interfaces;
using WeatherDetailsApi.Services;

namespace WeatherDetailsApiNUnit
{
    [TestFixture]
    public class Tests
    {
        
        Mock<IWeatherAPI> _mockWeatherApiService = new Mock<IWeatherAPI>(MockBehavior.Strict);
        [SetUp]
        public void Setup()
        {
            
            //moq all the services injected to this service class to instantiate the object
        }

        //write nunit test cases covering all edge cases scenario and null exception or response cases
        //write test case to validate Http get or post call
        
        [TestCase("London")]
        public async Task MockWeatherApi_ReturnExpectedResult(string cityName)
        {
            WeatherDetailsDTO expectedResult = new  WeatherDetailsDTO
            {
                Location = new LocationDto
                {
                    Name = cityName,
                    Country = "United Kingdom"
                },
                Current = new CurrentDto
                {
                    Temp_c = 20,
                    Temp_f = 95,
                    Condition = new ConditionDto
                    {
                        Text = "Partly Sunny"
                    }

                }
            };
            CityWeatherDetails cityWeatherDetail = new CityWeatherDetails
            {
                Localtime = "",
                Temp_c = 20,
                Weather = "Partly Sunny"

            };
            _mockWeatherApiService.Setup(p => p.GetCurrentWeatherDetails(cityName)).Returns(Task.FromResult(expectedResult));
            var _loggerMock = new Mock<ILogger<WeatherForecastController>>();

            var mapperMock = new Mock<IMapper>();
           // mapperMock.Setup(m => m.Map<WeatherDetailsDTO,CityWeatherDetails>(expectedResult)).Returns(cityWeatherDetail);

            WeatherForecastController _weatherForecastController = new WeatherForecastController(mapperMock.Object, _loggerMock.Object, _mockWeatherApiService.Object);
            var result = await _weatherForecastController.GetWeatherForecastByCity(cityName);
            Assert.That(result.Weather, Is.EqualTo(expectedResult.Current.Condition.Text));
            _mockWeatherApiService.VerifyAll();
        }
        
    }
}