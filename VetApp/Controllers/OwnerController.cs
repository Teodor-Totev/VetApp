namespace VetApp.Controllers
{
	using Microsoft.AspNetCore.Mvc;
	using VetApp.Services.Interfaces;
	using VetApp.Web.ViewModels.Patient;

	public class OwnerController : BaseController
	{
		private readonly IOwnerService ownerService;

        public OwnerController(IOwnerService ownerService)
        {
            this.ownerService = ownerService;
        }

        public async Task<IActionResult> All(string phoneNumber)
		{
			var model = await ownerService.GetOwnersAsync(phoneNumber);

			return View(model);
		}

		[HttpGet]
		public async Task<IActionResult> Edit(string ownerId)
		{
			var model = await ownerService.GetOwnerByIdAsync(ownerId);

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(OwnerViewModel model ,string ownerId)
		{

			return RedirectToAction("All");
		}
	}
}
