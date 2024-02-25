using Microsoft.AspNetCore.Mvc;
using VetApp.Data.Models;
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

			//Create the patient here to access the Id for redirection
			Patient patient = new Patient()
			{
				Name = model.Name,
				Type = model.Type,
				Gender = model.Gender,
				BirthDate = model.BirthDate,
				Neutered = model.Neutered,
				Microchip = model.Microchip,
				Characteristics = model.Characteristics,
				ChronicIllnesses = model.ChronicIllnesses,
			};

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
	}
}
