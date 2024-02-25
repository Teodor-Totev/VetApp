namespace VetApp.Controllers
{
	using Microsoft.AspNetCore.Mvc;
	using VetApp.Services.Interfaces;

	public class OwnerController : Controller
	{
		private readonly IOwnerService ownerService;

        public OwnerController(IOwnerService ownerService)
        {
            this.ownerService = ownerService;
        }

		[HttpPost]
        public async Task<IActionResult> All(string phoneNumber)
		{
			var model = await ownerService.GetOwnersWithTheirPatientsByPhoneNumberAsync(phoneNumber);

			return View(model);
		}
	}
}
