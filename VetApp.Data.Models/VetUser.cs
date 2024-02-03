namespace VetApp.Data.Models
{
	using System.ComponentModel.DataAnnotations;

	using Microsoft.AspNetCore.Identity;

	using static Common.ValidationConstants.AppUser;

	public class VetUser : IdentityUser
	{
		[Required]
		[StringLength(NameMaxLength, MinimumLength = NameMinLength)]
		public string? Name { get; set; }

		public string? Address { get; set; }
	}
}