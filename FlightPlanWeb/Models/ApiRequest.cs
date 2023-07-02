namespace FlightPlanWeb.Models
{
    public class ApiRequest
    {
        public string Url { get; set; } = "";   
        public HttpMethod httpMethod { get; set; } = HttpMethod.Get;
        public string data { get; set; } = string.Empty;
        public string apikey { get; set; } = string.Empty;
    }
}
