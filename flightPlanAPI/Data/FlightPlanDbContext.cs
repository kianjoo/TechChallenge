using FlightPlanAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightPlanAPI.Data
{
    public class FlightPlanDbContext : DbContext
    {
        public FlightPlanDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<FlightPlan> FlightPlan {get; set;}
    }
}
