namespace VetApp.Web.ViewModels.Patient
{
	using System.ComponentModel.DataAnnotations;
	using VetApp.Data.Common.Enums.Patient;

	public class PatientViewModel
	{
		public string Id { get; set; } = null!;

		public string Name { get; set; } = null!;

		public string Type { get; set; } = null!;

		[Display(Name = "Owner Name")]
		public string OwnerName { get; set; } = null!;

		public string OwnerId { get; set; } = null!;

		public PatientGender Gender { get; set; }

		public PatientNeutered Neutered { get; set; }

		[Display(Name = "Birthdate")]
		public DateTime? BirthDate { get; set; }

		public string? Microchip { get; set; }

		public string? Characteristics { get; set; }

		[Display(Name = "Chronic Illnesses")]
		public string? ChronicIllnesses { get; set; }
    }
}
