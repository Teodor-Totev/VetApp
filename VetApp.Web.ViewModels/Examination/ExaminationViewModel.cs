namespace VetApp.Web.ViewModels.Examination
{
	using System.ComponentModel.DataAnnotations;

	public class ExaminationViewModel
    {
        public string Id { get; set; } = null!;

		[Display(Name = "Created on")]
		public DateTime CreatedOn { get; set; }

		public string Reason { get; set; } = null!;

        public string StatusName { get; set; } = null!;
		
		public string DoctorName { get; set; } = null!;

        public int TotalCount { get; set; }

        public string PatientId { get; set; } = null!;
    }
}
