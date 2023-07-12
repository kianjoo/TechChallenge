using Azure;
using FlightplanWeb.Models;
using FlightplanWeb.Services.IServices;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
//using System.Text.Json;


namespace FlightplanWeb.Services
{
	public class FlightplanService : IFlightplanService
    {
        public IHttpClientFactory httpClient { get; set; }
		public readonly ILogger<FlightplanService> logger;
		public readonly IConfiguration configuration;
		
		static List<FlightPlan> _flightPlanList = new List<FlightPlan>();
		static List<Fix> _fixList = new List<Fix>();
		static List<Fix> _airportList = new List<Fix>();

		public FlightplanService(IHttpClientFactory httpClient, ILogger<FlightplanService> logger, IConfiguration configuration)
        {
            this.httpClient = httpClient;
            this.logger = logger;
            this.configuration = configuration;
        }

		public async Task<T?> GetFlightManagerDisplayAllAsync<T>()
        {
			string apiURL = configuration.GetValue<string>("ServiceUrls:APIUrl") ?? string.Empty;
			string serviceURL = configuration.GetValue<string>("ServiceUrls:FlightManagerDisplayAll") ?? string.Empty;
			string apiKey = configuration.GetValue<string>("apiKey") ?? string.Empty;

			var client = httpClient.CreateClient("FlightPlanAPI");
			HttpRequestMessage reqMsg= new HttpRequestMessage()
			{
				Headers = {
						{ "Accept", "application/json" },
						{ "apikey", apiKey },
					},
				Method = HttpMethod.Get,
				RequestUri = new Uri(apiURL + serviceURL),
			};

			try
			{
				HttpResponseMessage response = await client.SendAsync(reqMsg);
				string content = await response.Content.ReadAsStringAsync();
				return JsonConvert.DeserializeObject<T>(content);
			}
			catch (Exception ex)
			{
				logger.LogError(ex.ToString());
			}

			return default(T);
		}

		public async Task<T?> GetGeoPointListAirwaysAsync<T>()
		{
			string apiURL = configuration.GetValue<string>("ServiceUrls:APIUrl") ?? string.Empty;
			string serviceURL = configuration.GetValue<string>("ServiceUrls:GeoPointListAirways") ?? string.Empty;
			string apiKey = configuration.GetValue<string>("apiKey") ?? string.Empty;

			var client = httpClient.CreateClient("FlightPlanAPI");
			HttpRequestMessage reqMsg = new HttpRequestMessage()
			{
				Headers = {
						{ "Accept", "application/json" },
						{ "apikey", apiKey },
					},
				Method = HttpMethod.Get,
				RequestUri = new Uri(apiURL + serviceURL),
			};

			try
			{
				HttpResponseMessage response = await client.SendAsync(reqMsg);
				string content = await response.Content.ReadAsStringAsync();
				return JsonConvert.DeserializeObject<T>(content);
			}
			catch (Exception ex)
			{
				logger.LogError(ex.ToString());
			}

			return default(T);
		}

		public async Task<T?> GetGeoPointListFixesAsync<T>()
		{
			string apiURL = configuration.GetValue<string>("ServiceUrls:APIUrl") ?? string.Empty;
			string serviceURL = configuration.GetValue<string>("ServiceUrls:GeoPointListFixes") ?? string.Empty;
			string apiKey = configuration.GetValue<string>("apiKey") ?? string.Empty;

		
			var client = httpClient.CreateClient("FlightPlanAPI");
			HttpRequestMessage reqMsg= new HttpRequestMessage()
			{
				Headers = {
						{ "Accept", "application/json" },
						{ "apikey", apiKey },
					},
				Method = HttpMethod.Get,
				RequestUri = new Uri(apiURL + serviceURL),
			};

			try
			{
				HttpResponseMessage response = await client.SendAsync(reqMsg);
				string content = await response.Content.ReadAsStringAsync();
				return JsonConvert.DeserializeObject<T>(content);
			}
			catch (Exception ex)
			{
				logger.LogError(ex.ToString());
			}

			return default(T);
		}


		public async Task<T?> GetGeoPointListAirportsAsync<T>()
		{
			string apiURL = configuration.GetValue<string>("ServiceUrls:APIUrl") ?? string.Empty;
			string serviceURL = configuration.GetValue<string>("ServiceUrls:GeoPointListAirports") ?? string.Empty;
			string apiKey = configuration.GetValue<string>("apiKey") ?? string.Empty;

			var client = httpClient.CreateClient("FlightPlanAPI");
			HttpRequestMessage reqMsg=new HttpRequestMessage()
			{
				Headers = {
						{ "Accept", "application/json" },
						{ "apikey", apiKey },
					},
				Method = HttpMethod.Get,
				RequestUri = new Uri(apiURL + serviceURL),
			};

			try
			{
				HttpResponseMessage response = await client.SendAsync(reqMsg);
				string content = await response.Content.ReadAsStringAsync();
				return JsonConvert.DeserializeObject<T>(content);
			}
			catch (Exception ex)
			{
				logger.LogError(ex.ToString());
			}

			return default(T);
		}

		//Waypoints
		public async Task<List<Fix>> GetFixAsync()
		{
			return await Task.Run(() => _fixList);
		}

		public async Task<List<Fix>> SetFixAsync()
		{
			List<string> fixList = await GetGeoPointListFixesAsync<List<string>>() ?? new List<string>();

			_fixList.Clear();
			Regex regex = new Regex(@"^(?<airway>[A-Z0-9]+)\s+\((?<lat>[-+]?\d+\.\d+),\s*(?<lon>[-+]?\d+\.\d+)\)$");
			foreach (string fixStr in fixList)
			{
				Match match = regex.Match(fixStr);
				if (match.Success)
				{
					_fixList.Add(new Fix
					{
						airway = match.Groups["airway"].Value,
						lat = double.Parse(match.Groups["lat"].Value),
						lon = double.Parse(match.Groups["lon"].Value)
					});
				}
			}
			return _fixList;
		}

		//FlightPlans
		public async Task<List<FlightPlan>> GetFlightplanAsync()
		{
			return await Task.Run(() => _flightPlanList);
		}

		public async Task<List<FlightPlan>> SetFlightplanAsync()
        {
			_flightPlanList = await GetFlightManagerDisplayAllAsync<List<FlightPlan>>() ?? new List<FlightPlan>();
			return _flightPlanList;
		}

		public async Task<List<Fix>> GetAirportAsync()
		{
			return await Task.Run(() => _airportList);
		}

		public async Task<List<Fix>> SetAirportAsync()
		{
			List<string> fixList = await GetGeoPointListAirportsAsync<List<string>>() ?? new List<string>();
			_airportList.Clear();
			Regex regex = new Regex(@"^(?<airway>[A-Z0-9]+)\s+\((?<lat>[-+]?\d+\.\d+),\s*(?<lon>[-+]?\d+\.\d+)\)$");
			foreach (string fixStr in fixList)
			{
				Match match = regex.Match(fixStr);
				if (match.Success)
				{
					_airportList.Add(new Fix
					{
						airway = match.Groups["airway"].Value,
						lat = double.Parse(match.Groups["lat"].Value),
						lon = double.Parse(match.Groups["lon"].Value)
					});
				}
			}
			return _airportList;
		}

		private bool getNextFlightPath(List<FlightPlan> route, string arrival)
		{
			FlightPlan cfp = route.Last();

			if (cfp?.arrival?.arrivalAerodrome?.Trim().ToLower() == arrival.Trim().ToLower())
			{
				return true;
			}

			foreach (FlightPlan fp in _flightPlanList)
			{
				if (fp?.departure?.departureAerodrome?.Trim().ToLower() == cfp?.arrival?.arrivalAerodrome?.Trim().ToLower()
					&& fp?.departure?.actualTimeOfDeparture >= cfp?.arrival?.actualTimeOfArrival)
				{
					route.Add(fp);
					return getNextFlightPath(route, arrival);
				}

			}
			return false;
		}

		public async Task<SortedDictionary<string, List<FlightPlan>>> GetRouting(string departure, string arrival)
		{
			SortedDictionary<string, List<FlightPlan>> routeList = new SortedDictionary<string, List<FlightPlan>>();
			//List<List<FlightPlanDTO>> routeResult = new List<List<FlightPlanDTO>>();

			foreach (FlightPlan fp in _flightPlanList)
			{
				TimeSpan shortestTimespan = TimeSpan.Zero;
				if (fp?.departure?.departureAerodrome?.Trim().ToLower() == departure.Trim().ToLower())
				{
					List<FlightPlan> route = new List<FlightPlan>
					{
						fp
					};

					if (route!=null && getNextFlightPath(route, arrival) == true)
					{
						TimeSpan? taken = route.Last().arrival?.actualTimeOfArrival - route.First().departure?.actualTimeOfDeparture;
						routeList[taken?.TotalHours.ToString("0000.00") + "," + fp.id] = route;
					}
				}
			}
			return await Task.Run(()=>routeList);
		}
	}
}
