using Npgsql;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using System.Diagnostics;
using TRIMANA.Customer.Api.Middlewares;
using TRIMANA.Customer.Application.ProjectDependencies;
using TRIMANA.Customer.Infrastructure.ProjectDependencies;

var builder = WebApplication.CreateBuilder(args);
{
    IServiceCollection services = builder.Services;
    IConfiguration configuration = builder.Configuration;

    services.AddControllers();
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();
    services.ApplicationDependence();
    services.InfrastructureDependence(configuration);
    OpenTelematryDependence(services, configuration);
}

var app = builder.Build();
{
    IConfiguration configuration = app.Configuration;

    if (app.Environment.IsDevelopment() || app.Environment.IsProduction() || app.Environment.IsStaging())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    //app.UseMiddleware<RequestResponseMiddleware>();
    //app.UseMiddleware<OpenTelemetryInfosMiddlewareMiddleware>();
    //app.UseMiddleware<CustomExceptionMiddleware>();

    app.MapControllers();
    app.UseHttpsRedirection();
    app.Run();
}

void OpenTelematryDependence(IServiceCollection services, IConfiguration configuration)
{
    var otlpEndpoint = configuration.GetSection("OtlpEndpoint:url").Value;

    services.AddOpenTelemetry()
        .WithTracing(opts => 
            opts
            .AddSource(new ActivitySource("TRIMANA_Customer_Api").Name)
            .ConfigureResource(rosource => rosource
                .AddService("TRIMANA_Customer_Api"))
            .AddAspNetCoreInstrumentation()
            .AddJaegerExporter(otlp => {
                otlp.Endpoint = new Uri(otlpEndpoint);
            })
            .AddNpgsql()
            .AddConsoleExporter()); 

    //services.AddOpenTelemetryTracing(b =>
    //{
    //    b.SetResourceBuilder(
    //        ResourceBuilder.CreateDefault().AddService("TRIMANA.Customer.Api"))
    //        .AddAspNetCoreInstrumentation()
    //        .AddOtlpExporter(opts => { opts.Endpoint = new System.Uri(otlpEndpoint); })
    //        .AddHttpClientInstrumentation()
    //        .AddNpgsql();
    //});
}
