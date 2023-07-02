using FlightPlanAPI.Models.DTO;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using System.Text;

namespace FlightPlanWeb.Services
{
    public class BaseService
    {
        public IHttpClientFactory httpClient { get; set; }
        public BaseService(IHttpClientFactory httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<T> SendAsync<T>(string URL, HttpMethod httpMethod, string data = "", string apiToken = "")
        {
            try
            {
                var client = httpClient.CreateClient();
                HttpRequestMessage message = new HttpRequestMessage();
                message.Headers.Add("Accept", "application/json");
                message.RequestUri = new Uri(URL);
                if(data !=null)
                {
                    message.Content = new StringContent(JsonConvert.SerializeObject(data)),Encoding.UTF8, "application/json")
                }

                message.Method = httpMethod;

                
                if(!string.IsNullOrEmpty(apiToken))
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiToken);
                }

                HttpResponseMessage apiResponse = apiResponse = await client.SendAsync(message);
                var apiContent = await apiResponse.Content.ReadAsStringAsync();

                try
                {
                    FlightPlanDTO flightPlanDTO = JsonConvert.DeserializeObject<FlightPlanDTO>(apiContent);
                
                }
                catch(Exception ex)
                {
                }

            }
        }
    }
}
