namespace VetApp.Areas.Admin.Models
{
	using System.ComponentModel.DataAnnotations;
	using static VetApp.Web.Common.ViewModelValidationConstants.AddRoleViewModelConstants;

	public class AddRoleViewModel
	{
		[Required]
		[Display(Name = "Role name")]
		[StringLength(NameMaxLength, MinimumLength = NameMinLength)]
		public string RoleName { get; set; } = null!;
    }
}
