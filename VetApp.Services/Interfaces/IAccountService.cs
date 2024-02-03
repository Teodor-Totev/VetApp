using VetApp.Web.ViewModels.Account;

namespace VetApp.Services.Interfaces
{
	public interface IAccountService
	{
		Task<bool> RegisterUserAsync(RegisterVM model);
	}
}
