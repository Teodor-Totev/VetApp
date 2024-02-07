namespace VetApp.Web.ViewModels.Patient
{
	using System.ComponentModel.DataAnnotations;

	using VetApp.Data.Models.Enums;
	using static Common.EntityValidationConstants.Patient;

	public class CreateVM
	{
        public CreateVM()
        {
			this.Genders = new HashSet<PatientGender>();
        }

        [Required]
		[StringLength(NameMaxLength, MinimumLength = NameMinLength, 
			ErrorMessage = "Name must be between 2 and 25 characters long.")]
		public string Name { get; set; } = null!;

		[Required]
		[StringLength(TypeMaxLength, MinimumLength = TypeMinLength,
			ErrorMessage = "Type must be between 2 and 15 characters long.")]
		public string Type { get; set; } = null!;

		[DataType(DataType.DateTime)]
		public DateTime? Age { get; set; }

		[StringLength(MicroChipMaxLength, MinimumLength = MicroChipMinLength,
			ErrorMessage = "Microchip must be between 5 and 50 characters long.")]
		[Display(Name = "Microchip")]
		public string? MicroChip { get; set; }

		[Required]
		[EnumDataType(typeof(GenderType))]
		public GenderType Gender { get; set; }

		public NeuteredType Neutered { get; set; }

		public string? Characteristics { get; set; }

		public string? ChronicIllnesses { get; set; }

		[Required]
		public string OwnerName { get; set; } = null!;

		[Required]
        public string OwnerAddress { get; set; } = null!;

		[Required]
		public string OwnerPhoneNumber { get; set; } = null!;

		public string? OwnerEmail { get; set;}

        public ICollection<PatientGender> Genders { get; set; }
    }
}
