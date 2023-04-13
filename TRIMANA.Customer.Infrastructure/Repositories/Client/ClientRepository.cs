using Dapper;
using System.Data;
using TRIMANA.Customer.Domain.Entities.Client;

namespace TRIMANA.Customer.Infrastructure.Repositories.Client
{
    public class ClientRepository : IClientRepository
    {
        private readonly IDbConnection _database;

        public ClientRepository(IDbConnection database)
        {
            _database = database;
        }

        public async Task<ClientEntity> GetById(int id)
        {
            string query = @"select asdasd id from teste order by 1 desc";

                var teste = await _database.QueryFirstOrDefaultAsync<ClientEntity>(query);

            return teste;
        }
    }

    public interface IClientRepository
    {
        Task<ClientEntity> GetById(int id);
    }
}
