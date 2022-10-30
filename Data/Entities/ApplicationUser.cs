using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace SimpleStoreWeb.Data.Entities
{
    public class ApplicationUser : IdentityUser<int>
    {
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<Order>   Orders { get; set; }
    }
}
