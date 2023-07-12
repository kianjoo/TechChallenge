
using FlightplanWeb.Data;
using FlightplanWeb.Services;
using FlightplanWeb.Services.IServices;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace FlightplanWeb
{
    public class Program
    {
		[STAThread]
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
            builder.Services.AddDbContext<FlightplanDbContext>(x => x.UseSqlServer(connectionString));

			builder.Services.AddHttpClient<IFlightplanService, FlightplanService>();
			builder.Services.AddScoped<IFlightplanService, FlightplanService>();

			//view
			builder.Services.AddControllersWithViews();
            builder.Services.AddAutoMapper(typeof(MappingConfig));

            //
            logger.Information($"Using Service API:{configuration.GetValue<string>("ServiceUrlsAPIUrl")}");
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
                pattern: "{controller=Flightplan}/{action=Index}/{id?}");

            app.Run();
        }
    }
}