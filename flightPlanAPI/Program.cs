using FlightPlanAPI.IRepository;
using FlightPlanAPI.Repository;
using FlightPlanAPI.Data;
using Microsoft.EntityFrameworkCore;
using Serilog;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace FlightPlanAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = WebApplication.CreateBuilder(args);

            var logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();

            // Add services to the container.
            //logger
            builder.Logging.ClearProviders();
            builder.Logging.AddSerilog(logger);

            //db
            var connectionString = builder.Configuration.GetConnectionString("FlightDb");
            builder.Services.AddDbContext<FlightPlanDbContext>(x => x.UseSqlServer(connectionString));

            //services
            builder.Services.AddScoped<IFlightPlanRepository, FlightPlanRepository>();


            builder.Services.AddAutoMapper(typeof(MappingConfig));

            builder.Services.AddControllers().AddNewtonsoftJson(options =>
				{
					options.SerializerSettings.ContractResolver = new DefaultContractResolver();
				});

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            //JWT
            //var tokenHandler = new JwtSecurityTokenHandler();
            //var secretKey = configuration.GetValue<string>("ApiSettings:Secret") ?? "";
            //var key = Encoding.ASCII.GetBytes(secretKey);
            //var tokenDescriptor = new SecurityTokenDescriptor
            //{
            //    Expires = DateTime.UtcNow.AddDays(7),
            //    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            //};

            //var token = tokenHandler.CreateToken(tokenDescriptor);
            //logger.Information(tokenHandler.WriteToken(token));

            //builder.Services.AddAuthentication(x =>
            //{
            //    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            //}).AddJwtBearer(x =>
            //{
            //    x.RequireHttpsMetadata = false;
            //    x.SaveToken = true;
            //    x.TokenValidationParameters = new TokenValidationParameters { 
            //        ValidateIssuerSigningKey = true,
            //        IssuerSigningKey=new SymmetricSecurityKey(key),
            //        ValidateIssuer=false,
            //        ValidateAudience=false
            //    };
            //});


            //builder.Services.AddSwaggerGen(options =>
            //{
            //    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            //    {
            //        Description =
            //        "JWT Authorization header using the Bearer scheme. \r\n\r\n " +
            //        "Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\n" +
            //        "Example: \"Bearer 12345abcdef\"",
            //        Name="Authorization",
            //        In=ParameterLocation.Header,
            //        Scheme="Bearer"
            //    });
            //    options.AddSecurityRequirement(new OpenApiSecurityRequirement()
            //    {
            //        {
            //            new OpenApiSecurityScheme
            //            {
            //                Reference=new OpenApiReference
            //                {
            //                    Type=ReferenceType.SecurityScheme,
            //                    Id="Bearer"
            //                }, 
            //                Scheme="oauth2",
            //                Name="Bearer",
            //                In=ParameterLocation.Header
            //            },
            //            new List<string>()
            //        }
            //    });
            //});


            builder.Services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme
                {
                    Name = "apikey",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Description = "Authorization by apikey",
                    Scheme = "ApiKeyScheme"
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference=new OpenApiReference
                            {
                                Type=ReferenceType.SecurityScheme,
                                Id="ApiKey"
                            },
                            In=ParameterLocation.Header
                        },
                        new List<string>()
                    }
                }); ;
            });

            builder.Services.AddSingleton<ApiKeyAuthorizationFilter>();
            builder.Services.AddSingleton<IApiKeyValidator, ApiKeyValidator>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            //if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();

        }
    }
}