using FlightPlanWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace FlightPlanWeb.Services.IServices
{
    public interface IBaseService
    {
        public Task<T> SendAsync<T>(HttpRequestMessage message);
    }
}
