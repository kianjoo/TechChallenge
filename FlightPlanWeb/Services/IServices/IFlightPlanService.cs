using FlightPlanWeb.Models.DTO;

namespace FlightPlanWeb.Services.IServices
{
    public interface IFlightPlanService
    {
		public Task<T>? GenerateFlightPlanAsync<T>();
		public Task<T>? GetAllAsync<T>();
		public Task<T>? GetAsync<T>();
		public Task<SortedDictionary<string,List<FlightPlanDTO>>> GetRouting(string departure, string arrival);
		public void SetFlightPlan(List<FlightPlanDTO> flightPlanDTOList);
	}
}
