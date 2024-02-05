namespace VetApp.Web.ViewModels.Account
{
    using System.ComponentModel.DataAnnotations;
	using static Common.ValidationConstants.RegisterViewModel;

	public class RegisterVM
    {
        [Required]
		[StringLength(UsernameMaxLength, MinimumLength = UsernameMinLength,
			ErrorMessage = "Username must be between 2 and 15 characters long!!")]
		public string? Username { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

		[Required]
		[DataType(DataType.Password)]
		[Compare("Password", ErrorMessage = "Password don't match")]
        [Display(Name = "Confirm Password")]
        public string? ConfirmPassword { get; set; }

        [DataType(DataType.MultilineText)]
        public string? Address { get; set; }

		[Required]
		[StringLength(FirstNameMaxLength, MinimumLength = FirstNameMinLength,
			ErrorMessage = "Username must be between 2 and 15 characters long!!")]
		[Display(Name = "First Name")]
		public string? FirstName { get; set; }

		[Required]
		[StringLength(LastNameMaxLength, MinimumLength = LastNameMinLength,
			ErrorMessage = "Username must be between 2 and 15 characters long!!")]
		[Display(Name = "Last Name")]
		public string? LastName { get; set; }
	}
}
