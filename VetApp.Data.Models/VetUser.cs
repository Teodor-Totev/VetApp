namespace VetApp.Data.Models
{
	using System.ComponentModel.DataAnnotations;

	using Microsoft.AspNetCore.Identity;

	using static Common.EntityValidationConstants.AppUser;

	public class VetUser : IdentityUser<Guid>
	{
		public VetUser()
		{
			this.PatientsUsers = new HashSet<PatientUser>();
		}

		[Required]
		[MaxLength(NameMaxLength)]
		public string? FirstName { get; set; }

		[Required]
		[MaxLength(NameMaxLength)]
		public string? LastName { get; set; }

		[MaxLength(AddresMaxLength)]
		public string? Address { get; set; }

		public virtual ICollection<PatientUser> PatientsUsers { get; set; }
	}
}