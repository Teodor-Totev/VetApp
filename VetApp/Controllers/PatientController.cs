using Microsoft.AspNetCore.Mvc;
using VetApp.Services.Interfaces;
using VetApp.Web.ViewModels.Patient;

namespace VetApp.Controllers
{
    public class PatientController : BaseController
    {
        private readonly IPatientService patientService;
		

        public PatientController(IPatientService patientService)
        {
            this.patientService = patientService;
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

            await patientService.CreateAsync(model);
			var owner = await patientService
				.GetPatientsByPhoneNumberAsync(model.OwnerPhoneNumber);

			var patientId = owner
				.Select(o => o.Patients
						.Where(p => p.Name == model.Name)
						.Select(p => p.Id))
				.FirstOrDefault();

			return RedirectToAction("Add", "Examination", new { patientId });
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

		public async Task<IActionResult> OwnerPatients(string phoneNumber)
		{
			var model = await patientService.GetPatientsByPhoneNumberAsync(phoneNumber);

			return View(model);
		}
	}
}
