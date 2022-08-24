using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using WeatherDetailsApi.DataModel;
using WeatherDetailsApi.Interfaces;
using WeatherDetailsApi.Middlewares;
using WeatherDetailsApi.Services;

namespace WeatherDetailsApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        private readonly string _allowedOrigins = "_allowedOrigins";
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen();
            services.AddEndpointsApiExplorer();
            services.Configure<WeatherApiConstant>(Configuration.GetSection("WeatherApiConstant"));
            services.AddHttpClient<IWeatherAPI, WeatherApiService>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddCors();
            services.AddCors(options =>
            {
                options.AddPolicy(_allowedOrigins,
                builder =>
                {
                    builder.SetIsOriginAllowedToAllowWildcardSubdomains()
                        .WithOrigins(
                        "https://localhost:5001",
                        "http://localhost:4200",
                        "https://localhost:4200",
                        "*")
                           .AllowAnyHeader()
                           .AllowAnyMethod()
                           .AllowCredentials();
                });
            });
        }
        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            if (app.Environment.IsDevelopment())
            {
                //app.UseExceptionHandler("/Error"); to navigate to custom "Error" page in case of any exception encountered
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();
            app.UseCors(_allowedOrigins);
            app.UseAuthorization();
            app.UseMiddleware<ExceptionHandleMiddleware>();
            app.MapControllers();

            app.Run();
        }

        
    }
}
