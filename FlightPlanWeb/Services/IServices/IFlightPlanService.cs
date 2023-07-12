using FlightplanWeb.Models;

namespace FlightplanWeb.Services.IServices
{
    public interface IFlightplanService
    {
		public Task<T?> GetFlightManagerDisplayAllAsync<T>();
		public Task<T?> GetGeoPointListAirwaysAsync<T>();
		public Task<T?> GetGeoPointListFixesAsync<T>();
		public Task<T?> GetGeoPointListAirportsAsync<T>();

		//FlightPlans
		public Task<List<FlightPlan>> GetFlightplanAsync();
		public Task<List<FlightPlan>> SetFlightplanAsync();

		//Fixes
		public Task<List<Fix>> GetFixAsync();
		public Task<List<Fix>> SetFixAsync();

		//Airport
		public Task<List<Fix>> GetAirportAsync();
		public Task<List<Fix>> SetAirportAsync();

		public Task<SortedDictionary<string,List<FlightPlan>>> GetRouting(string departure, string arrival);
	}
}
