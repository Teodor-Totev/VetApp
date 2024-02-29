namespace VetApp.Services.Interfaces
{
	using VetApp.Data.Models;
	using VetApp.Web.ViewModels.Patient;

	public interface IPatientService
	{
		Task CreateAsync(PatientFormModel model, Patient patient);

		Task<ICollection<PatientViewModel>> GetAllPatientsAsync(string patientName, string ownerName, string doctorId);

		Task<PatientViewModel> GetPatientByIdAsync(int patientId);
	}
}
