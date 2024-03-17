namespace VetApp.Services.Interfaces
{
	using VetApp.Services.Models.Owner;
	using VetApp.Web.ViewModels.Owner;
	using VetApp.Web.ViewModels.Patient;

	public interface IOwnerService
	{
		Task<AllOwnerOrderedAndPagedServiceModel> GetAllOwnersAsync(AllOwnersQueryModel model);

		Task<OwnerFormModel> GetOwnerForEditByIdAsync(string ownerId);

		Task EditOwnerAsync(OwnerFormModel model, string ownerId);

		Task<bool> OwnerExistsAsync (string ownerId);

		Task<bool> CheckOwnerExistsByNameAndPhoneNumberAsync(string name, string phoneNumber);

		Task<IEnumerable<AllExistingOwnersServiceModel>> GetAllExistingOwnersAsync();
	}
}
