namespace VetApp.Web.ViewModels.Patient
{
	public class PatientViewModel
	{
		public int Id { get; set; }

		public string Name { get; set; } = null!;

		public string Type { get; set; } = null!;

		public DateTime? BirthDate { get; set; }

		public string? Microchip { get; set; }

		public string Gender { get; set; } = null!;

		public string Neutered { get; set; } = null!;

		public string? Characteristics { get; set; }

		public string? ChronicIllnesses { get; set; }

		public string OwnerId { get; set; } = null!;

		public string DoctorId { get; set; } = null!;
    }
}
