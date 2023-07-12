using AutoMapper;
using FlightplanWeb.Models;
using FlightplanWeb.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics;

namespace FlightplanWeb.Controllers
{
	public class FlightplanController : Controller
    {
        private readonly IFlightplanService _flightplanService;
        private readonly IMapper _mapper;
        private readonly ILogger<FlightplanController> _logger;


        public FlightplanController(IFlightplanService flightplanService, IMapper mapper, ILogger<FlightplanController> logger)
        {
            _flightplanService = flightplanService;
            _mapper = mapper;
            _logger = logger;
        }

		public async Task<IActionResult> Index()
		{
			List<Fix> fixList = await _flightplanService.GetFixAsync();
			if(fixList.Count()==0) fixList=await _flightplanService.SetFixAsync();

			List<FlightPlan> flightplanList= await _flightplanService.GetFlightplanAsync();
			if(flightplanList.Count()==0) flightplanList=await _flightplanService.SetFlightplanAsync();
			
			List<Fix> airportList = await _flightplanService.GetAirportAsync();
			if (airportList.Count() == 0) airportList=await _flightplanService.SetAirportAsync();


			ViewBag.fixListCount = fixList.Count;
			ViewBag.flightPlanListCount = flightplanList.Count;
			ViewBag.airportListCount = airportList.Count;

			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
		
		public async Task<IActionResult> AirwayList()
        {
            //List
			List<string> airways = await _flightplanService.GetGeoPointListAirwaysAsync<List<string>>() ?? new List<string>();

			return View(airways);
		}

		public async Task<IActionResult> RetrieveFix(string filter)
		{
			await _flightplanService.SetFixAsync();
			return RedirectToAction(nameof(FixList));
		}

		public async Task<IActionResult> FixList(string filterFix="", int pageNumber = 1, int pageSize = 1000)
		{
			ViewBag.filterFix = filterFix;

			List<Fix> fixes = await _flightplanService.GetFixAsync();
			ViewBag.fixesCount = fixes.Count;

			if (filterFix.IsNullOrEmpty())
			{
				ViewBag.fixesToDisplay = fixes.Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList();
			}
			else
			{
				List<Fix> filteredFixes = fixes.Where(fix => fix.airway.Trim().ToLower().Contains(filterFix.Trim().ToLower())).ToList();
				ViewBag.filteredFixesCount = filteredFixes.Count;
				ViewBag.fixesToDisplay = filteredFixes.Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList();
			}

			return View();
        }


		public async Task<IActionResult> RetrieveAirport(string filter)
		{
			await _flightplanService.SetAirportAsync();
			return await Task.Run(()=>RedirectToAction(nameof(AirportList)));
		}

		public async Task<IActionResult> AirportList(string filterAirport = "", int pageNumber = 1, int pageSize = 1000)
		{
			ViewBag.filterAirport = filterAirport;

			List<Fix> airports = await _flightplanService.GetAirportAsync();
			ViewBag.airportsCount = airports.Count;

			if (filterAirport.IsNullOrEmpty())
			{
				ViewBag.airportsToDisplay = airports.Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList();
			}
			else
			{
				List<Fix> filteredAirports = airports.Where(fix => fix.airway.Trim().ToLower().Contains(filterAirport.Trim().ToLower())).ToList();
				ViewBag.filteredAirportsCount = filteredAirports.Count;
				ViewBag.airportsToDisplay = filteredAirports.Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList();
			}

			return View();
		}

		public async Task<IActionResult> RetrieveFlightPlan()
		{
			await _flightplanService.SetFlightplanAsync();
			await _flightplanService.SetFixAsync();
			await _flightplanService.SetAirportAsync();
			return RedirectToAction(nameof(FlightPlanList));
		}

		public async Task<IActionResult> FlightPlanList(string filteredCallsign = "", string flightplanToPlotId = "")
		{
			//Flightplan
			List<FlightPlan> flightplanList = await _flightplanService.GetFlightplanAsync();
			ViewBag.flightplanList = flightplanList;

			//Waypoints
			List<Fix> fixList = await _flightplanService.GetFixAsync();

			//Airports
			List<Fix> airportList = await _flightplanService.GetAirportAsync();

			//Flightplan to display route
			if (!flightplanToPlotId.IsNullOrEmpty())
			{
				List<Waypoint> mapRoute = new List<Waypoint>();
				FlightPlan flightplan=flightplanList.FirstOrDefault(fp => fp?.id?.Trim().ToLower() == flightplanToPlotId.Trim().ToLower()) ?? new FlightPlan();

				//routeText
				ViewBag.routeText = flightplan?.filedRoute?.routeText ?? "";

				//departure
				Fix departure = airportList.FirstOrDefault(fix => fix.airway.Trim().ToLower() == flightplan?.departure?.departureAerodrome?.Trim().ToLower()) ?? new Fix();
				if (!departure.airway.IsNullOrEmpty())
				{
					mapRoute.Add(new Waypoint
					{
						designatedPoint = departure.airway ?? string.Empty,
						airway = "Departure",
						latitude = departure.lat,
						longitude = departure.lon
					});
				}
				//waypoint
				foreach (FiledRouteElement r in flightplan?.filedRoute?.routeElement ?? new List<FiledRouteElement>())
				{
					if (r == null) continue;

					string speedCode = r.changeSpeed == null ? string.Empty : (r.changeSpeed.Last() + (r.changeSpeed.Last().Equals('M') ? r.changeSpeed.Substring(0, r.changeSpeed.IndexOf(" ")).Replace(".", "") : r.changeSpeed.Substring(0, r.changeSpeed.IndexOf(".")).PadLeft(4, '0')));
					string levelCode = r.changeLevel==null? string.Empty: r.changeLevel.Last() + r.changeLevel.Substring(0, r.changeLevel.IndexOf("."));

					Fix fix = fixList.FirstOrDefault(fix => fix.airway.Trim().ToLower() == r?.position?.designatedPoint?.Trim().ToLower()) ?? new Fix();

					mapRoute.Add(new Waypoint
									{
										seqNum=r.seqNum,
										designatedPoint=r.position?.designatedPoint ?? string.Empty,
										speedCode=speedCode,
										levelCode=levelCode,
										airway=r.airway ?? string.Empty,
										latitude=fix.lat,
										longitude=fix.lon
									});
				}

				//arrival
				Fix arrival = airportList.FirstOrDefault(fix => fix.airway.Trim().ToLower() == flightplan?.arrival?.destinationAerodrome?.Trim().ToLower()) ?? new Fix();
				if (!arrival.airway.IsNullOrEmpty())
				{
					mapRoute.Add(new Waypoint
					{
						designatedPoint = arrival.airway ?? string.Empty,
						airway = "Arrival",
						latitude = arrival.lat,
						longitude = arrival.lon
					});
				}
				ViewBag.mapRoute = mapRoute;
			}
			ViewBag.flightplanToPlotId = flightplanToPlotId;

			//filter
			if (filteredCallsign.IsNullOrEmpty())
			{
				ViewBag.flightPlanToDisplay = flightplanList;
			}
			else
			{
				List<FlightPlan> filteredFlightplan = flightplanList.Where(fp => fp.aircraftIdentification != null 
					&& fp.aircraftIdentification.Trim().ToLower().Contains(filteredCallsign.Trim().ToLower())).ToList();

				
				ViewBag.flightplanToDisplay = filteredFlightplan;
				
			}
			ViewBag.filteredCallsign = filteredCallsign;

			return View();
		}

		public async Task<IActionResult> SearchFlightPlan(FlightPlan flightPlanDTO, string departureAerodrome="", string arrivalAerodrome="")
        {
			SortedDictionary<string, List<FlightPlan>> routing = new SortedDictionary<string, List<FlightPlan>>();
			if (ModelState.IsValid)
            {
                if (Request.HasFormContentType)
                {

                    if (departureAerodrome != "" && arrivalAerodrome != "")
                    {
                        routing = await _flightplanService.GetRouting(departureAerodrome, arrivalAerodrome);
                    }
                }
            }

            ViewBag.routing = routing;
            ViewBag.departure = departureAerodrome;
            ViewBag.arrival= arrivalAerodrome; 

			return View();
		}
    }
}
