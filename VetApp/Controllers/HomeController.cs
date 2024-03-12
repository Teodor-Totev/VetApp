namespace VetApp.Controllers
{
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;

	public class HomeController : BaseController
	{
		[AllowAnonymous]
		public IActionResult Index()
		{
			if (User.Identity!.IsAuthenticated)
			{
				return RedirectToAction("Dashboard", "Examination");
			}
			else
			{
				return View();
			}
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error(int statusCode)
		{
			if (statusCode == 404)
			{
				return View("Error404");
			}

			if (statusCode == 500)
			{
				return View("Error500");
			}

			return View();
		}
	}
}
