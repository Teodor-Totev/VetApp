namespace VetApp.Web.ViewModels.Patient
{
	using System.ComponentModel.DataAnnotations;
    using VetApp.Data.Common.Enums.Patient;

    public class PatientViewModel
	{
		public string Id { get; set; } = null!;

		public string Name { get; set; } = null!;

		public string OwnerName { get; set; } = null!;

        public string Type { get; set; } = null!;

		public DateTime? BirthDate { get; set; }

		public string? Microchip { get; set; }

        [EnumDataType(typeof(PatientGender))]
        public PatientGender Gender { get; set; }

        [EnumDataType(typeof(PatientNeutered))]
        public PatientNeutered Neutered { get; set; }

		public string? Characteristics { get; set; }

		[Display(Name = "Chronic Illnesses")]
		public string? ChronicIllnesses { get; set; }

		public string OwnerId { get; set; } = null!;

		public string DoctorId { get; set; } = null!;
    }
}
