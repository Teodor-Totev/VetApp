namespace VetApp.Data.Models
{
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

    using VetApp.Data.Common.Enums.Patient;
    using static Common.EntityValidationConstants.PatientValidations;

	public class Patient
	{
        public Patient()
        {
            this.PatientsUsers = new HashSet<PatientUser>();
            this.Examinations = new HashSet<Examination>();
		}

        [Key]
		public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(TypeMaxLength)]
        public string Type { get; set; } = null!;

		public DateTime? BirthDate { get; set; }

		[MaxLength(MicroChipMinLength)]
        public string? Microchip { get; set; }

        [Required]
        [EnumDataType(typeof(PatientGender))]
        public PatientGender Gender { get; set; }

        [Required]
        [EnumDataType(typeof(PatientNeutered))]
		public PatientNeutered Neutered { get; set; }

        public bool IsActive { get; set; }

        public string? Characteristics { get; set; }

        public string? ChronicIllnesses { get; set; }

		public Guid OwnerId { get; set; }

        [ForeignKey(nameof(OwnerId))]
        public virtual Owner Owner{ get; set; } = null!;

        public virtual ICollection<Examination> Examinations { get; set; }

        public virtual ICollection<PatientUser> PatientsUsers { get; set; }
    }
}