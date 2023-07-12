using FlightplanWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightplanWeb.Data
{
    public class FlightplanDbContext : DbContext
    {
        public FlightplanDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<FlightPlan> FlightPlan { get; set; }
    }
}