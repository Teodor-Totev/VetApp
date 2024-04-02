namespace VetApp.Controllers;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using VetApp.Data.Models;
using VetApp.Extensions;
using VetApp.Web.ViewModels.Account;
using static VetApp.Data.Common.AdminUser;

public class AccountController : BaseController
{
	private readonly SignInManager<ApplicationUser> signInManager;
	private readonly UserManager<ApplicationUser> userManager;

	public AccountController(
		SignInManager<ApplicationUser> signInManager,
		UserManager<ApplicationUser> userManager)
	{
		this.signInManager = signInManager;
		this.userManager = userManager;
	}

	[HttpGet]
	[AllowAnonymous]
	public async Task<IActionResult> Login(string? returnUrl = null)
	{
		if (this.signInManager.IsSignedIn(User))
		{
			return RedirectToAction("Index", "Home");
		}

		await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

		LoginViewModel model = new()
		{
			ReturnUrl = returnUrl
		};

		return View(model);
	}

	[HttpPost]
	[AllowAnonymous]
	public async Task<IActionResult> Login(LoginViewModel model)
	{
		if (!ModelState.IsValid)
		{
			return View(model);
		}

		var result = await this.signInManager.PasswordSignInAsync(
			model.Username,
			model.Password,
			model.RememberMe,
			false);

		if (!result.Succeeded)
		{
			ModelState.AddModelError(string.Empty, "Invalit login attempt.");
			return View(model);
		}

		if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
		{
			return Redirect(model.ReturnUrl);
		}
		else
		{
			var user = await userManager.FindByNameAsync(model.Username);

			if (await userManager.IsInRoleAsync(user, AdminRoleName))
			{
				return RedirectToAction("Dashboard", "Home", new { Area = AdminAreaName });
			}

			return RedirectToAction("Index", "Home");
		}
	}

	[HttpGet]
	[AllowAnonymous]
	public IActionResult Register()
	{
		if (this.signInManager.IsSignedIn(User))
		{
			return RedirectToAction("Index", "Home");
		}

		return View();
	}

	[HttpPost]
	[AllowAnonymous]
	public async Task<IActionResult> Register(RegisterViewModel model)
	{
		if (!ModelState.IsValid)
		{
			return this.View(model);
		}

		var user = new ApplicationUser()
		{
			FirstName = model.FirstName,
			LastName = model.LastName,
			Address = model.Address,
		};

		await userManager.SetEmailAsync(user, model.Email);
		await userManager.SetUserNameAsync(user, model.Username);

		var result = await this.userManager.CreateAsync(user, model.Password);

		if (!result.Succeeded)
		{
			foreach (var err in result.Errors)
			{
				ModelState.AddModelError(string.Empty, err.Description);
			}

			return View(model);
		}

		await this.signInManager.SignInAsync(user, false);

		return RedirectToAction("Index", "Home");
	}

	public async Task<IActionResult> Logout()
	{
		await signInManager.SignOutAsync();
		return RedirectToAction("Index", "Home");
	}
}
