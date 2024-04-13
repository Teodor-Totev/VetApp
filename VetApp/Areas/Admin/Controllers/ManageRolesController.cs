namespace VetApp.Areas.Admin.Controllers
{
	using Microsoft.AspNetCore.Identity;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.EntityFrameworkCore;

	using VetApp.Areas.Admin.Models;
	using VetApp.Data.Models;
	using VetApp.Extensions;

	public class ManageRolesController : AdminBaseController
	{
		private readonly RoleManager<IdentityRole<Guid>> roleManager;
		private readonly UserManager<ApplicationUser> userManager;

		public ManageRolesController(
			RoleManager<IdentityRole<Guid>> roleManager,
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
		public IActionResult AddRole()
		{
			return View();
		}

		[HttpPost]
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
						return RedirectToAction("All");
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
				TempData["error"] = "Role does not exist.";
				return RedirectToAction("Index", "Home");
			}

			var model = new EditRoleViewModel()
			{
				Id = role.Id.ToString(),
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
				TempData["error"] = "Role does not exist.";
				return RedirectToAction("All");
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

		[HttpGet]
		public async Task<IActionResult> EditUsersInRole(string roleId)
		{
			ViewBag.RoleId = roleId;

			IdentityRole<Guid> role = await roleManager.FindByIdAsync(roleId);

			if (role == null)
			{
				TempData["error"] = "Role does not exist.";
				return RedirectToAction("All");
			}

			List<UserRoleViewModel> model = new();

			List<ApplicationUser> users = await userManager.Users.ToListAsync();

			foreach (var user in users)
			{
				bool isUserInRole = await userManager.IsInRoleAsync(user, role.Name);

				model.Add(new UserRoleViewModel()
				{
					UserId = user.Id.ToString(),
					UserName = user.UserName,
					IsSelected = isUserInRole
				});
			}

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> EditUsersInRole(List<UserRoleViewModel> model, string roleId)
		{
			IdentityRole<Guid> role = await roleManager.FindByIdAsync(roleId);

			if (role == null)
			{
				TempData["error"] = "Role does not exist.";
				return RedirectToAction("All");
			}

			foreach (var userRole in model)
			{
				ApplicationUser user = await userManager.FindByIdAsync(userRole.UserId);

				if (user == null)
				{
					continue;
				}

				bool isInRole = await userManager.IsInRoleAsync(user, role.Name);

				if (userRole.IsSelected && !isInRole)
				{
					await userManager.AddToRoleAsync(user, role.Name);
				}
				else if (!userRole.IsSelected && isInRole)
				{
					await userManager.RemoveFromRoleAsync(user, role.Name);
				}
			}

			return RedirectToAction("EditRole", new { roleId });
		}

		[HttpPost]
		public async Task<IActionResult> DeleteRole(string roleId)
		{
			var role = await roleManager.FindByIdAsync(roleId);

			if (role == null)
			{
				TempData["error"] = "Role cannot be found";
				return RedirectToAction("All");
			}

			var result = await roleManager.DeleteAsync(role);

			if (result.Succeeded)
			{
				TempData["success"] = "Successfully delete role";
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
