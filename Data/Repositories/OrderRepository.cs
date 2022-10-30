using Microsoft.EntityFrameworkCore;
using SimpleStoreWeb.Data.Entities;
using SimpleStoreWeb.Data.Repositories.Abstraction;
using System.Linq;

namespace SimpleStoreWeb.Data.Repositories
{
    public class OrderRepository : Repository<Order>
    {
        public OrderRepository(SimpleStoreDbContext dbContext)
            : base(dbContext) { }

        public IQueryable<Order> GetByUserIdQuery(int userId)
            => base.Query()
                .Include(x => x.ApplicationUser)
                .Where(x => x.ApplicationUserId == userId);
    }
}
