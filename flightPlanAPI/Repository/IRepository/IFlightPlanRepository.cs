using FlightPlanAPI.Models;

namespace FlightPlanAPI.IRepository
{
    public interface IFlightPlanRepository
    {
        FlightPlan GetRandomFlightPlan();
		string GetMockData(string filename);

		List<FlightPlan> GenerateFlightPlan();
		List<FlightPlan> GetFlightPlanList();
		bool Save();
    }
}
