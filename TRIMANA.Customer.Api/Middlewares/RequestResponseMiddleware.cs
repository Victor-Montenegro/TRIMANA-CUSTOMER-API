using Serilog;
using Serilog.Events;
using System.Diagnostics;
using System.Text;

namespace TRIMANA.Customer.Api.Middlewares
{
    public class RequestResponseMiddleware
    {
        readonly RequestDelegate _next;
        public RequestResponseMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            var stopWatch = Stopwatch.StartNew();
            try
            {
                await _next(httpContext);
                stopWatch.Stop();
                WriteLog(httpContext, stopWatch.Elapsed);
            }
            catch (Exception e)
            {
                Log.Fatal(e, "exception has been thrown by RequestResponseMiddleware");
                throw;
            }
        }
        private static void WriteLog(HttpContext httpContext, TimeSpan elapsed)
        {
            var level = httpContext.Response?.StatusCode > 299 ? LogEventLevel.Error : LogEventLevel.Information;

            //Infelizmente, usar a estrutura de formatação de log do proprio Serilog não funciona com o Sinks do Loki. Então, foi necessário utilizar concatenação de string
            var endpoint = $"{httpContext.Request.Host}{httpContext.Request?.Path}{httpContext.Request?.QueryString}";

            var sbLog = new StringBuilder();
            sbLog.AppendFormat("HTTP {0} {1} returned StatusCode {2} in {3}.", httpContext.Request?.Method, endpoint, httpContext.Response?.StatusCode, elapsed);
            sbLog.Append(Environment.NewLine);
            sbLog.Append(Environment.NewLine);

            Log
               .ForContext("Method", httpContext.Request?.Path)
               .Write(level, sbLog.ToString());
        }
    }
}
