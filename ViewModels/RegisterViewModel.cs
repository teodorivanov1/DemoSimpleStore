using System.ComponentModel.DataAnnotations;

namespace SimpleStoreWeb.ViewModels
{
    // Small LSP break identified.
    public class RegisterViewModel : IdentityViewModel
    {
        [Required(ErrorMessage = ErrorMessages.RequiredMessage)]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Паролите не съвпадат.")]
        public string ConfirmPassword { get; set; }
    }
}
