using System.ComponentModel.DataAnnotations;

namespace Vidly.View_Models
{
    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}