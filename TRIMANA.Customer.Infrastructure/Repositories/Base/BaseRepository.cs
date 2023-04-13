using Microsoft.EntityFrameworkCore;
using TRIMANA.Customer.Domain.Entities.Base;
using TRIMANA.Customer.Infrastructure.Database;

namespace TRIMANA.Customer.Infrastructure.Repositories.Base
{
    public abstract class BaseRepository<T> where T : EntityBase
    {
        private readonly DbSet<T> _dataSet;
        private readonly CustomerDatabaseContext _database;

        public BaseRepository(CustomerDatabaseContext database)
        {
            _database = database;

            _dataSet = _database.Set<T>();
        }

        protected async Task<int> Delete(T entity)
        {
            int rows = 0;

            entity.DeletedAt = DateTime.UtcNow;
            entity.UpdatedAt = DateTime.UtcNow;

            _dataSet.Update(entity);

            rows = await _database.SaveChangesAsync();

            return rows;
        } 
    }
}
