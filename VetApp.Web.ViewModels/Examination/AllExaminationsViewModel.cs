namespace VetApp.Web.ViewModels.Examination
{
	public class AllExaminationsViewModel
	{
		public string Id { get; set; } = null!;

		public DateTime CreatedOn { get; set; }

		public double Weight { get; set; }

		public string DoctorName { get; set; } = null!;

		public string Reason { get; set; } = null!;

		public string Status { get; set; } = null!;
	}
}
