using Microsoft.EntityFrameworkCore;
using SimpleStoreWeb.Data.Entities;
using SimpleStoreWeb.Data.Repositories.Abstraction;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleStoreWeb.Data.Repositories
{
    public class CategoryRepository : Repository<Category>
        
    {
        public CategoryRepository(SimpleStoreDbContext dbContext)
            : base(dbContext)
        {
        }

        public async Task<Category> GetByNameAsync(string name)
            => await base.Query().Where(x => x.Name == name).FirstOrDefaultAsync();
    }
}
