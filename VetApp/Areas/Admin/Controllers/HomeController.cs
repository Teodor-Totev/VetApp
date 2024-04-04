namespace VetApp.Areas.Admin.Controllers
{
	using Microsoft.AspNetCore.Mvc;

	public class HomeController : AdminBaseController
	{
		public IActionResult Dashboard()
		{
			return View();
		}
	}
}
