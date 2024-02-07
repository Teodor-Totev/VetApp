using Microsoft.AspNetCore.Mvc;
using VetApp.Services.Interfaces;
using VetApp.Web.ViewModels.Patient;

namespace VetApp.Controllers
{
    public class PatientController : Controller
    {
        private readonly IPatientService patientService;

        public PatientController(IPatientService patientService)
        {
            this.patientService = patientService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            CreateVM model = new CreateVM()
            {
                Genders = this.patientService.GetPatientGender()
            };

            return View(model);
        }
    }
}
