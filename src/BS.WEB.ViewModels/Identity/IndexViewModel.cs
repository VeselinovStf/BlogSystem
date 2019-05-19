using System.ComponentModel.DataAnnotations;

namespace BS.WEB.ViewModels.Identity
{
    public class IndexViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }

        public string Username { get; set; }

        public bool IsEmailConfirmed { get; set; }

        public string StatusMessage { get; set; }
    }
}