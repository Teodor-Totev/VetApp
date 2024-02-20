namespace VetApp.Controllers
{
	using Microsoft.AspNetCore.Mvc;
    using VetApp.Services.Interfaces;
    using VetApp.Web.ViewModels.Examination;

	public class ExaminationController : BaseController
	{
		private readonly IExaminationService examinationService;

        public ExaminationController(IExaminationService examinationService)
        {
            this.examinationService = examinationService;
        }

        [HttpGet]
		public IActionResult Add(int patientId)
		{
            string doctorName = User.Identity.Name;
            var model = new AddExaminationFM
            {
                User = doctorName,
                PatientId = id
            };
            return View(model);
		}

		[HttpPost]
        public async Task<IActionResult> Add(AddExaminationFM model)
        {
            await this.examinationService.AddAsync(model);

            return RedirectToAction("All", "Patient");
        }

		[HttpGet]
		public async Task<IActionResult> All(int patientId)
		{
			IEnumerable<PatientExaminationVM> patientExaminations = await examinationService.GetPatientExaminationsAsync(patientId);

			return View(patientExaminations);
		}
	}
}
