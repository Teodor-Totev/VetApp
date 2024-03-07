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

			var exceptionHandlerPathFeature =
			HttpContext.Features.Get<IExceptionHandlerPathFeature>();

			var exception = exceptionHandlerPathFeature?.Error;

			switch (statusCode)
			{
				case 400:
					ViewData["ErrorCode"] = "400";
					ViewBag.ErrorMessage = exception?.Message;
					break;
				case 404:
					ViewData["ErrorCode"] = "404";
					ViewBag.ErrorMessage = exception?.Message;
					break;
				case 500:
					ViewData["ErrorCode"] = "500";
					ViewBag.ErrorMessage = exception?.Message;
					break;
				default:
					ViewBag.ErrorMessage = "Error";
					ViewBag.ErrorMessage = exception?.Message;
					break;
			}

			return View("Error");
		}
	}
}
