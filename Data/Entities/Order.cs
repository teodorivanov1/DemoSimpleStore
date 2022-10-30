using SimpleStoreWeb.Data.Entities.Abstraction;
using SimpleStoreWeb.ViewModels;
using System.Collections.Generic;

namespace SimpleStoreWeb.Data.Entities
{
    #pragma warning disable format
    public class Order : Entity
    {
        public string Name{ get; set; }
        public int    ApplicationUserId { get; set; }

        public virtual ApplicationUser          ApplicationUser { get; set; }
        public virtual ICollection<OrderItem>   OrderItems { get; set; }

        public static explicit operator Order(OrderViewModel orderViewModel) => new()
        {
            Id      = orderViewModel.Id,
            Name    = orderViewModel.Name,
        };
    }
    #pragma warning restore format
}
