using SimpleStoreWeb.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace SimpleStoreWeb.ViewModels.Admin
{
    #pragma warning disable format
    public class CategoryViewModel : IIdNameCompatable
    {
        [Required]
        public int      Id { get; set; }
        public string   Name { get; set; }

        public static explicit operator CategoryViewModel(Category category) => new()
        {
            Id      = category.Id,
            Name    = category.Name,
        };
    }
    #pragma warning restore format
}
