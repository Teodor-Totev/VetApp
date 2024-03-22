namespace VetApp.Data.Models
{
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	using static Common.EntityValidationConstants.ExaminationValidations;

	public class Examination
	{
        public Examination()
        {
            this.Id = Guid.NewGuid();
        }

        [Key]
		public Guid Id { get; set; }

		public DateTime CreatedOn { get; set; }

        public double Weight { get; set; }

        [MaxLength(InputFieldMaxLength)]
        public string Reason { get; set; } = null!;

        [MaxLength(MedicalHistoryMaxLength)]
        public string? MedicalHistory { get; set; }

        [MaxLength(InputFieldMaxLength)]
        public string? CurrentCondition { get; set; }

        [MaxLength(InputFieldMaxLength)]
        public string? SpecificCondition { get; set; }

        [MaxLength(InputFieldMaxLength)]
        public string? Research { get; set; }

        [MaxLength(DiagnosisMaxLength)]
        public string? Diagnosis { get; set; }

        [MaxLength(SurgeryMaxLength)]
        public string? Surgery { get; set; }

        [MaxLength(InputFieldMaxLength)]
        public string? Therapy { get; set; }

        [MaxLength(InputFieldMaxLength)]
        public string? Exit { get; set; }

        public bool IsActive { get; set; }

        public int StatusId { get; set; }

        [ForeignKey(nameof(StatusId))]
        public Status Status { get; set; } = null!;

        public Guid DoctorId { get; set; }

        [ForeignKey(nameof(DoctorId))]
        public ApplicationUser Doctor { get; set; } = null!;

		public Guid PatientId { get; set; }

		[ForeignKey(nameof(PatientId))]
		public virtual Patient Patient { get; set; } = null!;
    }
}
