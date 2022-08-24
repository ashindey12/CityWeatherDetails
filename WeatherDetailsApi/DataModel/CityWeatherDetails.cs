using System.ComponentModel.DataAnnotations;

namespace WeatherDetailsApi.DataModel
{
    public class CityWeatherDetails
    {
        [Required]
        public string? Localtime { get; set; }
        [Required]
        public string? Weather { get; set; }
        [Required]
        public double Temp_c { get; set; }
        [Required]

        public double Temp_F => Temp_c * 9 / 5 + 32;
    }
}
