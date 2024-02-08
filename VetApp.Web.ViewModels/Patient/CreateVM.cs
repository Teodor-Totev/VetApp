namespace VetApp.Web.ViewModels.Patient
{
	using System.ComponentModel.DataAnnotations;

	using static Common.EntityValidationConstants.PatientValidations;
	using static Common.EntityValidationConstants.OwnerValidations;

	public class CreateVM
	{
		public CreateVM()
		{
		}

		[Required]
		[StringLength(NameMaxLength, MinimumLength = NameMinLength,
			ErrorMessage = "Name must be between 2 and 25 characters long.")]
		public string Name { get; set; } = null!;

		[Required]
		[StringLength(TypeMaxLength, MinimumLength = TypeMinLength,
			ErrorMessage = "Type must be between 2 and 15 characters long.")]
		public string Type { get; set; } = null!;

		[DataType(DataType.Date)]
		public DateTime? BirthDate { get; set; }

		[StringLength(MicroChipMaxLength, MinimumLength = MicroChipMinLength,
			ErrorMessage = "Microchip must be between 5 and 50 characters long.")]
		[Display(Name = "Microchip")]
		public string? MicroChip { get; set; }

		[Required]
		public string Gender { get; set; } = null!;

		[Required]
		public string Neutered { get; set; } = null!;

        public string? Characteristics { get; set; }

		public string? ChronicIllnesses { get; set; }

		[Required]
		[StringLength(OwnerNameMaxLength, MinimumLength = OwnerNameMinLength)]
		[Display(Name = "Name")]
		public string OwnerName { get; set; } = null!;

		[Required]
		[StringLength(OwnerAddressMaxLength, MinimumLength = OwnerAddressMinLength)]
		[Display(Name = "Address")]
		public string OwnerAddress { get; set; } = null!;

		[Required]
		[StringLength(OwnerPhoneMaxLength, MinimumLength = OwnerPhoneMinLength)]
		[Display(Name = "PhoneNumber")]
		public string OwnerPhoneNumber { get; set; } = null!;

		[DataType(DataType.EmailAddress)]
		[Display(Name = "Email")]
		public string? OwnerEmail { get; set; }
	}
}
