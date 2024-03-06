using Microsoft.AspNetCore.Mvc;
using VetApp.Extensions;
using VetApp.Services.Interfaces;
using VetApp.Services.Models.Patient;
using VetApp.Web.ViewModels.Examination;
using VetApp.Web.ViewModels.Owner;
using VetApp.Web.ViewModels.Patient;

namespace VetApp.Controllers
{
	public class PatientController : BaseController
	{
		private readonly IPatientService patientService;
		private readonly IExaminationService examinationService;
		private readonly IOwnerService ownerService;

		public PatientController(IPatientService patientService,
			IExaminationService examinationService,
			IOwnerService ownerService)
		{
			this.patientService = patientService;
			this.examinationService = examinationService;
			this.ownerService = ownerService;
		}

		[HttpGet]
		public async Task<IActionResult> Add(string ownerId)
		{
			if (ownerId == null)
			{
				return View();
			}

			PatientFormModel model = new PatientFormModel();

			if (await this.ownerService.OwnerExistsAsync(ownerId))
			{
				OwnerFormModel owner = await this.ownerService.GetOwnerFormModelByIdAsync(ownerId);
				model.Owner = owner;
			}

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Add(PatientFormModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			int patientId = await patientService.CreateAsync(model);
			TempData["message"] = "Patient Details Saved Successfully";

			return RedirectToAction("Add", "Examination", new { patientId });
		}

		[HttpGet]
		public async Task<IActionResult> All([FromQuery] AllPatientsQueryModel queryModel)
		{
			AllPatientsOrderedAndPagedServiceModel serviceModel =
				await patientService.GetAllPatientsAsync(queryModel);
			ViewBag.UserId = User.Id();

			queryModel.Patients = serviceModel.Patients;
			queryModel.TotalPatients = serviceModel.TotalPatientsCount;

			return View(queryModel);
		}

		[HttpGet]
		public async Task<IActionResult> Details(int patientId)
		{
			PatientViewModel patient = await patientService.GetPatientByIdAsync(patientId);
			ICollection<ExaminationViewModel> examinations = await examinationService.GetPatientExaminationsAsync(patientId);

			PatientDetailsViewModel model = new PatientDetailsViewModel()
			{
				Patient = patient,
				Examinations = examinations
			};


			return View(model);
		}

		[HttpGet]
		public async Task<IActionResult> Edit(int patientId)
		{
			if (!await patientService.PatientExistsAsync(patientId))
			{
				return BadRequest();
			}

			PatientEditViewModel model = await this.patientService.GetPatientForEditByIdAsync(patientId);

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(PatientEditViewModel model, int patientId)
		{
			if (!await patientService.PatientExistsAsync(patientId))
			{
				TempData["error"] = "Patient does not exist";
				return View();
			}

			if (!ModelState.IsValid)
			{
				return View(model);
			}

			await patientService.EditPatientAsync(model, patientId);
			TempData["success"] = "Successfully Updated Patient";

			return RedirectToAction("Details", "Patient", new { patientId });
		}
	}
}
