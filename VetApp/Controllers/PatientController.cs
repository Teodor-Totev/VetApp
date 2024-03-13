namespace VetApp.Controllers
{
	using Microsoft.AspNetCore.Mvc;

	using Extensions;
	using Services.Interfaces;
	using Services.Models.Patient;
	using Web.ViewModels.Examination;
	using Web.ViewModels.Owner;
	using Web.ViewModels.Patient;

	public class PatientController : BaseController
	{
		private readonly IPatientService patientService;
		private readonly IExaminationService examinationService;
		private readonly IOwnerService ownerService;
		private readonly IAccountService accountService;

		public PatientController(
			IPatientService patientService,
			IExaminationService examinationService,
			IOwnerService ownerService,
			IAccountService accountService)
		{
			this.patientService = patientService;
			this.examinationService = examinationService;
			this.ownerService = ownerService;
			this.accountService = accountService;
		}

		[HttpGet]
		public IActionResult Add()
		{
			PatientFormModel model = new PatientFormModel();

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Add(PatientFormModel model)
		{
			try
			{
				if (await this.ownerService.CheckOwnerExistsByNameAndPhoneNumberAsync(model.Owner.Name, model.Owner.PhoneNumber))
				{
					TempData["error"] = "An owner with the same name and phone number already exists.";
					return View(model);
				}

				if (!ModelState.IsValid)
				{
					return View(model);
				}

				string patientId = await patientService.CreateAsync(model, User.Id());

				TempData["success"] = "Patient and Owner Details Saved Successfully.";

				return RedirectToAction("Add", "Examination", new { patientId });
			}
			catch (Exception ex)
			{
				TempData["error"] = $"An error occurred: {ex.Message}";
				return RedirectToAction("Index", "Home");
			}
		}

		[HttpGet]
		public async Task<IActionResult> AddPet(string ownerId)
		{
			try
			{
				OwnerFormModel? owner = await this.ownerService.GetOwnerFormModelByIdAsync(ownerId);

				if (owner == null)
				{
					TempData["error"] = "Owner does not exist";
					return RedirectToAction("Index", "Home");
				}

				PatientFormModel model = new PatientFormModel()
				{
					OwnerId = ownerId
				};

				return View(model);
			}
			catch (Exception ex)
			{
				TempData["error"] = $"An error occurred: {ex.Message}";
				return RedirectToAction("Index", "Home");
			}
		}

		[HttpPost]
		public async Task<IActionResult> AddPet(PatientFormModel model, string ownerId)
		{
			try
			{
				OwnerFormModel? owner = await this.ownerService.GetOwnerFormModelByIdAsync(ownerId);

				if (owner == null)
				{
					TempData["error"] = "Owner does not exist";
					return RedirectToAction("Index", "Home");
				}

				if (!ModelState.IsValid)
				{
					return View(model);
				}

				string patientId = await this.patientService.AddPetAsync(model, ownerId);

				TempData["success"] = $"Successfully added Pet to Owner {owner.Name}.";

				return RedirectToAction("Add", "Examination", new { patientId });
			}
			catch (Exception ex)
			{
				TempData["error"] = $"An error occurred: {ex.Message}";
				return RedirectToAction("Index", "Home");
			}
		}

		[HttpGet]
		public async Task<IActionResult> All([FromQuery] AllPatientsQueryModel queryModel)
		{
			if (!ModelState.IsValid)
			{
				TempData["error"] = "The sorting option is not valid.";
				return View(queryModel);
			}

			if (queryModel.PatientsPerPage != 3 &&
				queryModel.PatientsPerPage != 6 &&
				queryModel.PatientsPerPage != 9)
			{
				TempData["error"] = "The animals per page option is not valid.";
				return View(queryModel);
			}

			ViewBag.UserId = User.Id();

			try
			{
				AllPatientsOrderedAndPagedServiceModel serviceModel =
					await patientService.GetAllPatientsAsync(queryModel);

				queryModel.Patients = serviceModel.Patients;
				queryModel.TotalPatients = serviceModel.TotalPatientsCount;

				return View(queryModel);
			}
			catch (Exception ex)
			{
				TempData["error"] = $"An error occurred: {ex.Message}";
				return RedirectToAction("Index", "Home");
			}
		}

		[HttpGet]
		public async Task<IActionResult> Mine([FromQuery] AllPatientsQueryModel queryModel, string doctorId)
		{
			if (!string.IsNullOrEmpty(doctorId))
			{
				if (!await this.accountService.UserExistsAsync(doctorId))
				{
					TempData["error"] = "User does not exist.";
					return RedirectToAction("Index", "Home");
				}
			}

			ViewBag.UserId = User.Id();
			AllPatientsOrderedAndPagedServiceModel serviceModel =
					await patientService.GetAllPatientsForUserAsync(queryModel, doctorId);

			queryModel.Patients = serviceModel.Patients;
			queryModel.TotalPatients = serviceModel.TotalPatientsCount;

			return View(queryModel);
		}

		[HttpGet]
		public async Task<IActionResult> Details(string patientId)
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

		[HttpGet]
		public async Task<IActionResult> Edit(string patientId)
		{
			if (!await patientService.PatientExistsAsync(patientId))
			{
				return BadRequest();
			}

			PatientEditViewModel model = await this.patientService.GetPatientForEditByIdAsync(patientId);

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(PatientEditViewModel model, string patientId)
		{
			if (!await patientService.PatientExistsAsync(patientId))
			{
				TempData["error"] = "Patient does not exist";
				return View();
			}

			if (!ModelState.IsValid)
			{
				return View(model);
			}

			await patientService.EditPatientAsync(model, patientId);
			TempData["success"] = "Successfully Updated Patient";

			return RedirectToAction("Details", "Patient", new { patientId });
		}
	}
}
