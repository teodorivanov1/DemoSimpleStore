using SimpleStoreWeb.Data.Entities.Abstraction;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleStoreWeb.Data.Repositories.Abstraction
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        IQueryable<TEntity> Query();
        Task<TEntity> GetByIdAsync(int id);
        Task InsertAsync(TEntity entity);
        void Update(TEntity entity);
        Task<IList<TEntity>> GetAllAsync();
        Task<bool> SaveAsync();
    }
}
