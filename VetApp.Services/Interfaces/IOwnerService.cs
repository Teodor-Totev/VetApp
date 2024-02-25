namespace VetApp.Services.Interfaces
{
	using VetApp.Web.ViewModels.Patient;

	public interface IOwnerService
	{
		Task<ICollection<OwnerPatient>> GetOwnersWithTheirPatientsByPhoneNumberAsync(string phoneNumber);
	}
}
