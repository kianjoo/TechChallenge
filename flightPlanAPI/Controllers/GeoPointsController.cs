using AutoMapper;
using FlightPlanAPI.Data;
using FlightPlanAPI.IRepository;
using FlightPlanAPI.Models;
using FlightPlanAPI.Models.DTO;
using FlightPlanAPI.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FlightPlanAPI.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class GeoPointsController : ControllerBase
	{
		private IGeoPointsRepository _IGPrepo;
		private readonly ILogger<GeoPointsController> _logger;
		private readonly IMapper _mapper;

		public GeoPointsController(IGeoPointsRepository igpRepository, ILogger<GeoPointsController> logger, IMapper mapper)
		{
			_IGPrepo = igpRepository;
			_mapper = mapper;
			_logger = logger;
		}


		[HttpGet("list/airways")]
		[ApiKey]
		public IActionResult airways()
		{
			string data = _IGPrepo.GetMockData(@"MockData\\MockAirways.json");

			return Ok(JsonConvert.DeserializeObject(data));
		}		

		[HttpGet("list/airways/{srch_icao}")]
		[ApiKey]
		public IActionResult SearchAirways(string srch_icao)
		{
			List<ICAO> icaoList = _IGPrepo.GetICAOList(srch_icao);
			List<string> icaoDTOList = new List<string>();
			foreach (ICAO i in icaoList)
			{
				icaoDTOList.Add($"{i.icao} ({i.lat},{i.lon})");
			}
			return Ok(icaoDTOList);
		}

		[HttpGet("list/fixes")]
		[ApiKey]
		public IActionResult fixes()
		{

			string data = _IGPrepo.GetMockData(@"MockData\\MockFixes.json");

			return Ok(JsonConvert.DeserializeObject(data));
		}


		[HttpGet("list/airports")]
		[ApiKey]
		public IActionResult airports()
		{

			string data = _IGPrepo.GetMockData(@"MockData\\MockAirports.json");

			return Ok(JsonConvert.DeserializeObject(data));
		}

	}
}
