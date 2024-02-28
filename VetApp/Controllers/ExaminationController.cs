namespace VetApp.Controllers
{
	using Microsoft.AspNetCore.Mvc;
	using System.Diagnostics.Metrics;
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

		public ExaminationController(IExaminationService examinationService,
			IPatientService patientService, IStatusService statusService,
			IWebHostEnvironment webHostEnvironment)
		{
			this.examinationService = examinationService;
			this.patientService = patientService;
			this.statusService = statusService;
			this.webHostEnvironment = webHostEnvironment;
		}

		[HttpGet]
		public async Task<IActionResult> Add(int patientId)
		{
			var patient = await patientService.GetPatientByIdAsync(patientId);
			var statuses = await statusService.GetStatusesAsync();
			var model = new ExaminationFM
			{
				Patient = patient,
				Statuses = statuses
			};
			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Add(ExaminationFM model, int patientId)
		{
			string doctorId = base.GetUserId();
			await this.examinationService.AddAsync(model, patientId, doctorId);

			return RedirectToAction("Index", "Home");
		}

		[HttpGet]
		public async Task<IActionResult> All(int patientId)
		{
			IEnumerable<ExaminationVM> patientExaminations = await examinationService.GetPatientExaminationsAsync(patientId);

			var model = new PatientExaminationVM
			{
				Id = patientId,
				Examinations = patientExaminations
			};

			return View(model);
		}

		[HttpGet]
		public async Task<IActionResult> Edit(int examinationId)
		{
			ExaminationFM model = await examinationService.GetExaminationByIdAsync(examinationId);
			PatientVM patient = await patientService.GetPatientByIdAsync(model.PatientId);
			ICollection<StatusVM> statuses = await statusService.GetStatusesAsync();
			model.Patient = patient;
			model.Statuses = statuses;

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(ExaminationFM model, int examinationId)
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
	}
}
