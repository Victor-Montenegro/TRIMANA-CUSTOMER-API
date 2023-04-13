using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace TRIMANA.Customer.Application.ProjectDependencies
{
    public static class ApplicationDependency
    {
        public static IServiceCollection ApplicationDependence(this IServiceCollection service)
        {
            Assembly applicationAssembly = Assembly.GetExecutingAssembly();

            service.AddMediatR(c =>
                    c.RegisterServicesFromAssembly(applicationAssembly));

            return service;
        }
    }
}
