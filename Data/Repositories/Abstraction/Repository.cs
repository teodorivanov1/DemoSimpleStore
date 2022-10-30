using Microsoft.EntityFrameworkCore;
using SimpleStoreWeb.Data.Entities.Abstraction;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleStoreWeb.Data.Repositories.Abstraction
{
    public abstract class Repository<TEntity> : IRepository<TEntity>
        where TEntity : Entity
    {
        private readonly SimpleStoreDbContext dbContext = null;
        private readonly DbSet<TEntity> dbSet = null;

        protected Repository(SimpleStoreDbContext dbContext)
        {
            this.dbContext = dbContext;
            dbSet = dbContext.Set<TEntity>();
        }

        protected virtual IQueryable<TEntity> BaseQuery() 
            => dbContext.Set<TEntity>()
            .OrderByDescending(x => x.Id)
            .AsNoTracking();

        public async Task<TEntity> GetByIdAsync(int id) => await dbSet.FindAsync(id);

        public async Task InsertAsync(TEntity entity) => await dbSet.AddAsync(entity);

        public void Update(TEntity entity)
        {
            dbSet.Attach(entity);
            dbContext.Entry(entity).State = EntityState.Modified;
        }
        
        public async Task<bool> SaveAsync() => await dbContext.SaveChangesAsync() > 0;

        public IQueryable<TEntity> Query() => BaseQuery();

        public async Task<IList<TEntity>> GetAllAsync() => await Query().ToListAsync();
    }
}
