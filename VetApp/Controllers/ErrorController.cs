namespace VetApp.Controllers
{
	using Microsoft.AspNetCore.Diagnostics;
	using Microsoft.AspNetCore.Mvc;

	public class ErrorController : Controller
	{
		[Route("Error/{statusCode}")]
		public IActionResult Error (int statusCode)
		{
			var statusCodeResult = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();

			switch (statusCode)
			{
				case 400:
					ViewData["ErrorCode"] = "400";
					ViewBag.ErrorMessage = "The request could not be understood by the server due to malformed syntax. Please check your request and try again.";
					break;
				case 404:
                    ViewData["ErrorCode"] = "404";
                    ViewBag.ErrorMessage = "Sorry, the resource you requested could not be found.";
					break;
				case 500:
                    ViewData["ErrorCode"] = "500";
                    ViewBag.ErrorMessage = "Sorry, something went wrong on the server.";
					break;
				default:
					ViewBag.ErrorMessage = "Error";
					break;
			}
			return View("Error");
		}
	}
}
