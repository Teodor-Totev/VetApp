namespace VetApp.Services.Interfaces
{
	using VetApp.Web.ViewModels.Patient;

	public interface IPatientService
	{
		Task CreateAsync(CreateVM model);

		Task<ICollection<PatientVM>> GetAllPatientsAsync();

		Task<ICollection<PatientVM>> GetUserPatientsAsync(string doctorId);

		Task<PatientVM> GetPatientByIdAsync(int patientId);

		Task<ICollection<PatientOwnerVM>> GetPatientsByPhoneNumberAsync(string phoneNumber);
	}
}
