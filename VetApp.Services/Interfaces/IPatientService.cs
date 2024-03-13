namespace VetApp.Services.Interfaces
{
	using VetApp.Services.Models.Patient;
	using VetApp.Web.ViewModels.Patient;

	public interface IPatientService
	{
		Task<string> CreateAsync(PatientFormModel model, string doctorId);

		Task<string> AddPetAsync(PatientFormModel model, string ownerId);

		Task<AllPatientsOrderedAndPagedServiceModel> GetAllPatientsAsync(AllPatientsQueryModel queryModel);

		Task<PatientViewModel> GetPatientByIdAsync(string patientId);

		Task<PatientEditViewModel> GetPatientForEditByIdAsync(string patientId);

		Task EditPatientAsync(PatientEditViewModel model, string patientId);

		Task<bool> PatientExistsAsync(string patientId);

		Task<AllPatientsOrderedAndPagedServiceModel> GetAllPatientsForUserAsync(MinePatientsQueryModel queryModel, string doctorId);
	}
}
