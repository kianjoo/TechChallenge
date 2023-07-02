using FlightPlanWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightPlanWeb.Data
{
    public class FlightPlanDbContext : DbContext
    {
        public FlightPlanDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<FlightPlan> FlightPlan { get; set; }
    }
}