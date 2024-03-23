namespace VetApp.Controllers
{
	using Microsoft.AspNetCore.Mvc;
	using VetApp.Services.Interfaces;
	using VetApp.Services.Models.Owner;
	using VetApp.Services.Models.Patient;
	using VetApp.Web.Common.Helpers;
	using VetApp.Web.ViewModels.Owner;
	using VetApp.Web.ViewModels.Patient;

	public class OwnerController : BaseController
	{
		private readonly IOwnerService ownerService;
		private readonly IPatientService patientService;


		public OwnerController(IOwnerService ownerService, IPatientService patientService)
		{
			this.ownerService = ownerService;
			this.patientService = patientService;
		}

		[HttpGet]
		public async Task<IActionResult> All([FromQuery] AllOwnersQueryModel queryModel)
		{
			try
			{
				AllOwnersOrderedAndPagedServiceModel serviceModel =
					await ownerService.GetAllOwnersAsync(queryModel);

				queryModel.Owners = serviceModel.Owners;
				Pager pager =
					new(queryModel.CurrentPage, queryModel.OwnersPerPage, serviceModel.TotalOwnersCount);
				ViewBag.Pager = pager;

				return View(queryModel);
			}
			catch (Exception ex)
			{
				TempData["error"] = ex.Message;
				return RedirectToAction("Index", "Home");
			}
		}

		[HttpGet]
		public async Task<IActionResult> Edit(string ownerId)
		{
			if (string.IsNullOrEmpty(ownerId))
			{
				TempData["error"] = "Owner Id is required.";
				return RedirectToAction("All", "Owner");
			}

			try
			{
				if (!await this.ownerService.OwnerExistsAsync(ownerId))
				{
					TempData["error"] = "Owner does not exist.";
					return RedirectToAction("All", "Owner");
				}

				var model = await ownerService.GetOwnerForEditByIdAsync(ownerId);
				ViewBag.OwnerId = ownerId;

				return View(model);
			}
			catch (Exception ex)
			{
				TempData["error"] = ex.Message;
				return RedirectToAction("All", "Owner");
			}
		}

		[HttpPost]
		public async Task<IActionResult> Edit(OwnerFormModel model, string ownerId)
		{
			if (string.IsNullOrEmpty(ownerId))
			{
				TempData["error"] = "Owner Id is required.";
				return RedirectToAction("All", "Owner");
			}

			try
			{
				if (!await this.ownerService.OwnerExistsAsync(ownerId))
				{
					TempData["error"] = "Owner does not exist.";
					return RedirectToAction("All", "Owner");
				}

				if (!ModelState.IsValid)
				{
					return View(model);
				}

				await this.ownerService.EditOwnerAsync(model, ownerId);
				TempData["success"] = "Owner was edited successfully.";

				return RedirectToAction("All", "Owner");
			}
			catch (Exception ex)
			{
				TempData["error"] = ex.Message;
				return RedirectToAction("Index", "Home");
			}
		}

		[HttpGet]
		public async Task<IActionResult> Details(string ownerId, int currentPage = 1)
		{
			if (string.IsNullOrEmpty(ownerId))
			{
				TempData["error"] = "Owner Id is required.";
				return RedirectToAction("All", "Owner");
			}

			try
			{
				OwnerViewModel owner = await this.ownerService.GetOwnerByIdAsync(ownerId);

				OwnerPetsServiceModel serviceModel = await this.patientService.GetOwnerPetsAsync(ownerId, currentPage);
				Pager pager = new(currentPage, 2, serviceModel.TotalItems);
				ViewBag.Pager = pager;

				OwnerDetailsViewModel model = new OwnerDetailsViewModel()
				{
					Owner = owner,
					Patients = serviceModel.Patients
				};

				return View(model);
			}
			catch (InvalidOperationException)
			{
				TempData["error"] = "Owner does not exist.";
				return RedirectToAction("All", "Owner");
			}
			catch (Exception ex)
			{
				TempData["error"] = ex.Message;
				return RedirectToAction("All", "Owner");
			}
		}
	}
}
