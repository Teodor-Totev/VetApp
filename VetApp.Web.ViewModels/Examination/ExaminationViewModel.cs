namespace VetApp.Web.ViewModels.Examination
{
	public class ExaminationViewModel
	{
		public int Id { get; set; }

		public DateTime CreatedOn { get; set; }

		public double Weight { get; set; }

		public string? MedicalHistory { get; set; }

		public string DoctorName { get; set; } = null!;

        public string? Diagnosis { get; set; }

		public string Reason { get; set; } = null!;

		public string? Surgery { get; set; }

		public string? Therapy { get; set; }

		public string Status { get; set; } = null!;

		public string? CurrentCondition { get; set; }

		public string? SpecificCondition { get; set; }

		public string? Research { get; set; }

		public string? Exit { get; set; }
	}
}