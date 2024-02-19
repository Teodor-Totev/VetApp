namespace VetApp.Data.Models
{
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;
	using static Common.EntityValidationConstants.ExaminationValidations;

	public class Examination
	{
        public Examination()
        {
            this.CreatedOn = DateTime.Now;
        }

        [Key]
        public int Id { get; set; }

        public string User { get; set; } = null!;

        public DateTime CreatedOn { get; set; }

        public int? Weight { get; set; }

        public string? Reason { get; set; }

        public string? MedicalHistory { get; set; }

        public string? CurrentCondition { get; set; }

        public string? SpecificCondition { get; set; }

        public string? Research { get; set; }

        public string? Diagnosis { get; set; }

        public string? Surgery { get; set; }

        public string? Therapy { get; set; }

        public string? Exit { get; set; }

        public DateTime? NextExamination { get; set; }

        public int PatientId { get; set; }

		[ForeignKey(nameof(PatientId))]
		public virtual Patient Patient { get; set; } = null!;
    }
}
