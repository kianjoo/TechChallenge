using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FlightPlanAPI.Repository
{
    public class ApiKeyAttribute : ServiceFilterAttribute
    {
        public ApiKeyAttribute() : base(typeof(ApiKeyAuthorizationFilter))
        {
        }
    }

    public class ApiKeyAuthorizationFilter : IAuthorizationFilter
    {
        private const string ApiKeyHeaderName = "apikey";

        private readonly IApiKeyValidator _apiKeyValidator;

        public ApiKeyAuthorizationFilter(IApiKeyValidator apiKeyValidator)
        {
            _apiKeyValidator = apiKeyValidator;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            string? apiKey = context.HttpContext.Request.Headers["apikey"];

            if (string.IsNullOrEmpty(apiKey) || !_apiKeyValidator.IsValid(apiKey))
            {
                context.Result = new UnauthorizedResult();
            }
        }
    }

    public class ApiKeyValidator : IApiKeyValidator
    {
        public bool IsValid(string apiKey)
        {
            // Implement logic for validating the API key.
            return apiKey.Equals("eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9");
        }
    }

    public interface IApiKeyValidator
    {
        bool IsValid(string apiKey);
    }
}
