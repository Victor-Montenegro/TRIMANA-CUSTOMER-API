using Microsoft.Extensions.Primitives;
using Serilog;
using System.Diagnostics;

namespace TRIMANA.Customer.Api.Middlewares
{
    public class OpenTelemetryInfosMiddlewareMiddleware
    {
        readonly RequestDelegate _next;
        public OpenTelemetryInfosMiddlewareMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            var responseBodyMemoryStream = new MemoryStream();

            try
            {
                var originalResponseBodyReference = httpContext.Response.Body;
                httpContext.Response.Body = responseBodyMemoryStream;

                await _next(httpContext);

                httpContext.Response.Body.Seek(0, SeekOrigin.Begin);
                httpContext.Response.Headers.Add("TraceId", new StringValues(Activity.Current?.Id));

                await responseBodyMemoryStream.CopyToAsync(originalResponseBodyReference);
            }
            catch (Exception e)
            {
                Log.Fatal(e, "exception has been thrown by RequestResponseMiddleware");
                throw;
            }
        }
    }
}
