namespace VetApp.Data.Models
{
	using System.ComponentModel.DataAnnotations;

	using Microsoft.AspNetCore.Identity;

	using static Common.EntityValidationConstants.AppUserValidations;

	public class ApplicationUser : IdentityUser<Guid>
	{
		public ApplicationUser()
		{
			this.PatientsUsers = new HashSet<PatientUser>();
			this.Examinations = new HashSet<Examination>();
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

		public virtual ICollection<Examination> Examinations { get; set; }
	}
}