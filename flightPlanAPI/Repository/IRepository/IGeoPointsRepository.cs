using FlightPlanAPI.Models;

namespace FlightPlanAPI.IRepository
{
    public interface IGeoPointsRepository
    {
		string GetMockData(string filename);
		List<ICAO> GetICAOList(string icao);
		bool Save();
    }
}
