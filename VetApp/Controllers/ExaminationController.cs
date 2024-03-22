namespace VetApp.Controllers
{
	using Microsoft.AspNetCore.Mvc;

	using VetApp.Extensions;
	using VetApp.Services.Interfaces;
	using VetApp.Web.Common.Helpers;
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
				TempData["success"] = "Examination was added successfully.";

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
		public async Task<IActionResult> All(int currentPage = 1, int pageSize = 5)
		{
			IEnumerable<ExaminationViewModel> examinations =
				await examinationService.GetAllExaminationsAsync();

			if (currentPage < 1)
			{
				currentPage = 1;
			}

			int totalItems = examinations.Count();

			Pager pager = new(currentPage, pageSize, totalItems);

			int skip = (currentPage - 1) * pageSize;

			var model = examinations.Skip(skip).Take(pager.PageSize).ToArray();

			ViewBag.Pager = pager;

			return View(model);
		}

		[HttpGet]
		public async Task<IActionResult> Edit(string examinationId, string patientId)
		{
			if (string.IsNullOrEmpty(examinationId))
			{
				TempData["error"] = "Examination Id is required.";
				return RedirectToAction("Index", "Home");
			}

			if (string.IsNullOrEmpty(patientId))
			{
				TempData["error"] = "Patient Id is required.";
				return RedirectToAction("Index", "Home");
			}

			try
			{
				if (!await this.patientService.PatientExistsAsync(patientId))
				{
					TempData["error"] = "Patient does not exist.";
					return RedirectToAction("All", "Patient");
				}

				PatientViewModel patient = await patientService.GetPatientByIdAsync(patientId);

				if (!await this.examinationService.ExaminationExistsAsync(examinationId))
				{
					TempData["error"] = "Examination does not exist.";
					return RedirectToAction("All");
				}

				ExaminationFormModel examination =
					await examinationService.GetExaminationByIdAsync(examinationId);
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
				TempData["error"] = "Examination Id is required.";
				return RedirectToAction("Index", "Home");
			}

			if (string.IsNullOrEmpty(patientId))
			{
				TempData["error"] = "Patient Id is required.";
				return RedirectToAction("Index", "Home");
			}

			try
			{
				PatientViewModel patient =
					await patientService.GetPatientByIdAsync(patientId);

				if (!await this.examinationService.ExaminationExistsAsync(examinationId))
				{
					TempData["error"] = "Examination does not exist.";
					return RedirectToAction("All");
				}

				if (!ModelState.IsValid)
				{
					model.Patient = patient;
					model.Examination.Statuses =
						await statusService.AllStatusesAsync();

					return View(model);
				}

				await examinationService.EditExaminationAsync(model.Examination, examinationId);
				TempData["success"] = "Examination was edited successfully.";

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
		public async Task<IActionResult> Dashboard()
		{
			try
			{
				var model = await examinationService.GetExaminationsGroupedByStatus();

				return View(model);
			}
			catch (Exception ex)
			{
				TempData["error"] = ex.Message;
				return RedirectToAction("Index", "Home");
			}
		}

		[HttpGet]
		public async Task<IActionResult> Details(string examinationId)
		{
			if (string.IsNullOrEmpty(examinationId))
			{
				TempData["error"] = "Examination Id is required.";
				return RedirectToAction("Index", "Home");
			}

			try
			{
				ExaminationDetailsViewModel model =
					await examinationService.GetExaminationDetailsByIdAsync(examinationId);

				return View(model);
			}
			catch (InvalidOperationException)
			{
				TempData["error"] = "Examination does not exist.";
				return RedirectToAction("All", "Examination");
			}
			catch (Exception ex)
			{
				TempData["error"] = ex.Message;
				return RedirectToAction("Index", "Home");
			}
		}

		[HttpGet]
		public async Task<IActionResult> Delete(string examinationId)
		{
			if (string.IsNullOrEmpty(examinationId))
			{
				TempData["error"] = "Examination Id is required.";
				return RedirectToAction("Index", "Home");
			}

			try
			{
				PreDeleteDetailsViewModel model =
				await this.examinationService.GetExaminationForDeleteByIdAsync(examinationId);

				return View(model);
			}
			catch (InvalidOperationException)
			{
				TempData["error"] = "Examination does not exist.";
				return RedirectToAction("All", "Examination");
			}
			catch (Exception ex)
			{
				TempData["error"] = ex.Message;
				return RedirectToAction("Index", "Home");
			}
		}

		[HttpPost]
		public async Task<IActionResult> Delete(string examinationId, PreDeleteDetailsViewModel model)
		{
			try
			{
				await this.examinationService.DeleteExaminationByIdAsync(examinationId);
				TempData["success"] = "The examination was successfully deleted.";
				return RedirectToAction("All");
			}
			catch (Exception ex)
			{
				TempData["error"] = ex.Message;
				return RedirectToAction("Index", "Home");
			}
		}
	}
}
