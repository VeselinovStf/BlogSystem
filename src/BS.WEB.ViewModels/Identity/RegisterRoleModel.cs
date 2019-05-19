
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BS.WEB.ViewModels.Identity
{
    public class RegisterRoleModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Confirm Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Role")]
        public string Role { get; set; }

     
    }
}