using SimpleStoreWeb.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SimpleStoreWeb.ViewModels
{
    #pragma warning disable format
    public class ProductsViewModel : IIdNameCompatable
    {
        public int                      Id { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = ErrorMessages.RequiredMessage)]
        public int                      CategoryId { get; set; }
        public IEnumerable<Category>    Categories { get; set; }

        [Required(ErrorMessage = ErrorMessages.RequiredMessage)]
        public string                   Name { get; set; }

        [Required(ErrorMessage = ErrorMessages.RequiredMessage)]
        [Range(1, int.MaxValue, ErrorMessage = ErrorMessages.RequiredMessage)]
        public decimal                  Price { get; set; }
        public string                   Description { get; set; }
        public string                   ImagePath { get; set; }
        public int                      ApplicationUserId { get; set; }
        public ApplicationUser          ApplicationUser { get; set; }
        public string                   CategoryName { get; set; }
        public string                   ProductTitle { get; set; }
        public int                      Order { get; set; }
        public string                   PriceStr{ get; private set;}

        public static explicit operator ProductsViewModel(Product product) => new()
        {
            Id                  = product.Id,
            Name                = product.Name,
            Description         = product.Description,
            Price               = product.Price,
            CategoryId          = product.CategoryId,
            ApplicationUserId   = product.ApplicationUser != null ? product.ApplicationUser.Id : 0,
            CategoryName        = product.Category?.Name,
            ProductTitle        = string.Join("/", product.Category?.Name, product.Name),
            PriceStr            = string.Join(" ","Цена:", product.Price)
        };
        
    }
    #pragma warning restore format
}
