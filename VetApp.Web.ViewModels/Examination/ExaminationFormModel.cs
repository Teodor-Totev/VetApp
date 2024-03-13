namespace VetApp.Web.ViewModels.Examination
{
	using System.ComponentModel.DataAnnotations;

	using VetApp.Web.ViewModels.Patient;
	using VetApp.Web.ViewModels.Status;
	using static Common.ViewModelValidationConstants.ExaminationFormModelConstants;

	public class ExaminationFormModel
	{
		public ExaminationFormModel()
		{
			this.Statuses = new HashSet<StatusViewModel>();
			if (this.CreatedOn == default)
			{
				this.CreatedOn = DateTime.Now;
			}
		}

		public string Id { get; set; } = null!;

		public string DoctorId { get; set; } = null!;

		public string DoctorName { get; set; } = null!;

		public PatientViewModel Patient { get; set; } = null!;

		public int StatusId { get; set; }

		[DataType(DataType.Date)]
		[Display(Name = "Created on")]
		public DateTime CreatedOn { get; set; }

		public double Weight { get; set; }

		[StringLength(InputFieldMaxLength, MinimumLength = InputFieldMinLength,
			ErrorMessage = "Reason must be between 2 and 50 characters long.")]
		public string Reason { get; set; } = null!;

		[StringLength(InputFieldMaxLength, MinimumLength = InputFieldMinLength,
			ErrorMessage = "MedicalHistory must be between 2 and 50 characters long.")]
		public string? MedicalHistory { get; set; }

		[StringLength(InputFieldMaxLength, MinimumLength = InputFieldMinLength,
			ErrorMessage = "CurrentCondition must be between 2 and 50 characters long.")]
		public string? CurrentCondition { get; set; }

		[StringLength(InputFieldMaxLength, MinimumLength = InputFieldMinLength,
			ErrorMessage = "SpecificCondition must be between 2 and 50 characters long.")]
		public string? SpecificCondition { get; set; }

		[StringLength(InputFieldMaxLength, MinimumLength = InputFieldMinLength,
			ErrorMessage = "Research must be between 2 and 50 characters long.")]
		public string? Research { get; set; }

		[StringLength(TextAreaMaxLength, MinimumLength = TextAreaMinLength,
			ErrorMessage = "Diagnosis must be between 5 and 200 characters long.")]
		public string? Diagnosis { get; set; }

		[StringLength(TextAreaMaxLength, MinimumLength = TextAreaMinLength,
			ErrorMessage = "Surgery must be between 5 and 200 characters long.")]
		public string? Surgery { get; set; }

		[StringLength(InputFieldMaxLength, MinimumLength = InputFieldMinLength,
			ErrorMessage = "Therapy must be between 2 and 50 characters long.")]
		public string? Therapy { get; set; }

		[StringLength(InputFieldMaxLength, MinimumLength = InputFieldMinLength,
			ErrorMessage = "Exit must be between 2 and 50 characters long.")]
		public string? Exit { get; set; }

		public ICollection<StatusViewModel> Statuses { get; set; }
	}
}
