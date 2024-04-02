namespace VetApp.Areas.Admin.Models
{
	public class UserRoleViewModel
	{
		public string UserName { get; set; } = null!;

		public string UserId { get; set; } = null!;

        public bool IsSelected { get; set; }
    }
}
