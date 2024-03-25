namespace VetApp.Controllers
{
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Identity;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.EntityFrameworkCore;
	using VetApp.Data.Models;
	using VetApp.Extensions;
	using VetApp.Web.ViewModels.Administration;

	public class AdministrationController : BaseController
	{
		private readonly RoleManager<IdentityRole<Guid>> roleManager;
		private readonly UserManager<ApplicationUser> userManager;

		public AdministrationController(RoleManager<IdentityRole<Guid>> roleManager,
			UserManager<ApplicationUser> userManager)
		{
			this.roleManager = roleManager;
			this.userManager = userManager;
		}

		[HttpGet]
		public IActionResult All()
		{
			var model = roleManager.Roles.ToArray();
			ViewBag.UserId = User.Id();
			return View(model);
		}

		[HttpGet]
		[AllowAnonymous]
		public IActionResult AddRole()
		{
			return View();
		}

		[HttpPost]
		[AllowAnonymous]
		public async Task<IActionResult> AddRole(AddRoleViewModel model)
		{
			if (ModelState.IsValid)
			{
				if (await roleManager.RoleExistsAsync(model.RoleName) == false)
				{
					IdentityRole<Guid> role = new()
					{
						Name = model.RoleName
					};

					IdentityResult result = await roleManager.CreateAsync(role);

					if (result.Succeeded)
					{
						return RedirectToAction("All", "Administration");
					}

					foreach (IdentityError error in result.Errors)
					{
						ModelState.AddModelError(string.Empty, error.Description);
					}
				}
			}

			return View(model);
		}

		[HttpGet]
		public async Task<IActionResult> EditRole(string roleId)
		{
			var role = await roleManager.Roles.FirstOrDefaultAsync(r => r.Id.ToString() == roleId);

			if (role == null)
			{
				TempData["error"] = $"Role does not exist.";
				RedirectToAction("Index", "Home");
			}

			var model = new EditRoleViewModel()
			{
				Id = role!.Id.ToString(),
				RoleName = role.Name
			};

			var users = userManager.Users.ToList();

			foreach (var user in users)
			{
				if (await this.userManager.IsInRoleAsync(user, role.Name))
				{
					model.Users.Add(user.UserName);
				}
			}

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> EditRole(EditRoleViewModel model)
		{
			var role = await roleManager.Roles.FirstOrDefaultAsync(r => r.Id.ToString() == model.Id);

			if (role == null)
			{
				TempData["error"] = $"Role does not exist.";
				RedirectToAction("Index", "Home");
			}
			else
			{
				role.Name = model.RoleName;
				var result = await this.roleManager.UpdateAsync(role);

				if (result.Succeeded)
				{
					return RedirectToAction("All");
				}

				foreach (var error in result.Errors)
				{
					ModelState.AddModelError(string.Empty, error.Description);
				}

			}

			return View(model);
		}
	}
}
