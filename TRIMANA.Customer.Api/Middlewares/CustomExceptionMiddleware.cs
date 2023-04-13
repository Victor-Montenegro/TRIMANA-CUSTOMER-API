using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Diagnostics;
using System.Net;
using TRIMANA.Customer.Domain.Exceptions;

namespace TRIMANA.Customer.Api.Middlewares
{
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<CustomExceptionMiddleware> _logger;
        public CustomExceptionMiddleware(RequestDelegate next, ILogger<CustomExceptionMiddleware> logger)
        {
            _logger = logger;
            _next = next;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            //catch (BadGatewayException ex)
            //{
            //    _logger.LogError(ex, "RequestTransportError");
            //    await HandleExceptionAsync(httpContext, "Bad Gateway", HttpStatusCode.BadGateway);
            //}
            //catch (ProxyClientException ex)
            //{
            //    _logger.LogError(ex, "ProxyClientException");
            //    await HandleExceptionAsync(httpContext, ex.StatusCode.ToString(), ex.StatusCode);
            //}
            //catch (CheckoutApplicationException ex)
            //{
            //    _logger.LogError($"Exception: {ex}");
            //    await HandleExceptionAsync(httpContext, ex.Message, ex.HttpStatusCode);
            //}
            catch (Exception ex)
            {
                _logger.LogError($"Exception: {ex}");
                await HandleExceptionAsync(httpContext, "Internal Server Error", HttpStatusCode.InternalServerError);
            }
        }
        private static Task HandleExceptionAsync(HttpContext context, string message, HttpStatusCode statusCode)
        {
            var result = BuildErrorResponse(message, statusCode);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = result.Status;
            return context.Response.WriteAsync(JsonConvert.SerializeObject(result,
                new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                }));
        }

        private static ExceptionResponse BuildErrorResponse(string message, HttpStatusCode statusCode)
            => new()
            {
                Type = "Exception",
                Title = message,
                TraceId = Activity.Current?.Id ?? "Unable to get TraceId",
                Status = (int)statusCode,
                Errors = new Dictionary<string, List<string>>
                {
                    {
                        "ErrorDetails", new List<string>
                                    {
                                        statusCode.ToString()
                                    }
                    }
                }
            };

    }
}
