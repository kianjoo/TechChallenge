namespace FlightPlanWeb.Services.IServices
{
    public interface IFlightPlanService
    {
        Task<T> GetAllAsync<T>();
    }
}
