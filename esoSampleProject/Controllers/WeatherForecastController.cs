using Microsoft.AspNetCore.Mvc;

namespace esoSampleProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        

        private string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly IConfiguration _config;

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _config = configuration;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            var firstName = "Not found !!";
            var lastName = "Not found !!";
          
            firstName = _config["firstname01"]; //.GetValue<string>("AllowedHosts");// Summaries.Append(_config["Name"]);
            lastName = _config["lastname01"]; //.GetValue<string>("Logging: LogLevel:Default");
          

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)] + "::"+"Secret Key 1 is: "+firstName+", Secret Key 2 is : "+lastName
            })
            .ToArray();
        }
    }
}