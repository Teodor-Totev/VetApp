namespace VetApp.Controllers;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using VetApp.Data.Models;
using VetApp.Web.ViewModels.Account;

public class AccountController : Controller
{
	private SignInManager<VetUser> signInManager;
	private UserManager<VetUser> userManager;

	public AccountController(
		SignInManager<VetUser> signInManager, 
		UserManager<VetUser> userManager)
	{
		this.signInManager = signInManager;
		this.userManager = userManager;
	}

    [HttpGet]
	public IActionResult Login()
	{
		return View();
	}

	[HttpPost]
	public async Task<IActionResult> Login(LoginVM model)
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

		if (result.Succeeded)
		{
			return RedirectToAction("Index", "Home");
		}

		ModelState.AddModelError(string.Empty, "Invalit login attempt.");

		return View(model);
	}

	[HttpGet]
	public IActionResult Register()
	{
		return View();
	}

	[HttpPost]
	public async Task<IActionResult> Register(RegisterVM model)
	{
		if (ModelState.IsValid)
		{
			var user = new VetUser()
			{
				Name = model.Username,
				UserName = model.Username,
				Email = model.Email,
				Address = model.Address,
			};

			var result = await this.userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await this.signInManager.SignInAsync(user, false);

                return RedirectToAction("Index", "Home");
            }

            foreach (var err in result.Errors)
            {
                ModelState.AddModelError("", err.Description);
            }
        }

		return View(model);
	}

	public async Task<IActionResult> Logout()
	{
		await signInManager.SignOutAsync();
		return RedirectToAction("Index", "Home");
	}
}
