namespace VetApp.Web.ViewModels.Examination
{
	using System.ComponentModel.DataAnnotations;
	using VetApp.Web.ViewModels.Patient;
	using VetApp.Web.ViewModels.Status;
	using static Common.EntityValidationConstants.ExaminationValidations;

	public class ExaminationFM
    {
        public ExaminationFM()
        {
            this.Statuses = new HashSet<StatusVM>();
			this.CreatedOn = DateTime.Now;
        }

        public int Id { get; set; }

        public int PatientId { get; set; }

        public string DoctorId { get; set; } = null!;

        public string DoctorName { get; set; } = null!;

		public PatientVM Patient { get; set; } = null!;

		public int StatusId { get; set; }

		public DateTime CreatedOn { get; set; }

        public double Weight { get; set; }

        [MaxLength(TextMaxLength)]
        public string Reason { get; set; } = null!;

        [MaxLength(TextMaxLength)]
        public string? MedicalHistory { get; set; }

        [MaxLength(TextMaxLength)]
        public string? CurrentCondition { get; set; }

        [MaxLength(TextMaxLength)]
        public string? SpecificCondition { get; set; }

        [MaxLength(TextMaxLength)]
        public string? Research { get; set; }

        [MaxLength(TextMaxLength)]
        public string? Diagnosis { get; set; }

        [MaxLength(TextMaxLength)]
        public string? Surgery { get; set; }

        [MaxLength(TextMaxLength)]
        public string? Therapy { get; set; }

        [MaxLength(TextMaxLength)]
        public string? Exit { get; set; }

        public DateTime? NextExamination { get; set; }

        public ICollection<StatusVM> Statuses { get; set; }
    }
}
