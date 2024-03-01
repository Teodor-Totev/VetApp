namespace VetApp.Web.ViewModels.Patient
{
	using System.ComponentModel.DataAnnotations;

	using static Common.ViewModelValidationConstants.OwnerViewModelConstants;

	public class OwnerViewModel
	{
		public OwnerViewModel()
		{
			this.Patients = new HashSet<PatientViewModel>();
		}

		public string Id { get; set; } = null!;

		[Required]
		[StringLength(OwnerNameMaxLength, MinimumLength = OwnerNameMinLength)]
		[Display(Name = "Name")]
		public string Name { get; set; } = null!;

		[Required]
		[StringLength(OwnerAddressMaxLength, MinimumLength = OwnerAddressMinLength)]
		[Display(Name = "Address")]
		public string Address { get; set; } = null!;

		[Required]
		[StringLength(OwnerPhoneMaxLength, MinimumLength = OwnerPhoneMinLength)]
		[Display(Name = "PhoneNumber")]
		public string PhoneNumber { get; set; } = null!;

		[DataType(DataType.EmailAddress)]
		[Display(Name = "Email")]
		public string? Email { get; set; }

		public IEnumerable<PatientViewModel> Patients { get; set; }
    }
}
