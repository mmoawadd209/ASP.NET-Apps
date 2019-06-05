using System.ComponentModel.DataAnnotations;

namespace Vidly.View_Models.AccountViewModels
{
    public class RegisterViewModel
    {
       

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }


        [Required]
        [RegularExpression(@"(\+)?(2)?(01)[0-9]{9}", ErrorMessage = "Invalid Phone Number.")]
        [Display(Name = "Phone")]
        public string PhoneNumber { get; set; }
    }
}