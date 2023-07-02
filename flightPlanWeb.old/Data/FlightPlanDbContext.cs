using FlightPlanWeb.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FlightPlanWeb.Data
{
    public class FlightPlanDbContext : DbContext
    {
        //Constructor with DbContextOptions and the context class itself
        public FlightPlanDbContext(DbContextOptions<FlightPlanDbContext> options) : base(options)
        {
        }
        //Create the DataSet for the Employee         
        public DbSet<FlightPlan> FlightPlan { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Aircraft>().HasNoKey();
        }
    }
}