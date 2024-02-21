namespace VetApp.Controllers
{
	using Microsoft.AspNetCore.Mvc;
    using VetApp.Services.Interfaces;
    using VetApp.Web.ViewModels.Examination;

	public class ExaminationController : BaseController
	{
		private readonly IExaminationService examinationService;
        private readonly IPatientService patientService;

        public ExaminationController(IExaminationService examinationService,
			IPatientService patientService)
        {
            this.examinationService = examinationService;
            this.patientService = patientService;
        }

        [HttpGet]
		public async Task<IActionResult> Add(int patientId)
		{
            var patient = await patientService.GetPatientByIdAsync(patientId);
            var model = new AddExaminationFM
            {
                Patient = patient
			};
            return View(model);
		}

		[HttpPost]
        public async Task<IActionResult> Add(AddExaminationFM model, int patientId)
        {
            await this.examinationService.AddAsync(model, patientId);

			return RedirectToAction("All", new { patientId });
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
	}
}
