using Microsoft.AspNetCore.Mvc;
using VetApp.Extensions;
using VetApp.Services.Interfaces;
using VetApp.Services.Models.Patient;
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
		public async Task<IActionResult> Add(PatientFormModel model)
		{
            if (!ModelState.IsValid)
            {
				return View(model);
			}

			int patientId = await patientService.CreateAsync(model);

			return RedirectToAction("Add", "Examination", new { patientId });
		}

		[HttpGet]
		public async Task<IActionResult> All([FromQuery]AllPatientsQueryModel queryModel)
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
	}
}
