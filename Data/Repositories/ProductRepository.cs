using Microsoft.EntityFrameworkCore;
using SimpleStoreWeb.Data.Entities;
using SimpleStoreWeb.Data.Repositories.Abstraction;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleStoreWeb.Data.Repositories
{
    public class ProductRepository : Repository<Product>
    {
        public ProductRepository(SimpleStoreDbContext dbContext)
            : base(dbContext) { }

        public async Task<Product> GetByNamePerCategoryAsync(string name, int? categoryId = null)
            => await base.Query()
            .Where(x => x.Name == name && (categoryId == null || x.CategoryId == categoryId.Value))
            .FirstOrDefaultAsync();

        public IQueryable<Product> GetByUserIdQuery(int userId)
            => base.Query().Where(x => x.ApplicationUserId == userId);

        protected override IQueryable<Product> BaseQuery() =>
            base.BaseQuery()
            .Include(b => b.Category)
            .Include(x => x.OrderItems)
            .Include(x => x.ApplicationUser);

        public IQueryable<Product> GetNotOrderedExcludeByUserIdQuery(int userId, int orderListId)
        {
            // No performance issue here - an expression builder will build the same 
            // as a single query representation but we will lose the debuging and reading simplicity.
            // this can be designed through query combine extensions (expression builder).
            var products = base.Query()
                .Include(oi => oi.OrderItems);

            var productsPerOrderList = products
                .Where(prod => prod.ApplicationUserId != userId)
                .Where(prod => prod.OrderItems
                    .Any(items => items.OrderId == orderListId));

            var allProductsExceptMy = products
                    .Where(prod => prod.ApplicationUserId != userId);

            var result = allProductsExceptMy.Except(productsPerOrderList);

            return result;
        }
    }
}
