using SimpleStoreWeb.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace SimpleStoreWeb.ViewModels
{
    public class OrderViewModel : IIdNameCompatable
    {
        public int      Id { get; set; }
        
        [Required(ErrorMessage = ErrorMessages.RequiredMessage)]
        public string   Name { get; set; }
        public int      ApplicationUserId { get; set; }

        public static explicit operator OrderViewModel(Order order) => new()
        {
            Id      = order.Id,
            Name    = order.Name,
        };
    }
}
