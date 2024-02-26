namespace VetApp.Controllers
{
	using Microsoft.AspNetCore.Mvc;
    using VetApp.Services.Interfaces;
    using VetApp.Web.ViewModels.Examination;
	using VetApp.Web.ViewModels.Patient;

	public class ExaminationController : BaseController
	{
		private readonly IExaminationService examinationService;
        private readonly IPatientService patientService;
        private readonly IStatusService statusService;

        public ExaminationController(IExaminationService examinationService,
			IPatientService patientService, IStatusService statusService)
        {
            this.examinationService = examinationService;
            this.patientService = patientService;
            this.statusService = statusService;
        }

        [HttpGet]
		public async Task<IActionResult> Add(int patientId)
		{
            var patient = await patientService.GetPatientByIdAsync(patientId);
            var statuses = await statusService.GetStatusesAsync();
            var model = new AddExaminationFM
            {
                Patient = patient,
                Statuses = statuses
			};
            return View(model);
		}

		[HttpPost]
        public async Task<IActionResult> Add(AddExaminationFM model, int patientId)
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
		public async Task<IActionResult> Dashboard()
		{
			var model = await examinationService.GetExaminationsGroupedByStatus();

			return View(model);
		}
	}
}
