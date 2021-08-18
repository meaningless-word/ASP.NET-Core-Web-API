using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ScreenApi.Contracts.Models;
using System.IO;
using System.Linq;

namespace ScreenApi.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class DevicesController : ControllerBase
	{
		private readonly ILogger<WeatherForecastController> _logger;
		private readonly IHostEnvironment _environment;

		public DevicesController(ILogger<WeatherForecastController> logger, IHostEnvironment environment)
		{
			_logger = logger;
			_environment = environment;
		}

		/// <summary>
		/// Поиск и загрузка инфтрукции по ичпользованию устройства
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		[HttpHead]
		[Route("{manufacturer}")]
		public IActionResult GetManual([FromRoute] string manufacturer)
		{
			var staticPath = Path.Combine(_environment.ContentRootPath, "Static");
			var filePath = Directory.GetFiles(staticPath).FirstOrDefault(f => f.Split("\\").Last().Split('.')[0] == manufacturer);

			if (string.IsNullOrEmpty(filePath))
				return StatusCode(404, $"Инструкция для производителя '{manufacturer}' не найдена на сервере. проверьте название.");

			string fileType = "application/pdf";
			string fileName = $"{manufacturer}.pdf";


			return PhysicalFile(filePath, fileType, fileName);
		}

		[HttpPost]
		[Route("")]
		public IActionResult Add([FromBody] Device request)
		{
			return StatusCode(200, request.StorageType.ToString());
		}
	}
}
