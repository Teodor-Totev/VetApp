namespace VetApp.Web.ViewModels.Administration
{
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;

	public class EditRoleViewModel
	{
		public EditRoleViewModel()
		{
			this.Users = new List<string>();
		}

		public string Id { get; set; } = null!;

		[Required]
		[Display(Name = "Role name")]
		public string RoleName { get; set; } = null!;

		public List<string> Users { get; set; }
	}
}
