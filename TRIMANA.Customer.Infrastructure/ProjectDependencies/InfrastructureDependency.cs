using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using System.Data;
using TRIMANA.Customer.Infrastructure.Repositories.Client;

namespace TRIMANA.Customer.Infrastructure.ProjectDependencies
{
    public static class InfrastructureDependency
    {
        public static IServiceCollection InfrastructureDependence(this IServiceCollection service, IConfiguration configuration)
        {
            DatabaseDependece(service, configuration);
            
            RepositoriesDependence(service);

            return service;
        }

        private static void RepositoriesDependence(IServiceCollection service)
        {
            service.AddTransient<IClientRepository, ClientRepository>();
        }

        private static void DatabaseDependece(IServiceCollection service, IConfiguration configuration)
        {
            string connectionDatabaseCustomer = configuration.GetSection("ConnectionDatabase:TRIMANA_CUSTOMER_DATABASE").Value;
            IDbConnection dbConnection = new NpgsqlConnection(connectionDatabaseCustomer);

            service.AddScoped<IDbConnection>(opt => new NpgsqlConnection(connectionDatabaseCustomer));

            //service.AddNpgsql<CustomerDatabaseContext>(connectionDatabaseCustomer);

            //service.AddEntityFrameworkNpgsql();
            //service.AddScoped<CustomerDatabaseContext>();
            //DbConnection connection = new NpgsqlConnection(connectionDatabaseCustomer);
            //service.AddDbContext<CustomerDatabaseContext>(options => options.UseNpgsql(connection));
        }
    }
}
