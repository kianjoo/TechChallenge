
using FlightPlanWeb.Data;
using FlightPlanWeb.Services;
using FlightPlanWeb.Services.IServices;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace FlightPlanWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();


            var builder = WebApplication.CreateBuilder(args);
            builder.Logging.ClearProviders();
            builder.Logging.AddSerilog(logger);

            // Add services to the container.
            //Db
            var connectionString = builder.Configuration.GetConnectionString("FlightDb");
            builder.Services.AddDbContext<FlightPlanDbContext>(x => x.UseSqlServer(connectionString));

			builder.Services.AddHttpClient<IFlightPlanService, FlightPlanService>();
			builder.Services.AddScoped<IFlightPlanService, FlightPlanService>();

			//view
			builder.Services.AddControllersWithViews();
            builder.Services.AddAutoMapper(typeof(MappingConfig));
            
            
            
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

           //app.UseAuthentication
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}