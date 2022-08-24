using WeatherDetailsApi.DataModel;

namespace WeatherDetailsApi.Interfaces
{
    public interface IWeatherAPI
    {
        public Task<WeatherDetailsDTO> GetCurrentWeatherDetails(string CityName);
    }
}
