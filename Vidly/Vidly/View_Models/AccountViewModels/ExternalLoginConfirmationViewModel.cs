using System.ComponentModel.DataAnnotations;

namespace Vidly.View_Models.AccountViewModels
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Phone")]
        public string PhoneNumber { get; set; }
    }
}