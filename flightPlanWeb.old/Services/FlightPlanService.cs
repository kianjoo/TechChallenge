using FlightPlanWeb.Services.IServices;
using System;
using System.Net.Http;

namespace FlightPlanWeb.Services
{
    public class FlightPlanService : BaseService, IFlightPlanService
    {
        private string flightPlanUrl;

        public FlightPlanService(IHttpClientFactory clientFactory, IConfiguration configuration) :base(clientFactory)
        {
            flightPlanUrl = configuration.GetValue<string>("ServiceUrls:FlightPlanAPI");
        }

        public Task<T> GetAllAsync<T>()
        {
            return SendAsync<T>(flightPlanUrl, HttpMethod.Get);
        }
    }
}
