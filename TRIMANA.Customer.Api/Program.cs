using TRIMANA.Customer.Application.ProjectDependencies;

var builder = WebApplication.CreateBuilder(args);
{
    IServiceCollection services = builder.Services;

    services.AddControllers();
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();
    services.ApplicationDependence();
}

var app = builder.Build();
{
    IConfiguration configuration = app.Configuration;

    if (app.Environment.IsDevelopment() || app.Environment.IsProduction() || app.Environment.IsStaging())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.MapControllers();
    app.UseHttpsRedirection();

    app.Run();
}