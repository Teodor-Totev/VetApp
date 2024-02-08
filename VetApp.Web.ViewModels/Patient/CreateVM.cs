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

		[DataType(DataType.DateTime)]
		public DateTime? Age { get; set; }

		[StringLength(MicroChipMaxLength, MinimumLength = MicroChipMinLength,
			ErrorMessage = "Microchip must be between 5 and 50 characters long.")]
		[Display(Name = "Microchip")]
		public string? MicroChip { get; set; }

		[Required]
		public string Gender { get; set; } = null!;

		public string[] Genders = new[] { "Male", "Female" };

		public string Neutered { get; set; } = null!;

		public string[] Neutereds = new[] { "Yes", "No", "Homeless" };

		public string? Characteristics { get; set; }

		public string? ChronicIllnesses { get; set; }

		[Required]
		[StringLength(OwnerNameMaxLength, MinimumLength = OwnerNameMinLength)]
		public string OwnerName { get; set; } = null!;

		[Required]
		[StringLength(OwnerAddressMaxLength, MinimumLength = OwnerAddressMinLength)]
		public string OwnerAddress { get; set; } = null!;

		[Required]
		[StringLength(OwnerPhoneMaxLength, MinimumLength = OwnerPhoneMinLength)]
		public string OwnerPhoneNumber { get; set; } = null!;

		public string? OwnerEmail { get; set; }
	}
}
