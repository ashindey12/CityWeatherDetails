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
            if (!string.IsNullOrEmpty(CityName))
            {
                var url = $"{_apiConstants?.Url}?q={CityName}";
                _httpClient.DefaultRequestHeaders.Add("key", _apiConstants?.Key);
                var response = await _httpClient.GetAsync(url);
                //log step by step execution depending on log level configured in nlog
                //TODO - add nlog or any other third party logging tool
                _logger.LogTrace("Get weather.api called", nameof(WeatherApiService));
                if (response.IsSuccessStatusCode)
                {
                    weatherDetails = await response.Content.ReadFromJsonAsync<WeatherDetailsDTO>();
                }
            }
            //TODO - else we can send the error in custome response model todisplay in UI for user
            
            return _mapper.Map<WeatherDetailsDTO>(weatherDetails);
        }
    }
}
