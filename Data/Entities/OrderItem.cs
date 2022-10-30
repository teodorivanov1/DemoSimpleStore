using SimpleStoreWeb.Data.Entities.Abstraction;

namespace SimpleStoreWeb.Data.Entities
{
    #pragma warning disable format
    public class OrderItem : Entity
    {
        public int  OrderId { get; set; }
        public int  ProductId { get; set; }
        public bool IsPurchased { get; set; }

        public virtual Order    Order { get; set; }
        public virtual Product  Product { get; set; }
    }
    #pragma warning restore format
}