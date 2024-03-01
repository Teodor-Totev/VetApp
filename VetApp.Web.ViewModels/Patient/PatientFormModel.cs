namespace VetApp.Web.ViewModels.Patient
{
	using System.ComponentModel.DataAnnotations;

	using VetApp.Web.ViewModels.Owner;
	using static Common.ViewModelValidationConstants.PatientViewModelConstants;

	public class PatientFormModel
	{
		public PatientFormModel()
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
		[Display(Name = "Birthdate")]
		public DateTime? BirthDate { get; set; }

		[StringLength(MicroChipMaxLength, MinimumLength = MicroChipMinLength,
			ErrorMessage = "Microchip must be between 5 and 50 characters long.")]
		[Display(Name = "Microchip")]
		public string? Microchip { get; set; }

		[Required]
		public string Gender { get; set; } = null!;

		[Required]
		public string Neutered { get; set; } = null!;

        public string? Characteristics { get; set; }

		public string? ChronicIllnesses { get; set; }

		public OwnerViewModel Owner { get; set; } = null!;
    }
}
