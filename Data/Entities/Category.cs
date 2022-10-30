using SimpleStoreWeb.Data.Entities.Abstraction;
using SimpleStoreWeb.ViewModels.Admin;
using System.Collections.Generic;

namespace SimpleStoreWeb.Data.Entities
{
#pragma warning disable format
    public class Category : Entity
    {
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }

        public static explicit operator Category(CategoryViewModel categoryViewModel) => new()
        {
            Id      = categoryViewModel.Id,
            Name    = categoryViewModel.Name,
        };
    }
    #pragma warning restore format
}
