namespace VetApp.Controllers
{
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;

	public class HomeController : BaseController
	{
		[AllowAnonymous]
		public IActionResult Index()
		{
			var imagePaths = Directory.GetFiles(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "home"))
								  .Select(path => $"/home/{Path.GetFileName(path)}")
								  .ToList();

			return View(imagePaths);
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		[AllowAnonymous]
		public IActionResult Error(int statusCode)
		{
			if (statusCode == 401)
			{
				return View("Error401");
			}

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
