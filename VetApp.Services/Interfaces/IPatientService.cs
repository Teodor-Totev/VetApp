namespace VetApp.Services.Interfaces
{
	using VetApp.Services.Models.Patient;
	using VetApp.Web.ViewModels.Patient;

	public interface IPatientService
	{
		Task<int> CreateAsync(PatientFormModel model);

		Task<int> AddPetAsync(PatientFormModel model, string ownerId);

		Task<AllPatientsOrderedAndPagedServiceModel> GetAllPatientsAsync(AllPatientsQueryModel queryModel);

		Task<PatientViewModel> GetPatientByIdAsync(int patientId);

		Task<PatientEditViewModel> GetPatientForEditByIdAsync(int patientId);

		Task EditPatientAsync(PatientEditViewModel model, int patientId);

		Task<bool> PatientExistsAsync(int patientId);

	}
}
