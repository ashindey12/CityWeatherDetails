namespace WeatherDetailsApiNUnit
{
    [TestFixture]
    public class Tests
    {
        //private WeatherDetailsApi.Services.WeatherApiService _weatherApiService;
        [SetUp]
        public void Setup()
        {
            //_weatherApiService = new WeatherDetailsApi.Services.WeatherApiService();
            //moq all the services injected to this service class to instantiate the object
        }

        //write nunit test cases covering all edge cases scenario and null exception or response cases
        //write test case to validate Http get or post call
        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}