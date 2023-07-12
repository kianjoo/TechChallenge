using FlightPlanAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightPlanAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

		public DbSet<FlightPlan> FlightPlan { get; set; }
		public DbSet<ICAO> Icao { get; set; }
	}
}
