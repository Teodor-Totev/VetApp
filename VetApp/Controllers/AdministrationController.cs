﻿namespace VetApp.Controllers
{
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Identity;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.EntityFrameworkCore;
	using VetApp.Data.Models;
	using VetApp.Extensions;
	using VetApp.Web.ViewModels.Administration;

	[Authorize(Roles = "Admin")]
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

			for (int i = 0; i < model.Count; i++)
			{
				ApplicationUser user = await userManager.FindByIdAsync(model[i].UserId);

				IdentityResult result = null;

				if (model[i].IsSelected && !(await userManager.IsInRoleAsync(user, role.Name)))
				{
					result = await userManager.AddToRoleAsync(user, role.Name);
				}
				else if (!model[i].IsSelected && await userManager.IsInRoleAsync(user, role.Name))
				{
					result = await userManager.RemoveFromRoleAsync(user, role.Name);
				}
				else
				{
					continue;
				}

				if (result.Succeeded)
				{
					if(i < (model.Count - 1))
					{
						continue;
					}
					else
					{
						return RedirectToAction("EditRole", new { roleId });
					}
				}
			}

			return RedirectToAction("EditRole", new { roleId });
		}
	}
}
