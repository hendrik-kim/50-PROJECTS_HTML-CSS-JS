using System.ComponentModel.DataAnnotations;

namespace Talent.Web.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        //[Remote(action:"IsEmailInUse", controller:"Account")]
        //[ValidEmailDomain(allowedDomain: "", ErrorMessage = "")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")] 
        [Compare("Password", ErrorMessage ="Password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Remember me")]
        public bool RememberMe { get; set; }
    }
}
