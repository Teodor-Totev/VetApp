namespace VetApp.Services.Interfaces
{
	using VetApp.Web.ViewModels.Patient;

	public interface IPatientService
	{
		Task CreateAsync(CreateVM model, string userId);

		Task<ICollection<PatientVM>> GetAllPatientsAsync();

		Task<ICollection<PatientVM>> GetUserPatientsAsync(string userId);

		Task<PatientVM> GetPatientByIdAsync(int patientId);

		Task<ICollection<PatientOwnerVM>> GetPatientsByPhoneNumberAsync(string phoneNumber);
	}
}
