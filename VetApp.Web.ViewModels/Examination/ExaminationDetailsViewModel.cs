namespace VetApp.Web.ViewModels.Examination
{
	public class ExaminationDetailsViewModel
	{
		public string Id { get; set; } = null!;

		public DateTime CreatedOn { get; set; }

		public double Weight { get; set; }

		public string Reason { get; set; } = null!;

		public string? MedicalHistory { get; set; }

		public string? CurrentCondition { get; set; }

		public string? SpecificCondition { get; set; }

		public string? Research { get; set; }

		public string? Diagnosis { get; set; }

		public string? Surgery { get; set; }

		public string? Therapy { get; set; }

		public string? Exit { get; set; }

		public DateTime? NextExamination { get; set; }

		public int StatusId { get; set; }
	}
}
