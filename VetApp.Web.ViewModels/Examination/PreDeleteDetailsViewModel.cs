namespace VetApp.Web.ViewModels.Examination
{
	using System.ComponentModel.DataAnnotations;

	public class PreDeleteDetailsViewModel
	{
		public string Id { get; set; } = null!;

        [Display(Name = "Doctor")]
		public string DoctorName { get; set; } = null!;

		[Display(Name = "Status")]
		public string StatusName { get; set; } = null!;

		[Display(Name = "Patient")]
		public string PatientName { get; set; } = null!;

		public string PatientId { get; set; } = null!;

        public string Reason { get; set; } = null!;

		public double Weight { get; set; }

		[Display(Name = "Created on")]
		public DateTime CreatedOn { get; set; }
	}
}
