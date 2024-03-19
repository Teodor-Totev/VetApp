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
				PatientViewModel patient = await patientService.GetPatientByIdAsync(patientId);
				IEnumerable<StatusViewModel> statuses = await statusService.AllStatusesAsync();
				ViewBag.DoctorFullName =
					await accountService.GetUserFullNameByUsernameAsync(User.Identity?.Name!);

				ExaminationFormModel examination = new()
				{
					DoctorId = User.Id(),
				};

				AddAndEditExaminationViewModel model = new()
				{
					Patient = patient,
					Examination = examination
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

				if (!ModelState.IsValid)
				{
					model.Patient = patient;
					model.Examination = new ExaminationFormModel()
					{
						DoctorId = User.Id(),
					};

					return View(model);
				}

				if (model.Examination.StatusId != 4)
				{
					TempData["error"] = "Examination status must be 'New' for adding a new examination.";
					return RedirectToAction("Index", "Home");
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
			IEnumerable<ExaminationViewModel> model =
				await examinationService.GetAllExaminationsAsync();

			return View(model);
		}

		[HttpGet]
		public async Task<IActionResult> Edit(string examinationId, string patientId)
		{
			if (string.IsNullOrEmpty(examinationId))
			{
				TempData["error"] = "Examination Id is required";
				return RedirectToAction("Index", "Home");
			}

			if (string.IsNullOrEmpty(patientId))
			{
				TempData["error"] = "Patient Id is required";
				return RedirectToAction("Index", "Home");
			}

			try
			{
				PatientViewModel patient = await patientService.GetPatientByIdAsync(patientId);
				ExaminationFormModel examination = await examinationService.GetExaminationByIdAsync(examinationId);
				examination.Statuses = await statusService.AllStatusesAsync();

				ViewBag.ExaminationId = examinationId;
				ViewBag.DoctorFullName =
						await accountService.GetUserFullNameByUsernameAsync(User.Identity?.Name!);

				AddAndEditExaminationViewModel model = new()
				{
					Patient = patient,
					Examination = examination,
				};

				return View(model);
			}
			catch (InvalidOperationException)
			{
				TempData["error"] = "Patient or Examination does not exist.";
				return RedirectToAction("All", "Patient");
			}
			catch (Exception ex)
			{
				TempData["error"] = ex.Message;
				return RedirectToAction("Index", "Home");
			}

		}

		[HttpPost]
		public async Task<IActionResult> Edit(AddAndEditExaminationViewModel model, string examinationId, string patientId)
		{
			if (string.IsNullOrEmpty(examinationId))
			{
				TempData["error"] = "Examination Id is required";
				return RedirectToAction("Index", "Home");
			}

			if (string.IsNullOrEmpty(patientId))
			{
				TempData["error"] = "Patient Id is required";
				return RedirectToAction("Index", "Home");
			}

			try
			{
				PatientViewModel patient = await patientService.GetPatientByIdAsync(patientId);

				if (!ModelState.IsValid)
				{
					model.Patient = patient;
					model.Examination.Statuses = await statusService.AllStatusesAsync();
					return View(model);
				}

				await examinationService.EditExaminationAsync(model.Examination, examinationId);
				TempData["success"] = "Successfully Edited Examination";
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
