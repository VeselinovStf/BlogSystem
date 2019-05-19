using System.ComponentModel.DataAnnotations;

namespace BS.WEB.ViewModels.Identity
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}