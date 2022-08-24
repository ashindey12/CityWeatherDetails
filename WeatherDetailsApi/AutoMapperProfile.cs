using AutoMapper;
using WeatherDetailsApi.DataModel;

namespace WeatherDetailsApi
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            //TODO - add formating for date or number if any and use with method extension for valid checks
            CreateMap<WeatherDetailsDTO, CityWeatherDetails>()
                .ForMember(dest => dest.Localtime, opt => opt.MapFrom(src => src.Location.Localtime))
                .ForMember(dest => dest.Temp_c, opt => opt.MapFrom(src => Convert.ToDouble(src.Current.Temp_c)))
                .ForMember(dest => dest.Weather, opt => opt.MapFrom(src => src.Current.Condition.Text));
        }

        //we can also create extension methos of for string to return valid value or check vlue value in another static class
        //like following functions inside static class
        //public static bool IsValidString(this string str)
        //{
        //    if (!string.IsNullOrEmpty(str?.Trim()))
        //        return true;
        //    return false;
        //}

        //public static string GetValidString(this string str)
        //{
        //    return str?.Trim();
        //}
    }
}
