using System.ComponentModel.DataAnnotations;

namespace WeatherDetailsApi.DataModel
{
    public class WeatherDetailsDTO
    {
        public LocationDto Location { get; set; }
        public CurrentDto Current { get; set; }

        public WeatherDetailsDTO()
        {
            Location = new LocationDto();
            Current = new CurrentDto();
        }
    }

     
    /*
     * As per response object of weather api there are many fields being sent
     * here I have only used the fields which felt relevant to capture
     * we can add here all the properties of the json response from weather api
     */
    public class LocationDto
    {
        public string? Name { get; set; }
        public string? Region { get; set; }
        public string? Country { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }
        public string? Tz_id { get; set; }
        public int Localtime_epoch { get; set; }
        [Required]
        public string Localtime { get; set; }
    }

    /*
     * As per response object of weather api there are many fields being sent
     * here I have only used the fields which felt relevant to capture
     * we can add here all the properties of the json response from weather api
     */
    public class CurrentDto
    {
        public int Last_updated_epoch { get; set; }
        public string? Last_updated { get; set; }
        [Required]
        public double Temp_c { get; set; }
        public double Temp_f { get; set; }
        public int Is_day { get; set; }
        [Required]
        public ConditionDto Condition { get; set; }
    }

    public class ConditionDto
    {
        [Required]
        public string Text { get; set; }
        public string? Icon { get; set; }
        [Required]
        public int Code { get; set; }
    }
}
