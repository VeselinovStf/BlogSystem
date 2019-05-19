using BS.WEB.ViewModels.Abstract;
using System.ComponentModel.DataAnnotations;

namespace BS.WEB.ViewModels.Identity
{
    public class LoginViewModel : IBasePageViewModel, IPageDisplayErrorViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
        public string PageTitle { get; set; }
        public string BackgroundImage { get; set; }
        public string HeaderTitle { get; set; }
        public string ErrorMessage { get; set; }
    }
    
}