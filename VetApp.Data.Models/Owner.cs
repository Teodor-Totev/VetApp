namespace VetApp.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static Common.EntityValidationConstants.OwnerValidations;

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
		[MaxLength(OwnerNameMaxLength)]
		public string Name { get; set; } = null!;

		[Required]
		[MaxLength(OwnerPhoneMaxLength)]
		public string PhoneNumber { get; set; } = null!;

		[Required]
		[MaxLength(OwnerAddressMaxLength)]
		public string Address { get; set; } = null!;

        public bool IsActive { get; set; }

        public string? Email { get; set; }

        public virtual ICollection<Patient> Patients { get; set; }
	}
}