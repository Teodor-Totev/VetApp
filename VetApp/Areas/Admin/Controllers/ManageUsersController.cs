namespace VetApp.Areas.Admin.Controllers
{
	using Microsoft.AspNetCore.Identity;
	using Microsoft.AspNetCore.Mvc;

	using VetApp.Data.Models;

	public class ManageUsersController : AdminBaseController
	{
		private readonly RoleManager<IdentityRole<Guid>> roleManager;
		private readonly UserManager<ApplicationUser> userManager;

		public ManageUsersController(
			RoleManager<IdentityRole<Guid>> roleManager,
			UserManager<ApplicationUser> userManager)
		{
			this.roleManager = roleManager;
			this.userManager = userManager;
		}
		public IActionResult Index()
		{
			return View();
		}

		[HttpGet]
		public IActionResult All()
		{
			var model = userManager.Users.ToArray();
			return View(model);
		}
	}
}
