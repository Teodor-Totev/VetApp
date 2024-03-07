namespace VetApp.Controllers;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using VetApp.Data.Models;
using VetApp.Web.ViewModels.Account;

public class AccountController : Controller
{
	private SignInManager<ApplicationUser> signInManager;
	private UserManager<ApplicationUser> userManager;

	public AccountController(
		SignInManager<ApplicationUser> signInManager,
		UserManager<ApplicationUser> userManager)
	{
		this.signInManager = signInManager;
		this.userManager = userManager;
	}

	[HttpGet]
	public async Task<IActionResult> Login(string? returnUrl = null)
	{
		await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

		LoginViewModel loginVM = new LoginViewModel()
		{
			ReturnUrl = returnUrl
		};

		return View(loginVM);
	}

	[HttpPost]
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

		return Redirect(model.ReturnUrl ?? "/Patient/All");
	}

	[HttpGet]
	public IActionResult Register()
	{
		return View();
	}

	[HttpPost]
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
