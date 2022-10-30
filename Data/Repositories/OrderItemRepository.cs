using Microsoft.EntityFrameworkCore;
using SimpleStoreWeb.Data.Entities;
using SimpleStoreWeb.Data.Repositories.Abstraction;
using System.Linq;

namespace SimpleStoreWeb.Data.Repositories
{
    public class OrderItemRepository : Repository<OrderItem>
        
    {
        public OrderItemRepository(SimpleStoreDbContext dbContext)
            : base(dbContext) { }
        
        public IQueryable<OrderItem> GetByOrderIdQuery(int orderId)
            => base.Query()
                .Include(x => x.Product)
                .Where(x => x.OrderId == orderId);
    }
}
