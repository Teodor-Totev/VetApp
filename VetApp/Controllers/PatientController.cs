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
        public IActionResult Create()
        {
			return View();
        }

		[HttpPost]
		public async Task<IActionResult> Create(CreateVM model)
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

		[HttpGet]
		public async Task<IActionResult> All()
		{
            ICollection<PatientVM> model = await patientService.GetAllPatientsAsync();

			return View(model);
		}

		[HttpGet]
		public async Task<IActionResult> MyPatients()
		{
			var userId = GetUserId();
			ICollection<PatientVM> model = await patientService.GetUserPatientsAsync(userId);

			return View(model);
		}

		[HttpGet]
		//This method receive patientId
		public async Task<IActionResult> Details(int id)
		{
			PatientVM patient = await patientService.GetPatientByIdAsync(id);
			ICollection<ExaminationVM> examinations = await examinationService.GetPatientExaminationsAsync(id);

			PatientDetailVM model = new PatientDetailVM()
			{
				Patient = patient,
				Examinations = examinations
			};


			return View(model);
		}
	}
}
