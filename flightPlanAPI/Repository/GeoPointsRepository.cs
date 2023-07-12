
using FlightPlanAPI.IRepository;
using FlightPlanAPI.Models;
using FlightPlanAPI.Data;
using Newtonsoft.Json;

namespace FlightPlanAPI.Repository
{
	public class GeoPointsRepository : IGeoPointsRepository
	{
		private readonly AppDbContext _db;
		private readonly ILogger<GeoPointsRepository> _logger;
		public GeoPointsRepository(AppDbContext db, ILogger<GeoPointsRepository> logger)
		{
			_logger = logger;
			_db = db;
		}

		public string GetMockData(string filename)
		{
			string mockData = String.Empty;
			try
			{
				using (StreamReader reader = new StreamReader(filename))
				{
					mockData = reader.ReadToEnd();
				}
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
			}

			return mockData;
		}

		public List<ICAO> GetICAOList(string icao="")
		{

			if (icao == "") return _db.Icao.ToList();

			List<ICAO> icaoList = _db.Icao.Where(x => x.icao.ToLower().StartsWith(icao.ToLower())).ToList();
			if (icaoList.Count <= 0) return new List<ICAO>();

			return icaoList;
		}

		public bool Save()
		{
			return _db.SaveChanges() >= 0 ? true : false;
		}
	}
}
