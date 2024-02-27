namespace VetApp.Web.ViewModels.Examination
{
	using System.ComponentModel.DataAnnotations;

	public class ExaminationVM
	{
		public int Id { get; set; }

        [DataType(DataType.Date)]
		public DateTime CreatedOn { get; set; }

		public double Weight { get; set; }

		public string DoctorName { get; set; } = null!;

        public string? Diagnosis { get; set; }

		public string Reason { get; set; } = null!;

		public string? Surgery { get; set; }

		public string? Therapy { get; set; }
	}
}
