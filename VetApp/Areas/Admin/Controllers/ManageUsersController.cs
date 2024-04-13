namespace VetApp.Areas.Admin.Controllers
{
	using Microsoft.AspNetCore.Identity;
	using Microsoft.AspNetCore.Mvc;

	using VetApp.Data.Models;

	public class ManageUsersController : AdminBaseController
	{
		private readonly UserManager<ApplicationUser> userManager;

		public ManageUsersController(
			UserManager<ApplicationUser> userManager)
		{
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

		[HttpPost]
		public async Task<IActionResult> DeleteUser(string userId)
		{
			var user = await userManager.FindByIdAsync(userId);

			if (user == null)
			{
				TempData["error"] = "User cannot be found";
				return RedirectToAction("All");
			}

			var result = await userManager.DeleteAsync(user);

			if (result.Succeeded)
			{
				TempData["success"] = "Successfully delete user";
				return RedirectToAction("All");
			}

			foreach (var error in result.Errors)
			{
				ModelState.AddModelError(string.Empty, error.Description);
			}

			return RedirectToAction("All");
		}
	}
}
