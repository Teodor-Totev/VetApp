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
                PatientId = patientId,
                Patient = patient
			};
            return View(model);
		}

		[HttpPost]
        public async Task<IActionResult> Add(AddExaminationFM model, int patientId)
        {
            await this.examinationService.AddAsync(model, patientId);

            return RedirectToAction("All", patientId);
        }

		[HttpGet]
		public async Task<IActionResult> All(int patientId)
		{
			IEnumerable<PatientExaminationVM> patientExaminations = await examinationService.GetPatientExaminationsAsync(patientId);

            if (!patientExaminations.Any())
            {
                return RedirectToAction("Add", patientId);
            }

			return View(patientExaminations);
		}
	}
}
