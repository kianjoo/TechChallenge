using FlightPlanAPI.Models;

namespace FlightPlanAPI.IRepository
{
    public interface IFlightPlanRepository
    {
        FlightPlan GetSingleFlightPlan();
		FlightPlan GetFlightPlan(string id);
		List<FlightPlan> GenerateFlightPlan();
		List<FlightPlan> GetFlightPlanList();
		bool Save();
    }
}
