using Microsoft.AspNetCore.Mvc;
using WarehouseApi2.Model;

namespace WarehouseApi2.Controllers

{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };
        [Route("Show/[controller]")]
        [HttpGet]
        public IActionResult Show()
        {
            Carryngs newCarryng = new Carryngs();
            // Вместо создания нового экземпляра контекста, лучше внедрить его через конструктор
            ContextDB DB = new ContextDB();
            // Получаем список всех записей из таблицы Carryngs
            var carryngs = DB.carryng.ToList();
            // Возвращаем только список, а не весь контекст
            return Ok(carryngs);
        }

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}