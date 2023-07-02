using FlightPlanWeb.Models;
using FlightPlanWeb.Models.DTO;
using FlightPlanWeb.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Core;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Web.Http;
using HttpMethod = System.Net.Http.HttpMethod;

namespace FlightPlanWeb.Services
{
    public class BaseService : IBaseService
    {
        public IHttpClientFactory httpClient { get; set; }
        public readonly ILogger<BaseService> logger;
        public BaseService(IHttpClientFactory httpClient, ILogger<BaseService> logger)
        {
            this.httpClient = httpClient;
            this.logger = logger;
        }

        public async Task<T>? SendAsync<T>(HttpRequestMessage message)
        {
            try
            {
                //var client = httpClient.CreateClient("FlightPlanAPI");

                //HttpRequestMessage msg = new HttpRequestMessage
                //{
                //    Headers =
                //    {
                //        { "Accept", "application/json" },
                //        { "apikey", "applicationjson" },
                //    },
                //    Method = HttpMethod.Get,
                //    RequestUri = new Uri("Your request URL"),
                //    Content = new StringContent(JsonSerializer.Serialize("apiContent"), Encoding.UTF8, "application/json")
                //};
                //message.Headers.Add("Accept", "application/json");
                //message.Method = req.httpMethod;

                //HttpResponseMessage apiResponse = await client.SendAsync(message);
                HttpResponseMessage apiResponse = await httpClient.CreateClient("FlightPlanAPI").SendAsync(
                    new HttpRequestMessage()
                    {
                        Headers =
                            {
                                { "Accept", "application/json" },
                                { "apikey", "applicationjson" },
                            },
                        Method = HttpMethod.Get,
                        RequestUri = new Uri("Your request URL"),
                        Content = new StringContent(JsonSerializer.Serialize("apiContent"), Encoding.UTF8, "application/json")
                    }
                );
                
                var apiContent = await apiResponse.Content.ReadAsStringAsync();

                FlightPlanDTO? flightPlanDTO = JsonSerializer.Deserialize<FlightPlanDTO>(apiContent);
                return flightPlanDTO;
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                throw;
            }
        }
    }
}
