using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ScreenApi.Configuration;

namespace ScreenApi.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class InfoController : ControllerBase
	{
		private readonly ILogger<WeatherForecastController> _logger;
		private IOptions<ScreenApiOptions> _options;

		public InfoController(ILogger<WeatherForecastController> logger, IOptions<ScreenApiOptions> options)
		{
			_logger = logger;
			_options = options;
		}

		[HttpGet]
		public IActionResult Get()
		{
			return StatusCode(200, $"Имя сервиса: {_options.Value.ServiceName}");
		}
	}
}
