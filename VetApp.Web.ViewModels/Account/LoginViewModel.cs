namespace VetApp.Web.ViewModels.Account
{
    using System.ComponentModel.DataAnnotations;
    using static Common.ViewModelValidationConstants.LoginViewModelConstants;

    public class LoginViewModel
    {
        [Required(ErrorMessage = "Name is required")]
		[StringLength(UsernameMaxLength, MinimumLength = UsernameMinLength, 
            ErrorMessage = "Username must be between 2 and 50 characters long!!")]
		public string? Username { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Display(Name = "Remember me")]
        public bool RememberMe { get; set; }

        public string? ReturnUrl { get; set; }
    }
}
