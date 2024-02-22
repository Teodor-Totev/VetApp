namespace VetApp.Data.Models
{
	using Microsoft.AspNetCore.Identity;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;
	using static Common.EntityValidationConstants.ExaminationValidations;

	public class Examination
	{
        [Key]
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public int Weight { get; set; }

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

        public Guid DoctorId { get; set; }

        [ForeignKey(nameof(DoctorId))]
        public ApplicationUser Doctor { get; set; } = null!;

		public int PatientId { get; set; }

		[ForeignKey(nameof(PatientId))]
		public virtual Patient Patient { get; set; } = null!;
    }
}
