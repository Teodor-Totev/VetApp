using Microsoft.AspNetCore.Mvc;
using VetApp.Data.Models;
using VetApp.Services.Interfaces;
using VetApp.Web.ViewModels.Examination;
using VetApp.Web.ViewModels.Patient;

namespace VetApp.Controllers
{
    public class PatientController : BaseController
    {
        private readonly IPatientService patientService;
		private readonly IExaminationService examinationService;

		public PatientController(IPatientService patientService, IExaminationService examinationService)
        {
            this.patientService = patientService;
			this.examinationService = examinationService;
        }

        [HttpGet]
        public IActionResult Add()
        {
			return View();
        }

		[HttpPost]
		public async Task<IActionResult> Add(CreateViewModel model)
		{
            if (!ModelState.IsValid)
            {
				return View(model);
			}

			//Create the patient here to access the Id for redirection
			Patient patient = new Patient();

			await patientService.CreateAsync(model, patient);

			return RedirectToAction("Add", "Examination", new { patientId = patient.Id });
		}

		public async Task<IActionResult> All(string patientName, string ownerName, string doctorId)
		{
			ICollection<PatientViewModel> model = await patientService.GetAllPatientsAsync(patientName, ownerName, doctorId);
			ViewBag.UserId = base.GetUserId();

			return View(model);
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
	}
}
