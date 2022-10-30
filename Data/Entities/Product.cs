using SimpleStoreWeb.Data.Entities.Abstraction;
using SimpleStoreWeb.ViewModels;
using System.Collections.Generic;

namespace SimpleStoreWeb.Data.Entities
{
    #pragma warning disable format
    public class Product : Entity
    {
        public string           Name { get; set; }
        public decimal          Price { get; set; }
        public string           Description { get; set; }
        public string           ImagePath { get; set; }
        public int              CategoryId { get; set; }
        public int              ApplicationUserId { get; set; }

        public virtual Category                 Category { get; set; }
        public virtual ApplicationUser          ApplicationUser { get; set; }
        public virtual ICollection<OrderItem>   OrderItems { get; set; }

        public static explicit operator Product(ProductsViewModel productsViewModel) => new()
        {
            Id              = productsViewModel.Id,
            Name            = productsViewModel.Name,
            ApplicationUser = productsViewModel.ApplicationUser,
            Price           = productsViewModel.Price,
            Description     = productsViewModel.Description,
            ImagePath       = productsViewModel.ImagePath,
            CategoryId      = productsViewModel.CategoryId,
        };
    }
    #pragma warning restore format
}
