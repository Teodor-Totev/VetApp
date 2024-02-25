namespace VetApp.Services.Interfaces
{
	using VetApp.Data.Models;
	using VetApp.Web.ViewModels.Patient;

	public interface IPatientService
	{
		Task CreateAsync(CreateVM model, Patient patient);

		Task<ICollection<PatientVM>> GetAllPatientsAsync();

		Task<ICollection<PatientVM>> GetUserPatientsAsync(string doctorId);

		Task<PatientVM> GetPatientByIdAsync(int patientId);

		
	}
}
