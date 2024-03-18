namespace VetApp.Controllers
{
	using Microsoft.AspNetCore.Mvc;

	using Extensions;
	using Services.Interfaces;
	using Services.Models.Patient;
	using Web.ViewModels.Examination;
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
				TempData["error"] = ex.Message;
				return RedirectToAction("Index", "Home");
			}
		}

		[HttpGet]
		public async Task<IActionResult> AddPet(string ownerId)
		{
			if (string.IsNullOrEmpty(ownerId))
			{
				TempData["error"] = "Owner Id is required when trying to add a pet to an existing owner.";
				return RedirectToAction("All", "Owner");
			}

			try
			{
				if (!await this.ownerService.OwnerExistsAsync(ownerId))
				{
					TempData["error"] = "Owner does not exist.";
					return RedirectToAction("Index", "Home");
				}
			}
			catch (Exception ex)
			{
				TempData["error"] = ex.Message;
				return RedirectToAction("Index", "Home");
			}

			AddPetViewModel model = new AddPetViewModel()
			{
				OwnerId = ownerId
			};

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> AddPet(AddPetViewModel model, string ownerId)
		{
			if (string.IsNullOrEmpty(ownerId))
			{
				TempData["error"] = "Owner Id is required when trying to add a pet to an existing owner.";
				return RedirectToAction("All", "Owner");
			}

			try
			{
				if (!await this.ownerService.OwnerExistsAsync(ownerId))
				{
					TempData["error"] = "Owner does not exist.";
					return RedirectToAction("Index", "Home");
				}

				if (await this.patientService.DoesPatientExistInOwnerCollection(ownerId, model.Name))
				{
					TempData["error"] = $"Sorry, this owner already have a pet named {model.Name}.";
					return View(model);
				}

				if (!ModelState.IsValid)
				{
					return View(model);
				}

				string patientId = await this.patientService.AddPetAsync(model, ownerId, User.Id());

				TempData["success"] = $"Successfully added Pet.";

				return RedirectToAction("Add", "Examination", new { patientId });
			}
			catch (Exception ex)
			{
				TempData["error"] = ex.Message;
				return RedirectToAction("Index", "Home");
			}
		}

		[HttpGet]
		public async Task<IActionResult> All([FromQuery] AllPatientsQueryModel queryModel)
		{
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
				TempData["error"] = ex.Message;
				return RedirectToAction("Index", "Home");
			}
		}

		[HttpGet]
		public async Task<IActionResult> Mine([FromQuery] MinePatientsQueryModel queryModel, string? doctorId)
		{
			if (string.IsNullOrEmpty(doctorId))
			{
				TempData["error"] = "User Id is required.";
				return RedirectToAction("All", "Patient");
			}

			if (!await this.accountService.UserExistsAsync(doctorId!))
			{
				TempData["error"] = "User does not exist.";
				return RedirectToAction("Index", "Home");
			}

			if (queryModel.PatientsPerPage != 3 &&
				queryModel.PatientsPerPage != 6 &&
				queryModel.PatientsPerPage != 9)
			{
				TempData["error"] = "The animals per page option is not valid.";
				return View(queryModel);
			}

			ViewBag.UserId = User.Id();
			AllPatientsOrderedAndPagedServiceModel serviceModel =
					await patientService.GetAllPatientsForUserAsync(queryModel, doctorId!);

			queryModel.Patients = serviceModel.Patients;
			queryModel.TotalPatients = serviceModel.TotalPatientsCount;

			return View(queryModel);
		}

		[HttpGet]
		public async Task<IActionResult> Details(string patientId)
		{
			if (string.IsNullOrEmpty(patientId))
			{
				TempData["error"] = "Patient Id is required.";
				return RedirectToAction("All", "Patient");
			}

			try
			{
				PatientViewModel patient = 
					await patientService.GetPatientByIdAsync(patientId);

				IEnumerable<PatientExaminationsViewModel> examinations = 
					await examinationService.GetExaminationsForPatientByIdAsync(patientId);

				PatientDetailsViewModel model = new()
				{
					Patient = patient,
					Examinations = examinations
				};

				return View(model);
			}
			catch (InvalidOperationException)
			{
				TempData["error"] = "Patient does not exist.";
				return RedirectToAction("All", "Patient");
			}
			catch (Exception ex)
			{
				TempData["error"] = ex.Message;
				return RedirectToAction("Index", "Home");
			}

		}

		[HttpGet]
		public async Task<IActionResult> Edit(string patientId)
		{
			if (string.IsNullOrEmpty(patientId))
			{
				TempData["error"] = "Patient Id is required.";
				return RedirectToAction("All", "Patient");
			}

			try
			{
				PatientEditViewModel model =
					await this.patientService.GetPatientForEditByIdAsync(patientId);
				ViewBag.PatientId = patientId;
				return View(model);
			}
			catch (InvalidOperationException)
			{
				TempData["error"] = "Patient does not exist.";
				return RedirectToAction("All", "Patient");
			}
			catch (Exception ex)
			{
				TempData["error"] = ex.Message;
				return RedirectToAction("Index", "Home");
			}
		}

		[HttpPost]
		public async Task<IActionResult> Edit(PatientEditViewModel model, string patientId)
		{
			if (string.IsNullOrEmpty(patientId))
			{
				TempData["error"] = "Patient Id is required.";
				return RedirectToAction("All", "Patient");
			}

			try
			{
				if (!await patientService.PatientExistsAsync(patientId))
				{
					TempData["error"] = "Patient does not exist";
					return RedirectToAction("All", "Patient");
				}

				if (!ModelState.IsValid)
				{
					return View(model);
				}

				await patientService.EditPatientAsync(model, patientId);
				TempData["success"] = "Successfully Edited Patient";

				return RedirectToAction("Details", "Patient", new { patientId });
			}
			catch (Exception ex)
			{
				TempData["error"] = ex.Message;
				return RedirectToAction("Index", "Home");
			}

		}
	}
}
