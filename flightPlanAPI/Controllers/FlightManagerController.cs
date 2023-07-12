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
    [Route("Flight-Manager")]
    [ApiController]
    public class FlightManagerController : ControllerBase
    {
        private IFlightPlanRepository _FPrepo;
        private readonly ILogger<FlightManagerController> _logger;
        private readonly IMapper _mapper;

        public FlightManagerController(IFlightPlanRepository flightPlanRepository, ILogger<FlightManagerController> logger, IMapper mapper)
        {
            _FPrepo = flightPlanRepository;
            _mapper = mapper;
            _logger = logger;
        }


        [HttpGet("retrieveFlightPlan")]
        [ApiKey]
        public IActionResult RetrieveFlightPlan()
        {
            List<FlightPlan> flightPlanList = _FPrepo.GenerateFlightPlan();
            List<FlightPlanDTO> flightPlanDTOList = flightPlanList.Select(fp => _mapper.Map<FlightPlanDTO>(fp)).ToList();

            return Ok(flightPlanDTOList);
        }

        [HttpGet("displayAll")]
        [Produces("application/json")]
		[ApiKey]
        public IActionResult DisplayAll()
        {
            _logger.LogInformation("DisplayAll");
            try
            {
                //List<FlightPlan> flightPlanList = _FPrepo.GetFlightPlanList();

                //List<FlightPlanDTO> flightPlanDTOList = flightPlanList.Select(fp => _mapper.Map<FlightPlanDTO>(fp)).ToList();

                //return Ok(flightPlanDTOList);

                string flightDataInJson = _FPrepo.GetMockData(@"MockData\\MockFlightPlan.json");
                

                return Ok(JsonConvert.DeserializeObject(flightDataInJson));
			}
			catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return BadRequest("Error Occurred"); ;
        }
    }
}
