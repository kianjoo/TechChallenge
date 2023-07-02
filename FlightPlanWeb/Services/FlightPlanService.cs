using FlightPlanWeb.Models.DTO;
using FlightPlanWeb.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Nodes;
//using System.Text.Json;
using System.Web.Http.Results;
using OkResult = System.Web.Http.Results.OkResult;

namespace FlightPlanWeb.Services
{
    public class FlightPlanService : IFlightPlanService
    {
        public IHttpClientFactory httpClient { get; set; }
        public readonly ILogger<FlightPlanService> logger;
        static List<FlightPlanDTO> _flightPlanDTOList = new List<FlightPlanDTO>();

        public FlightPlanService(IHttpClientFactory httpClient, ILogger<FlightPlanService> logger)
        {
            this.httpClient = httpClient;
            this.logger = logger;
        }

        public async Task<T>? GetAllAsync<T>()
        {
            HttpRequestMessage message = new HttpRequestMessage()
            {
                Headers =
                    {
                        { "Accept", "application/json" },
                        { "apikey", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9" },
                    },
                Method = HttpMethod.Get,
                RequestUri = new Uri("http://localhost:5000/api/FlightPlan/displayall"),
                //Content = new StringContent(JsonConvert.SerializeObject('apiContent'), Encoding.UTF8, "application/json")

            };
            var client = httpClient.CreateClient("FlightPlanAPI");
            HttpResponseMessage apiResponse = await client.SendAsync(message);
            var apiContent = await apiResponse.Content.ReadAsStringAsync();

            //string res=JsonConvert.SerializeObject(apiContent);

            return JsonConvert.DeserializeObject<T>(apiContent);
        }

        public async Task<T>? GetAsync<T>()
        {
            HttpRequestMessage message = new HttpRequestMessage()
            {
                Headers =
                    {
                        { "Accept", "application/json" },
                        { "apikey", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9" },
                    },
                Method = HttpMethod.Get,
                RequestUri = new Uri("http://localhost:5000/api/FlightPlan/displayFlightPlan"),
                //Content = new StringContent(JsonConvert.SerializeObject('apiContent'), Encoding.UTF8, "application/json")

            };
            var client = httpClient.CreateClient("FlightPlanAPI");
            HttpResponseMessage apiResponse = await client.SendAsync(message);
            string apiContent = await apiResponse.Content.ReadAsStringAsync();

            //string res=JsonConvert.SerializeObject(apiContent);
            //object jsonResponse = JsonConvert.DeserializeObject(apiContent);
            //return JsonConvert.DeserializeObject<T>(jsonResponse.ToString());
            return JsonConvert.DeserializeObject<T>(apiContent);
        }

        public async Task<T>? GenerateFlightPlanAsync<T>()
        {
            HttpRequestMessage message = new HttpRequestMessage()
            {
                Headers =
                    {
                        { "Accept", "application/json" },
                        { "apikey", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9" },
                    },
                Method = HttpMethod.Get,
                RequestUri = new Uri("http://localhost:5000/api/FlightPlan/retrieveFlightPlan"),
                //Content = new StringContent(JsonConvert.SerializeObject('apiContent'), Encoding.UTF8, "application/json")

            };
            var client = httpClient.CreateClient("FlightPlanAPI");
            HttpResponseMessage apiResponse = await client.SendAsync(message);
            string apiContent = await apiResponse.Content.ReadAsStringAsync();

            //string res=JsonConvert.SerializeObject(apiContent);
            //object jsonResponse = JsonConvert.DeserializeObject(apiContent);
            //return JsonConvert.DeserializeObject<T>(jsonResponse.ToString());
            return JsonConvert.DeserializeObject<T>(apiContent);
        }

        public void SetFlightPlan(List<FlightPlanDTO> flightPlanDTOList)
        {
            _flightPlanDTOList = flightPlanDTOList;
        }

        private bool getNextFlightPath(List<FlightPlanDTO> route, string arrival)
        {
            FlightPlanDTO cfp = route.Last();

			if (cfp.arrival.arrivalAerodrome.Trim().ToLower() == arrival.Trim().ToLower())
			{
				return true;
			}

			foreach (FlightPlanDTO fp in _flightPlanDTOList)
            {
                if(fp.departure.departureAerodrome.Trim().ToLower() == cfp.arrival.arrivalAerodrome.Trim().ToLower() 
                    && fp.departure.actualTimeOfDeparture>= cfp.arrival.actualTimeOfArrival)
                {
                    route.Add(fp);
                    return getNextFlightPath(route , arrival);
                }

            }
            return false;
        }

        public async Task<SortedDictionary<string, List<FlightPlanDTO>>> GetRouting(string departure, string arrival)
        {
            SortedDictionary<string, List<FlightPlanDTO>> routeList = new SortedDictionary<string, List<FlightPlanDTO>>();
            //List<List<FlightPlanDTO>> routeResult = new List<List<FlightPlanDTO>>();

            foreach (FlightPlanDTO fp in _flightPlanDTOList)
            {
                string shortestRoute = "";
                TimeSpan shortestTimespan = TimeSpan.Zero;
                if (fp.departure.departureAerodrome.Trim().ToLower() == departure.Trim().ToLower())
                {
                    List<FlightPlanDTO> route = new List<FlightPlanDTO>
                    {
                        fp
                    };

                    if (getNextFlightPath(route, arrival) == true)
                    {
                        TimeSpan taken = route.Last().arrival.actualTimeOfArrival - route.First().departure.actualTimeOfDeparture;
                        routeList[taken.TotalHours.ToString("0000.00") +","+ fp.id] = route;

                        //if (shortestRoute == "")
                        //{
                        //    shortestRoute = route.First().id;
                        //    shortestTimespan = taken;
                        //}
                        //else
                        //{
                        //    if(taken<shortestTimespan)
                        //    {
                        //        shortestRoute = route.First().id;
                        //        shortestTimespan = taken;
                        //    }
                        //}

                        //routeResult.Add(route);

                    }
                }
            }
			return routeList;
		}
	}
}
