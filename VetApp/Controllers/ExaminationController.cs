namespace VetApp.Controllers
{
	using Microsoft.AspNetCore.Mvc;

	using VetApp.Extensions;
	using VetApp.Services.Interfaces;
	using VetApp.Web.ViewModels.Examination;
	using VetApp.Web.ViewModels.Patient;
	using VetApp.Web.ViewModels.Status;

	public class ExaminationController : BaseController
	{
		private readonly IExaminationService examinationService;
		private readonly IPatientService patientService;
		private readonly IStatusService statusService;
		private readonly IWebHostEnvironment webHostEnvironment;
		private readonly IAccountService accountService;

		public ExaminationController(IExaminationService examinationService,
			IPatientService patientService, IStatusService statusService,
			IWebHostEnvironment webHostEnvironment, IAccountService accountService)
		{
			this.examinationService = examinationService;
			this.patientService = patientService;
			this.statusService = statusService;
			this.webHostEnvironment = webHostEnvironment;
			this.accountService = accountService;
		}

		[HttpGet]
		public async Task<IActionResult> Add(string patientId)
		{
			if (string.IsNullOrEmpty(patientId))
			{
				TempData["error"] = "Patient Id is required.";
				return RedirectToAction("All", "Patient");
			}

			try
			{
				var patient = await patientService.GetPatientByIdAsync(patientId);
				var statuses = await statusService.AllStatusesAsync();
				ViewBag.DoctorFullName =
					await accountService.GetUserFullNameByUsernameAsync(User.Identity?.Name!);

				ExaminationFormModel examinationFormModel = new()
				{
					DoctorId = User.Id(),
					Statuses = statuses,
				};

				AddAndEditExaminationViewModel model = new()
				{
					Patient = patient,
					Examination = examinationFormModel
				};

				return View(model);
			}
			catch (InvalidOperationException)
			{
				TempData["error"] = "Patient does not exist.";
				return RedirectToAction("All", "Patient");
			}
			catch (Exception ex)
			{
				TempData["error"] = ex.Message;
				return RedirectToAction("Index", "Home");
			}
		}

		[HttpPost]
		public async Task<IActionResult> Add(AddAndEditExaminationViewModel model, string patientId)
		{
			if (string.IsNullOrEmpty(patientId))
			{
				TempData["error"] = "Patient Id is required.";
				return RedirectToAction("All", "Patient");
			}

			try
			{
				PatientViewModel patient = await patientService.GetPatientByIdAsync(patientId);

				IEnumerable<StatusViewModel> statuses =
					await statusService.AllStatusesAsync();

				if (!ModelState.IsValid)
				{
					model.Patient = patient;
					model.Examination.Statuses = statuses;

					return View(model);
				}

				await this.examinationService.AddAsync(model.Examination, patientId, User.Id());
				TempData["success"] = "Successfully Added Examination";

				return RedirectToAction("Details", "Patient", new { patientId });
			}
			catch (InvalidOperationException)
			{
				TempData["error"] = "Patient does not exist.";
				return RedirectToAction("All", "Patient");
			}
			catch (Exception ex)
			{
				TempData["error"] = ex.Message;
				return RedirectToAction("Index", "Home");
			}
		}

		[HttpGet]
		public async Task<IActionResult> All()
		{
			IEnumerable<AllExaminationsViewModel> model =
				await examinationService.GetAllExaminationsAsync();

			return View(model);
		}

		//[HttpGet]
		//public async Task<IActionResult> Edit(string examinationId)
		//{
		//	ExaminationFormModel model = await examinationService.GetExaminationByIdAsync(examinationId);
		//	PatientViewModel patient = await patientService.GetPatientByIdAsync(model.PatientId);
		//	IEnumerable<StatusViewModel> statuses = await statusService.AllStatusesAsync();

		//	model.Patient = patient;
		//	model.Statuses = statuses;
		//	ViewBag.ExaminationId = examinationId;

		//	return View(model);
		//}

		[HttpPost]
		public async Task<IActionResult> Edit(ExaminationFormModel model, string examinationId)
		{
			await examinationService.EditExaminationAsync(model, examinationId);

			return RedirectToAction("Index", "Home");
		}

		[HttpGet]
		public IActionResult Upload()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Upload(List<IFormFile> files)
		{
			var uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "files");

			if (!Directory.Exists(uploadsFolder))
			{
				Directory.CreateDirectory(uploadsFolder);
			}

			foreach (var file in files.Where(f => f.Length > 0))
			{
				string fileName = Path.GetFileName(file.FileName);
				string fileSavePath = Path.Combine(uploadsFolder, fileName);
				int coutner = 0;

				using (var stream = new FileStream(fileSavePath, FileMode.Create))
				{
					await file.CopyToAsync(stream);
					coutner++;
				}

				ViewBag.FileMessage = coutner + " uploaded successfully";
			}

			return View();
		}


		[HttpGet]
		public async Task<IActionResult> Dashboard()
		{
			var model = await examinationService.GetExaminationsGroupedByStatus();

			return View(model);
		}

		[HttpGet]
		public async Task<IActionResult> Details(string examinationId)
		{
			var model = await examinationService.GetExaminationDetailsByIdAsync(examinationId);

			return View(model);
		}
	}
}
