using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Repositories.Abstract
{
    public interface IRepository<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAsync();
        Task<TEntity?> GetByKeyAsync(long key);
        Task<bool> AddAsync(TEntity entity);
        Task<bool> UpdateAsync(TEntity entity);
        Task<bool> DeleteByKeyAsync(long key);
        Task<bool> DeleteAllAsync();
        Task<int> SaveChangesAsync();
    }
}