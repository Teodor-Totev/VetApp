namespace VetApp.Web.ViewModels.Examination
{
	using System.ComponentModel.DataAnnotations;
	using VetApp.Web.ViewModels.Status;
	using static VetApp.Data.Common.EntityValidationConstants.ExaminationValidations;

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

		public string DoctorId { get; set; } = null!;

		[Required(ErrorMessage = "Status is required.")]
		[Display(Name = "Status")]
		[Range(typeof(int),"1","4", ErrorMessage = "Status not valid.")]
		public int StatusId { get; set; }

		[DataType(DataType.Date)]
		[Display(Name = "Created on")]
		public DateTime CreatedOn { get; set; }

		[Range(typeof(double), MinWeight, MaxWeight)]
		public double Weight { get; set; }

		[StringLength(InputFieldMaxLength, MinimumLength = InputFieldMinLength,
			ErrorMessage = "Reason must be between 2 and 50 characters long.")]
		public string Reason { get; set; } = null!;

		[StringLength(MedicalHistoryMaxLength, MinimumLength = MedicalHistoryMinLength,
			ErrorMessage = "MedicalHistory must be between 5 and 200 characters long.")]
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

		[StringLength(DiagnosisMaxLength, MinimumLength = DiagnosisMinLength,
			ErrorMessage = "Diagnosis must be between 5 and 200 characters long.")]
		public string? Diagnosis { get; set; }

		[StringLength(SurgeryMaxLength, MinimumLength = SurgeryMinLength,
			ErrorMessage = "Surgery must be between 5 and 200 characters long.")]
		public string? Surgery { get; set; }

		[StringLength(InputFieldMaxLength, MinimumLength = InputFieldMinLength,
			ErrorMessage = "Therapy must be between 2 and 50 characters long.")]
		public string? Therapy { get; set; }

		[StringLength(InputFieldMaxLength, MinimumLength = InputFieldMinLength,
			ErrorMessage = "Exit must be between 2 and 50 characters long.")]
		public string? Exit { get; set; }

		public IEnumerable<StatusViewModel> Statuses { get; set; }
	}
}
