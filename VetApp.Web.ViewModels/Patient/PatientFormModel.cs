namespace VetApp.Web.ViewModels.Patient
{
	using System.ComponentModel.DataAnnotations;

	using VetApp.Web.ViewModels.Owner;
	using static Common.ViewModelValidationConstants.PatientFormModelConstants;

	public class PatientFormModel
	{
		public PatientFormModel()
		{
		}

		[Required]
		[StringLength(NameMaxLength, MinimumLength = NameMinLength,
			ErrorMessage = NameErrorMessage)]
		public string Name { get; set; } = null!;

		[Required]
		[StringLength(TypeMaxLength, MinimumLength = TypeMinLength,
			ErrorMessage = TypeErrorMessage)]
		public string Type { get; set; } = null!;

		[DataType(DataType.Date)]
		[Display(Name = "Birthdate")]
		public DateTime? BirthDate { get; set; }

		[StringLength(MicroChipMaxLength, MinimumLength = MicroChipMinLength,
			ErrorMessage = MicrochipErrorMessage)]
		[Display(Name = "Microchip")]
		public string? Microchip { get; set; }

		[Required]
		public string Gender { get; set; } = null!;

		[Required]
		public string Neutered { get; set; } = null!;

        public string? Characteristics { get; set; }

		public string? ChronicIllnesses { get; set; }

		public OwnerFormModel Owner { get; set; } = null!;
    }
}
