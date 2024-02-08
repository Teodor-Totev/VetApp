namespace VetApp.Data.Models
{
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;
	using static Common.EntityValidationConstants.ExaminationValidations;

	public class Examination
	{
		[Key]
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

		[Required]
		[MaxLength(DescMaxLength)]
        public string Description { get; set; } = null!;

		[Required]
		[MaxLength(StateMaxLength)]
		public string State { get; set; } = null!;

        public int? PatientId { get; set; }

		[ForeignKey(nameof(PatientId))]
		public Patient? Patient { get; set; }
    }
}
