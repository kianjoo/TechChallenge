using AutoMapper;
using FlightPlanWeb.Models;
using FlightPlanWeb.Models.DTO;
using FlightPlanWeb.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;

namespace FlightPlanWeb.Controllers
{
    public class FlightPlanController : Controller
    {
        private readonly IFlightPlanService _flightPlanService;
        private readonly IMapper _mapper;
        private readonly ILogger<FlightPlanController> _logger;


        public FlightPlanController(IFlightPlanService flightPlanService, IMapper mapper, ILogger<FlightPlanController> logger)
        {
            _flightPlanService = flightPlanService;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IActionResult> RetrieveFlightPlan()
        {
            List<FlightPlanDTO> flightPlanDTOList = await _flightPlanService.GenerateFlightPlanAsync<List<FlightPlanDTO>>();
			return RedirectToAction(nameof(FlightPlanList));
        }

        public async Task<IActionResult> FlightPlanList()
        {
            //Search
			SortedDictionary<string, List<FlightPlanDTO>> routing = new SortedDictionary<string, List<FlightPlanDTO>>();
			string departure = "";
			string arrival = "";
			if (ModelState.IsValid)
			{

				if (Request.HasFormContentType)
				{
					departure = Request.Form["departureAerodrome"];
					arrival = Request.Form["arrivalAerodrome"];

					if (departure != null && arrival != null)
					{
						routing = await _flightPlanService.GetRouting(departure, arrival);
					}
				}
			}

			ViewBag.routing = routing;
			ViewBag.departure = departure;
			ViewBag.arrival = arrival;


            //List
			List<FlightPlanDTO> flightPlanDTOList = await _flightPlanService.GetAllAsync<List<FlightPlanDTO>>();
            if (flightPlanDTOList != null)
            {
                _flightPlanService.SetFlightPlan(flightPlanDTOList);
            };

            ViewBag.flightPlanDTOList = flightPlanDTOList;
			return View();
        }

        public async Task<IActionResult> FlightPlan()
        {
            FlightPlanDTO flightPlanDTO = await _flightPlanService.GetAsync<FlightPlanDTO>();
            if (flightPlanDTO != null)
            {

            };
            return View(flightPlanDTO);
        }

        public async Task<IActionResult> SearchFlightPlan(FlightPlanDTO flightPlanDTO)
        {
			SortedDictionary<string, List<FlightPlanDTO>> routing = new SortedDictionary<string, List<FlightPlanDTO>>();
            string departure = "";
			string arrival = "";
			if (ModelState.IsValid)
            {

                if (Request.HasFormContentType)
                {
                    departure = Request.Form["departureAerodrome"];
                    arrival = Request.Form["arrivalAerodrome"];

                    if (departure != null && arrival != null)
                    {
                        routing = await _flightPlanService.GetRouting(departure, arrival);
                    }
                }
            }

            ViewBag.routing = routing;
            ViewBag.departure = departure;
            ViewBag.arrival= arrival; 

			return View();
		}
    }
}
