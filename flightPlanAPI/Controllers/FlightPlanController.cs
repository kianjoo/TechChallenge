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
    [Route("api/[controller]")]
    [ApiController]
    public class FlightPlanController : ControllerBase
    {
        private IFlightPlanRepository _FPrepo;
        private readonly ILogger<FlightPlanController> _logger;
        private readonly IMapper _mapper;

		public FlightPlanController(IFlightPlanRepository flightPlanRepository, ILogger<FlightPlanController> logger, IMapper mapper)
        {
            _FPrepo = flightPlanRepository;
            _mapper = mapper;
            _logger = logger;
        }


		[HttpGet("retrieveFlightPlan")]
		[ApiKey]
		public IActionResult RetrieveFlightPlan()
        {
            List<FlightPlan> flightPlanList=_FPrepo.GenerateFlightPlan();
			List<FlightPlanDTO> flightPlanDTOList = flightPlanList.Select(fp => _mapper.Map<FlightPlanDTO>(fp)).ToList();

			return Ok(flightPlanDTOList);
		}

        [HttpGet("displayAll")]
        [ApiKey]
        public IActionResult GetAllFlightPlan()
        {
            _logger.LogInformation("GetAllFlightPlan");
            try
            {
				List<FlightPlan> flightPlanList=_FPrepo.GetFlightPlanList();

				List<FlightPlanDTO> flightPlanDTOList = flightPlanList.Select(fp => _mapper.Map<FlightPlanDTO>(fp)).ToList();

				//return Ok(JsonConvert.SerializeObject(flightPlanDTOList));

				return Ok(flightPlanDTOList);
			}
			catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return BadRequest("Error Occurred"); ;            
        }

   //     [HttpGet("DisplayFlightPlan")]
   //     [ApiKey]
   //     public IActionResult GetSingleFlightPlan()
   //     {
   //         _logger.LogInformation("GetSingleFlightPlan");
   //         try
   //         {

   //             FlightPlan flightPlan = _FPrepo.GetSingleFlightPlan();

   //             FlightPlanDTO flightPlanDTO = _mapper.Map<FlightPlanDTO>(flightPlan);
			//	//return Ok(JsonConvert.SerializeObject(flightPlanDTO));
			//	return Ok(flightPlanDTO);
			//}
			//catch (Exception ex)
   //         {
   //             _logger.LogError(ex.Message);
   //         }
   //         //return Task.FromResult<ActionResult<APIResponse>>(Ok(_response));

   //         return BadRequest("Error Occurred"); ;
   //     }

        //// POST api/<FlightPlanController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<FlightPlanController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<FlightPlanController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
