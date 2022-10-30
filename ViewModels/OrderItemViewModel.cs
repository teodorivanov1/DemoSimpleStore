using SimpleStoreWeb.Data.Entities;

namespace SimpleStoreWeb.ViewModels
{
    public class OrderItemViewModel
    {
        public int      Id { get; set; }
        public string   ProductName { get; set; }
        public bool     IsPurchased { get; set; }

        public static explicit operator OrderItemViewModel(OrderItem orderItem) => new()
        {
            Id          = orderItem.Id,
            ProductName = orderItem.Product.Name,
            IsPurchased = orderItem.IsPurchased
        };
    }
}