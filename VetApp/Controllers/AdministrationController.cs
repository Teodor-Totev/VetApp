namespace VetApp.Controllers
{
	using Microsoft.AspNetCore.Identity;
	using Microsoft.AspNetCore.Mvc;
	using VetApp.Web.ViewModels.Administration;

	public class AdministrationController : Controller
	{
		private readonly RoleManager<IdentityRole<Guid>> roleManager;

        public AdministrationController(RoleManager<IdentityRole<Guid>> roleManager)
        {
            this.roleManager = roleManager;
        }

		[HttpGet]
        public IActionResult AddRole()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> AddRole(AddRoleViewModel model)
		{
			if (ModelState.IsValid)
			{
				IdentityRole<Guid> role = new()
				{
					Name = model.RoleName
				};

				IdentityResult result = await roleManager.CreateAsync(role);

				if (result.Succeeded)
				{
					return RedirectToAction("Index", "Home");
				}

				foreach (IdentityError error in result.Errors)
				{
					ModelState.AddModelError(string.Empty, error.Description);
				}
			}

			return View(model);
		} 
	}
}
