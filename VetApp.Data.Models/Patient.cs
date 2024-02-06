namespace VetApp.Data.Models
{
	using System.ComponentModel.DataAnnotations;

	using VetApp.Data.Models.Enums;

	using static Common.EntityValidationConstants.Patient;

	public class Patient
	{
        public Patient()
        {
            this.Id = Guid.NewGuid();
            this.PatientsUsers = new HashSet<PatientUser>();
		}

        [Key]
		public Guid Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(TypeMaxLength)]
        public string Type { get; set; } = null!;

		public DateTime? Age { get; set; }

		[MaxLength(MicroChipMinLength)]
        public string? MicroChip { get; set; }

        [Required]
		public GenderType Gender { get; set; }

		public NeuteredType Neutered { get; set; }

        public string? Characteristics { get; set; }

        public string? ChronicIllnesses { get; set; }

        public virtual Owner Owner{ get; set; } = null!;

		public Guid OwnerId { get; set; }

        public virtual ICollection<PatientUser> PatientsUsers { get; set; }
    }
}