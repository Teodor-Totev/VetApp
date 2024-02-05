namespace VetApp.Data.Models
{
	using System.ComponentModel.DataAnnotations;

	using Microsoft.AspNetCore.Identity;

	using static Common.ValidationConstants.AppUser;

	public class VetUser : IdentityUser
	{
		[Required]
		[MaxLength(NameMaxLength)]
		public string? FirstName { get; set; }

		[Required]
		[MaxLength(NameMaxLength)]
		public string? LastName { get; set; }

		[MaxLength(AddresMaxLength)]
		public string? Address { get; set; }
	}
}