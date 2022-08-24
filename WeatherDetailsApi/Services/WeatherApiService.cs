using AutoMapper;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using WeatherDetailsApi.DataModel;
using WeatherDetailsApi.Interfaces;

namespace WeatherDetailsApi.Services
{
    public class WeatherApiService : IWeatherAPI
    {
        private readonly IConfiguration _config;
        private readonly WeatherApiConstant _apiConstants;
        private readonly ILogger<WeatherApiService> _logger;
        private readonly IMapper _mapper;
        private readonly HttpClient _httpClient;

        public WeatherApiService(HttpClient httpClient, IMapper mapper, IConfiguration config, IOptions<WeatherApiConstant> options, ILogger<WeatherApiService> logger)
        {
            _config = config;
            _apiConstants = options.Value;
            _logger = logger; 
            _mapper = mapper;
            _httpClient = httpClient;
        }
        public async Task<WeatherDetailsDTO> GetCurrentWeatherDetails(string CityName)
        {
            var weatherDetails = new WeatherDetailsDTO();
            var url = $"{_apiConstants?.Url}?q={CityName}";
            _httpClient.DefaultRequestHeaders.Add("key", _apiConstants?.Key);
            var response = await _httpClient.GetAsync(url);
            _logger.LogTrace("Get weather.api called", nameof(WeatherApiService));
            if(response.IsSuccessStatusCode)
            {
                weatherDetails = await response.Content.ReadFromJsonAsync<WeatherDetailsDTO>();
            }
            return _mapper.Map<WeatherDetailsDTO>(weatherDetails);
        }
    }
}
