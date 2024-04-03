namespace VetApp.Services.Interfaces
{
	using VetApp.Services.Models.Owner;
	using VetApp.Web.ViewModels.Owner;
	using VetApp.Web.ViewModels.Patient;

	public interface IOwnerService
	{
		Task<AllOwnersOrderedAndPagedServiceModel> GetAllOwnersAsync(AllOwnersQueryModel model);

		Task<OwnerViewModel> GetOwnerForEditByIdAsync(string ownerId);

		Task EditOwnerAsync(OwnerViewModel model);

		Task<bool> OwnerExistsAsync (string ownerId);

		Task<bool> CheckOwnerExistsByNameAndPhoneNumberAsync(string name, string phoneNumber);

		Task<IEnumerable<OwnerViewModel>> GetAllExistingOwnersAsync();

		Task<OwnerViewModel> GetOwnerByIdAsync(string ownerId);
	}
}
