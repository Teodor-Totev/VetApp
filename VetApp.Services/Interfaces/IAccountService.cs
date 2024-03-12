using VetApp.Web.ViewModels.Account;

namespace VetApp.Services.Interfaces
{
	public interface IAccountService
	{
		Task<string> GetUserFullNameByUsernameAsync(string username);

		Task<bool> UserExistsAsync(string id);
	}
}
