﻿namespace VetApp.Controllers
{
	using Microsoft.AspNetCore.Mvc;
	using VetApp.Services.Interfaces;

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
	}
}
