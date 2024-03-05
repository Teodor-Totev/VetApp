namespace VetApp.Services.Interfaces
{
	using VetApp.Services.Models.Patient;
	using VetApp.Web.ViewModels.Patient;

	public interface IPatientService
	{
		Task<int> CreateAsync(PatientFormModel model);

		Task<AllPatientsOrderedAndPagedServiceModel> GetAllPatientsAsync(AllPatientsQueryModel queryModel);

		Task<PatientViewModel> GetPatientByIdAsync(int patientId);
	}
}
