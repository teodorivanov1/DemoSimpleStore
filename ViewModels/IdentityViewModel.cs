using System.ComponentModel.DataAnnotations;

namespace SimpleStoreWeb.ViewModels
{
    public abstract class IdentityViewModel
    {
        [Required(ErrorMessage = ErrorMessages.RequiredMessage)]
        public string Username { get; set; }

        [Required(ErrorMessage = ErrorMessages.RequiredMessage)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
