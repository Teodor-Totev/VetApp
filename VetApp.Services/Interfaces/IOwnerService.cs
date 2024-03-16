namespace VetApp.Services.Interfaces
{
	using VetApp.Services.Models.Owner;
	using VetApp.Web.ViewModels.Owner;
	using VetApp.Web.ViewModels.Patient;

	public interface IOwnerService
	{
		Task<ICollection<OwnerViewModel>> GetOwnersAsync(string phoneNumber);

		Task<OwnerViewModel> GetOwnerByIdAsync(string ownerId);

		Task<bool> OwnerExistsAsync (string ownerId);

		Task<bool> CheckOwnerExistsByNameAndPhoneNumberAsync(string name, string phoneNumber);

		Task<IEnumerable<AllExistingOwnersServiceModel>> GetAllExistingOwnersAsync();
	}
}
