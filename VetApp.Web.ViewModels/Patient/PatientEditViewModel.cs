﻿namespace VetApp.Web.ViewModels.Patient
{
	using System.ComponentModel.DataAnnotations;
	using static Common.ViewModelValidationConstants.PatientConstants;

	public class PatientEditViewModel
	{
        public int Id { get; set; }

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

		[StringLength(CharacteristicsMaxLength, MinimumLength = CharacteristicsMinLength,
			ErrorMessage = CharacteristicsErrorMessage)]
		[Display(Name = "Characteristics")]
		public string? Characteristics { get; set; }

		[StringLength(ChronicIllnessesMaxLength, MinimumLength = ChronicIllnessesMinLength,
			ErrorMessage = ChronicIllnessesErrorMessage)]
		[Display(Name = "Chronic Illnesses")]
		public string? ChronicIllnesses { get; set; }
	}
}
