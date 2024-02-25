namespace VetApp.Web.ViewModels.Owner
{
	using System.ComponentModel.DataAnnotations;
	using static Common.EntityValidationConstants.OwnerValidations;

	public class OwnerFM
	{
		[Required]
		[StringLength(OwnerNameMaxLength, MinimumLength = OwnerNameMinLength)]
		[Display(Name = "Name")]
		public string OwnerName { get; set; } = null!;

		[Required]
		[StringLength(OwnerAddressMaxLength, MinimumLength = OwnerAddressMinLength)]
		[Display(Name = "Address")]
		public string OwnerAddress { get; set; } = null!;

		[Required]
		[StringLength(OwnerPhoneMaxLength, MinimumLength = OwnerPhoneMinLength)]
		[Display(Name = "PhoneNumber")]
		public string OwnerPhoneNumber { get; set; } = null!;

		[DataType(DataType.EmailAddress)]
		[Display(Name = "Email")]
		public string? OwnerEmail { get; set; }
	}
}
