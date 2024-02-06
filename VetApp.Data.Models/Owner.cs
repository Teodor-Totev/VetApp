namespace VetApp.Data.Models
{
	using System.ComponentModel.DataAnnotations;
	using static Common.EntityValidationConstants.Owner;

	public class Owner
	{
		public Owner()
		{
			this.Id = Guid.NewGuid();
			this.Patients = new HashSet<Patient>();
		}

		[Key]
		public Guid Id { get; set; }

		[Required]
		[MaxLength(NameMaxLength)]
		public string Name { get; set; } = null!;

		[Required]
		[MaxLength(PhoneMaxLength)]
		public string PhoneNumber { get; set; } = null!;

		[Required]
		[MaxLength(AddressMaxLength)]
		public string Address { get; set; } = null!;

        public string? Email { get; set; }

        public virtual ICollection<Patient> Patients { get; set; }
	}
}