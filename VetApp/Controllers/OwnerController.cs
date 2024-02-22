namespace VetApp.Controllers
{
	using Microsoft.AspNetCore.Mvc;

	public class OwnerController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
