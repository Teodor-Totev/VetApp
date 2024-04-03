﻿namespace VetApp.Web.ViewModels.Patient
{
	using System.ComponentModel.DataAnnotations;

	using static VetApp.Data.Common.EntityValidationConstants.OwnerValidations;

	public class OwnerViewModel
	{
		public string Id { get; set; } = null!;

		[Required]
		[StringLength(NameMaxLength, MinimumLength = NameMinLength)]
		[Display(Name = "Name")]
		public string Name { get; set; } = null!;

		[Required]
		[StringLength(AddressMaxLength, MinimumLength = AddressMinLength)]
		[Display(Name = "Address")]
		public string Address { get; set; } = null!;

		[Required]
		[StringLength(PhoneMaxLength, MinimumLength = PhoneMinLength)]
		[Display(Name = "PhoneNumber")]
		[Phone]
		public string PhoneNumber { get; set; } = null!;

		[DataType(DataType.EmailAddress)]
		[Display(Name = "Email")]
		public string? Email { get; set; }
	}
}
