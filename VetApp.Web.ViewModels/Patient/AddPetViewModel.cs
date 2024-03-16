namespace VetApp.Web.ViewModels.Patient
{
	using System;
	using System.ComponentModel.DataAnnotations;

	using VetApp.Data.Common.Enums.Patient;
	using static Common.ViewModelValidationConstants.PatientConstants;

	public class AddPetViewModel
	{
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

		[Required(ErrorMessage = "Please select a gender.")]
		[EnumDataType(typeof(PatientGender))]
		public PatientGender Gender { get; set; }

		[Required(ErrorMessage = "Please select a neutered status.")]
		[EnumDataType(typeof(PatientNeutered))]
		public PatientNeutered Neutered { get; set; }

		[StringLength(CharacteristicsMaxLength, MinimumLength = CharacteristicsMinLength,
			ErrorMessage = CharacteristicsErrorMessage)]
		public string? Characteristics { get; set; }

		[StringLength(ChronicIllnessesMaxLength, MinimumLength = ChronicIllnessesMinLength,
			ErrorMessage = ChronicIllnessesErrorMessage)]
		[Display(Name = "Chronic Illnesses")]
		public string? ChronicIllnesses { get; set; }

		public string OwnerId { get; set; } = null!;
    }
}
